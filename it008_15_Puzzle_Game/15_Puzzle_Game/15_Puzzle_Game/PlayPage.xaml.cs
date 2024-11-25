using _15_Puzzle_Game.ViewModel;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Page
    {
        public List<Image> imageList = new List<Image>();
        public List<CroppedBitmap> images = new List<CroppedBitmap>();
        public List<string> locations = new List<string>();
        public List<string> currentLocations = new List<string>();
        public BitmapImage bitmap;

        string win_position;
        string current_position;
       

        public PlayPage()
        {
            InitializeComponent();
            Initial();
        }


        //Thêm hình ảnh vào
        private void Initial()
        {
            if (imageList != null)
            {
                foreach (Image pic in imageList.ToList())
                {
                    // Kiểm tra nếu item này là phần tử con của Canvas
                    if (PuzzleCanvas.Children.Contains(pic)) // PuzzleGrid là tên Canvas của bạn
                    {
                        PuzzleCanvas.Children.Remove(pic);
                    }
                }
                imageList.Clear();
                images.Clear();
                locations.Clear();
                currentLocations.Clear();
                win_position = "";
            }

            MainViewModel ViewModel = new MainViewModel();
            {
                bitmap = new BitmapImage();
                bitmap.BeginInit();

                bitmap.UriSource = new Uri("file:///C:/Users/Admin/Downloads/462572198_1069373354980230_9189314957615253265_n.png");
                bitmap.EndInit();

                CreateImageList();
                AddImages();

            }
        }



        //Tạo các image nhỏ 3x3,4x4,5x5
        private void CreateImageList()
        {
            for (int i = 0; i < 9; i++)
            {
                Image temp = new Image();
                temp.Width = 130;
                temp.Height = 130;
                temp.Tag = i.ToString();

                temp.MouseLeftButtonDown += OnPicClick;
                locations.Add(i.ToString());
                imageList.Add(temp);
            }
        }



        private CroppedBitmap CropImage2(BitmapImage main_bitmap, int x, int y, int height, int width)
        {
            if (main_bitmap.PixelWidth == width * 3 && main_bitmap.PixelHeight == height * 3)
            {
                CroppedBitmap croppedImage = new CroppedBitmap(main_bitmap, new Int32Rect(x, y, height, width));
                return croppedImage;
            }
            else
            {
                MessageBox.Show("Ảnh quá lớn để cắt", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }


        private void CropImage(BitmapImage main_bitmap, int height, int width)
        {
            int x = 0, y = 0;

            for (int blocks = 0; blocks < 9; blocks++)
            {
                CroppedBitmap cropped_image = CropImage2(main_bitmap, x, y, height, width);
                images.Add(cropped_image);
                x += width;
                if (x == width * 3)
                {
                    x = 0;
                    y += height;
                }
            }
        }

        private void AddImages()
        {
            float scaleX = (float)390 / bitmap.PixelWidth;
            float scaleY = (float)390 / bitmap.PixelHeight;

            BitmapImage tempBitmap = ResizeAndDisplayImage(bitmap, scaleX, scaleY);
            CropImage(tempBitmap, 130, 130);
            for (int i = 1; i < imageList.Count; i++)
            {
                imageList[i].Source = images[i];
            }
            PlaceImageList();
        }




        public BitmapImage ResizeAndDisplayImage(BitmapImage main_bitmap, double scaleX, double scaleY)
        {


            // Tạo một ScaleTransform để thay đổi kích thước hình ảnh
            ScaleTransform scaleTransform = new ScaleTransform(scaleX, scaleY);

            // Tạo một TransformedBitmap với ScaleTransform
            TransformedBitmap transformedBitmap = new TransformedBitmap(main_bitmap, scaleTransform);

            // Tạo MemoryStream để lưu hình ảnh đã thay đổi kích thước
            MemoryStream memoryStream = new MemoryStream();

            // Mã hóa transformedBitmap vào MemoryStream
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(transformedBitmap));
            encoder.Save(memoryStream);

            // Đảm bảo rằng MemoryStream đang trỏ về vị trí bắt đầu (vị trí 0)
            memoryStream.Position = 0;

            // Tạo BitmapImage từ MemoryStream
            BitmapImage resizedImage = new BitmapImage();
            resizedImage.BeginInit();
            resizedImage.StreamSource = memoryStream;
            resizedImage.CacheOption = BitmapCacheOption.OnLoad; // Đảm bảo hình ảnh được tải vào bộ nhớ ngay lập tức
            resizedImage.EndInit();

            // Gán resizedImage vào Image control để hiển thị
            return resizedImage;
        }



        private void PlaceImageList()
        {
            //Shuffle lại danh sách hình ảnh
           // var shuffleImages = imageList.OrderBy(a => Guid.NewGuid()).ToList();
            //imageList = shuffleImages;




            double paddingBetween = 20; // Padding giữa các hình ảnh
            double x = 0; // Khởi tạo vị trí x
            double y = 0; // Khởi tạo vị trí y
            double width = imageList[0].Width; // Chiều rộng của mỗi hình ảnh
            double height = imageList[0].Height; // Chiều cao của mỗi hình ảnh


            for (int i = 0; i < imageList.Count; i++)
            {
                var img = imageList[i];

                // Điều chỉnh vị trí hình ảnh
                if (i == 3 || i == 6)  // Khi tới hình ảnh thứ 4 và thứ 7, di chuyển xuống hàng mới
                {
                    y = y + height + paddingBetween;  // Di chuyển xuống hàng mới
                    x = 0; // Đặt lại x về vị trí đầu dòng mới
                }

                // Đặt vị trí hình ảnh trong Canvas hoặc Grid
                Canvas.SetLeft(img, x);
                Canvas.SetTop(img, y);

                // Thêm Image vào Grid (hoặc Canvas)
                PuzzleCanvas.Children.Add(img);

                // Cập nhật vị trí để hình ảnh tiếp theo được thêm vào cạnh bên
                x = x + width + paddingBetween;  // Di chuyển sang bên phải

                // Nếu bạn muốn lưu vị trí hình ảnh, có thể lưu vào danh sách
                win_position += (locations[i]);  // Lưu vị trí hiện tại (nếu cần)

            }

            locations.Clear();

            foreach (var child in imageList)
            {
                if (child is Image image)
                {
                    // Kiểm tra thuộc tính Tag (hoặc các thuộc tính khác tùy theo yêu cầu)
                    locations.Add(image.Tag?.ToString());
                    //Console.WriteLine(image.Tag.ToString());
                }
            }


        }


        private bool CanSwap(Image clickedImage, Image emptyBox)
        {
            // Lấy tọa độ của mảnh ghép đã click và ô trống
            double clickedLeft = Canvas.GetLeft(clickedImage);
            double clickedTop = Canvas.GetTop(clickedImage);
            double emptyLeft = Canvas.GetLeft(emptyBox);
            double emptyTop = Canvas.GetTop(emptyBox);

            // Kiểm tra nếu mảnh ghép kề ô trống theo chiều ngang hoặc chiều dọc
            return (Math.Abs(clickedLeft - emptyLeft) == 150 && clickedTop == emptyTop) || // Kề nhau theo chiều ngang
                   (Math.Abs(clickedTop - emptyTop) == 150 && clickedLeft == emptyLeft);   // Kề nhau theo chiều dọc
        }

        private void UpdateLocations(Image clickedImage, Image emptyBox)
        {
            // Cập nhật vị trí của clickedImage và emptyBox trong danh sách locations

            var clickedLocation = clickedImage.Tag.ToString();
            var emptyLocation = emptyBox.Tag.ToString();


            int clickedIndex = locations.IndexOf(clickedLocation);
            int emptyIndex = locations.IndexOf(emptyLocation);

            string temp = locations[clickedIndex];
            locations[clickedIndex] = locations[emptyIndex];
            locations[emptyIndex] = temp;
        }

        private void CheckGame()
        {
            current_position = "";
            // Kết hợp các vị trí hiện tại thành chuỗi
            current_position = string.Join("", locations);

            // Hiển thị kết quả trong các Label

            // Kiểm tra nếu vị trí hiện tại khớp với vị trí chiến thắng
            if (win_position == current_position)
            {
                    Congratulation congratulationWindow = new Congratulation();
                    congratulationWindow.Show();

            }
            //Console.WriteLine(current_position);
           // Console.WriteLine(win_position);
        }



        private void OnPicClick(object sender, MouseButtonEventArgs e)
        {
            //Image clickedImage = (Image)sender;
            //Image emptyBox = imageList.FirstOrDefault(x => x.Tag.ToString() == "0");

            //// Lấy tọa độ của các mảnh ghép
            //Point clickedImagePosition = new Point(Canvas.GetLeft(clickedImage), Canvas.GetTop(clickedImage));
            //Point emptyBoxPosition = new Point(Canvas.GetLeft(emptyBox), Canvas.GetTop(emptyBox));


            //// Kiểm tra xem mảnh ghép có thể hoán đổi với ô trống không
            //if (CanSwap(clickedImage, emptyBox))
            //{
            //    // Hoán đổi vị trí giữa mảnh ghép và ô trống
            //    Canvas.SetLeft(clickedImage, emptyBoxPosition.X);
            //    Canvas.SetTop(clickedImage, emptyBoxPosition.Y);

            //    Canvas.SetLeft(emptyBox, clickedImagePosition.X);
            //    Canvas.SetTop(emptyBox, clickedImagePosition.Y);

            //    // Cập nhật lại danh sách các vị trí của mảnh ghép
            //    UpdateLocations(clickedImage, emptyBox);

            //}

            // Kiểm tra xem trò chơi đã hoàn thành chưa
            CheckGame();
        }

    }
}

