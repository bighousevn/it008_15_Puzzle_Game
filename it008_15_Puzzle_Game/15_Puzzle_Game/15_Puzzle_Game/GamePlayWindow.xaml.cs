using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for GamePlayWindow.xaml
    /// </summary>
    /// 
    public partial class GamePlayWindow : Window
    {
        public GamePlayWindow()
        {
            InitializeComponent();
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            var temp = ButtonProgressAssist.GetIsIndeterminate(SettingButton);    

             // Thay đổi giá trị của thuộc tính ButtonProgressAssist.IsIndeterminate
            ButtonProgressAssist.SetIsIndeterminate(SettingButton, !temp);
        }
    }
}
