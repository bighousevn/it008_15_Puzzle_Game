using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace _15_Puzzle_Game.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand PauseCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand GamePlayCommand { get; set; }
        public ICommand SelectLevelCommand { get; set; }
        public ICommand PictureCommand { get; set; }

        private double _SiderValue = 0.3;
        public double SiderValue
        {
            get { return _SiderValue; }
            set 
            { 
                if(_SiderValue != value )
                {
                    _SiderValue = value;
                    OnPropertyChanged(nameof(SiderValue));
                }

            }
        }

        private BitmapImage _PictureSource;
        public BitmapImage PictureSource
        {
            get { return _PictureSource; }
            set
            {
                if (_PictureSource != value)
                {
                    _PictureSource = value;
                    OnPropertyChanged(nameof(PictureSource));
                }

            }
        }

        public MainViewModel()
        {
            PauseCommand = new RelayCommand<object>((p) => { return true; }, (p) => { 
                PauseWindow wd = new PauseWindow();
                wd.ShowDialog();
            });

            SettingCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                SettingWindow wd = new SettingWindow();
                wd.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return true; }, p => CloseWindow(p));

            PictureCommand = new RelayCommand<Button>((p) => { return true; }, (p) => getPictureSource(p));
        }

        private void CloseWindow(object parameter) 
        {
            if (parameter is Window window)
                window.Close();
        }

        private void getPictureSource(object parameter)
        {
            if (parameter is Button button)
            {
                var backGround = button.Background as ImageBrush;
                BitmapImage bitmapImage = backGround.ImageSource as BitmapImage;
                PictureSource = bitmapImage;
            }
        }
    }
}
