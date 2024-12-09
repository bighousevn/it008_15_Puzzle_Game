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

        private void SiderVolumeBackground_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AudioControl.Instance.SetBackGroundMusicVolume(SiderVolumeBackground.Value);
        }

        private void SiderVolumeEffect_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AudioControl.Instance.SetEffectVolume(SiderVolumeEffect.Value);
        }
    }
}
