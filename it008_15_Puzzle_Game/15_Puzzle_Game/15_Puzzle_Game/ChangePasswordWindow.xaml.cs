using _15_Puzzle_Game.Model;
using _15_Puzzle_Game.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CurrentPassword.Text) || string.IsNullOrWhiteSpace(NewPassword.Text))
            {
                Status.Text = "Vui lòng nhập đầy đủ thông tin!";
                Status.Foreground = Brushes.Red;
                return;
            }

            var _user = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);

            if (_user.password_hash != LoginViewModel.sha256(CurrentPassword.Text))
            {
                Status.Text = "Mật khẩu không chính xác!";
                Status.Foreground = Brushes.Red;
                return;
            }

            if (CurrentPassword.Text == NewPassword.Text)
            {
                Status.Text = "Mật khẩu mới không được giống mật khẩu cũ!";
                Status.Foreground = Brushes.Red;
                return;
            }

            try
            {
                _user.password_hash = LoginViewModel.sha256(NewPassword.Text);
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
    }
}