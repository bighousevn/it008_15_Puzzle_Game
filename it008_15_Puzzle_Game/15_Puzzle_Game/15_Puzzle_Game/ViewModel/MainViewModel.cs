using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _15_Puzzle_Game.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand PauseCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public event Action RequestClose;

        public MainViewModel()
        {
            PauseCommand = new RelayCommand<object>((p) => { return true; }, (p) => { 
                PauseWindow wd = new PauseWindow();
                wd.ShowDialog();
            });

            SettingCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                SettingWindow wd = new SettingWindow();
                wd.ShowDialog();
            });

            CloseWindowCommand = new RelayCommand<object>((p) => { return true; }, p => CloseWindow(p));
        }

        private void CloseWindow(object parameter) 
        {
            if (parameter is Window window)
                window.Close();
        }

    }
}
