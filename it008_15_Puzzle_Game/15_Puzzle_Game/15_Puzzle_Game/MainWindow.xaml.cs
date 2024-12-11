using _15_Puzzle_Game.ViewModel;
using System.Runtime.Remoting.Channels;
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
            AudioControl.Instance.BackgroundMusic_Play();
        }

        private void mainWindow_Closed(object sender, System.EventArgs e) 
        {
            Application.Current.Dispatcher.InvokeShutdown();
        }
    }
}
