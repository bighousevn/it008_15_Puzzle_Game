using _15_Puzzle_Game.ViewModel;
using System.Windows;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {

        public SettingWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AudioControl.Instance.SetBackGroundMusicVolume(siderVolumn.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PauseWindow wd = new PauseWindow(this); 
            wd.ShowDialog();
        }
    }
}
