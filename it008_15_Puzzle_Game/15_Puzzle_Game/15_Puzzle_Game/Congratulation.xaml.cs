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
    /// Interaction logic for Congratulation.xaml
    /// </summary>
    public partial class Congratulation : Window
    {
        public Congratulation()
        {
            InitializeComponent();
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.LoadXepHangData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            var mainwindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainwindow != null)
            {
                mainwindow.mainFrame.NavigationService.GoBack();
            }
            var window = Window.GetWindow(this);
            var gamePlayPage = this.DataContext as GamePlayPage;
            window.KeyDown -= gamePlayPage.GamePlayPage_KeyDown;
            gamePlayPage.PlayFrame.KeyDown -= gamePlayPage.GamePlayPage_KeyDown;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
