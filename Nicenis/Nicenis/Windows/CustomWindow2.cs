/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.11.03
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows.Input;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Animation;
using Nicenis.Interop;

#if NICENIS_NF4C
using Microsoft.Windows.Shell;
#else
using System.Windows.Shell;
#endif

namespace Nicenis.Windows
{
    /// <summary>
    /// A base class for non-standard windows.
    /// </summary>
    public class CustomWindow2 : Window
    {
        #region Constructors

        static CustomWindow2()
        {
            FullScreenWindowStyleAnimation = new ObjectAnimationUsingKeyFrames
            {
                FillBehavior = FillBehavior.HoldEnd,
            };
            FullScreenWindowStyleAnimation.KeyFrames.Add(new DiscreteObjectKeyFrame
            {
                KeyTime = TimeSpan.Zero,
                Value = WindowStyle.None,
            });
            FullScreenWindowStyleAnimation.Freeze();

            FullScreenWindowChromeAnimation = new ObjectAnimationUsingKeyFrames
            {
                FillBehavior = FillBehavior.HoldEnd,
            };
            FullScreenWindowChromeAnimation.KeyFrames.Add(new DiscreteObjectKeyFrame
            {
                KeyTime = TimeSpan.Zero,
                Value = null,
            });
            FullScreenWindowChromeAnimation.Freeze();
        }

        /// <summary>
        /// Initializes a new instance of the CustomWindow class.
        /// </summary>
        public CustomWindow2()
        {
            // Initialize commands
            InitializeCommands();
        }

        #endregion


        #region Properties

        /// <summary>
        /// The dependency property for IsAutoAdjustment.
        /// </summary>
        public static readonly DependencyProperty IsAutoAdjustmentProperty = DependencyProperty.Register
        (
            name: nameof(IsAutoAdjustment),
            propertyType: typeof(bool),
            ownerType: typeof(CustomWindow2),
            typeMetadata: new FrameworkPropertyMetadata(true)
        );

        /// <summary>
        /// Gets or sets a value that indicates whether the window position and size adjustment is performed or not.
        /// </summary>
        public bool IsAutoAdjustment
        {
            get { return (bool)GetValue(IsAutoAdjustmentProperty); }
            set { SetValue(IsAutoAdjustmentProperty, value); }
        }


        /// <summary>
        /// The dependency property for specifing the extended WindowState.
        /// </summary>
        public static readonly DependencyProperty WindowStateExProperty = DependencyProperty.Register
        (
            "WindowStateEx",
            typeof(WindowStateEx),
            typeof(CustomWindow2),
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
            ((CustomWindow2)d).Apply((WindowStateEx)e.NewValue);
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
            typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            ownerType: typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            ownerType: typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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
            ownerType: typeof(CustomWindow2),
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
            typeof(CustomWindow2),
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


        #region Helpers

        /// <summary>
        /// Raises the System.Windows.Window.SourceInitialized event.
        /// </summary>
        /// <param name="e">An System.EventArgs that contains the event data.</param>
        protected override void OnSourceInitialized(EventArgs e)
        {
            AdjustPositionSize();
            base.OnSourceInitialized(e);
        }

        static readonly ObjectAnimationUsingKeyFrames FullScreenWindowStyleAnimation;
        static readonly ObjectAnimationUsingKeyFrames FullScreenWindowChromeAnimation;

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

            if (_oldWindowStateEx != WindowStateEx.FullScreen && windowStateEx == WindowStateEx.FullScreen)
            {
                BeginAnimation(WindowStyleProperty, FullScreenWindowStyleAnimation);
                BeginAnimation(WindowChrome.WindowChromeProperty, FullScreenWindowChromeAnimation);

                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;

                if (Visibility == Visibility.Visible)
                {
                    Visibility = Visibility.Collapsed;
                    Visibility = Visibility.Visible;
                }
            }
            else if (_oldWindowStateEx == WindowStateEx.FullScreen && windowStateEx != WindowStateEx.FullScreen)
            {
                BeginAnimation(WindowStyleProperty, null);
                BeginAnimation(WindowChrome.WindowChromeProperty, null);

                if (WindowState == WindowState.Maximized)
                    WindowState = WindowState.Normal;

                if (Visibility == Visibility.Visible)
                {
                    Visibility = Visibility.Collapsed;
                    Visibility = Visibility.Visible;
                }
            }

            // Sets the WindowStateEx.
            WindowStateEx = windowStateEx;

            // Sets the WindowState.
            WindowState = windowStateEx.ToWindowState();

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
                OnStateExChanged(new StateExChangedEventArgs(_oldWindowStateEx, windowStateEx));
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

        /// <summary>
        /// Adjusts the window position and size to show in the monitor work area rectangle.
        /// </summary>
        private void AdjustPositionSize()
        {
            if (IsAutoAdjustment == false)
                return;

            var windowHandle = new WindowInteropHelper(this).Handle;

            var monitorHandle = Win32.MonitorFromWindow(windowHandle, Win32.MONITOR_DEFAULTTONEAREST);
            if (monitorHandle == IntPtr.Zero)
            {
                Debug.WriteLine($"{nameof(Win32.MonitorFromWindow)} failed.");
                return;
            }

            var monitorInfo = Win32.MONITORINFO.Create();
            if (Win32.GetMonitorInfo(monitorHandle, ref monitorInfo) == 0)
            {
                Debug.WriteLine($"{nameof(Win32.GetMonitorInfo)} failed.");
                return;
            }

            var presentationSource = PresentationSource.FromVisual(this);
            if (presentationSource == null)
            {
                Debug.WriteLine($"{nameof(PresentationSource)}.{nameof(PresentationSource.FromVisual)} failed.");
                return;
            }

            var transform = presentationSource.CompositionTarget.TransformToDevice;
            var workArea = new Rect
            (
                transform.Transform(new Point(monitorInfo.rcWork.left, monitorInfo.rcWork.top)),
                transform.Transform(new Point(monitorInfo.rcWork.right, monitorInfo.rcWork.bottom))
            );

            var width = Width;
            var height = Height;

            var sizeToContent = SizeToContent;
            if (sizeToContent != SizeToContent.WidthAndHeight)
            {
                if (sizeToContent != SizeToContent.Width && double.IsNaN(width) == false)
                {
                    if (width > workArea.Width)
                        Width = workArea.Width;
                }

                if (sizeToContent != SizeToContent.Height && double.IsNaN(height) == false)
                {
                    if (height > workArea.Height)
                        Height = workArea.Height;
                }
            }

            var left = Left;

            if (double.IsNaN(width) == false && (left + width) > workArea.Right)
                left -= ((left + width) - workArea.Right);

            if (left < workArea.X)
                left = workArea.X;

            Left = left;

            var top = Top;

            if (double.IsNaN(height) == false && (top + height) > workArea.Bottom)
                top -= ((top + height) - workArea.Bottom);

            if (top < workArea.Y)
                top = workArea.Y;

            Top = top;
        }

        #endregion


        #region StateExChanged

        #region tateExChangedEventArgs

        /// <summary>
        /// The event arguments for the StateExChanged event.
        /// </summary>
        public class StateExChangedEventArgs : EventArgs
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance of the StateExChangedEventArgs class.
            /// </summary>
            /// <param name="oldValue">The WindowStateEx before the change.</param>
            /// <param name="newValue">The WindowStateEx after the change.</param>
            internal StateExChangedEventArgs(WindowStateEx oldValue, WindowStateEx newValue)
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
        /// Occurs when the window's WindowStateEx property changes.
        /// </summary>
        public event EventHandler<StateExChangedEventArgs> StateExChanged;

        /// <summary>
        /// Raises the StateExChanged event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnStateExChanged(StateExChangedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            StateExChanged?.Invoke(this, e);
        }

        #endregion
    }
}
