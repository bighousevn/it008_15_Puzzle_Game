using _15_Puzzle_Game.Model;
using _15_Puzzle_Game.ViewModel;
using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Interaction logic for ForgotPasswordWindow.xaml
    /// </summary>
    public partial class ForgotPasswordWindow : Window
    {
        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string _Email = EmailTextBox.Text;
            if ( string.IsNullOrEmpty(_Email))
            {
                Status.Text = "Vui lòng nhập UserName và Email";
                Status.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }
            var _user = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.email == EmailTextBox.Text);
            if (_user == null)
            {
                Status.Text = "Tên người dùng và địa chỉ email không hợp lệ";
                Status.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }
            string newPassword = GenerateRandomCode();
            bool isSent= SendNewPassword(_Email, newPassword);
            if (isSent)
            {
                _user.password_hash = LoginViewModel.sha256(newPassword);
                DataProvider.Instance.DB.SaveChanges();
                Status.Text = $"Email chứa mật khẩu mới đã được gửi tới {_Email}.";
                Status.Foreground = System.Windows.Media.Brushes.Green;
            }
            else
            {
                Status.Text = "Không thể gửi email. Vui lòng kiểm tra lại.";
                Status.Foreground = System.Windows.Media.Brushes.Red;
            }
        }
        private string GenerateRandomCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
        private bool SendNewPassword(string toEmail, string newPassword)
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
                    Subject = "Bạn đã khôi phục mật khẩu thành công! ",
                    Body = $"Mật khẩu mới của bạn là: {newPassword}",
                    IsBodyHtml = true,
                };
                mail.To.Add(toEmail);
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi gửi email", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
