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
using System.Windows.Threading;
using System.Collections.ObjectModel;
using _15_Puzzle_Game.Model;
using System.Data.Entity;
namespace _15_Puzzle_Game.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<XepHang> _XepHangList;
        public ObservableCollection<XepHang> XepHangList { get => _XepHangList; set { _XepHangList = value; OnPropertyChanged(); } }

        public ICommand PauseCommand { get; set; }
        public ICommand SettingGamePlayCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand CloseSettingGamePlayWindowCommand { get; set; }
        public ICommand GamePlayCommand { get; set; }
        public ICommand SelectLevelCommand { get; set; }
        public ICommand PictureCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand Button3 { get; set; }
        public ICommand Button4 { get; set; }
        public ICommand Button5 { get; set; }
        public ICommand ClearPictureSourceCommand {  get; set; }
        public ICommand LoadedWindowCommand {  get; set; }

        public bool Isloaded = false;

        private string path1 = "Picture/1039168.png";
        private string path2 = "Picture/1092839.jpg";
        private string path3 = "Picture/BackGround.jpg";
        private string path4 = "Picture/sunset-river-nature-scenery-4k-wallpaper-uhdpaper.com-693@0@j.jpg";

        private string _Picture1;
        private string _Picture2;
        private string _Picture3;
        private string _Picture4;

        public string Picture1
        {
            get { return _Picture1; }
            set
            {
                if (_Picture1 != value)
                {
                    _Picture1 = value;
                    OnPropertyChanged(nameof(Picture1));
                }

            }
        }
        public string Picture2
        {
            get { return _Picture2; }
            set
            {
                if (_Picture2 != value)
                {
                    _Picture2 = value;
                    OnPropertyChanged(nameof(Picture2));
                }

            }
        }
        public string Picture3
        {
            get { return _Picture3; }
            set
            {
                if (_Picture3 != value)
                {
                    _Picture3 = value;
                    OnPropertyChanged(nameof(Picture3));
                }

            }
        }
        public string Picture4
        {
            get { return _Picture4; }
            set
            {
                if (_Picture4 != value)
                {
                    _Picture4 = value;
                    OnPropertyChanged(nameof(Picture4));
                }

            }
        }

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

        private string _PictureSource;
        public string PictureSource
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

        private DispatcherTimer _timer;
        private int _elapsedTime = 0;
        private string _DisplayTime;
        public string DisplayTime
        {
            get { return _DisplayTime; }
            set
            {
                if (_DisplayTime != value)
                {
                    _DisplayTime = value;
                    OnPropertyChanged(nameof(DisplayTime));
                }
            }
        }

        private bool _isTimerRunning;
        public bool IsTimerRunning
        {
            get => _isTimerRunning;
            set
            {
                if (_isTimerRunning != value)
                {
                    _isTimerRunning = value;
                    OnPropertyChanged(nameof(IsTimerRunning));
                }
            }
        }

        public MainViewModel()
        {
            _elapsedTime = 0;
            _DisplayTime = "00:00";
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            LoadXepHangData();

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginwindow = new LoginWindow();
                loginwindow.ShowDialog();

                if (loginwindow.DataContext == null)
                    return;
                var loginvm = loginwindow.DataContext as LoginViewModel;

                if (loginvm.IsLogin)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            }
              );

            PauseCommand = new RelayCommand<object>((p) => { return true; }, (p) => { 
                PauseWindow wd = new PauseWindow();
                wd.ShowDialog();
            });

            SettingGamePlayCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                StopTimer();
                SettingWindow wd = new SettingWindow();
                wd.ShowDialog();
                
            });

            CloseSettingGamePlayWindowCommand = new RelayCommand<object>((p) => { return true; }, p => {
                StartTimer();
                CloseWindow(p);
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return true; }, p => {
                CloseWindow(p);
            });

            PictureCommand = new RelayCommand<Button>((p) => { return true; }, (p) =>
            {
                getPictureSource(p);
                ResetTimer();
                StartTimer();
            });

            Button3 = new RelayCommand<object>((p) => { return true; }, p => {
                Picture1 = path1;
                Picture2 = path2;
                Picture3 = path3;
                Picture4 = path4;
            });

            Button4 = new RelayCommand<object>((p) => { return true; }, p => {
                Picture1 = path3;
                Picture2 = path2;
                Picture3 = path1;
                Picture4 = path4;
            });
            
            Button5 = new RelayCommand<object>((p) => { return true; }, p => {
                Picture1 = path1;
                Picture2 = path4;
                Picture3 = path3;
                Picture4 = path2;
            });

            ClearPictureSourceCommand = new RelayCommand<object>((p) => { return true; }, p =>
            {
                PictureSource = string.Empty;
            });
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
                if (button.Name == "Button1")
                    PictureSource = Picture1;
                if (button.Name == "Button2")
                    PictureSource = Picture2;
                if (button.Name == "Button3")
                    PictureSource = Picture3;
                if (button.Name == "Button4")
                    PictureSource = Picture4;
            }
        }

        private void ResetTimer()
        {
            if (_isTimerRunning)
            {
                _elapsedTime = 0;
            }
        }

        private void StartTimer()
        {
            if(!_isTimerRunning)
            {
                _timer.Start();
                IsTimerRunning = true;
            }
        }

        public void StopTimer()
        {
            if (_isTimerRunning)
            {
                _timer.Stop();
                IsTimerRunning = false;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedTime++;
            DisplayTime = TimeSpan.FromSeconds(_elapsedTime).ToString(@"mm\:ss");
        }
        void LoadXepHangData()
        {
            XepHangList = new ObservableCollection<XepHang>();

            var top10Leaderboards = DataProvider.Instance.DB.LeaderBoards
                .OrderBy(lb => lb.time_taken)
                .ThenBy(lb => lb.move)
                .Take(10);

            foreach (var item in top10Leaderboards)
            {
                XepHang xepHang = new XepHang();
                var user = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.user_id == item.user_id);
                xepHang.UserName = user?.username ?? "Unknown";
                xepHang.LeaderBoard = item;
                int minutes = item.time_taken / 60;
                int seconds = item.time_taken % 60;
                string timeFormatted = $"{minutes:D2}:{seconds:D2}"; 
                xepHang.TimeDisplay = timeFormatted;

                XepHangList.Add(xepHang);
            }
        }


    }
}
