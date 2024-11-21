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
    /// Interaction logic for PicturePage.xaml
    /// </summary>
    public partial class PicturePage : Page
    {
        public PicturePage()
        {
            InitializeComponent();
        }

        public PicturePage(string path1, string path2, string path3, string path4)
        {
            InitializeComponent();
            ImageBrush imageBrush1 = new ImageBrush();
            imageBrush1.ImageSource = new BitmapImage(new Uri(path1, UriKind.RelativeOrAbsolute));
            Button1.Background = imageBrush1;
            ImageBrush imageBrush2 = new ImageBrush();
            imageBrush2.ImageSource = new BitmapImage(new Uri(path2, UriKind.RelativeOrAbsolute));
            Button2.Background = imageBrush2;
            ImageBrush imageBrush3 = new ImageBrush();
            imageBrush3.ImageSource = new BitmapImage(new Uri(path3, UriKind.RelativeOrAbsolute));
            Button3.Background = imageBrush3;
            ImageBrush imageBrush4 = new ImageBrush();
            imageBrush4.ImageSource = new BitmapImage(new Uri(path4, UriKind.RelativeOrAbsolute));
            Button4.Background = imageBrush4;
        }
    }
}
