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
            mediaPlayer.Open(new Uri("D:\\Đồ Án\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Music\\BackGroundMusic.mp3"));
            mediaPlayer.Play();
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;  // Đưa về đầu
            mediaPlayer.Play();  // Phát lại nhạc
        }
        public void AdjustVolume(double value)
        {
            mediaPlayer.Volume = value;
        }
    }
}
