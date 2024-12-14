using _15_Puzzle_Game.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for OptionalGamePlayPage.xaml
    /// </summary>
    public partial class OptionalGamePlayPage : Page
    {
        public event EventHandler<KeyEventArgs> KeyPressed;

        public OptionalGamePlayPage(string n, string path, int checkOption)
        {
            InitializeComponent();
            
        }


        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void OptionalGamePlayPage_KeyDown(object sender, KeyEventArgs e)
        {
        }
        void PlayPage_UpdateUri(string uri)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            
        }

        private void PlayPage_OnMoveTextChanged(object sender, string newText)
        {
            
        }
    }
}
