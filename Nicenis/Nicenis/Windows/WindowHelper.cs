/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.27
 * Version	$Id: WindowHelper.cs 24043 2013-05-21 14:49:03Z unknown $
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Interop;
using System;
using System.Windows;
using System.Windows.Interop;

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides functionalities for Window.
    /// </summary>
    public static class WindowHelper
    {
        /// <summary>
        /// Displays the system menu for the specified window.
        /// </summary>
        /// <param name="window">The window to have its system menu displayed.</param>
        /// <param name="screenLocation">The location of the system menu.</param>
        public static void ShowSystemMenu(this Window window, Point screenLocation)
        {
            if (window == null)
                throw new ArgumentNullException("window");


            // Gets the PresentationSource from the window.
            PresentationSource presentationSource = PresentationSource.FromVisual(window);
            if (presentationSource == null)
                return;

            // Gets the location in device coordinate.
            Point deviceScreenLocation = presentationSource.CompositionTarget.TransformToDevice.Transform(screenLocation);

            // Gets the window handle.
            IntPtr hWnd = new WindowInteropHelper(window).Handle;

            // Gets the system menu handle.
            IntPtr hMenu = Win32.GetSystemMenu(hWnd, false);


            // Displays the system menu.
            int menuItemId = Win32.TrackPopupMenuEx
            (
                hMenu,
                Win32.TPM_NONOTIFY | Win32.TPM_RETURNCMD | Win32.TPM_RIGHTBUTTON,
                (int)deviceScreenLocation.X,
                (int)deviceScreenLocation.Y,
                hWnd,
                IntPtr.Zero
            );

            // If user does not select any menu or an error occurs
            if (menuItemId == 0)
                return;

            // Posts a WM_SYSCOMMAND message.
            Win32.PostMessage(hWnd, Win32.WM_SYSCOMMAND, (IntPtr)menuItemId, IntPtr.Zero);
        }
    }
}
