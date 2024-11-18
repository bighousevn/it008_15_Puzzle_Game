using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MediaPlayer mediaPlayer {  get; set; }

        public App()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("C:\\Users\\ToanHuynh\\Downloads\\Như Anh Mơ.mp3"));
            mediaPlayer.Play();
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;  // Đưa về đầu
            mediaPlayer.Play();  // Phát lại nhạc
        }
    }
}
