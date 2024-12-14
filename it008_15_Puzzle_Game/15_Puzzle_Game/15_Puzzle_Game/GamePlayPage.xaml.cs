using _15_Puzzle_Game.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        public event EventHandler<KeyEventArgs> KeyPressed;
        PlayPage playPage;


        public GamePlayPage(string n, string path, int checkOption, BitmapImage bitmap1)
        {
            InitializeComponent();
            // Lấy ViewModel
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.LoadXepHangData();

            // Khởi tạo PlayPage
            playPage = new PlayPage(n, path, bitmap1);
            PlayFrame.Navigate(playPage);

            //Nếu n == "1", lắng nghe URI từ PlayPage
            if (checkOption == 1)
            {
                sampleImage.Source = bitmap1;
            }
            else
            {
                // Nếu n != "1", sử dụng Binding
                sampleImage.SetBinding(Image.SourceProperty, new Binding("PictureSource") { Source = mainViewModel });
            }

            // Xử lý sự kiện khác nếu có
            playPage.OnMoveTextChanged += PlayPage_OnMoveTextChanged;

            this.KeyDown += GamePlayPage_KeyDown;
            Console.WriteLine(this);
            playPage.SubscribeToGamePlayPageEvents(this);
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += GamePlayPage_KeyDown;
        }

        public void GamePlayPage_KeyDown(object sender, KeyEventArgs e)
        {
            // Khi một phím được nhấn, kích hoạt sự kiện KeyPressed
            KeyPressed?.Invoke(this, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.StopTimer();
            mainViewModel._elapsedTime = 0;

            var window = Window.GetWindow(this);
            window.KeyDown -= GamePlayPage_KeyDown;
            PlayFrame.KeyDown -= GamePlayPage_KeyDown;
            NavigationService.GoBack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            if (PlayFrame.Content is PlayPage playPage)
            {
                // Gọi phương thức ShuffleClick trong PlayPage
                var mainvm = this.DataContext as MainViewModel;
                playPage.ShuffleClick(sender, e);
                mainvm.ResetTimer(); 
            }
        }

        private void PlayPage_OnMoveTextChanged(object sender, string newText)
        {
            // Cập nhật nội dung của TextBlockMove từ sự kiện
            TextBlockMove.Text = newText;
        }


    }
}
