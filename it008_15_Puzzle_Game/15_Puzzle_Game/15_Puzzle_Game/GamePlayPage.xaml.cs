using _15_Puzzle_Game.ViewModel;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for GamePlayPage.xaml
    /// </summary>
    public partial class GamePlayPage : Page
    {
        
        public GamePlayPage(string n, string path)
        {
            InitializeComponent();
            var playPage = new PlayPage(n, path);
            PlayFrame.Navigate(playPage);
            playPage.OnMoveTextChanged += PlayPage_OnMoveTextChanged;
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.LoadXepHangData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int temp = int.Parse(UndoButtonBadge.Badge.ToString());
            temp--;
            UndoButtonBadge.Badge = temp;   

            if (temp == 0)
            {
                UndoButton.IsEnabled = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (PlayFrame.Content is PlayPage playPage)
            {
                // Gọi phương thức ShuffleClick trong PlayPage
                playPage.ShuffleClick(sender, e);
            }
        }

        private void PlayPage_OnMoveTextChanged(object sender, string newText)
        {
            // Cập nhật nội dung của TextBlockMove từ sự kiện
            TextBlockMove.Text = newText;
        }
    }
}
