using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace _15_Puzzle_Game.ViewModel
{
    public class BackGround
    {
        public void ChangeToDarkTheme(Border rightBorder, Border leftBorder)
        {
            rightBorder.Background = new SolidColorBrush(Color.FromArgb(255, 98, 62, 208));
            leftBorder.Background = new SolidColorBrush(Colors.White);
            //GreetingText.Foreground = new SolidColorBrush(Colors.White);
        }

        public void ChangeToLightTheme(Border rightBorder, Border leftBorder)
        {
            rightBorder.Background = new SolidColorBrush(Colors.White);
            leftBorder.Background = new SolidColorBrush(Color.FromArgb(255, 98, 62, 208));
            //GreetingText.Foreground = new
        }
    }
}
