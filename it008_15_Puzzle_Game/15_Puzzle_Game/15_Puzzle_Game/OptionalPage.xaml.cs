using _15_Puzzle_Game.Model;
using _15_Puzzle_Game.ViewModel;
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
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for OptionalPage.xaml
    /// </summary>
    public partial class OptionalPage : Page
    {
        private List<System.Windows.Controls.Image> selectedImages = new List<System.Windows.Controls.Image>();  // Lưu trữ ảnh đã chọn
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

            var allImage = DataProvider.Instance.DB.UserImages.Where(p => p.user_id == Userid);
            foreach (var item in allImage)
            {
                BitmapImage bitmap = ToImage(item.image_byte);
                Image ImageControl = new Image
                {
                    Source = bitmap,
                    Width = 255,
                    Height = 255,
                    Margin = new Thickness(5),
                    Stretch = Stretch.Fill,
                    Tag = item.image_id
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
                var imageId = (int)selectedImage.Tag;
                var imageRecord = DataProvider.Instance.DB.UserImages.FirstOrDefault(p => p.image_id == imageId);
                BitmapImage bitmap = ToImage(imageRecord.image_byte);
                NavigationService.Navigate(new SelectLevelOptional(bitmap.StreamSource.ToString(),bitmap));
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

                if (imageRecord != null)
                {
                    // Xóa bản ghi trong database
                    DataProvider.Instance.DB.UserImages.Remove(imageRecord);
                    DataProvider.Instance.DB.SaveChanges();

                    // Xóa ImageControl khỏi WrapPanel và khỏi danh sách selectedImages
                    MainWrappanel.Children.Remove(ImageControl);
                    // Xóa phần tử tại chỉ số i
                    selectedImages.RemoveAt(i);
                }
            }
            SampleImage.Source = null;
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
                        Image image = (Image)item;
                        image.Opacity = 1.0;
                    }
                }
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
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
            var Image = ImageToByte(bitmap);

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
            Console.WriteLine(Convert.FromBase64String(Convert.ToBase64String(addimage.image_byte)));
            var CurrUser = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);
            CurrentUser.Instance.CurrentUserMoney -= 200;
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
            NavigationService.GoBack();
        }

        void EditStatusBtnText()
        {
            if (CanEdit && !AddButton.IsEnabled)
                StatusBtn.Text = "Not enough money";
            else
                StatusBtn.Text = "200$ per one";
        }
    }
}
