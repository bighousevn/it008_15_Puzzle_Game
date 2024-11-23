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
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        private App appInstance;
        private SelectLevelPage page;

        public SettingWindow()
        {
            InitializeComponent();
            appInstance = (App)Application.Current;
            page = new SelectLevelPage(); 
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (appInstance != null)
            {
                appInstance.AdjustVolume(e.NewValue);
            }
        }
    }
}
