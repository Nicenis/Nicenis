/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.11.03
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Windows;

namespace Nicenis.Windows
{
    /// <summary>
    /// The extended WindowState which contains the full screen mode.
    /// </summary>
    public enum WindowStateEx
    {
        /// <summary>
        /// Window is normal or restored.
        /// </summary>
        Normal,

        /// <summary>
        /// Window is minimized.
        /// </summary>
        Minimized,

        /// <summary>
        /// Window is maximized.
        /// </summary>
        Maximized,

        /// <summary>
        /// Window is in full screen mode.
        /// </summary>
        FullScreen,
    }


    #region WindowStateExHelper

    /// <summary>
    /// Provides WindowStateEx related utility methods.
    /// </summary>
    public static class WindowStateExHelper
    {
        /// <summary>
        /// Converts a WindowState enumeration to a WindowStateEx enumeration.
        /// </summary>
        /// <param name="windowState">A WindowState.</param>
        /// <param name="isFullScreenMode">Whether it is in full screen mode.</param>
        /// <returns>The converted  WindowStateEx.</returns>
        public static WindowStateEx ToWindowStateEx(this WindowState windowState, bool isFullScreenMode)
        {
            switch (windowState)
            {
                case WindowState.Normal:
                    return WindowStateEx.Normal;

                case WindowState.Minimized:
                    return WindowStateEx.Minimized;

                case WindowState.Maximized:
                    return isFullScreenMode ? WindowStateEx.FullScreen : WindowStateEx.Maximized;
            }

            throw new InvalidOperationException(string.Format("The WindowState {0} is unknown.", windowState));
        }

        /// <summary>
        /// Converts a WindowStateEx enumeration to a WindowState enumeration.
        /// </summary>
        /// <param name="windowStateEx">A WindowStateEx.</param>
        /// <returns>The converted  WindowState.</returns>
        public static WindowState ToWindowState(this WindowStateEx windowStateEx)
        {
            switch (windowStateEx)
            {
                case WindowStateEx.Normal:
                    return WindowState.Normal;

                case WindowStateEx.Minimized:
                    return WindowState.Minimized;

                case WindowStateEx.Maximized:
                case WindowStateEx.FullScreen:
                    return WindowState.Maximized;
            }

            throw new InvalidOperationException(string.Format("The WindowStateEx {0} is unknown.", windowStateEx));
        }
    }

    #endregion
}