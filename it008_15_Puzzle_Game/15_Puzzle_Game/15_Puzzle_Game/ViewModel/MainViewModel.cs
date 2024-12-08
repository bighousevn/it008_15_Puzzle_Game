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
using System.Data.Entity.Migrations;
namespace _15_Puzzle_Game.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        private ObservableCollection<XepHang> _XepHangList;
        public ObservableCollection<XepHang> XepHangList { get => _XepHangList; set { _XepHangList = value; OnPropertyChanged(); } }
        public ICommand PauseCommand { get; set; }
        public ICommand SettingGamePlayCommand { get; set; }
        public ICommand CloseSettingGamePlayWindowCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand GamePlayCommand { get; set; }
        public ICommand SelectLevelCommand { get; set; }
        public ICommand PictureCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand Button3 { get; set; }
        public ICommand Button4 { get; set; }
        public ICommand Button5 { get; set; }
        public ICommand ClearPictureSourceCommand {  get; set; }
        public ICommand LoadedWindowCommand {  get; set; }
        public ICommand SignOutCommnand { get; set; }

        public bool Isloaded;
        private string path1 = "Picture/GamePlay/Dog.png";
        private string path2 = "Picture/GamePlay/Duck.jpg";
        private string path3 = "Picture/GamePlay/Cat.jpg";
        private string path4 = "Picture/GamePlay/Kid.jpg";
        private string path5 = "Picture/GamePlay/Pepe.jpg";
        private string path6 = "Picture/GamePlay/ChillGuy.jpg";
        private string path7 = "Picture/GamePlay/DragonBall.jpg";
        private string path8 = "Picture/GamePlay/Naruto.jpg";
        private string path9 = "Picture/GamePlay/OnePiece.jpg";

        private string _PictureName1;
        private string _PictureName2;
        private string _PictureName3;

        public string PictureName1
        {
            get { return _PictureName1; }
            set
            {
                if (_PictureName1 != value)
                {
                    _PictureName1 = value;
                    OnPropertyChanged(nameof(PictureName1));
                }

            }
        }
        public string PictureName2
        {
            get { return _PictureName2; }
            set
            {
                if (_PictureName2 != value)
                {
                    _PictureName2 = value;
                    OnPropertyChanged(nameof(PictureName2));
                }

            }
        }
        public string PictureName3
        {
            get { return _PictureName3; }
            set
            {
                if (_PictureName3 != value)
                {
                    _PictureName3 = value;
                    OnPropertyChanged(nameof(PictureName3));
                }

            }
        }

        private string _Picture1;
        private string _Picture2;
        private string _Picture3;

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

        private double _SiderValue = AudioControl.Instance.BackGroundMusicVolume;
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
        private int _move=0;
        public int Move
        {
            get { return _move; }
            set { _move = value; OnPropertyChanged(nameof(Move)); }
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

        private string _LevelName;
        public string LevelName
        {
            get { return _LevelName; }
            set
            {
                if (_LevelName != value)
                {
                    _LevelName = value;
                    OnPropertyChanged(nameof(LevelName));
                }

            }
        }

        public MainViewModel()
        {
            AudioControl.Instance.BackgroundMusic_Play();
            Isloaded = false;
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

                LoadedWindow(p);
            });

            SignOutCommnand = new RelayCommand<Window>((p) => { return true; }, (p) =>{ SignOut(p);});

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

            SettingCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SettingWindow wd = new SettingWindow();
                wd.ShowDialog();
            });

            CloseSettingGamePlayWindowCommand = new RelayCommand<object>((p) => { return true; }, p => {
                StartTimer();
                CloseWindow(p);
                AudioControl.Instance.CloseWindowEffect_Play();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return true; }, p => {
                AudioControl.Instance.CloseWindowEffect_Play();
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
                PictureName1 = "Dog";
                PictureName2 = "Duck";
                PictureName3 = "Cat";
                LevelName = "Level name: 3x3";
            });

            Button4 = new RelayCommand<object>((p) => { return true; }, p => {
                Picture1 = path4;
                Picture2 = path5;
                Picture3 = path6;
                PictureName1 = "Kid";
                PictureName2 = "Pepe";
                PictureName3 = "ChillGuy";
                LevelName = "Level name: 4x4";
            });
            
            Button5 = new RelayCommand<object>((p) => { return true; }, p => {
                Picture1 = path7;
                Picture2 = path8;
                Picture3 = path9;
                PictureName1 = "DragonBall";
                PictureName2 = "Naruto";
                PictureName3 = "OnePiece";
                LevelName = "Level name: 5x5";
            });

            ClearPictureSourceCommand = new RelayCommand<object>((p) => { return true; }, p =>
            {
                PictureSource = string.Empty;
            });
        }

        public void LoadedWindow(Window p)
        {
            LoginWindow loginwindow = new LoginWindow();
            if (loginwindow.DataContext == null)
                return;
            var loginvm = loginwindow.DataContext as LoginViewModel;
            if (loginvm.IsLogin)
            {
                p.Show();
                Isloaded = false;
                AudioControl.Instance.DiscordEffect_Play();
            }
            else
            {
                p.Close();
            }
        }

        public void SignOut(Window p)
        {
            Isloaded = false;
            if (p == null)
                return;
            p.Hide();
            LoginWindow loginwindow = new LoginWindow();
            if (loginwindow.DataContext == null)
                return;
            var loginvm = loginwindow.DataContext as LoginViewModel;
            loginvm.IsLogin = false;
            loginvm.UserName = string.Empty;
            loginvm.Password = string.Empty;
            loginwindow.ShowDialog();
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
        public int getTime() { return  _elapsedTime; }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _elapsedTime++;
            DisplayTime = TimeSpan.FromSeconds(_elapsedTime).ToString(@"mm\:ss");
        }

        public void LoadXepHangData()
        {
            XepHangList = new ObservableCollection<XepHang>();

            var level = DataProvider.Instance.DB.Levels
                .FirstOrDefault(p => p.level_name == CurrentUser.Instance.CurrentLevelName);
            var puzzle = DataProvider.Instance.DB.Puzzles
                .FirstOrDefault(p => p.image_path == CurrentUser.Instance.CurrentImagePath);

            if (level == null || puzzle == null)
            {
                return;
            }

            var top10Leaderboards = DataProvider.Instance.DB.LeaderBoards
                .Where(lb => lb.level_id == level.level_id && lb.puzzle_id == puzzle.puzzle_id)
                .OrderBy(lb => lb.time_taken)
                .ThenBy(lb => lb.move)
                .Take(10);
            int rank = 1;
            foreach (var item in top10Leaderboards)
            {
                XepHang xepHang = new XepHang();
                var user = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.user_id == item.user_id);
                xepHang.Rank = rank;
                rank++;
                xepHang.UserName = user?.username ?? "Unknown";
                xepHang._LeaderBoard = item;
                int minutes = item.time_taken / 60;
                int seconds = item.time_taken % 60;
                string timeFormatted = $"{minutes:D2}:{seconds:D2}";
                xepHang.TimeDisplay = timeFormatted;

                XepHangList.Add(xepHang);
            }
        }
    }
}
