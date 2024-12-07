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
using System.Windows.Shapes;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for PauseWindow.xaml
    /// </summary>
    public partial class PauseWindow : Window
    {
        MainWindow MainWD;
        MainViewModel MainVM;
        public PauseWindow()
        {
            InitializeComponent();
        }

        public PauseWindow(Window mainWindow)
        {
            InitializeComponent();
            MainWD = mainWindow as MainWindow;
            MainVM = mainWindow.DataContext as MainViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainVM.SignOut(MainWD);
        }
    }
}
