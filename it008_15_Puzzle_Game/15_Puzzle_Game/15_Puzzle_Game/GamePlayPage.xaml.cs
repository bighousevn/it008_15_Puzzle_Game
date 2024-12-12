using _15_Puzzle_Game.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Management;
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
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        public event EventHandler<KeyEventArgs> KeyPressed;

        public GamePlayPage(string n, string path,int checkOption)
        {
            InitializeComponent();
            // Lấy ViewModel
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.LoadXepHangData();

            // Khởi tạo PlayPage
            var playPage = new PlayPage(n, path);
            PlayFrame.Navigate(playPage);

            //Nếu n == "1", lắng nghe URI từ PlayPage
            if (checkOption==1)
            {
                playPage.OnImageUriChanged += PlayPage_UpdateUri;
                playPage.UpdateImageUri();
            }

            else
            {
                // Nếu n != "1", sử dụng Binding
                sampleImage.SetBinding(Image.SourceProperty, new Binding("PictureSource") { Source = mainViewModel });
            }

            // Xử lý sự kiện khác nếu có
            playPage.OnMoveTextChanged += PlayPage_OnMoveTextChanged;

            this.KeyDown += GamePlayPage_KeyDown;
            playPage.SubscribeToGamePlayPageEvents(this);
        }

       
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += GamePlayPage_KeyDown;
        }

        private void GamePlayPage_KeyDown(object sender, KeyEventArgs e)
        {
            // Khi một phím được nhấn, kích hoạt sự kiện KeyPressed
            KeyPressed?.Invoke(this, e);
        }
        void PlayPage_UpdateUri(string uri)
        {
            Console.WriteLine("Inside PlayPage_UpdateUri");
            Console.WriteLine(uri);

            // Cập nhật ảnh
            Dispatcher.Invoke(() =>
            {
                sampleImage.Source = new BitmapImage(new Uri(uri, UriKind.Absolute));
            });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.StopTimer();
            mainViewModel._elapsedTime = 0;
            NavigationService.GoBack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (PlayFrame.Content is PlayPage playPage)
            {
                // Gọi phương thức ShuffleClick trong PlayPage
                var mainvm = this.DataContext  as MainViewModel;
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
