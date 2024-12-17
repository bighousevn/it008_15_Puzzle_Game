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
        GamePlayPage _page;
        MainViewModel mainViewModel;
        public Congratulation(GamePlayPage gamePlayPage)
        {
            InitializeComponent();
            mainViewModel = (MainViewModel)DataContext;
            Console.WriteLine(this.DataContext);
            mainViewModel.LoadXepHangData();
            _page= gamePlayPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainViewModel.LoadStageList();
            this.Close();
            var mainwindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainwindow != null)
            {
                mainwindow.mainFrame.NavigationService.GoBack();
                mainwindow.mainFrame.NavigationService.GoBack();
            }
            var window = Application.Current.MainWindow;
            window.KeyDown -= _page.GamePlayPage_KeyDown;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
