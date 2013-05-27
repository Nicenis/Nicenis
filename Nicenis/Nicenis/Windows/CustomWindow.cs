/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.03
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Interop;
using Nicenis.Windows.Input;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Nicenis.Windows
{
    /// <summary>
    /// A base class for non-standard window.
    /// </summary>
    public class CustomWindow : Window
    {
        #region Constructors

        /// <summary>
        /// The static constructor.
        /// </summary>
        static CustomWindow()
        {
            WindowStyleProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(WindowStyle.None));
            AllowsTransparencyProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(true));
        }

        /// <summary>
        /// Initializes a new instance of the CustomWindow class.
        /// </summary>
        public CustomWindow()
        {
            // Initialize commands
            InitializeCommands();
        }

        #endregion


        #region Properties

        /// <summary>
        /// The dependency property for specifing the extended WindowState.
        /// </summary>
        public static readonly DependencyProperty WindowStateExProperty = DependencyProperty.Register
        (
            "WindowStateEx",
            typeof(WindowStateEx),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata
            (
                WindowStateEx.Normal,
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                WindowStateExProperty_Changed
            )
        );

        private static void WindowStateExProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Applies the changed WindowStateEx.
            ((CustomWindow)d).Apply((WindowStateEx)e.NewValue);
        }

        /// <summary>
        /// Gets or sets a value that specifies the extended WindowState.
        /// It supports full screen.
        /// </summary>
        public WindowStateEx WindowStateEx
        {
            get { return (WindowStateEx)GetValue(WindowStateExProperty); }
            set { SetValue(WindowStateExProperty, value); }
        }


        /// <summary>
        /// The dependency property key for indicating whether the window is minimized.
        /// </summary>
        private static readonly DependencyPropertyKey IsMinimizedPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsMinimized",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// The dependency property for indicating whether the window is minimized.
        /// </summary>
        public static readonly DependencyProperty IsMinimizedProperty = IsMinimizedPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the window is minimized.
        /// </summary>
        public bool IsMinimized
        {
            get { return (bool)GetValue(IsMinimizedProperty); }
            private set { SetValue(IsMinimizedPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for indicating whether the window is normal.
        /// </summary>
        private static readonly DependencyPropertyKey IsNormalPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsNormal",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(true)
        );

        /// <summary>
        /// The dependency property for indicating whether the window is normal.
        /// </summary>
        public static readonly DependencyProperty IsNormalProperty = IsNormalPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the window is normal.
        /// </summary>
        public bool IsNormal
        {
            get { return (bool)GetValue(IsNormalProperty); }
            private set { SetValue(IsNormalPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for indicating whether the window is maximized.
        /// </summary>
        private static readonly DependencyPropertyKey IsMaximizedPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsMaximized",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// The dependency property for indicating whether the window is maximized.
        /// </summary>
        public static readonly DependencyProperty IsMaximizedProperty = IsMaximizedPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the window is maximized.
        /// </summary>
        public bool IsMaximized
        {
            get { return (bool)GetValue(IsMaximizedProperty); }
            private set { SetValue(IsMaximizedPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for indicating whether the window is full screen.
        /// </summary>
        private static readonly DependencyPropertyKey IsFullScreenPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsFullScreen",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// The dependency property for indicating whether the window is full screen.
        /// </summary>
        public static readonly DependencyProperty IsFullScreenProperty = IsFullScreenPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the window is full screen.
        /// </summary>
        public bool IsFullScreen
        {
            get { return (bool)GetValue(IsFullScreenProperty); }
            private set { SetValue(IsFullScreenPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for indicating whether the window is in full screen mode.
        /// </summary>
        private static readonly DependencyPropertyKey IsFullScreenModePropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsFullScreenMode",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// The dependency property for indicating whether the window is in full screen mode.
        /// </summary>
        public static readonly DependencyProperty IsFullScreenModeProperty = IsFullScreenModePropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the window is in full screen mode.
        /// </summary>
        /// <remarks>
        /// This value indicates whether the window is full screen or not when it's WindowStateEx is not Maximized or FullScreen.
        /// This property is required to restore the full screen window from the minimized state.
        /// </remarks>
        public bool IsFullScreenMode
        {
            get { return (bool)GetValue(IsFullScreenModeProperty); }
            private set { SetValue(IsFullScreenModePropertyKey, value); }
        }

        #endregion


        #region Commands

        #region InitializeCommands

        /// <summary>
        /// Initializes the related commands.
        /// </summary>
        private void InitializeCommands()
        {
            MinimizeCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.Minimized, () => WindowStateEx != WindowStateEx.Minimized);
            RestoreCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.Normal, () => WindowStateEx != WindowStateEx.Normal);
            MaximizeCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.Maximized, () => WindowStateEx != WindowStateEx.Maximized);
            FullScreenCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.FullScreen, () => WindowStateEx != WindowStateEx.FullScreen);
            CloseCommand = new DelegateCommand(() => Close());
        }

        #endregion


        /// <summary>
        /// The dependency property key for the command that minimizes the window.
        /// </summary>
        private static readonly DependencyPropertyKey MinimizeCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "MinimizeCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that minimizes the window.
        /// </summary>
        public static readonly DependencyProperty MinimizeCommandProperty = MinimizeCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that minimizes the window.
        /// </summary>
        public ICommand MinimizeCommand
        {
            get { return (ICommand)GetValue(MinimizeCommandProperty); }
            private set { SetValue(MinimizeCommandPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for the command that restores the window.
        /// </summary>
        private static readonly DependencyPropertyKey RestoreCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "RestoreCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that restores the window.
        /// </summary>
        public static readonly DependencyProperty RestoreCommandProperty = RestoreCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that restores the window.
        /// </summary>
        public ICommand RestoreCommand
        {
            get { return (ICommand)GetValue(RestoreCommandProperty); }
            private set { SetValue(RestoreCommandPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for the command that maximizes the window.
        /// </summary>
        private static readonly DependencyPropertyKey MaximizeCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "MaximizeCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that maximizes the window.
        /// </summary>
        public static readonly DependencyProperty MaximizeCommandProperty = MaximizeCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that maximizes the window.
        /// </summary>
        public ICommand MaximizeCommand
        {
            get { return (ICommand)GetValue(MaximizeCommandProperty); }
            private set { SetValue(MaximizeCommandPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for the command that makes the window full screen.
        /// </summary>
        private static readonly DependencyPropertyKey FullScreenCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "FullScreenCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that makes the window full screen.
        /// </summary>
        public static readonly DependencyProperty FullScreenCommandProperty = FullScreenCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that makes the window full screen.
        /// </summary>
        public ICommand FullScreenCommand
        {
            get { return (ICommand)GetValue(FullScreenCommandProperty); }
            private set { SetValue(FullScreenCommandPropertyKey, value); }
        }


        /// <summary>
        /// The dependency property key for the command that closes the window.
        /// </summary>
        private static readonly DependencyPropertyKey CloseCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "CloseCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that closes the window.
        /// </summary>
        public static readonly DependencyProperty CloseCommandProperty = CloseCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that closes the window.
        /// </summary>
        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            private set { SetValue(CloseCommandPropertyKey, value); }
        }

        #endregion


        #region Event Handlers

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Attaches the window procedure.
            HwndSource.FromHwnd(new WindowInteropHelper(this).Handle).AddHook(WndProc);
        }

        protected override void OnInitialized(EventArgs e)
        {
            // WindowState 와 WindowStateEx 동기화
            Apply(WindowState.ToWindowStateEx(IsFullScreenMode));

            base.OnInitialized(e);
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);

            // 상태 변화 적용
            Apply(WindowState.ToWindowStateEx(IsFullScreenMode));
        }

        #endregion


        #region Window Procedure

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == Win32.WM_GETMINMAXINFO)
            {
                // 모니터 핸들 구하기
                IntPtr hMonitor = Win32.MonitorFromWindow(hwnd, Win32.MONITOR_DEFAULTTONEAREST);

                if (hMonitor != IntPtr.Zero)
                {
                    // 모니터 정보 구하기
                    Win32.MONITORINFO monitorInfo = Win32.MONITORINFO.Create();

                    if (Win32.GetMonitorInfo(hMonitor, ref monitorInfo) != 0)
                    {
                        // MINMAXINFO 구하기
                        Win32.MINMAXINFO minMaxInfo = (Win32.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Win32.MINMAXINFO));

                        if (IsFullScreenMode)
                        {
                            // 전체 화면 모드인 경우 모든 화면을 다 사용하도록 함
                            minMaxInfo.ptMaxPosition.x = monitorInfo.rcMonitor.left;
                            minMaxInfo.ptMaxPosition.y = monitorInfo.rcMonitor.top;
                            minMaxInfo.ptMaxSize.x = Math.Abs(monitorInfo.rcMonitor.right - monitorInfo.rcMonitor.left);
                            minMaxInfo.ptMaxSize.y = Math.Abs(monitorInfo.rcMonitor.bottom - monitorInfo.rcMonitor.top);
                        }
                        else
                        {
                            // 일반 모드인 경우 작업 영역을 사용하도록 함
                            minMaxInfo.ptMaxPosition.x = monitorInfo.rcWork.left;
                            minMaxInfo.ptMaxPosition.y = monitorInfo.rcWork.top;
                            minMaxInfo.ptMaxSize.x = Math.Abs(monitorInfo.rcWork.right - monitorInfo.rcWork.left);
                            minMaxInfo.ptMaxSize.y = Math.Abs(monitorInfo.rcWork.bottom - monitorInfo.rcWork.top);
                        }

                        // 수정된 MINMAXINFO 설정하기
                        Marshal.StructureToPtr(minMaxInfo, lParam, false);
                        handled = true;
                    }

                } // if (hMonitor != IntPtr.Zero)

            } // if (msg == Win32.WM_GETMINMAXINFO)

            return IntPtr.Zero;
        }

        #endregion


        #region Helpers

        /// <summary>
        /// 현재 적용 중인 WindowStateEx 값
        /// </summary>
        WindowStateEx? _appliedWindowStateEx;

        /// <summary>
        /// windowStateEx 로 지정된 윈도 상태를 적용한다.
        /// </summary>
        /// <param name="windowStateEx">적용할 WindowStateEx</param>
        private void Apply(WindowStateEx windowStateEx)
        {
            // 이미 적용되었다면
            if (_appliedWindowStateEx == windowStateEx)
                return;

            // StateExChanged 이벤트를 발생시켜야 하는지 여부
            // 윈도 표시 당시의 초기값인 경우에는 이벤트를 발생시키지 않는다. (StateChanged 도 발생 안함)
            bool isRequiredToRaiseStateExChanged = _appliedWindowStateEx != null;

            // 현재 적용값 갱신
            WindowStateEx oldWindowStateEx = _appliedWindowStateEx ?? WindowStateEx.Normal;
            _appliedWindowStateEx = windowStateEx;

            // 전체화면 모드 설정
            switch (windowStateEx)
            {
                case WindowStateEx.Normal:
                case WindowStateEx.Maximized:
                    IsFullScreenMode = false;
                    break;

                case WindowStateEx.FullScreen:
                    IsFullScreenMode = true;
                    break;
            }

            // WindowStateEx 설정
            WindowStateEx = windowStateEx;

            // WindowState 설정
            WindowState = windowStateEx.ToWindowState();

            // 최대화 -> 전체화면 이거나 전체화면 -> 최대화라면 제대로 크기 조정이 되도록 감췄다 다시 표시한다.
            if ((oldWindowStateEx == WindowStateEx.Maximized && windowStateEx == WindowStateEx.FullScreen)
                || (oldWindowStateEx == WindowStateEx.FullScreen && windowStateEx == WindowStateEx.Maximized))
            {
                Visibility = Visibility.Collapsed;
                Visibility = Visibility.Visible;
            }

            // 관련 속성 갱신
            IsMinimized = WindowStateEx == WindowStateEx.Minimized;
            IsNormal = WindowStateEx == WindowStateEx.Normal;
            IsMaximized = WindowStateEx == WindowStateEx.Maximized;
            IsFullScreen = WindowStateEx == WindowStateEx.FullScreen;

            // 이벤트 발생
            if (isRequiredToRaiseStateExChanged)
                OnStateExChanged(oldWindowStateEx, windowStateEx);
        }

        #endregion


        #region StateExChanged

        #region StateExChangedEventArgs

        /// <summary>
        /// StateExChanged 이벤트 인자
        /// </summary>
        public class StateExChangedEventArgs : EventArgs
        {
            #region Constructors

            /// <summary>
            /// StateExChangedEventArgs 를 생성한다.
            /// </summary>
            /// <param name="oldValue">변경 전 WindowStateEx</param>
            /// <param name="newValue">변경 후 WindowStateEx</param>
            public StateExChangedEventArgs(WindowStateEx oldValue, WindowStateEx newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }

            #endregion


            #region Properties

            /// <summary>
            /// 변경 전 WindowStateEx
            /// </summary>
            public WindowStateEx OldValue { get; private set; }

            /// <summary>
            /// 변경 후 WindowStateEx
            /// </summary>
            public WindowStateEx NewValue { get; private set; }

            #endregion
        }

        #endregion


        /// <summary>
        /// WindowStateEx 가 변경될 경우 발생하는 이벤트
        /// </summary>
        public event EventHandler<StateExChangedEventArgs> StateExChanged;

        protected virtual void OnStateExChanged(WindowStateEx oldValue, WindowStateEx newValue)
        {
            if (StateExChanged != null)
                StateExChanged(this, new StateExChangedEventArgs(oldValue, newValue));
        }

        #endregion


        #region Attached Behaviors

        /// <summary>
        /// Sets as a window icon.
        /// It shows the system menu when mouse left button is down, mouse right button is up.
        /// It closes window when mouse is double clicked.
        /// </summary>
        public static readonly DependencyProperty IsWindowIconProperty = DependencyProperty.RegisterAttached
        (
            "IsWindowIcon",
            typeof(bool),
            typeof(CustomWindow),
            new PropertyMetadata(false, IsWindowIcon_Changed)
        );

        private static void IsWindowIcon_Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)o;

            element.MouseLeftButtonDown -= IsWindowIcon_Element_MouseLeftButtonDown;
            element.MouseRightButtonUp -= IsWindowIcon_Element_MouseRightButtonUp;

            if ((bool)e.NewValue)
            {
                element.MouseLeftButtonDown += IsWindowIcon_Element_MouseLeftButtonDown;
                element.MouseRightButtonUp += IsWindowIcon_Element_MouseRightButtonUp;
            }
        }

        static void IsWindowIcon_Element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = sender as Window;

            if (window == null)
                window = ((DependencyObject)sender).VisualAncestors().OfType<Window>().FirstOrDefault();

            if (window == null)
                return;

            if (e.ClickCount <= 1)
            {
                // Displays the system menu.
                FrameworkElement frameworkElement = (FrameworkElement)sender;
                window.ShowSystemMenu(frameworkElement.PointToScreen(new Point(0, frameworkElement.ActualHeight)));
                return;
            }

            // Close the window.
            window.Close();
        }

        static void IsWindowIcon_Element_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = sender as Window;

            if (window == null)
                window = ((DependencyObject)sender).VisualAncestors().OfType<Window>().FirstOrDefault();

            if (window == null)
                return;

            // Displays the system menu.
            window.ShowSystemMenu(window.PointToScreen(e.GetPosition(window)));
        }

        public static bool GetIsWindowIcon(FrameworkElement element)
        {
            return (bool)element.GetValue(IsWindowIconProperty);
        }

        public static void SetIsWindowIcon(FrameworkElement element, bool IsWindowIcon)
        {
            element.SetValue(IsWindowIconProperty, IsWindowIcon);
        }


        /// <summary>
        /// Shows System menu when mouse right button is up.
        /// </summary>
        public static readonly DependencyProperty IsSystemContextMenuEnabledProperty = DependencyProperty.RegisterAttached
        (
            "IsSystemContextMenuEnabled",
            typeof(bool),
            typeof(CustomWindow),
            new PropertyMetadata(false, IsSystemContextMenuEnabled_Changed)
        );

        private static void IsSystemContextMenuEnabled_Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)o;

            element.MouseRightButtonUp -= IsSystemContextMenuEnabled_Element_MouseRightButtonUp;

            if ((bool)e.NewValue)
                element.MouseRightButtonUp += IsSystemContextMenuEnabled_Element_MouseRightButtonUp;
        }

        static void IsSystemContextMenuEnabled_Element_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = sender as Window;

            if (window == null)
                window = ((DependencyObject)sender).VisualAncestors().OfType<Window>().FirstOrDefault();

            if (window == null)
                return;

            // Displays the system menu.
            window.ShowSystemMenu(window.PointToScreen(e.GetPosition(window)));
        }

        public static bool GetIsSystemContextMenuEnabled(UIElement element)
        {
            return (bool)element.GetValue(IsSystemContextMenuEnabledProperty);
        }

        public static void SetIsSystemContextMenuEnabled(UIElement element, bool isSystemContextMenuEnabled)
        {
            element.SetValue(IsSystemContextMenuEnabledProperty, isSystemContextMenuEnabled);
        }

        #endregion
    }
}
