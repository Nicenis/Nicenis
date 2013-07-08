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
    #region CustomWindowStateExChangedEventArgs

    /// <summary>
    /// The event arguments for the StateExChanged event.
    /// </summary>
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
            // Sets the WindowStateEx based on the WindowState.
            Apply(WindowState.ToWindowStateEx(IsFullScreenMode));

            base.OnInitialized(e);
        }

        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e);

            // Sets the WindowStateEx based on the WindowState.
            Apply(WindowState.ToWindowStateEx(IsFullScreenMode));
        }

        #endregion


        #region Window Procedure

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == Win32.WM_GETMINMAXINFO)
            {
                // Get the monitor handle.
                IntPtr hMonitor = Win32.MonitorFromWindow(hwnd, Win32.MONITOR_DEFAULTTONEAREST);

                if (hMonitor != IntPtr.Zero)
                {
                    // Gets monitor information.
                    Win32.MONITORINFO monitorInfo = Win32.MONITORINFO.Create();

                    if (Win32.GetMonitorInfo(hMonitor, ref monitorInfo) != 0)
                    {
                        // Gets the MINMAXINFO.
                        Win32.MINMAXINFO minMaxInfo = (Win32.MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(Win32.MINMAXINFO));

                        if (IsFullScreenMode)
                        {
                            // If it is the full screen mode, it must use the entire screen.
                            minMaxInfo.ptMaxPosition.x = monitorInfo.rcMonitor.left;
                            minMaxInfo.ptMaxPosition.y = monitorInfo.rcMonitor.top;
                            minMaxInfo.ptMaxSize.x = Math.Abs(monitorInfo.rcMonitor.right - monitorInfo.rcMonitor.left);
                            minMaxInfo.ptMaxSize.y = Math.Abs(monitorInfo.rcMonitor.bottom - monitorInfo.rcMonitor.top);
                        }
                        else
                        {
                            // If it is not the full screen mode, it must use the work area.
                            minMaxInfo.ptMaxPosition.x = monitorInfo.rcWork.left;
                            minMaxInfo.ptMaxPosition.y = monitorInfo.rcWork.top;
                            minMaxInfo.ptMaxSize.x = Math.Abs(monitorInfo.rcWork.right - monitorInfo.rcWork.left);
                            minMaxInfo.ptMaxSize.y = Math.Abs(monitorInfo.rcWork.bottom - monitorInfo.rcWork.top);
                        }

                        // Sets the modified MINMAXINFO.
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
            WindowStateEx oldWindowStateEx = _appliedWindowStateEx ?? WindowStateEx.Normal;
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
            if ((oldWindowStateEx == WindowStateEx.Maximized && windowStateEx == WindowStateEx.FullScreen)
                || (oldWindowStateEx == WindowStateEx.FullScreen && windowStateEx == WindowStateEx.Maximized))
            {
                Visibility = Visibility.Collapsed;
                Visibility = Visibility.Visible;
            }

            // Updates the WindowStateEx relate properties.
            IsMinimized = WindowStateEx == WindowStateEx.Minimized;
            IsNormal = WindowStateEx == WindowStateEx.Normal;
            IsMaximized = WindowStateEx == WindowStateEx.Maximized;
            IsFullScreen = WindowStateEx == WindowStateEx.FullScreen;

            // If it is required to raise the StateExChanged event
            if (isRequiredToRaiseStateExChanged)
            {
                // Raises the StateExChanged event.
                OnStateExChanged(new CustomWindowStateExChangedEventArgs(oldWindowStateEx, windowStateEx));

                // It is required to update UI that binds to CustomWindow's commands.
                CommandManager.InvalidateRequerySuggested();
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

            if (StateExChanged != null)
                StateExChanged(this, e);
        }

        #endregion


        #region Attached Behaviors

        /// <summary>
        /// The attached property to set an element as a window icon.
        /// The WindowIcon element shows the system menu when mouse left button is down or mouse right button is up.
        /// If mouse is double clicked on the WindowIcon element, the window is closed.
        /// </summary>
        public static readonly DependencyProperty IsWindowIconProperty = DependencyProperty.RegisterAttached
        (
            "IsWindowIcon",
            typeof(bool),
            typeof(CustomWindow),
            new PropertyMetadata(false, IsWindowIconProperty_Changed)
        );

        private static void IsWindowIconProperty_Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)o;

            element.MouseLeftButtonDown -= IsWindowIconProperty_PropertyHost_MouseLeftButtonDown;
            element.MouseRightButtonUp -= IsWindowIconProperty_PropertyHost_MouseRightButtonUp;

            if ((bool)e.NewValue)
            {
                element.MouseLeftButtonDown += IsWindowIconProperty_PropertyHost_MouseLeftButtonDown;
                element.MouseRightButtonUp += IsWindowIconProperty_PropertyHost_MouseRightButtonUp;
            }
        }

        static void IsWindowIconProperty_PropertyHost_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        static void IsWindowIconProperty_PropertyHost_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = sender as Window;

            if (window == null)
                window = ((DependencyObject)sender).VisualAncestors().OfType<Window>().FirstOrDefault();

            if (window == null)
                return;

            // Displays the system menu.
            window.ShowSystemMenu(window.PointToScreen(e.GetPosition(window)));
        }

        /// <summary>
        /// Gets a value that indicates whether the element is set as a window icon.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <returns>True if it is set as a window icon; otherwise, false.</returns>
        public static bool GetIsWindowIcon(FrameworkElement element)
        {
            return (bool)element.GetValue(IsWindowIconProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the element is set as a window icon.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="IsWindowIcon">A value that indicates whether the element is set as a window icon.</param>
        public static void SetIsWindowIcon(FrameworkElement element, bool IsWindowIcon)
        {
            element.SetValue(IsWindowIconProperty, IsWindowIcon);
        }


        /// <summary>
        /// The attached property that makes an element to show the system menu when mouse right button is up.
        /// </summary>
        public static readonly DependencyProperty IsSystemContextMenuEnabledProperty = DependencyProperty.RegisterAttached
        (
            "IsSystemContextMenuEnabled",
            typeof(bool),
            typeof(CustomWindow),
            new PropertyMetadata(false, IsSystemContextMenuEnabledProperty_Changed)
        );

        private static void IsSystemContextMenuEnabledProperty_Changed(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = (UIElement)o;

            element.MouseRightButtonUp -= IsSystemContextMenuEnabledProperty_PropertyHost_MouseRightButtonUp;

            if ((bool)e.NewValue)
                element.MouseRightButtonUp += IsSystemContextMenuEnabledProperty_PropertyHost_MouseRightButtonUp;
        }

        static void IsSystemContextMenuEnabledProperty_PropertyHost_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            Window window = sender as Window;

            if (window == null)
                window = ((DependencyObject)sender).VisualAncestors().OfType<Window>().FirstOrDefault();

            if (window == null)
                return;

            // Displays the system menu.
            window.ShowSystemMenu(window.PointToScreen(e.GetPosition(window)));
        }

        /// <summary>
        /// Gets a value that indicates whether it shows the system menu when mouse right button is up.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <returns>True if it shows system menu when mouse right button is up; otherwise, false.</returns>
        public static bool GetIsSystemContextMenuEnabled(UIElement element)
        {
            return (bool)element.GetValue(IsSystemContextMenuEnabledProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether it shows the system menu when mouse right button is up.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="isSystemContextMenuEnabled">A value that indicates whether it shows the system menu when mouse right button is up.</param>
        public static void SetIsSystemContextMenuEnabled(UIElement element, bool isSystemContextMenuEnabled)
        {
            element.SetValue(IsSystemContextMenuEnabledProperty, isSystemContextMenuEnabled);
        }

        #endregion
    }
}
