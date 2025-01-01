using _15_Puzzle_Game.Model;
using _15_Puzzle_Game.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using AForge.Imaging;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for OptionalPage.xaml
    /// </summary>
    public partial class OptionalPage : Page
    {
        private List<System.Windows.Controls.Image> selectedImages = new List<System.Windows.Controls.Image>();  // Lưu trữ ảnh đã chọn
        private List<byte[]> bytes = new List<byte[]>();
        private List<byte[]> existedImage = new List<byte[]>();

        BitmapImage bitmap;
        int Userid;
        private bool CanEdit = false;

        public OptionalPage()
        {
            InitializeComponent();
            Userid = CurrentUser.Instance.CurrentUserid;
            LoadImage();
            SampleImage.Source = null;
            StatusBtn.Text = "200$ per one";
        }

        void LoadImage()
        {
            MainWrappanel.Children.Clear();
            bytes.Clear();

            var allImage = DataProvider.Instance.DB.UserImages.Where(p => p.user_id == Userid);
            foreach (var item in allImage)
            {
                bytes.Add(item.image_byte);
                existedImage = DataProvider.Instance.DB.UserImages.Where(p => p.user_id == CurrentUser.Instance.CurrentUserid)
                                                              .Select(p => p.image_byte)
                                                              .ToList();

                BitmapImage addbitmap = ToImage(item.image_byte);

                ScaleTransform scaleTransform = new ScaleTransform();
                scaleTransform.ScaleX = 1;
                scaleTransform.ScaleY = 1;
                var imageStyle = (Style)this.FindResource("ImageStyle");

                System.Windows.Controls.Image ImageControl = new System.Windows.Controls.Image
                {
                    Source = addbitmap,
                    Width = 255,
                    Height = 255,
                    Margin = new Thickness(5),
                    Stretch = Stretch.Fill,
                    Tag = item.image_id,
                    RenderTransform = scaleTransform,
                    Style = imageStyle
                };

                ImageControl.MouseLeftButtonDown += Image_MouseLeftButtonUp;
                MainWrappanel.Children.Add(ImageControl);
            }
        }

        void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var selectedImage = (System.Windows.Controls.Image)sender;

            if (CanEdit)
            {
                if (!selectedImages.Contains(selectedImage))
                {
                    AudioControl.Instance.ErrorEffect_Play();
                    selectedImages.Add(selectedImage);
                    selectedImage.Opacity = 0.5;
                    SampleImage.Source = selectedImage.Source;
                    // Thay đổi độ mờ khi ảnh được chọn
                }
                else
                {
                    selectedImages.Remove(selectedImage);
                    selectedImage.Opacity = 1.0;  // Khôi phục lại độ mờ
                    SampleImage.Source = null;
                }
            }
            else
            {
                AudioControl.Instance.StartGameEffect_Play();
                var imageId = (int)selectedImage.Tag;
                CurrentUser.Instance.UserImageID = imageId;
                var imageRecord = DataProvider.Instance.DB.UserImages.FirstOrDefault(p => p.image_id == imageId);

                BitmapImage bitmap = ToImage(imageRecord.image_byte);
                string base64String = Convert.ToBase64String(imageRecord.image_byte);
                
                NavigationService.Navigate(new SelectLevelOptional(base64String, bitmap));
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedImages.Count == 0)
                StatusBtn.Text = "No image selected";
            for (int i = selectedImages.Count - 1; i >= 0; i--)
            {
                var ImageControl = selectedImages[i];
                var imageId = (int)ImageControl.Tag;

                var imageRecord = DataProvider.Instance.DB.UserImages.FirstOrDefault(p => p.image_id == imageId);

                var bestRecord = DataProvider.Instance.DB.UserImageRecords.Where(p => p.user_image_id == imageId);

                if (imageRecord != null)
                {
                    DataProvider.Instance.DB.UserImages.Remove(imageRecord);
                    
                    if(bestRecord != null)
                    {
                        foreach(var record in bestRecord)
                        {
                            DataProvider.Instance.DB.UserImageRecords.Remove(record);
                        }
                    }
                    DataProvider.Instance.DB.SaveChanges();
                    MainWrappanel.Children.Remove(ImageControl);
                    selectedImages.RemoveAt(i);
                    bytes.RemoveAt(i);
                    existedImage.RemoveAt(i);
                }
            }
            SampleImage.Source = null;
            LoadImage();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            CanEdit = !CanEdit;
            if (CurrentUser.Instance.CurrentUserMoney < 200)
                AddButton.IsEnabled = false;
            else
                AddButton.IsEnabled = CanEdit;

            DeleteButton.IsEnabled = CanEdit;

            EditStatusBtnText();

            if (!CanEdit)
            {
                SampleImage.Source = null;  
                selectedImages.Clear();

               foreach(var item in MainWrappanel.Children)
               {
                    if(item is System.Windows.Controls.Image)
                    {
                        System.Windows.Controls.Image image = (System.Windows.Controls.Image)item;
                        image.Opacity = 1.0;
                    }
               }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.Instance.CurrentUserMoney < 200)
               { return; }
            OpenFileDialog OB = new OpenFileDialog();
            OB.FileName = "";
            OB.Filter = "Supported Images| *.jpg;*.png";

            if (OB.ShowDialog() == true)
            {
                string filePath = OB.FileName;
                bitmap = new BitmapImage(new Uri(filePath));
            }
            else
                return;

            BitmapImage newBitmap = ResizeImage(bitmap);

            var Image = ImageToByte(newBitmap);


            
            foreach(var item in existedImage)
            {
                var temp = ToImage(item);
                var bitmaptemp1 = BitmapImage2Bitmap(temp);
                var bitmaptemp2 = BitmapImage2Bitmap(newBitmap);
                if (CompareImagesUsingTemplateMatching(bitmaptemp1, bitmaptemp2))
                {
                    MessageBox.Show("Already existed!");
                    return;
                }
            }

            var user = DataProvider.Instance.DB.Users.Where(p => p.username == CurrentUser.Instance.CurrentUserName).FirstOrDefault();
            bool existedUserImage = DataProvider.Instance.DB.UserImages.Any();
            int imageid;
            if (existedUserImage)
                imageid = DataProvider.Instance.DB.UserImages.Max(p => p.image_id) + 1;
            else
                imageid = 1;

            var addimage = new UserImages
            {
                user_id = user.user_id,
                image_id = imageid,
                image_byte = Image
            };

            var CurrUser = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);

            CurrentUser.Instance.CurrentUserMoney -= 200;
            if (CurrentUser.Instance.CurrentUserMoney < 200)
                AddButton.IsEnabled = false;

            CurrUser.usermoney = CurrentUser.Instance.CurrentUserMoney;
            var mainviewModel = this.DataContext as MainViewModel;
            mainviewModel.usermoney = CurrentUser.Instance.CurrentUserMoney.ToString();
            EditStatusBtnText();
            DataProvider.Instance.DB.UserImages.Add(addimage);
            DataProvider.Instance.DB.SaveChanges();

            LoadImage();
        }

        public BitmapImage ToImage(byte[] array)
        {
            using (var ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public static byte[] ImageToByte(BitmapImage img)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Sử dụng PngBitmapEncoder (hoặc JpegBitmapEncoder) để mã hóa hình ảnh thành byte[]
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(img));

                // Lưu hình ảnh vào MemoryStream
                encoder.Save(memoryStream);

                // Trả về mảng byte từ MemoryStream
                return memoryStream.ToArray();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AudioControl.Instance.BackEffect_Play();
            NavigationService.GoBack();
        }

        void EditStatusBtnText()
        {
            if (CanEdit && !AddButton.IsEnabled)
                StatusBtn.Text = "Not enough money";
            else
                StatusBtn.Text = "200$ per one";
        }

        public BitmapImage ResizeImage(BitmapImage bitmap)
        {
            int newWidth = 300;
            int newHeight = 300;

            WriteableBitmap writeableBitmap = new WriteableBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32, null);

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(bitmap, new Rect(0, 0, newWidth, newHeight));
            }

            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(drawingVisual);

            writeableBitmap = new WriteableBitmap(renderTargetBitmap);

            MemoryStream memoryStream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
            encoder.Save(memoryStream);

            memoryStream.Position = 0;

            BitmapImage resizedImage = new BitmapImage();
            resizedImage.BeginInit();
            resizedImage.StreamSource = memoryStream;
            resizedImage.CacheOption = BitmapCacheOption.OnLoad;
            resizedImage.EndInit();

            return resizedImage;
        }

        public static bool CompareImagesUsingTemplateMatching(Bitmap image1, Bitmap image2)
        {
            ExhaustiveTemplateMatching tm = new ExhaustiveTemplateMatching(0.9f);

            TemplateMatch[] matches = tm.ProcessImage(image1, image2);

            // Kiểm tra nếu có kết quả phù hợp
            if (matches.Length > 0 && matches[0].Similarity > 0.9f)
            {
                return true;
            }
            return false;
        }

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            // BitmapImage bitmapImage = new BitmapImage(new Uri("../Images/test.png", UriKind.Relative));

            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapImage));
                enc.Save(outStream);
                Bitmap bitmap = new Bitmap(outStream);

                return ConvertTo24bppRgb(new Bitmap(bitmap)); 
            }
        }

        public static Bitmap ConvertTo24bppRgb(Bitmap original)
        {
            // Kiểm tra nếu ảnh đã có định dạng 24bppRGB
            if (original.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)
            {
                return original;
            }

            // Tạo Bitmap mới với định dạng 24bppRgb
            Bitmap newBitmap = new Bitmap(original.Width, original.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Vẽ ảnh gốc vào ảnh mới
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.DrawImage(original, 0, 0);
            }

            return newBitmap;
        }
    }
}
