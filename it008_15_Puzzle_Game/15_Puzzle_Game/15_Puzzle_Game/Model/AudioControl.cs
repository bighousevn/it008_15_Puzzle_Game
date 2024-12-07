using _15_Puzzle_Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _15_Puzzle_Game.ViewModel
{
    public class AudioControl
    {
        private static AudioControl _instance;
        private MediaPlayer BackgroundMusic;

        public Double BackGroundMusicVolume { get; set; }
        public static AudioControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AudioControl();
                }
                return _instance;
            }
            set { _instance = value; }
        }

        public AudioControl()
        {
            BackGroundMusicVolume = 1;
            BackgroundMusic = new MediaPlayer();
            BackgroundMusic.Open(new Uri("D:\\Đồ Án\\it008_15_Puzzle_Game\\it008_15_Puzzle_Game\\15_Puzzle_Game\\15_Puzzle_Game\\Music\\BackGroundMusic.mp3"));
            BackgroundMusic.Volume = BackGroundMusicVolume;
            BackgroundMusic.MediaEnded += BackgroundMusic_MediaEnded;
        }

        private void BackgroundMusic_MediaEnded(object sender, EventArgs e)
        {
            BackgroundMusic.Position = TimeSpan.Zero;  // Đưa về đầu
            BackgroundMusic.Play();  // Phát lại nhạc
        }

        public void SetBackGroundMusicVolume(double volume)
        {
            BackGroundMusicVolume = volume;
            BackgroundMusic.Volume = BackGroundMusicVolume;
        }

        public void BackgroundMusic_Play()
        {
            BackgroundMusic.Play();
        }
    }
}

