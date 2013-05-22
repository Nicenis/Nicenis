/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.03
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Windows;

namespace Nicenis.Windows
{
    /// <summary>
    /// WindowState 의 확장 열거형.
    /// 전체 화면 모드를 추가로 포함한다.
    /// </summary>
    public enum WindowStateEx
    {
        /// <summary>
        /// 복원/일반
        /// </summary>
        Normal,

        /// <summary>
        /// 최소화
        /// </summary>
        Minimized,

        /// <summary>
        /// 최대화
        /// </summary>
        Maximized,

        /// <summary>
        /// 전체화면
        /// </summary>
        FullScreen,
    }


    #region WindowStateExExtensions

    /// <summary>
    /// WindowStateEx 확장 메서드
    /// </summary>
    public static class WindowStateExExtensions
    {
        /// <summary>
        /// WindowState 를 WindowStateEx 로 변환하여 반환한다.
        /// </summary>
        /// <param name="windowState">변환할 WindowState</param>
        /// <param name="isFullScreenMode">전체화면 모드인지 여부</param>
        /// <returns>변환된 WindowStateEx</returns>
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
        /// WindowStateEx 를 WindowState 로 변환하여 반환한다.
        /// </summary>
        /// <param name="windowStateEx">변환할 WindowStateEx</param>
        /// <returns>변환된 WindowState</returns>
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