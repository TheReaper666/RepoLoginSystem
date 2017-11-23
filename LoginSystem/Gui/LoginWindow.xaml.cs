﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bizz;

namespace Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BizzFunctions UsableBizz;
        public MainWindow()
        {
            InitializeComponent();
            UsableBizz = new BizzFunctions();
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            UsableBizz.CheckCredentials(textBoxUsername.Text, textBoxPassword.Text);
        }
    }
}
