using _15_Puzzle_Game.ViewModel;
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
using MaterialDesignColors;
using MaterialDesignThemes;
using MaterialDesignThemes.Wpf;

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
            NavigationService.Navigate(new GamePlayPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            SettingWindow wd = new SettingWindow();
            wd.ShowDialog();
        }
    }
}
