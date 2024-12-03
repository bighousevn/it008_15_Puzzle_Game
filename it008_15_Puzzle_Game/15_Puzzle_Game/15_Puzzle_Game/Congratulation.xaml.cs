﻿using _15_Puzzle_Game.ViewModel;
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
    /// Interaction logic for Congratulation.xaml
    /// </summary>
    public partial class Congratulation : Window
    {
        public Congratulation()
        {
            InitializeComponent();
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.LoadXepHangData();
        }
    }
}
