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
            NavigationService.Navigate(new GamePlayPage("D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\1039168.png",
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\1092839.jpg",
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\BackGround.jpg",
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\sunset-river-nature-scenery-4k-wallpaper-uhdpaper.com-693@0@j.jpg"));
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePlayPage("D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\BackGround.jpg", 
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\1039168.png",
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\sunset-river-nature-scenery-4k-wallpaper-uhdpaper.com-693@0@j.jpg",
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\1092839.jpg"));
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePlayPage("D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\1092839.jpg", 
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\1039168.png",
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\sunset-river-nature-scenery-4k-wallpaper-uhdpaper.com-693@0@j.jpg",
                                                        "D:\\DoAnLegit\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Picture\\BackGround.jpg"));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
