﻿using _15_Puzzle_Game.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
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
        private MediaPlayer SigninEffect;
        private MediaPlayer OpenWindowEffect;
        private MediaPlayer LogoutEffect;
        private MediaPlayer VictoryEffect;


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
            BackGroundMusicVolume = 0;
            EffectVolume = 1;

            BackgroundMusic = new MediaPlayer();
            BackgroundMusic.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "BackGroundMusic.mp3")));
            BackgroundMusic.Volume = BackGroundMusicVolume;
            BackgroundMusic.MediaEnded += BackgroundMusic_MediaEnded;

            WoodEffect = new MediaPlayer();
            WoodEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "Wood.mp3")));
            WoodEffect.Volume = EffectVolume;

            FlickEffect = new MediaPlayer();
            FlickEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "EnterGame.mp3")));
            FlickEffect.Volume = EffectVolume;

            SigninEffect = new MediaPlayer();
            SigninEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "Signin.mp3")));
            SigninEffect.Volume = EffectVolume;

            CloseWindowEffect = new MediaPlayer();
            CloseWindowEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "CloseWindow.mp3")));
            CloseWindowEffect.Volume = EffectVolume;

            OpenWindowEffect = new MediaPlayer();
            OpenWindowEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "OpenWindow.mp3")));
            OpenWindowEffect.Volume = EffectVolume;

            LogoutEffect = new MediaPlayer();
            LogoutEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "Logout.mp3")));
            LogoutEffect.Volume = EffectVolume;

            VictoryEffect = new MediaPlayer();
            VictoryEffect.Open(new Uri(Path.Combine(Environment.CurrentDirectory, "Music", "Victory.mp3")));
            VictoryEffect.Volume = EffectVolume;
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
            SigninEffect.Volume = EffectVolume;
            CloseWindowEffect.Volume = EffectVolume;
            OpenWindowEffect.Volume = EffectVolume;
            LogoutEffect.Volume = EffectVolume;
            VictoryEffect.Volume = EffectVolume;
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

        public void SigninEffect_Play()
        {
            SigninEffect.Play();
            SigninEffect.Position = TimeSpan.Zero;  // Đưa về đầu
        }

        public void CloseWindowEffect_Play()
        {
            CloseWindowEffect.Play();
            CloseWindowEffect.Position = TimeSpan.Zero;  // Đưa về đầu
        }

        public void OpenWindowEffect_Play()
        {
            OpenWindowEffect.Play();
            OpenWindowEffect.Position = TimeSpan.Zero;  // Đưa về đầu
        }

        public void LogoutEffect_Play()
        {
            LogoutEffect.Play();
            LogoutEffect.Position = TimeSpan.Zero;  // Đưa về đầu
        }

        public void VictoryEffect_Play()
        {
            VictoryEffect.Play();
            VictoryEffect.Position = TimeSpan.Zero;
        }
    }
}

