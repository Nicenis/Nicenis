/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.04.28
 * Version	$Id: HoverTestWindow.xaml.cs 24043 2013-05-21 14:49:03Z unknown $
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Diagnostics;
using System.Windows;

namespace NicenisTestGui
{
    /// <summary>
    /// Interaction logic for HoverTestWindow.xaml
    /// </summary>
    public partial class HoverTestWindow : Window
    {
        public HoverTestWindow()
        {
            InitializeComponent();
        }

        private void Border_PreviewHover(object sender, Nicenis.Windows.HoverEventArgs e)
        {
            Debug.WriteLine("Border_PreviewHover: " + e.BasePosition + " " + e.BaseTicks + " " + e.HoveredPosition + " " + e.HoveredTicks);
        }

        private void Border_Hover(object sender, Nicenis.Windows.HoverEventArgs e)
        {
            Debug.WriteLine("Border_Hover");
        }
    }
}
