/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.11.27
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Diagnostics;
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
        /// <param name="locationInScreen">The location of the system menu in screen coordination.</param>
        public static void ShowSystemMenu(this Window window, Point locationInScreen)
        {
            Verify.ParameterIsNotNull(window, "window");

            // Gets the window handle.
            IntPtr hWnd = new WindowInteropHelper(window).Handle;

            // Gets the system menu handle.
            IntPtr hMenu = Win32.GetSystemMenu(hWnd, false);

            // Displays the system menu.
            int menuItemId = Win32.TrackPopupMenuEx
            (
                hMenu,
                Win32.TPM_NONOTIFY | Win32.TPM_RETURNCMD | Win32.TPM_RIGHTBUTTON,
                (int)locationInScreen.X,
                (int)locationInScreen.Y,
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
