using _15_Puzzle_Game.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for SelectLevelOptional.xaml
    /// </summary>
    public partial class SelectLevelOptional : Page
    {
        private string path2;
        private BitmapImage bitmap;
        public SelectLevelOptional(string path, BitmapImage bitmap1)
        {
            InitializeComponent();
            path2 = path;
            bitmap = bitmap1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n;
            var mainViewModel = (MainViewModel)DataContext;
            Button clickedButton = sender as Button;
            n = clickedButton.Tag.ToString();
            if (clickedButton.Tag.ToString() == "3")
            {
                CurrentUser.Instance.LevelID = 1;
            }
            else if (clickedButton.Tag.ToString() == "4")
            {
                CurrentUser.Instance.LevelID = 2;
            }
            else
            {
                CurrentUser.Instance.LevelID = 3;
            }
            mainViewModel._elapsedTime = 0;
            mainViewModel.StartTimer();
            AudioControl.Instance.StartGameEffect_Play();
            NavigationService.Navigate(new OptionalGamePlayPage(n, path2));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AudioControl.Instance.BackEffect_Play();
            NavigationService.GoBack();
        }
    }
}
