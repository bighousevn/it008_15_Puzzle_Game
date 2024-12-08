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
        private MediaPlayer WoodEffect;
        private MediaPlayer FlickEffect;
        private MediaPlayer CloseWindowEffect;
        private MediaPlayer DiscordEffect;

        public Double BackGroundMusicVolume { get; set; }
        public Double EffectVolume { get; set; }

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

            EffectVolume = 1;
            WoodEffect = new MediaPlayer();
             WoodEffect.Open(new Uri("pack://application:,,,/Music/Wood.mp3"));
            WoodEffect.Volume = EffectVolume;

            FlickEffect = new MediaPlayer();
            FlickEffect.Open(new Uri("pack://application:,,,/Music/wood-plank-flicks.mp3"));
            FlickEffect.Volume = EffectVolume;

            DiscordEffect = new MediaPlayer();
            DiscordEffect.Open(new Uri("pack://application:,,,/Music/discord-notification.mp3"));
            DiscordEffect.Volume = EffectVolume;

            CloseWindowEffect = new MediaPlayer();
            CloseWindowEffect.Open(new Uri("pack://application:,,,/Music/CloseWindow.mp3"));
            CloseWindowEffect.Volume = EffectVolume;

            BackgroundMusic.Open(new Uri("pack://application:,,,/Music/BackGroundMusic.mp3"));
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

        public void SetEffectVolume(double volume)
        {
            EffectVolume = volume;
            WoodEffect.Volume = EffectVolume;
            FlickEffect.Volume = EffectVolume;
            DiscordEffect.Volume = EffectVolume;
        }

        public void BackgroundMusic_Play()
        {
            BackgroundMusic.Play();
        }

        public void WoodEffect_Play()
        {
            WoodEffect.Play();
            WoodEffect.Position = TimeSpan.Zero;  // Đưa về đầu
        }

        public void FlickEffect_Play()
        {
            FlickEffect.Play();
            FlickEffect.Position = TimeSpan.Zero;  // Đưa về đầu

        }
        public void DiscordEffect_Play()
        {
            DiscordEffect.Play();
            DiscordEffect.Position = TimeSpan.Zero;  // Đưa về đầu
        }

        public void CloseWindowEffect_Play()
        {
            CloseWindowEffect.Play();
            CloseWindowEffect.Position = TimeSpan.Zero;  // Đưa về đầu
        }
    }
}

