/*
 * Author   JO Hyeong-Ryeol
 * Since    2019.01.23
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2019 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows.Data;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace NicenisTestGui.VolatileBindingTest
{
    /// <summary>
    /// This window is used to test the VolatileBindingExtension.
    /// </summary>
    public partial class VolatileBindingTestWindow : Window
    {
        public VolatileBindingTestWindow()
        {
            InitializeComponent();
            DataContext = new VolatileBindingTestViewModel();
        }

        private void VolatileBindingTestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"{nameof(VolatileBindingTestWindow)} [{nameof(Thread.CurrentThread.ManagedThreadId)}: {Thread.CurrentThread.ManagedThreadId}]";
        }

        CultureInfo _defaultCultureInfo;

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_defaultCultureInfo == null)
            {
                _defaultCultureInfo = Thread.CurrentThread.CurrentCulture;
            }

            var comboBox = (ComboBox)sender;
            switch (((ComboBoxItem)comboBox.SelectedValue).Content?.ToString())
            {
                case "Korean":
                    Thread.CurrentThread.CurrentCulture
                        = Thread.CurrentThread.CurrentUICulture
                        = new CultureInfo("ko");
                    break;

                case "German":
                    Thread.CurrentThread.CurrentCulture
                        = Thread.CurrentThread.CurrentUICulture
                        = new CultureInfo("de");
                    break;

                default:
                    Thread.CurrentThread.CurrentCulture
                        = Thread.CurrentThread.CurrentUICulture
                        = _defaultCultureInfo;
                    break;
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            VolatileBindingExtension.RefreshAsync();
        }

        private void RefreshAllButton_Click(object sender, RoutedEventArgs e)
        {
            VolatileBindingExtension.RefreshAllAsync();
        }
    }
}
