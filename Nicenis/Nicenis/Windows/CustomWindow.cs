﻿/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.11.03
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
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
    #region CustomWindowStateExChangedEventArgs

    /// <summary>
    /// The event arguments for the StateExChanged event.
    /// </summary>
    [Obsolete]
    public class CustomWindowStateExChangedEventArgs : EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the StateExChangedEventArgs class.
        /// </summary>
        /// <param name="oldValue">The WindowStateEx before the change.</param>
        /// <param name="newValue">The WindowStateEx after the change.</param>
        internal CustomWindowStateExChangedEventArgs(WindowStateEx oldValue, WindowStateEx newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets the WindowStateEx before the change.
        /// </summary>
        public WindowStateEx OldValue { get; private set; }

        /// <summary>
        /// Gets the WindowStateEx after the change.
        /// </summary>
        public WindowStateEx NewValue { get; private set; }

        #endregion
    }

    #endregion


    /// <summary>
    /// A base class for non-standard window.
    /// </summary>
    [Obsolete]
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
            MinimizeCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.Minimized, () => WindowStateEx != WindowStateEx.Minimized, isAutomaticRequeryDisabled: true);
            ToggleMinimizedCommand = new DelegateCommand(ToggleMinimized, CanToggleMinimized, isAutomaticRequeryDisabled: true);
            RestoreCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.Normal, () => WindowStateEx != WindowStateEx.Normal, isAutomaticRequeryDisabled: true);
            MaximizeCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.Maximized, () => WindowStateEx != WindowStateEx.Maximized, isAutomaticRequeryDisabled: true);
            ToggleMaximizedCommand = new DelegateCommand(ToggleMaximized, CanToggleMaximized, isAutomaticRequeryDisabled: true);
            FullScreenCommand = new DelegateCommand(() => WindowStateEx = WindowStateEx.FullScreen, () => WindowStateEx != WindowStateEx.FullScreen, isAutomaticRequeryDisabled: true);
            ToggleFullScreenCommand = new DelegateCommand(ToggleFullScreen, CanToggleFullScreen, isAutomaticRequeryDisabled: true);
            CloseCommand = new DelegateCommand(() => Close(), null, isAutomaticRequeryDisabled: true);
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


        static readonly DependencyPropertyKey ToggleMinimizedCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            name: nameof(ToggleMinimizedCommand),
            propertyType: typeof(ICommand),
            ownerType: typeof(CustomWindow),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that toggles window minimization.
        /// </summary>
        public static readonly DependencyProperty ToggleMinimizedCommandProperty = ToggleMinimizedCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that toggles window minimization.
        /// </summary>
        public ICommand ToggleMinimizedCommand
        {
            get { return (ICommand)GetValue(ToggleMinimizedCommandProperty); }
            private set { SetValue(ToggleMinimizedCommandPropertyKey, value); }
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


        static readonly DependencyPropertyKey ToggleMaximizedCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            name: nameof(ToggleMaximizedCommand),
            propertyType: typeof(ICommand),
            ownerType: typeof(CustomWindow),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that toggles window maximization.
        /// </summary>
        public static readonly DependencyProperty ToggleMaximizedCommandProperty = ToggleMaximizedCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that toggles window maximization.
        /// </summary>
        public ICommand ToggleMaximizedCommand
        {
            get { return (ICommand)GetValue(ToggleMaximizedCommandProperty); }
            private set { SetValue(ToggleMaximizedCommandPropertyKey, value); }
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


        static readonly DependencyPropertyKey ToggleFullScreenCommandPropertyKey = DependencyProperty.RegisterReadOnly
        (
            name: nameof(ToggleFullScreenCommand),
            propertyType: typeof(ICommand),
            ownerType: typeof(CustomWindow),
            typeMetadata: new FrameworkPropertyMetadata(null)
        );

        /// <summary>
        /// The dependency property for the command that toggles full screen window.
        /// </summary>
        public static readonly DependencyProperty ToggleFullScreenCommandProperty = ToggleFullScreenCommandPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a command that toggles full screen window.
        /// </summary>
        public ICommand ToggleFullScreenCommand
        {
            get { return (ICommand)GetValue(ToggleFullScreenCommandProperty); }
            private set { SetValue(ToggleFullScreenCommandPropertyKey, value); }
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

        /// <summary>
        /// Raises the SourceInitialized event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            // Attaches the window procedure.
            HwndSource.FromHwnd(new WindowInteropHelper(this).Handle).AddHook(WndProc);
        }

        /// <summary>
        /// Raises the Initialized event. This method is invoked whenever IsInitialized is set to true internally. 
        /// </summary>
        /// <param name="e">The RoutedEventArgs that contains the event data.</param>
        protected override void OnInitialized(EventArgs e)
        {
            // Sets the WindowStateEx based on the WindowState.
            Apply(WindowState.ToWindowStateEx(IsFullScreenMode));

            base.OnInitialized(e);
        }

        /// <summary>
        /// Raises the StateChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);

            // Sets the WindowStateEx based on the WindowState.
            Apply(WindowState.ToWindowStateEx(IsFullScreenMode));
        }

        #endregion


        #region Window Procedure

        private static void SetMinMaxInfo(IntPtr lParam, int maxPositionX, int maxPositionY, int maxSizeX, int maxSizeY, bool setMaxTrackSize = false)
        {
            // Gets the MINMAXINFO.
            var minMaxInfo = (Win32.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Win32.MINMAXINFO));

            minMaxInfo.ptMaxPosition.x = maxPositionX;
            minMaxInfo.ptMaxPosition.y = maxPositionY;
            minMaxInfo.ptMaxSize.x = maxSizeX;
            minMaxInfo.ptMaxSize.y = maxSizeY;

            if (setMaxTrackSize)
            {
                minMaxInfo.ptMaxTrackSize.x = maxSizeX;
                minMaxInfo.ptMaxTrackSize.y = maxSizeY;
            }

            // Sets the modified MINMAXINFO.
            Marshal.StructureToPtr(minMaxInfo, lParam, false);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == Win32.WM_GETMINMAXINFO)
            {
                // Gets the primary monitor handle.
                IntPtr hPrimaryMonitor = Win32.MonitorFromPoint(new Win32.POINT(), Win32.MONITOR_DEFAULTTOPRIMARY);

                if (hPrimaryMonitor != IntPtr.Zero)
                {
                    // Gets the primary monitor information.
                    Win32.MONITORINFO primaryMonitorInfo = Win32.MONITORINFO.Create();

                    if (Win32.GetMonitorInfo(hPrimaryMonitor, ref primaryMonitorInfo) != 0)
                    {
                        if (IsFullScreenMode || WindowState == WindowState.Normal)
                        {
                            SetMinMaxInfo
                            (
                                lParam: lParam,
                                maxPositionX: primaryMonitorInfo.rcMonitor.left,
                                maxPositionY: primaryMonitorInfo.rcMonitor.top,
                                maxSizeX: primaryMonitorInfo.rcMonitor.right - primaryMonitorInfo.rcMonitor.left,
                                maxSizeY: primaryMonitorInfo.rcMonitor.bottom - primaryMonitorInfo.rcMonitor.top
                            );
                            handled = true;
                        }
                        else
                        {
                            // Get the monitor handle.
                            IntPtr hMonitor = Win32.MonitorFromWindow(hwnd, Win32.MONITOR_DEFAULTTONEAREST);

                            if (hMonitor != IntPtr.Zero)
                            {
                                if (hMonitor == hPrimaryMonitor)
                                {
                                    SetMinMaxInfo
                                    (
                                        lParam: lParam,
                                        maxPositionX: primaryMonitorInfo.rcWork.left,
                                        maxPositionY: primaryMonitorInfo.rcWork.top,
                                        maxSizeX: primaryMonitorInfo.rcWork.right - primaryMonitorInfo.rcWork.left,
                                        maxSizeY: primaryMonitorInfo.rcWork.bottom - primaryMonitorInfo.rcWork.top
                                    );
                                    handled = true;
                                }
                                else
                                {
                                    // Gets monitor information.
                                    Win32.MONITORINFO monitorInfo = Win32.MONITORINFO.Create();

                                    if (Win32.GetMonitorInfo(hMonitor, ref monitorInfo) != 0)
                                    {
                                        SetMinMaxInfo
                                        (
                                            lParam: lParam,
                                            maxPositionX: monitorInfo.rcWork.left - monitorInfo.rcMonitor.left,
                                            maxPositionY: monitorInfo.rcWork.top - monitorInfo.rcMonitor.top,
                                            maxSizeX: monitorInfo.rcWork.right - monitorInfo.rcWork.left,
                                            maxSizeY: monitorInfo.rcWork.bottom - monitorInfo.rcWork.top,
                                            setMaxTrackSize: true
                                        );
                                        handled = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return IntPtr.Zero;
        }

        #endregion


        #region Helpers

        /// <summary>
        /// The WindowStateEx that was in effect.
        /// </summary>
        WindowStateEx _oldWindowStateEx;

        /// <summary>
        /// The WindowStateEx that is in effect.
        /// </summary>
        WindowStateEx? _appliedWindowStateEx;

        /// <summary>
        /// Applies the specified windowStateEx to the window.
        /// </summary>
        /// <param name="windowStateEx">The WindowStateEx to apply.</param>
        private void Apply(WindowStateEx windowStateEx)
        {
            // If it is already applied.
            if (_appliedWindowStateEx == windowStateEx)
                return;

            // Whether the StateExChanged event is raised or not.
            // If it is the initialization, it should not raise the StateExChanged event. (StateChanged is not raised too.)
            bool isRequiredToRaiseStateExChanged = _appliedWindowStateEx != null;

            // Sets the applied WindowStateEx.
            _oldWindowStateEx = _appliedWindowStateEx ?? WindowStateEx.Normal;
            _appliedWindowStateEx = windowStateEx;

            // Sets the IsFullScreenMode to true if the WindowStateEx is FullScreen.
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

            // Sets the WindowStateEx.
            WindowStateEx = windowStateEx;

            // Sets the WindowState.
            WindowState = windowStateEx.ToWindowState();

            // If it is Maximized -> Full Screen or Full Screen -> Maximized, hides and shows the window to corrent the size.
            if ((_oldWindowStateEx == WindowStateEx.Maximized && windowStateEx == WindowStateEx.FullScreen)
                || (_oldWindowStateEx == WindowStateEx.FullScreen && windowStateEx == WindowStateEx.Maximized))
            {
                Visibility = Visibility.Collapsed;
                Visibility = Visibility.Visible;
            }

            // Updates the WindowStateEx relate properties.
            IsMinimized = WindowStateEx == WindowStateEx.Minimized;
            IsNormal = WindowStateEx == WindowStateEx.Normal;
            IsMaximized = WindowStateEx == WindowStateEx.Maximized;
            IsFullScreen = WindowStateEx == WindowStateEx.FullScreen;

            ((DelegateCommand)MinimizeCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)ToggleMinimizedCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)RestoreCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)MaximizeCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)ToggleMaximizedCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)FullScreenCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)ToggleFullScreenCommand).RaiseCanExecuteChanged();
            ((DelegateCommand)CloseCommand).RaiseCanExecuteChanged();

            // If it is required to raise the StateExChanged event, raises the StateExChanged event.
            if (isRequiredToRaiseStateExChanged)
#pragma warning disable CS0612 // Type or member is obsolete
                OnStateExChanged(new CustomWindowStateExChangedEventArgs(_oldWindowStateEx, windowStateEx));
#pragma warning restore CS0612 // Type or member is obsolete
        }

        private bool CanToggleMinimized()
        {
            return true;
        }

        private void ToggleMinimized()
        {
            if (CanToggleMinimized() == false)
                return;

            switch (WindowStateEx)
            {
                case WindowStateEx.Minimized:
                    WindowStateEx = _oldWindowStateEx != WindowStateEx.Minimized
                                  ? _oldWindowStateEx
                                  : WindowStateEx.Normal;
                    break;

                default:
                    WindowStateEx = WindowStateEx.Minimized;
                    break;
            }
        }

        private bool CanToggleMaximized()
        {
            return true;
        }

        private void ToggleMaximized()
        {
            if (CanToggleMaximized() == false)
                return;

            switch (WindowStateEx)
            {
                case WindowStateEx.Maximized:
                    switch (_oldWindowStateEx)
                    {
                        case WindowStateEx.Minimized:
                        case WindowStateEx.Maximized:
                            WindowStateEx = WindowStateEx.Normal;
                            break;

                        default:
                            WindowStateEx = _oldWindowStateEx;
                            break;
                    }
                    break;

                default:
                    WindowStateEx = WindowStateEx.Maximized;
                    break;
            }
        }

        private bool CanToggleFullScreen()
        {
            return true;
        }

        private void ToggleFullScreen()
        {
            if (CanToggleFullScreen() == false)
                return;

            switch (WindowStateEx)
            {
                case WindowStateEx.FullScreen:
                    switch (_oldWindowStateEx)
                    {
                        case WindowStateEx.Minimized:
                        case WindowStateEx.FullScreen:
                            WindowStateEx = WindowStateEx.Normal;
                            break;

                        default:
                            WindowStateEx = _oldWindowStateEx;
                            break;
                    }
                    break;

                default:
                    WindowStateEx = WindowStateEx.FullScreen;
                    break;
            }
        }

        #endregion


        #region StateExChanged

        /// <summary>
        /// Occurs when the window's WindowStateEx property changes.
        /// </summary>
        public event EventHandler<CustomWindowStateExChangedEventArgs> StateExChanged;

        /// <summary>
        /// Raises the StateExChanged event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnStateExChanged(CustomWindowStateExChangedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StateExChanged?.Invoke(this, e);
        }

        #endregion


        #region Attached Behaviors

        private static Window GetWindowFromEventHandler(object sender)
        {
            Window window = sender as Window;

            if (window == null)
                window = ((DependencyObject)sender).VisualAncestors().OfType<Window>().FirstOrDefault();

            return window;
        }

        private static void ShowSystemMenuFromMouseEventHandler(object sender, MouseButtonEventArgs e)
        {
            // Ignores if the event is not raised in the property host.
            if (sender != e.Source)
                return;

            Window window = GetWindowFromEventHandler(sender);

            if (window == null)
                return;

            // Displays the system menu.
            window.ShowSystemMenu(window.PointToScreen(e.GetPosition(window)));
        }


        /// <summary>
        /// The attached property to set an element as a window icon.
        /// The window icon element shows the system menu when mouse left button is down or mouse right button is up.
        /// If mouse is double clicked on the window icon element, the window is closed.
        /// </summary>
        public static readonly DependencyProperty IsIconProperty = DependencyProperty.RegisterAttached
        (
            "IsIcon",
            typeof(bool),
            typeof(CustomWindow),
            new PropertyMetadata(false, IsIconProperty_Changed)
        );

        private static void IsIconProperty_Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)o;

            element.MouseLeftButtonDown -= IsIconProperty_PropertyHost_MouseLeftButtonDown;
            element.MouseRightButtonUp -= IsIconProperty_PropertyHost_MouseRightButtonUp;

            if ((bool)e.NewValue)
            {
                element.MouseLeftButtonDown += IsIconProperty_PropertyHost_MouseLeftButtonDown;
                element.MouseRightButtonUp += IsIconProperty_PropertyHost_MouseRightButtonUp;
            }
        }

        static void IsIconProperty_PropertyHost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Ignores if the event is not raised in the property host.
            if (sender != e.Source)
                return;

            Window window = GetWindowFromEventHandler(sender);

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

        static void IsIconProperty_PropertyHost_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShowSystemMenuFromMouseEventHandler(sender, e);
        }

        /// <summary>
        /// Gets a value that indicates whether the element is set as a window icon.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <returns>True if it is set as a window icon; otherwise, false.</returns>
        public static bool GetIsIcon(FrameworkElement target)
        {
            return (bool)target.GetValue(IsIconProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the element is set as a window icon.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <param name="isIcon">A value that indicates whether the element is set as a window icon.</param>
        public static void SetIsIcon(FrameworkElement target, bool isIcon)
        {
            target.SetValue(IsIconProperty, isIcon);
        }


        /// <summary>
        /// The attached property to set an element as a window title bar.
        /// The WindowIcon element shows the system menu when mouse left button is down or mouse right button is up.
        /// If mouse is double clicked on the WindowIcon element, the window is closed.
        /// </summary>
        public static readonly DependencyProperty IsTitleBarProperty = DependencyProperty.RegisterAttached
        (
            "IsTitleBar",
            typeof(bool),
            typeof(CustomWindow),
            new PropertyMetadata(false, IsTitleBarProperty_Changed)
        );

        private static void IsTitleBarProperty_Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)o;

            element.MouseLeftButtonDown -= IsTitleBarProperty_PropertyHost_MouseLeftButtonDown;
            element.MouseRightButtonUp -= IsTitleBarProperty_PropertyHost_MouseRightButtonUp;

            if ((bool)e.NewValue)
            {
                element.MouseLeftButtonDown += IsTitleBarProperty_PropertyHost_MouseLeftButtonDown;
                element.MouseRightButtonUp += IsTitleBarProperty_PropertyHost_MouseRightButtonUp;
            }
        }

        static void IsTitleBarProperty_PropertyHost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Ignores if the event is not raised in the property host.
            if (sender != e.Source)
                return;

            Window window = GetWindowFromEventHandler(sender);

            if (window == null)
                return;

            // Moves the window.
            if (e.ClickCount <= 1)
            {
                window.DragMove();
            }
            else
            {
                // Toggles window maximization.
                window.WindowState = window.WindowState == WindowState.Normal
                                   ? WindowState.Maximized
                                   : WindowState.Normal;
            }

            e.Handled = true;
        }

        static void IsTitleBarProperty_PropertyHost_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShowSystemMenuFromMouseEventHandler(sender, e);
        }

        /// <summary>
        /// Gets a value that indicates whether the element is set as a window title bar.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <returns>True if it is set as a window title bar; otherwise, false.</returns>
        public static bool GetIsTitleBar(FrameworkElement target)
        {
            return (bool)target.GetValue(IsTitleBarProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the element is set as a window title bar.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <param name="isTitleBar">A value that indicates whether the element is set as a window title bar.</param>
        public static void SetIsTitleBar(FrameworkElement target, bool isTitleBar)
        {
            target.SetValue(IsTitleBarProperty, isTitleBar);
        }


        /// <summary>
        /// The attached property that makes an element to show the system menu when mouse right button is up.
        /// </summary>
        public static readonly DependencyProperty IsSystemContextMenuActivatedProperty = DependencyProperty.RegisterAttached
        (
            "IsSystemContextMenuActivated",
            typeof(bool),
            typeof(CustomWindow),
            new PropertyMetadata(false, IsSystemContextMenuActivatedProperty_Changed)
        );

        private static void IsSystemContextMenuActivatedProperty_Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)o;

            element.MouseRightButtonUp -= IsSystemContextMenuActivatedProperty_PropertyHost_MouseRightButtonUp;

            if ((bool)e.NewValue)
                element.MouseRightButtonUp += IsSystemContextMenuActivatedProperty_PropertyHost_MouseRightButtonUp;
        }

        static void IsSystemContextMenuActivatedProperty_PropertyHost_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShowSystemMenuFromMouseEventHandler(sender, e);
        }

        /// <summary>
        /// Gets a value that indicates whether it shows the system menu when mouse right button is up.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <returns>True if it shows system menu when mouse right button is up; otherwise, false.</returns>
        public static bool GetIsSystemContextMenuActivated(UIElement target)
        {
            return (bool)target.GetValue(IsSystemContextMenuActivatedProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether it shows the system menu when mouse right button is up.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <param name="isSystemContextMenuActivated">A value that indicates whether it shows the system menu when mouse right button is up.</param>
        public static void SetIsSystemContextMenuActivated(UIElement target, bool isSystemContextMenuActivated)
        {
            target.SetValue(IsSystemContextMenuActivatedProperty, isSystemContextMenuActivated);
        }

        #endregion
    }
}
