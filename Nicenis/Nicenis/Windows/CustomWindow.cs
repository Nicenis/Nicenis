/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.03
 * Version	$Id: CustomWindow.cs 24043 2013-05-21 14:49:03Z unknown $
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
    /// 사용자 지정 모습을 가지는 윈도를 위한 기반 클래스
    /// </summary>
    public class CustomWindow : Window
    {
        #region Constructors

        static CustomWindow()
        {
            WindowStyleProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(WindowStyle.None));
            AllowsTransparencyProperty.OverrideMetadata(typeof(CustomWindow), new FrameworkPropertyMetadata(true));
        }

        public CustomWindow()
        {
            // Initialize commands
            InitializeCommands();
        }

        #endregion


        #region Properties

        /// <summary>
        /// WindowState 에서 확장된 윈도 상태 Dependency Property
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
            // 변경된 WindowStateEx 적용
            ((CustomWindow)d).Apply((WindowStateEx)e.NewValue);
        }

        /// <summary>
        /// WindowState 에서 확장된 윈도 상태.
        /// 전체화면 모드를 추가로 지원한다.
        /// </summary>
        public WindowStateEx WindowStateEx
        {
            get { return (WindowStateEx)GetValue(WindowStateExProperty); }
            set { SetValue(WindowStateExProperty, value); }
        }


        /// <summary>
        /// 최소화 되었는지 여부 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey IsMinimizedPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsMinimized",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// 최소화 되었는지 여부 Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsMinimizedProperty = IsMinimizedPropertyKey.DependencyProperty;

        /// <summary>
        /// 최소화 되었는지 여부
        /// </summary>
        public bool IsMinimized
        {
            get { return (bool)GetValue(IsMinimizedProperty); }
            private set { SetValue(IsMinimizedPropertyKey, value); }
        }


        /// <summary>
        /// 일반 상태인지 여부 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey IsNormalPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsNormal",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(true)
        );

        /// <summary>
        /// 일반 상태인지 여부 Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsNormalProperty = IsNormalPropertyKey.DependencyProperty;

        /// <summary>
        /// 일반 상태인지 여부
        /// </summary>
        public bool IsNormal
        {
            get { return (bool)GetValue(IsNormalProperty); }
            private set { SetValue(IsNormalPropertyKey, value); }
        }


        /// <summary>
        /// 최대화 되었는지 여부 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey IsMaximizedPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsMaximized",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// 최대화 되었는지 여부 Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsMaximizedProperty = IsMaximizedPropertyKey.DependencyProperty;

        /// <summary>
        /// 최대화 되었는지 여부
        /// </summary>
        public bool IsMaximized
        {
            get { return (bool)GetValue(IsMaximizedProperty); }
            private set { SetValue(IsMaximizedPropertyKey, value); }
        }


        /// <summary>
        /// 전체화면인지 여부 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey IsFullScreenPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsFullScreen",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// 전체화면인지 여부 Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsFullScreenProperty = IsFullScreenPropertyKey.DependencyProperty;

        /// <summary>
        /// 전체화면인지 여부
        /// </summary>
        public bool IsFullScreen
        {
            get { return (bool)GetValue(IsFullScreenProperty); }
            private set { SetValue(IsFullScreenPropertyKey, value); }
        }


        /// <summary>
        /// 전체화면 모드인지 여부 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey IsFullScreenModePropertyKey = DependencyProperty.RegisterReadOnly
        (
            "IsFullScreenMode",
            typeof(bool),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// 전체화면 모드인지 여부 Dependency Property
        /// </summary>
        public static readonly DependencyProperty IsFullScreenModeProperty = IsFullScreenModePropertyKey.DependencyProperty;

        /// <summary>
        /// 전체화면 모드인지 여부.
        /// 이 값이 true 이면 최대화할 때 전체화면으로 표시된다.
        /// </summary>
        public bool IsFullScreenMode
        {
            get { return (bool)GetValue(IsFullScreenModeProperty); }
            private set { SetValue(IsFullScreenModePropertyKey, value); }
        }

        #endregion


        #region Commands

        #region InitializeCommands

        /// <summary>
        /// 커맨드 초기화 메서드
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
        /// 최소화 커맨드 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey MinimizeCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "MinimizeCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// 최소화 커맨드 Dependency Property
        /// </summary>
        public static readonly DependencyProperty MinimizeCommandProperty = MinimizeCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// 최소화 커맨드
        /// </summary>
        public ICommand MinimizeCommand
        {
            get { return (ICommand)GetValue(MinimizeCommandProperty); }
            private set { SetValue(MinimizeCommandPropertyKey, value); }
        }


        /// <summary>
        /// 복원 커맨드 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey RestoreCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "RestoreCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// 복원 커맨드 Dependency Property
        /// </summary>
        public static readonly DependencyProperty RestoreCommandProperty = RestoreCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// 복원 커맨드
        /// </summary>
        public ICommand RestoreCommand
        {
            get { return (ICommand)GetValue(RestoreCommandProperty); }
            private set { SetValue(RestoreCommandPropertyKey, value); }
        }


        /// <summary>
        /// 최대화 커맨드 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey MaximizeCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "MaximizeCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// 최대화 커맨드 Dependency Property
        /// </summary>
        public static readonly DependencyProperty MaximizeCommandProperty = MaximizeCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// 최대화 커맨드
        /// </summary>
        public ICommand MaximizeCommand
        {
            get { return (ICommand)GetValue(MaximizeCommandProperty); }
            private set { SetValue(MaximizeCommandPropertyKey, value); }
        }


        /// <summary>
        /// 전체화면 커맨드 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey FullScreenCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "FullScreenCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// 전체화면 커맨드 Dependency Property
        /// </summary>
        public static readonly DependencyProperty FullScreenCommandProperty = FullScreenCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// 전체화면 커맨드
        /// </summary>
        public ICommand FullScreenCommand
        {
            get { return (ICommand)GetValue(FullScreenCommandProperty); }
            private set { SetValue(FullScreenCommandPropertyKey, value); }
        }


        /// <summary>
        /// 닫기 커맨드 Dependency Property Key
        /// </summary>
        private static readonly DependencyPropertyKey CloseCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "CloseCommand",
            typeof(ICommand),
            typeof(CustomWindow),
            new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// 닫기 커맨드 Dependency Property
        /// </summary>
        public static readonly DependencyProperty CloseCommandProperty = CloseCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// 닫기 커맨드
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

            // Attaches window procedure.
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
