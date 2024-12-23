using System.Windows;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockPassWord.Text = LoginPasswordBox.Password;
            LoginPasswordBox.Visibility = Visibility.Collapsed;
            TextBlockPassWord.Visibility = Visibility.Visible;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            LoginPasswordBox.Password = TextBlockPassWord.Text;
            LoginPasswordBox.Visibility = Visibility.Visible;
            TextBlockPassWord.Visibility = Visibility.Collapsed;
        }
    }
}
