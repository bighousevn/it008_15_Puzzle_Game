using _15_Puzzle_Game.ViewModel;
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
        private string path2;
        private BitmapImage bitmap;
        public SelectLevelOptional(string path, BitmapImage bitmap1)
        {
            InitializeComponent();
            path2 = path;
            bitmap = bitmap1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n;
            var mainViewModel = (MainViewModel)DataContext;
            Button clickedButton = sender as Button;
            n = clickedButton.Tag.ToString();

            NavigationService.Navigate(new OptionalGamePlayPage(n, path2));

            //
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //bool fileSelected = false;
            //while (!fileSelected)
            //{
            //    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            //    if (openFileDialog.ShowDialog() == true)
            //    {
            //        path=openFileDialog.FileName; 
            //        fileSelected = true; // Người dùng đã chọn file thành công
            //        mainViewModel.StartTimer();
            //    }

            //    else
            //    {
            //        //var result = MessageBox.Show("Bạn chưa chọn file. Bạn có muốn thử lại không?",
            //        //    "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //        //if (result == MessageBoxResult.No) 
            //        //{
            //        //    break;
            //        //}
            //        break;
            //    }
            //}
            //if(fileSelected)
            //


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
