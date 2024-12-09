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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Window mainWindow;
        public MainPage()
        {
            InitializeComponent();
            mainWindow = Application.Current.MainWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AudioControl.Instance.FlickEffect_Play();
            NavigationService.Navigate(new SelectLevelPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AudioControl.Instance.OpenWindowEffect_Play();
            PauseWindow wd = new PauseWindow(mainWindow); 
            wd.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AudioControl.Instance.OpenWindowEffect_Play();
            ChangePasswordWindow wd = new ChangePasswordWindow();
            wd.ShowDialog();
        }
    }
}
