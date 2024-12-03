using _15_Puzzle_Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public ICommand LoginCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public ICommand OpenRegisterWindowCommand { get; set; }
        public ICommand RegisterPasswordChangedCommand { get; set; }
        public ICommand RegisterCommand { get; set; }


        public LoginViewModel()
        {
            IsLogin = false;

            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
            OpenRegisterWindowCommand = new RelayCommand<object>((p) => { return true; }, (p) =>{
                RegisterWindow wd = new RegisterWindow();
                wd.ShowDialog();    
            });
            RegisterPasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { RegisterPassWord = p.Password; });
            RegisterCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Register(p); });

        }

        void Login(Window p)
        {
            if (p == null)
                return;
            
            string pass = Password;
            var accCount = DataProvider.Instance.DB.Users.Any(x => x.username == UserName && x.password_hash == pass);

            if (accCount)
            {
                IsLogin = true;
                CurrentUser.Instance.CurrentUserName= UserName;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
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

            var user = new User
            {
                username = RegisterUserName,
                password_hash = RegisterPassWord,
                email = RegisterEmail,
                created_at = DateTime.Now,
            };

            DataProvider.Instance.DB.Users.Add(user);
            DataProvider.Instance.DB.SaveChanges();
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
    }
}
