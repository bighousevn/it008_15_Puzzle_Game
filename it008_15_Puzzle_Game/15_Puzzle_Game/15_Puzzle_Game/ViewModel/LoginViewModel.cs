using _15_Puzzle_Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _15_Puzzle_Game.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private string _RegisterUserName;
        public string RegisterUserName { get => _RegisterUserName; set { _RegisterUserName = value; OnPropertyChanged(); } }
        private string _RegisterEmail;
        public string RegisterEmail { get => _RegisterEmail; set { _RegisterEmail = value; OnPropertyChanged(); } }
        private string _RegisterPassWord;
        public string RegisterPassWord { get => _RegisterPassWord; set { _RegisterPassWord = value; OnPropertyChanged(); } }
        public string _VerificationCode;
        public string VerificationCode
        {
            get { return _VerificationCode; }
            set { _VerificationCode = value; OnPropertyChanged(); }
        }
        private string _GeneratedVerificationCode;

        private bool _isEnabledRegisterButton = false;
        public bool isEnabledRegisterButton
        {
            get { return _isEnabledRegisterButton; }
            set { _isEnabledRegisterButton = value; OnPropertyChanged(); }
        }

        public ICommand SendVerificationCodeCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand OpenRegisterWindowCommand { get; set; }
        public ICommand RegisterPasswordChangedCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ForgotPasswordWindowCommand { get; set; }
        public ICommand RegisterWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        Window mainWindow;
        MainViewModel mainViewModel;
        Random random;

        public LoginViewModel()
        {
            random = new Random();
            IsLogin = false;
            UserName = string.Empty;
            Password = string.Empty;

            mainWindow = Application.Current.MainWindow;
            mainViewModel = mainWindow.DataContext as MainViewModel;

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                AudioControl.Instance.SigninEffect_Play();
                Login(p); 
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            RegisterPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { RegisterPassWord = p.Password; });
            SendVerificationCodeCommand= new RelayCommand<object>((p) => { return true;}, (p) => { SendVerificationCode(); });
            RegisterCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Register(p); });

            ForgotPasswordWindowCommand = new RelayCommand<object>((p) => { return true; }, p => {
                AudioControl.Instance.OpenWindowEffect_Play();
                ForgotPasswordWindow wd = new ForgotPasswordWindow();   
                wd.ShowDialog();
            });

            RegisterWindowCommand = new RelayCommand<object>((p) => { return true; }, p => {
                AudioControl.Instance.OpenWindowEffect_Play();
                RegisterWindow wd = new RegisterWindow();
                wd.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return true; }, p => {
                AudioControl.Instance.CloseWindowEffect_Play();
                CloseWindow(p);
            });

            ExitCommand = new RelayCommand<Window>((p) => { return true; }, p => {
                Application.Current.Dispatcher.InvokeShutdown();
            });
        }
        void SendVerificationCode()
        {
            _GeneratedVerificationCode= random.Next(100000,999999).ToString();
            bool isSent= SendVerificationCode(RegisterEmail, _GeneratedVerificationCode);
            if(isSent)
            {
                MessageBox.Show($"Email chứa mã xác thực đã được gửi tới {RegisterEmail}");
            }
            else
            {
                MessageBox.Show("Không thể gửi email. Vui lòng kiểm tra lại.");
            }
        }

        private void CloseWindow(object parameter)
        {
            if (parameter is Window window)
                window.Close();
        }

        void Login(Window p)
        {
            if (p == null)
                return;

            if(string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(UserName))
                return;
            
            string pass = sha256(Password);
            var accCount = DataProvider.Instance.DB.Users.Any(x => x.username == UserName && x.password_hash == pass);

            if (accCount)
            {
                IsLogin = true;
                CurrentUser.Instance.CurrentUserName = UserName;
                var user = DataProvider.Instance.DB.Users.FirstOrDefault(x => x.username == UserName);
                CurrentUser.Instance.CurrentUserid = user.user_id;
                mainViewModel.CreateStageList();
                CurrentUser.Instance.CurrentUserMoney = (int)user.usermoney;
                mainViewModel.username = "Hello, " + UserName;
                mainViewModel.usermoney = user.usermoney.ToString();
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }

            if (!mainViewModel.Isloaded)
                mainViewModel.LoadedWindow(mainWindow);
        }
        private bool SendVerificationCode(string toEmail, string VerificationCode)
        {
            try
            {
                string fromEmail = "vmt22479@gmail.com";
                string fromPassword = "ureu ycei smql lzzp";
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential(fromEmail, fromPassword)
                };
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "Mã xác minh ",
                    Body = $"Mã xác minh của bạn là: {VerificationCode}",
                    IsBodyHtml = true,
                };
                mail.To.Add(toEmail);
                smtp.Send(mail);
                isEnabledRegisterButton = true;
                _ = ChangeVerificationCode();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi gửi email", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        void Register(Window p)
        {
            if (p == null) return;

            if (!IsEmailUnique(RegisterEmail) || !IsUserNameUnique(RegisterUserName))
            { 
                MessageBox.Show("UserName or email already exists.");
                return;
            }

            if(!isValidEmail(RegisterEmail))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            if(VerificationCode == string.Empty || VerificationCode == null || VerificationCode != _GeneratedVerificationCode)
            {
                MessageBox.Show("Invalid verification code.");
                return;
            }

            var user = new Users
            {
                username = RegisterUserName,
                password_hash = sha256(RegisterPassWord),
                email = RegisterEmail,
                created_at = DateTime.Now,
                maxlevel = 1,
                usermoney = 100
            };

            DataProvider.Instance.DB.Users.Add(user);
            DataProvider.Instance.DB.SaveChanges();
            _GeneratedVerificationCode = null;
            isEnabledRegisterButton = false;
            VerificationCode = null;
            MessageBox.Show("Succeed!");
            p.Close();
            //DataProvider.Instance.DB.SaveChanges();
        }

        bool IsUserNameUnique(string userName)
        {
            return !DataProvider.Instance.DB.Users.Any(x=>x.username == userName);
        }

        bool IsEmailUnique(string email)
        {
            return !DataProvider.Instance.DB.Users.Any(x => x.email == email);
        }

        bool isValidEmail(string email)
        {
            var emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailRegex);
        }
        static public string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        async Task ChangeVerificationCode()
        {
            await Task.Delay(30000);
            _GeneratedVerificationCode = null;
            VerificationCode = null;
            isEnabledRegisterButton = false;
        }

    }
}
