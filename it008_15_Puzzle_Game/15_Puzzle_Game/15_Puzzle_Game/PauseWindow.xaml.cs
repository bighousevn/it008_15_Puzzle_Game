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
        private SettingWindow _settingWindow;

        public PauseWindow()
        {
            InitializeComponent();
        }

        public PauseWindow(SettingWindow settingWindow)
        {
            InitializeComponent();
            _settingWindow = settingWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _settingWindow.Close();
        }
    }
}
