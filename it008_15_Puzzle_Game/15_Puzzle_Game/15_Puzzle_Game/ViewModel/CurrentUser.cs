using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace _15_Puzzle_Game.ViewModel
{
    public class CurrentUser : BaseViewModel
    {
        private static CurrentUser _instance;
        public static CurrentUser Instance => _instance ?? (_instance = new CurrentUser());
        private string _currentUserName;
        public string CurrentUserName
        {
            get { return _currentUserName; }
            set { _currentUserName = value; OnPropertyChanged(); }
        }
        private string _currentLevelName;
        public string CurrentLevelName
        {
            get { return _currentLevelName; }
            set { _currentLevelName = value; OnPropertyChanged(); }
        }
        public string _currentImagePath;
        public string CurrentImagePath {
            get { return _currentImagePath; }
            set { _currentImagePath = value; OnPropertyChanged(); }
        }
        

    }
}
