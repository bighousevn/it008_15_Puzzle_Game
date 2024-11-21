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
        public GamePlayPage()
        {
            InitializeComponent();
            
        }

        public GamePlayPage(string path1, string path2, string path3, string path4)
        {
            InitializeComponent();
            PlayFrame.Navigate(new PicturePage(path1, path2, path3, path4));
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

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow wd = new SettingWindow();
            wd.ShowDialog();
        }
    }
}
