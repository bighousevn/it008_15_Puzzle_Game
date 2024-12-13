using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Puzzle_Game.ViewModel
{
    public class Stage : BaseViewModel
    {
        private int _Manchoi;
        public int Manchoi { get { return _Manchoi; } set { _Manchoi = value; OnPropertyChanged(); } }
        private bool _unlock;
        public bool UnLock { get { return _unlock; } set { _unlock = value; OnPropertyChanged(); } }
    }
}

