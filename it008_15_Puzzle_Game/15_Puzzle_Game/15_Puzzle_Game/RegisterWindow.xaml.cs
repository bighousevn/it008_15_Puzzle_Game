using System.Windows;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            TextBlockPassWord.Text = RegisterPasswordBox.Password;
            RegisterPasswordBox.Visibility = Visibility.Collapsed;
            TextBlockPassWord.Visibility = Visibility.Visible;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RegisterPasswordBox.Password = TextBlockPassWord.Text;
            RegisterPasswordBox.Visibility = Visibility.Visible;
            TextBlockPassWord.Visibility = Visibility.Collapsed;
        }
    }
}
