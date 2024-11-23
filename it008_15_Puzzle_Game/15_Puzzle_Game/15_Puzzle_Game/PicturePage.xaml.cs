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
        }
    }
}
