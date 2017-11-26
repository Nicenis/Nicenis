/*
 * Author   JO Hyeong-Ryeol
 * Since    2017.10.15
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2017 JO Hyeong-Ryeol. All rights reserved.
 */

using NicenisGuiTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NicenisUwpGuiTests
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, MainViewModel.ILogWriter
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainViewModel.Assert.SetLogWriter(this);
            DataContext = new MainViewModel();
        }

        public async void AppendLogAsync(string log)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                logTextBox.Text += (log + "\r\n");
                //logTextBox.ScrollToEnd();
            });
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await ((MainViewModel)DataContext).RunAsync();
        }
    }
}
