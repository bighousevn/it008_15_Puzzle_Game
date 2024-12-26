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
        private ObservableCollection<Stage> _StageList;
        public ObservableCollection<Stage> StageList { get => _StageList; set { _StageList = value; OnPropertyChanged(); } }

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
        private string path1 = "Picture/GamePlay/Animal/Beaver.jpg";
        private string path2 = "Picture/GamePlay/Animal/Cat.jpg";
        private string path3 = "Picture/GamePlay/Animal/Dog.png";
        private string path4 = "Picture/GamePlay/Animal/Duck.jpg";
        private string path5 = "Picture/GamePlay/Animal/Fox.jpg";
        private string path6 = "Picture/GamePlay/Animal/Rabbit.jpg";
        private string path7 = "Picture/GamePlay/Animal/RedPanda.jpg";
        private string path8 = "Picture/GamePlay/Animal/Tiger.jpg";
        private string path9 = "Picture/GamePlay/Animal/Wolf.jpg";

        private string path10 = "Picture/GamePlay/Meme/ChillGuy.jpg";
        private string path11 = "Picture/GamePlay/Meme/JerryLove.jpg";
        private string path12 = "Picture/GamePlay/Meme/Kid.jpg";
        private string path13 = "Picture/GamePlay/Meme/MrBean.jpg";
        private string path14 = "Picture/GamePlay/Meme/Pepe.jpg";
        private string path15 = "Picture/GamePlay/Meme/ReallyNigger.jpg";
        private string path16 = "Picture/GamePlay/Meme/Sigma.jpg";
        private string path17 = "Picture/GamePlay/Meme/Stonks.jpg";
        private string path18 = "Picture/GamePlay/Meme/ThreeDragon.jpg";

        private string path19 = "Picture/GamePlay/Anime/Broly.jpg";
        private string path20 = "Picture/GamePlay/Anime/Doflamigo.jpg";
        private string path21 = "Picture/GamePlay/Anime/DragonBall.jpg";
        private string path22 = "Picture/GamePlay/Anime/Kakashi.jpg";
        private string path23 = "Picture/GamePlay/Anime/Naruto.jpg";
        private string path24 = "Picture/GamePlay/Anime/Obito.jpg";
        private string path25 = "Picture/GamePlay/Anime/OnePiece.jpg";
        private string path26 = "Picture/GamePlay/Anime/Vegeta.png";
        private string path27 = "Picture/GamePlay/Anime/Zoro.jpg";

        private string _username;
        public string username
        {
            get { return _username; }
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(username));
                }

            }
        }

        private string _usermoney;
        public string usermoney
        {
            get { return _usermoney; }
            set
            {
                if (_usermoney != value)
                {
                    _usermoney = value;
                    OnPropertyChanged(nameof(usermoney));
                }

            }
        }

        private string _PictureName1;
        private string _PictureName2;
        private string _PictureName3;
        private string _PictureName4;
        private string _PictureName5;
        private string _PictureName6;
        private string _PictureName7;
        private string _PictureName8;
        private string _PictureName9;

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
        public string PictureName4
        {
            get { return _PictureName4; }
            set
            {
                if (_PictureName4 != value)
                {
                    _PictureName4 = value;
                    OnPropertyChanged(nameof(PictureName4));
                }

            }
        }
        public string PictureName5
        {
            get { return _PictureName5; }
            set
            {
                if (_PictureName5 != value)
                {
                    _PictureName5 = value;
                    OnPropertyChanged(nameof(PictureName5));
                }

            }
        }
        public string PictureName6
        {
            get { return _PictureName6; }
            set
            {
                if (_PictureName6 != value)
                {
                    _PictureName6 = value;
                    OnPropertyChanged(nameof(PictureName6));
                }

            }
        }
        public string PictureName7
        {
            get { return _PictureName7; }
            set
            {
                if (_PictureName7 != value)
                {
                    _PictureName7 = value;
                    OnPropertyChanged(nameof(PictureName7));
                }

            }
        }
        public string PictureName8
        {
            get { return _PictureName8; }
            set
            {
                if (_PictureName8 != value)
                {
                    _PictureName8 = value;
                    OnPropertyChanged(nameof(PictureName8));
                }

            }
        }
        public string PictureName9
        {
            get { return _PictureName9; }
            set
            {
                if (_PictureName9 != value)
                {
                    _PictureName9 = value;
                    OnPropertyChanged(nameof(PictureName9));
                }

            }
        }

        private string _Picture1;
        private string _Picture2;
        private string _Picture3;
        private string _Picture4;
        private string _Picture5;
        private string _Picture6;
        private string _Picture7;
        private string _Picture8;
        private string _Picture9;

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
        public string Picture5
        {
            get { return _Picture5; }
            set
            {
                if (_Picture5 != value)
                {
                    _Picture5 = value;
                    OnPropertyChanged(nameof(Picture5));
                }

            }
        }
        public string Picture6
        {
            get { return _Picture6; }
            set
            {
                if (_Picture6 != value)
                {
                    _Picture6 = value;
                    OnPropertyChanged(nameof(Picture6));
                }

            }
        }
        public string Picture7
        {
            get { return _Picture7; }
            set
            {
                if (_Picture7 != value)
                {
                    _Picture7 = value;
                    OnPropertyChanged(nameof(Picture7));
                }

            }
        }
        public string Picture8
        {
            get { return _Picture8; }
            set
            {
                if (_Picture8 != value)
                {
                    _Picture8 = value;
                    OnPropertyChanged(nameof(Picture8));
                }

            }
        }
        public string Picture9
        {
            get { return _Picture9; }
            set
            {
                if (_Picture9 != value)
                {
                    _Picture9 = value;
                    OnPropertyChanged(nameof(Picture9));
                }

            }
        }

        private double _SiderBackgroundValue = AudioControl.Instance.BackGroundMusicVolume;
        public double SiderBackgroundValue
        {
            get { return _SiderBackgroundValue; }
            set 
            { 
                if(_SiderBackgroundValue != value )
                {
                    _SiderBackgroundValue = value;
                    OnPropertyChanged(nameof(SiderBackgroundValue));
                }

            }
        }

        private double _SiderEffectValue = AudioControl.Instance.EffectVolume;
        public double SiderEffectValue
        {
            get { return _SiderEffectValue; }
            set
            {
                if (_SiderEffectValue != value)
                {
                    _SiderEffectValue = value;
                    OnPropertyChanged(nameof(SiderEffectValue));
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
        private int _bestmove;

        public int BestMove
        {
            get { return _bestmove; }
            set { _bestmove = value; OnPropertyChanged(); }
        }
        private string _bestTime;

        public string BestTime
        {
            get { return _bestTime; }
            set { _bestTime = value; OnPropertyChanged(); }
        }


        private int _move=0;
        public int Move
        {
            get { return _move; }
            set { _move = value; OnPropertyChanged(nameof(Move)); }
        }

        private DispatcherTimer _timer;
        public int _elapsedTime = 0;
        private string _DisplayTime;
        public string DisplayTime        {
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

        
        private bool unlockLevel1;
        public bool UnLockLevel1
        {
            get { return unlockLevel1; }
            set { if (unlockLevel1 != value) unlockLevel1 = value; OnPropertyChanged(nameof(UnLockLevel1)); }
        }
        private bool unlockLevel2;
        public bool UnLockLevel2
        {
            get { return unlockLevel2; }
            set { if (unlockLevel2 != value) unlockLevel2 = value; OnPropertyChanged(nameof(UnLockLevel2)); }
        }
        private bool unlockLevel3;
        public bool UnLockLevel3
        {
            get { return unlockLevel3; }
            set { if (unlockLevel3 != value) unlockLevel3 = value; OnPropertyChanged(nameof(UnLockLevel3)); }
        }


        private bool unlockPickture1;
        public bool UnLockPicture1
        {
            get { return unlockPickture1; }
            set
            {
                if (unlockPickture1 != value)
                {
                    unlockPickture1 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture2;
        public bool UnLockPicture2
        {
            get { return unlockPickture2; }
            set
            {
                if (unlockPickture2 != value)
                {
                    unlockPickture2 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture3;
        public bool UnLockPicture3
        {
            get { return unlockPickture3; }
            set
            {
                if (unlockPickture3 != value)
                {
                    unlockPickture3 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture4;
        public bool UnLockPicture4
        {
            get { return unlockPickture4; }
            set
            {
                if (unlockPickture4 != value)
                {
                    unlockPickture4 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture5;
        public bool UnLockPicture5
        {
            get { return unlockPickture5; }
            set
            {
                if (unlockPickture5 != value)
                {
                    unlockPickture5 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture6;
        public bool UnLockPicture6
        {
            get { return unlockPickture6; }
            set
            {
                if (unlockPickture6 != value)
                {
                    unlockPickture6 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture7;
        public bool UnLockPicture7
        {
            get { return unlockPickture7; }
            set
            {
                if (unlockPickture7 != value)
                {
                    unlockPickture7 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture8;
        public bool UnLockPicture8
        {
            get { return unlockPickture8; }
            set
            {
                if (unlockPickture8 != value)
                {
                    unlockPickture8 = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool unlockPickture9;
        public bool UnLockPicture9
        {
            get { return unlockPickture9; }
            set
            {
                if (unlockPickture9 != value)
                {
                    unlockPickture9 = value;
                    OnPropertyChanged();
                }
            }
        }


        private bool _isLock = true;
        public bool isLock
        {
            get { return _isLock; }
            set
            {
                if (_isLock != value)
                {
                    _isLock = value;
                    OnPropertyChanged();
                }
            }
        }



        public MainViewModel()
        {
            Isloaded = false;
            _elapsedTime = 0;
            _DisplayTime = "00:00";
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            LoadXepHangData();
            StageList = new ObservableCollection<Stage>();

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

            SignOutCommnand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                AudioControl.Instance.SigninEffect_Play();
                SignOut(p);
            });

            PauseCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                AudioControl.Instance.OpenWindowEffect_Play();
                PauseWindow wd = new PauseWindow();
                wd.ShowDialog();
            });

            SettingGamePlayCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AudioControl.Instance.OpenWindowEffect_Play();
                StopTimer();
                SettingWindow wd = new SettingWindow();
                wd.ShowDialog();
                
            });

            SettingCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AudioControl.Instance.OpenWindowEffect_Play();
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
                UnLockPicture1 = StageList[0].UnLock;
                UnLockPicture2 = StageList[1].UnLock;
                UnLockPicture3 = StageList[2].UnLock;
                UnLockPicture4 = StageList[3].UnLock;
                UnLockPicture5 = StageList[4].UnLock;
                UnLockPicture6 = StageList[5].UnLock;
                UnLockPicture7 = StageList[6].UnLock;
                UnLockPicture8 = StageList[7].UnLock;
                UnLockPicture9 = StageList[8].UnLock;

                Picture1 = path1;
                Picture2 = path2;
                Picture3 = path3;
                Picture4 = path4;
                Picture5 = path5;
                Picture6 = path6;
                Picture7 = path7;
                Picture8 = path8;
                Picture9 = path9;
                PictureName1 = "Beaver";
                PictureName2 = "Cat";
                PictureName3 = "Dog";
                PictureName4 = "Duck";
                PictureName5 = "Fox";
                PictureName6 = "Rabbit";
                PictureName7 = "RedPanda";
                PictureName8 = "Tiger";
                PictureName9 = "Wolf";
                LevelName = "Level: 3x3"; 
            });

            Button4 = new RelayCommand<object>((p) => { return true; }, p => {
                UnLockPicture1 = StageList[9].UnLock;
                UnLockPicture2 = StageList[10].UnLock;
                UnLockPicture3 = StageList[11].UnLock;
                UnLockPicture4 = StageList[12].UnLock;
                UnLockPicture5 = StageList[13].UnLock;
                UnLockPicture6 = StageList[14].UnLock;
                UnLockPicture7 = StageList[15].UnLock;
                UnLockPicture8 = StageList[16].UnLock;
                UnLockPicture9 = StageList[17].UnLock;

                Picture1 = path10;
                Picture2 = path11;
                Picture3 = path12;
                Picture4 = path13;
                Picture5 = path14;
                Picture6 = path15;
                Picture7 = path16;
                Picture8 = path17;
                Picture9 = path18;

                PictureName1 = "ChillGuy";
                PictureName2 = "JerryLove";
                PictureName3 = "Kid";
                PictureName4 = "MrBean";
                PictureName5 = "Pepe";
                PictureName6 = "Really";
                PictureName7 = "Sigma";
                PictureName8 = "Stonks";
                PictureName9 = "Dragon";
                LevelName = "Level: 4x4";
            });
            
            Button5 = new RelayCommand<object>((p) => { return true; }, p => {
                UnLockPicture1=  StageList[18].UnLock;
                UnLockPicture2 = StageList[19].UnLock;
                UnLockPicture3 = StageList[20].UnLock;
                UnLockPicture4 = StageList[21].UnLock;
                UnLockPicture5 = StageList[22].UnLock;
                UnLockPicture6 = StageList[23].UnLock;
                UnLockPicture7 = StageList[24].UnLock;
                UnLockPicture8 = StageList[25].UnLock;
                UnLockPicture9 = StageList[26].UnLock;

                Picture1 = path19;
                Picture2 = path20;
                Picture3 = path21;
                Picture4 = path22;
                Picture5 = path23;
                Picture6 = path24;
                Picture7 = path25;
                Picture8 = path26;
                Picture9 = path27;

                PictureName1 = "Broly";
                PictureName2 = "Doflamigo";
                PictureName3 = "Songoku";
                PictureName4 = "Kakashi";
                PictureName5 = "Naruto";
                PictureName6 = "Obito";
                PictureName7 = "OnePiece";
                PictureName8 = "Vegeta";
                PictureName9 = "Zoro";
                LevelName = "Level: 5x5";
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
            StageList.Clear();
            CurrentUser.Instance.UserImageID = 0;
            CurrentUser.Instance.CurrentImagePath = null;
            CurrentUser.Instance.CurrentUserid = 0;
            CurrentUser.Instance.CurrentLevelName = string.Empty;
            CurrentUser.Instance.CurrentUserMoney = 0;
            CurrentUser.Instance.CurrentUserName = string.Empty;
            CurrentUser.Instance.LevelID = 0;

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
                if (button.Name == "Button4")
                    PictureSource = Picture4;
                if (button.Name == "Button5")
                    PictureSource = Picture5;
                if (button.Name == "Button6")
                    PictureSource = Picture6;
                if (button.Name == "Button7")
                    PictureSource = Picture7;
                if (button.Name == "Button8")
                    PictureSource = Picture8;
                if (button.Name == "Button9")
                    PictureSource = Picture9;
            }
        }
        public void ResetTimer()
        {
            if (_isTimerRunning)
            {
                _elapsedTime = 0;
            }
        }
        public void StartTimer()
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
        
        public void CreateStageList()
        {
            var currentUser = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);
            for (int i = 0; i < currentUser.maxlevel; i++)
            {
                Stage stage = new Stage
                {
                    Manchoi = i + 1,
                    UnLock = true
                };
                StageList.Add(stage);
            }
            for (int i = currentUser.maxlevel; i < DataProvider.Instance.DB.Puzzles.Count(); i++)
            {
                Stage stage = new Stage
                {
                    Manchoi = i,
                    UnLock = false
                };
                StageList.Add(stage);
            }
            UnLockLevels(currentUser.maxlevel);
        }

        private void UnLockLevels(int x)
        {
            UnLockLevel1 = true;
            if (x > 18)
            {
                UnLockLevel2 = true;
                UnLockLevel3 = true;
            }
            else if (x > 9) 
            { 
                UnLockLevel2 = true;
                UnLockLevel3 = false;
            }
            else
            {
                UnLockLevel2 = false;
                UnLockLevel3 = false;
            }
        }

        public void LoadStageList()
        {
            var puzzle = DataProvider.Instance.DB.Puzzles
                .FirstOrDefault(p => p.image_path == CurrentUser.Instance.CurrentImagePath);
            if (puzzle == null) return;
            else
            {
                int IDpuzzle = puzzle.puzzle_id;
                var currentUser = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);
                if (IDpuzzle < currentUser.maxlevel) 
                { 
                    return; 
                }
                else
                {
                    StageList[IDpuzzle].UnLock = true;
                    currentUser.maxlevel++;
                    DataProvider.Instance.DB.SaveChanges();
                }
                UnLockLevels(currentUser.maxlevel);
            }
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
