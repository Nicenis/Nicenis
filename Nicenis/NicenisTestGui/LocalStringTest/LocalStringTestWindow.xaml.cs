/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.09.15
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2018 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows.Data;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace NicenisTestGui.LocalStringTest
{
    /// <summary>
    /// This window is used to test the LocalStringExtension.
    /// </summary>
    public partial class LocalStringTestWindow : Window
    {
        public LocalStringTestWindow()
        {
            InitializeComponent();
        }

        private void LocalStringTestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"{nameof(LocalStringTestWindow)} [{nameof(Thread.CurrentThread.ManagedThreadId)}: {Thread.CurrentThread.ManagedThreadId}]";
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
            LocalStringExtension.RefreshAsync();
        }

        private void RefreshAllButton_Click(object sender, RoutedEventArgs e)
        {
            LocalStringExtension.RefreshAllAsync();
        }
    }
}
