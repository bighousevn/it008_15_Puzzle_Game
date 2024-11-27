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
using System.Xml.Linq;

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
        public double paddingBetween;
        public int n2;
        int steps;

        string win_position;
        string current_position;


        public event EventHandler<string> OnMoveTextChanged;


        // Phương thức để thay đổi nội dung TextBlockMove và gọi sự kiện
        public void ChangeMoveText(string newText)
        {
            // Gọi sự kiện OnMoveTextChanged nếu nó có người đăng ký
            OnMoveTextChanged?.Invoke(this, newText);
        }


        public PlayPage(string n, string path)
        {
            InitializeComponent();
            Initial(n,path);
        }

        //Thêm hình ảnh vào
        private void Initial(string n, string path)
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
                steps = 0;
            }

            bitmap = new BitmapImage();
            bitmap.BeginInit();
            switch (n)
            {
                case "1":
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        bitmap.UriSource = new Uri(openFileDialog.FileName);
                        bitmap.EndInit();
                        n = "3";
                        Myborder.Width = 415;
                        Myborder.Height = 415;
                    }
                    break;
                default:
                    bitmap.UriSource = new Uri(path);
                    bitmap.EndInit();
                    break;

            }

            switch (int.Parse(n))
            {
                case 3:
                    paddingBetween = 8;
                    Myborder.Width = 411;
                    Myborder.Height = 411;
                    break;
                case 4:
                    paddingBetween = 5;
                    Myborder.Width = 408;
                    Myborder.Height = 408;
                    break;
                default:
                    paddingBetween = 3;
                    Myborder.Width = 405;
                    Myborder.Height = 405;
                    break;
            }

            n2 = int.Parse(n);
            CreateImageList();
            AddImages();

            
        }



        //Tạo các image nhỏ 3x3,4x4,5x5
        private void CreateImageList()
        {
            for (int i = 0; i < n2*n2; i++)
            {
                Image temp = new Image();
                temp.Width = 390/n2;
                temp.Height = 390/n2;
                temp.Tag = i.ToString();

                temp.MouseLeftButtonDown += OnPicClick;
                locations.Add(i.ToString());
                imageList.Add(temp);
            }
        }



        private CroppedBitmap CropImage2(BitmapImage main_bitmap, int x, int y, int height, int width)
        {
            //if (main_bitmap.PixelWidth >= width * n2 && main_bitmap.PixelHeight >= height * n2)
            //{
            //    CroppedBitmap croppedImage = new CroppedBitmap(main_bitmap, new Int32Rect(x, y, height, width));
            //    return croppedImage;
            //}
            //else
            //{
            //    MessageBox.Show("Ảnh quá lớn để cắt", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            //    return null;
            //}
            
            CroppedBitmap croppedImage = new CroppedBitmap(main_bitmap, new Int32Rect(x, y, height, width));
            return croppedImage;
        }


        private void CropImage(BitmapImage main_bitmap, int height, int width)
        {
            int x = 0, y = 0;
           

            for (int blocks = 0; blocks < n2*n2; blocks++)
            {
                CroppedBitmap cropped_image = CropImage2(main_bitmap, x, y, height, width);
                images.Add(cropped_image);
                x += width;
                if (x == width * n2)
                {
                    x = 0;
                    y += height;
                }
            }
        }

        private void AddImages()
        {
            float scaleX = (float) 390 / bitmap.PixelWidth;
            float scaleY = (float) 390 / bitmap.PixelHeight;

            BitmapImage tempBitmap = ResizeAndDisplayImage(bitmap, scaleX, scaleY);
           
            CropImage(tempBitmap, ((int)tempBitmap.Width)/n2, ((int)tempBitmap.Height)/n2);
            for (int i = 1; i < imageList.Count; i++)
            {
                imageList[i].Source = images[i];
            }
            PlaceImageList();
        }


        public BitmapImage ResizeAndDisplayImage(BitmapImage main_bitmap, double scaleX, double scaleY)
        {
            // Calculate the new width and height based on the scaling factors
            int newWidth = (int)(main_bitmap.PixelWidth * scaleX);
            int newHeight = (int)(main_bitmap.PixelHeight * scaleY);

            // Create a WriteableBitmap with the new size
            WriteableBitmap writeableBitmap = new WriteableBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32, null);


            // Create a DrawingVisual to use for drawing the image
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Draw the image into the DrawingContext with the new dimensions
                drawingContext.DrawImage(main_bitmap, new Rect(0, 0, newWidth, newHeight));
            }

            // Create a RenderTargetBitmap to render the DrawingVisual into the WriteableBitmap
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(drawingVisual);

            // Now copy the rendered result into the WriteableBitmap
            writeableBitmap = new WriteableBitmap(renderTargetBitmap);

            // Create a MemoryStream to save the resized image
            MemoryStream memoryStream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
            encoder.Save(memoryStream);

            // Reset MemoryStream to the beginning
            memoryStream.Position = 0;

            // Create a new BitmapImage from the MemoryStream
            BitmapImage resizedImage = new BitmapImage();
            resizedImage.BeginInit();
            resizedImage.StreamSource = memoryStream;
            resizedImage.CacheOption = BitmapCacheOption.OnLoad;
            resizedImage.EndInit();

            // Return the resized BitmapImage
            return resizedImage;
        }



        static bool CountInversions(List<Image> puzzle)
        {
            int inversions = 0;
            int length = puzzle.Count;

            // Tính số đảo
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (int.Parse(puzzle[i].Tag.ToString())> int.Parse(puzzle[j].Tag.ToString()) && puzzle[i].Tag.ToString() != "0" && puzzle[j].Tag.ToString() != "0")
                    {
                        inversions++;
                    }
                }
            }
            return inversions%2==0;
        }


        private void PlaceImageList()
        {
            //Shuffle lại danh sách hình ảnh

            var shuffleImages = imageList.OrderBy(a => Guid.NewGuid()).ToList();
            while(!CountInversions(shuffleImages))
                shuffleImages = imageList.OrderBy(a => Guid.NewGuid()).ToList();
            imageList = shuffleImages;

            double x = 0; // Khởi tạo vị trí x
            double y = 0; // Khởi tạo vị trí y
            double width = imageList[0].Width; // Chiều rộng của mỗi hình ảnh
            double height = imageList[0].Height; // Chiều cao của mỗi hình ảnh

            PuzzleCanvas.Children.Clear();
            for (int i = 0; i < imageList.Count; i++)
            {
                var img = imageList[i];

                // Điều chỉnh vị trí hình ảnh
                if (i % n2 == 0 && i!=0)  // Khi tới hình ảnh thứ 4 và thứ 7, di chuyển xuống hàng mới
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
                    
                }
            }


        }


        private bool CanSwap(Image clickedImage, Image emptyBox, double n)
        {
            // Lấy tọa độ của mảnh ghép đã click và ô trống
            double clickedLeft = Canvas.GetLeft(clickedImage);
            double clickedTop = Canvas.GetTop(clickedImage);
            double emptyLeft = Canvas.GetLeft(emptyBox);
            double emptyTop = Canvas.GetTop(emptyBox);
            var check = 390 / n + paddingBetween;
            
            // Kiểm tra nếu mảnh ghép kề ô trống theo chiều ngang hoặc chiều dọc
            return (Math.Abs(clickedLeft - emptyLeft) == ((int)check) && clickedTop == emptyTop) || // Kề nhau theo chiều ngang
                   (Math.Abs(clickedTop - emptyTop) == ((int)check) && clickedLeft == emptyLeft);   // Kề nhau theo chiều dọc
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
            steps++;
            ChangeMoveText(steps.ToString());
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
           
        }



        private void OnPicClick(object sender, MouseButtonEventArgs e)
        {
            Image clickedImage = (Image)sender;
            Image emptyBox = imageList.FirstOrDefault(x => x.Tag.ToString() == "0");

            // Lấy tọa độ của các mảnh ghép
            Point clickedImagePosition = new Point(Canvas.GetLeft(clickedImage), Canvas.GetTop(clickedImage));
            Point emptyBoxPosition = new Point(Canvas.GetLeft(emptyBox), Canvas.GetTop(emptyBox));

            var n = Math.Sqrt(imageList.Count());
            // Kiểm tra xem mảnh ghép có thể hoán đổi với ô trống không
            if (CanSwap(clickedImage, emptyBox, n))
            {
                // Hoán đổi vị trí giữa mảnh ghép và ô trống
                Canvas.SetLeft(clickedImage, emptyBoxPosition.X);
                Canvas.SetTop(clickedImage, emptyBoxPosition.Y);

                Canvas.SetLeft(emptyBox, clickedImagePosition.X);
                Canvas.SetTop(emptyBox, clickedImagePosition.Y);

                // Cập nhật lại danh sách các vị trí của mảnh ghép
                UpdateLocations(clickedImage, emptyBox);

            }

            // Kiểm tra xem trò chơi đã hoàn thành chưa
            CheckGame();
        } 

        public void ShuffleClick(object sender, RoutedEventArgs e)
        {
            PlaceImageList();
        }

       
    }
}

