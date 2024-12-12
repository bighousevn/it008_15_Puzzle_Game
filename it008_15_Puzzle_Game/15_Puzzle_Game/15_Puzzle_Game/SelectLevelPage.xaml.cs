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
using _15_Puzzle_Game.Model;
using System.Diagnostics;

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
    }
}
