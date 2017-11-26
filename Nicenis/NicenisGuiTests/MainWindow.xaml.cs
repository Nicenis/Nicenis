/*
 * Author   JO Hyeong-Ryeol
 * Since    2017.10.15
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2017 JO Hyeong-Ryeol. All rights reserved.
 */

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NicenisGuiTests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, MainViewModel.ILogWriter
    {
        public MainWindow()
        {
            InitializeComponent();
            MainViewModel.Assert.SetLogWriter(this);
            DataContext = new MainViewModel();
        }

        public void AppendLogAsync(string log)
        {
            Dispatcher.InvokeAsync(() =>
            {
                logTextBox.Text += (log + "\r\n");
                logTextBox.ScrollToEnd();
            });
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ((MainViewModel)DataContext).RunAsync();
        }
    }
}
