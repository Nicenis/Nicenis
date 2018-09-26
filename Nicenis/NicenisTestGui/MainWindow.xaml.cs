/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.03.26
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System.Threading;
using System.Windows;

namespace NicenisTestGui
{
    /// <summary>
    /// The main window for the RyeolCore Test GUI.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateDragMoverTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new DragMoverTestWindow
            {
                Owner = this
            };

            window.Show();
        }

        private void CreateDragResizerTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new DragResizerTestWindow
            {
                Owner = this
            };

            window.Show();
        }

        private void CreateDragSourceNDropTargetTestWindow_Click(object sender, RoutedEventArgs e)
        {
            var window = new DragSourceNDropTargetTestWindow
            {
                Owner = this
            };

            window.Show();
        }

        private void CreateHoverTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new HoverTestWindow
            {
                Owner = this
            };

            window.Show();
        }

        private void CreateCustomWindowTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new CustomWindowTestWindow
            {
                Owner = this
            };

            window.Show();
        }

        private void CreateLocalStringTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                var thread = new Thread(() =>
                {
                    var window = new LocalStringTestWindow();
                    window.Closed += (_, __) => window.Dispatcher.InvokeShutdown();
                    window.Show();
                    System.Windows.Threading.Dispatcher.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }
    }
}
