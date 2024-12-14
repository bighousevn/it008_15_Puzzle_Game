using _15_Puzzle_Game.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for SelectLevelPage.xaml
    /// </summary>
    public partial class SelectLevelPage : Page
    {
        public SelectLevelPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Tag.ToString() != "1")
            {
                if (clickedButton.Tag.ToString() == "3")
                {
                    CurrentUser.Instance.CurrentLevelName = "3x3";
                }
                else if (clickedButton.Tag.ToString() == "4")
                {
                    CurrentUser.Instance.CurrentLevelName = "4x4";
                }
                else
                {
                    CurrentUser.Instance.CurrentLevelName = "5x5";
                }
                NavigationService.Navigate(new PicturePage(clickedButton.Tag.ToString()));
            }
            else
            {
                CurrentUser.Instance.CurrentLevelName = "Option";
                NavigationService.Navigate(new OptionalPage());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Btn3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            if(image.Tag.ToString() != "1")
            {
                if (image.Tag.ToString() == "3")
                {
                    CurrentUser.Instance.CurrentLevelName = "3x3";
                }
                else if (image.Tag.ToString() == "4")
                {
                    CurrentUser.Instance.CurrentLevelName = "4x4";
                }
                else
                {
                    CurrentUser.Instance.CurrentLevelName = "5x5";
                }
                NavigationService.Navigate(new PicturePage(image.Tag.ToString()));
            }
            else
            {
                CurrentUser.Instance.CurrentLevelName = "Option";
                NavigationService.Navigate(new OptionalPage());
            }
        }
    }
}
