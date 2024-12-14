using _15_Puzzle_Game.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for PicturePage.xaml
    /// </summary>
    public partial class PicturePage : Page
    {
        public string n;
        public PicturePage(string x)
        {
            InitializeComponent();
            n = x.Trim();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                // Lấy background của button vừa click
                var backgroundImage = clickedButton.Background as ImageBrush;
                if (backgroundImage != null)
                {
                    // Nếu ImageSource là BitmapImage, lấy đường dẫn
                    string imagePath = backgroundImage.ImageSource.ToString();
                    CurrentUser.Instance.CurrentImagePath=imagePath;
                    // Chuyển sang Page2 và truyền đường dẫn hình ảnh
                    GamePlayPage gamePlayPage = new GamePlayPage(n,imagePath,0);
                    this.NavigationService.Navigate(gamePlayPage);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
