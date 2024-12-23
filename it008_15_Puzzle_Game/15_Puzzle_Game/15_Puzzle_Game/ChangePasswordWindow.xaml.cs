using _15_Puzzle_Game.Model;
using _15_Puzzle_Game.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        string currPassword;
        string newPassword;
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(currPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                Status.Text = "Vui lòng nhập đầy đủ thông tin!";
                Status.Foreground = Brushes.Red;
                return;
            }

            var _user = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);

            if (_user.password_hash != LoginViewModel.sha256(currPassword))
            {
                Status.Text = "Mật khẩu không chính xác!";
                Status.Foreground = Brushes.Red;
                return;
            }

            if (currPassword == newPassword)
            {
                Status.Text = "Mật khẩu mới không được giống mật khẩu cũ!";
                Status.Foreground = Brushes.Red;
                return;
            }

            try
            {
                _user.password_hash = LoginViewModel.sha256(newPassword);
                DataProvider.Instance.DB.SaveChanges();
                Status.Text = "Đổi mật khẩu thành công!";
                Status.Foreground = Brushes.Green;
            }
            catch (Exception ex)
            {
                Status.Text = $"Đã xảy ra lỗi: {ex.Message}";
                Status.Foreground = Brushes.Red;
            }
        }

        private void CurrentPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            currPassword = CurrentPassword.Password;
        }

        private void NewPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            newPassword = NewPassword.Password;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            CurrPassWord.Text = CurrentPassword.Password;
            CurrentPassword.Visibility = Visibility.Collapsed;
            CurrPassWord.Visibility = Visibility.Visible;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CurrentPassword.Password = CurrPassWord.Text;
            CurrentPassword.Visibility = Visibility.Visible;
            CurrPassWord.Visibility = Visibility.Collapsed;
        }

        private void CurrPassWord_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            currPassword = CurrPassWord.Text;
        }

        private void NewPassWord_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            newPassword = NewPassWord.Text;
        }

        private void ToggleButton_Checked_1(object sender, RoutedEventArgs e)
        {
            NewPassWord.Text = NewPassword.Password;
            NewPassWord.Visibility = Visibility.Visible;
            NewPassword.Visibility = Visibility.Collapsed;
        }

        private void ToggleButton_Unchecked_1(object sender, RoutedEventArgs e)
        {
            NewPassword.Password = NewPassWord.Text;
            NewPassWord.Visibility = Visibility.Collapsed;
            NewPassword.Visibility = Visibility.Visible;
        }
    }
}