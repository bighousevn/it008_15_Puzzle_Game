using _15_Puzzle_Game.ViewModel;
using System.Windows;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new MainPage());
        }
    }
}
