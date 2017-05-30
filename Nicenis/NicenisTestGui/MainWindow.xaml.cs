/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.03.26
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

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
            DragMoverTestWindow window = new DragMoverTestWindow();
            window.Owner = this;

            window.Show();
        }

        private void CreateDragResizerTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            DragResizerTestWindow window = new DragResizerTestWindow();
            window.Owner = this;

            window.Show();
        }

        private void CreateDragSourceNDropTargetTestWindow_Click(object sender, RoutedEventArgs e)
        {
            DragSourceNDropTargetTestWindow window = new DragSourceNDropTargetTestWindow();
            window.Owner = this;

            window.Show();
        }

        private void CreateHoverTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            HoverTestWindow window = new HoverTestWindow();
            window.Owner = this;

            window.Show();
        }

        private void CreateCustomWindowTestWindowButton_Click(object sender, RoutedEventArgs e)
        {
            CustomWindowTestWindow window = new CustomWindowTestWindow();
            window.Owner = this;

            window.Show();
        }
    }
}
