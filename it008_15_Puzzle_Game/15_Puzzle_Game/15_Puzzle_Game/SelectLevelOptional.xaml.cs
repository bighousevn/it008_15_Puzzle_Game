using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for SelectLevelOptional.xaml
    /// </summary>
    public partial class SelectLevelOptional : Page
    {
        public SelectLevelOptional()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n;
            string path="";
            Button clickedButton = sender as Button;
            n = clickedButton.Tag.ToString();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool fileSelected = false;

            while (!fileSelected)
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == true)
                {
                    path=openFileDialog.FileName; 
                    fileSelected = true; // Người dùng đã chọn file thành công
                }

                else
                {
                    var result = MessageBox.Show("Bạn chưa chọn file. Bạn có muốn thử lại không?",
                        "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.No) 
                    {
                        break;
                    }
                }
            }
            if(fileSelected)
            NavigationService.Navigate(new GamePlayPage(n, path,1));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
