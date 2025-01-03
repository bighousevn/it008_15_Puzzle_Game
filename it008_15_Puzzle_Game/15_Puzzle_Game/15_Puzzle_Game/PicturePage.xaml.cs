﻿using _15_Puzzle_Game.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for PicturePage.xaml
    /// </summary>
    public partial class PicturePage : Page
    {
        public string n;
        public PicturePage(string x)
        {
            InitializeComponent();
            n = x.Trim();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            AudioControl.Instance.StartGameEffect_Play();
            if (clickedButton != null)
            {
                // Lấy background của button vừa click
                var backgroundImage = clickedButton.Background as ImageBrush;
                if (backgroundImage != null)
                {
                    // Nếu ImageSource là BitmapImage, lấy đường dẫn
                    string imagePath = backgroundImage.ImageSource.ToString();
                    CurrentUser.Instance.CurrentImagePath=imagePath;
                    // Chuyển sang Page2 và truyền đường dẫn hình ảnh


                    GamePlayPage gamePlayPage = new GamePlayPage(n, imagePath);
                    this.NavigationService.Navigate(gamePlayPage);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AudioControl.Instance.BackEffect_Play();
            NavigationService.GoBack();
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            AudioControl.Instance.MouseHoverEffect_Play();
        }
    }
}
