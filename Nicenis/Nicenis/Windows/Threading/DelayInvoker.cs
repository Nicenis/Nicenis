/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.07.10
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Diagnostics;

#if NICENIS_UWP
using Windows.Foundation;
using TheWindow = Windows.UI.Xaml.Window;
using TheDispatcherTimer = Windows.UI.Xaml.DispatcherTimer;
using TheDispatcherPriority = Windows.UI.Core.CoreDispatcherPriority;
#else
using System.Windows.Threading;
using TheDispatcher = System.Windows.Threading.Dispatcher;
using TheDispatcherTimer = System.Windows.Threading.DispatcherTimer;
using TheDispatcherPriority = System.Windows.Threading.DispatcherPriority;
#endif

#if NICENIS_UWP
namespace Nicenis.Windows.UI.Core
#else
namespace Nicenis.Windows.Threading
#endif
{
    /// <summary>
    /// Executes an action with delay on the thread that the dispatcher is associated with.
    /// </summary>
    /// <remarks>
    /// This class is thread-safe.
    /// </remarks>
    public class DelayInvoker
    {
#if NICENIS_UWP
        const TheDispatcherPriority DefaultDelegatePriority = TheDispatcherPriority.Normal;
#else
        const TheDispatcherPriority DefaultDispatcherPriority = TheDispatcherPriority.Normal;
        const TheDispatcherPriority DefaultDelegatePriority = TheDispatcherPriority.Send;
        readonly TheDispatcher _dispatcher;
#endif

        static readonly TimeSpan DefaultDelayTime = new TimeSpan(0, 0, 0, 1);
        readonly TheDispatcherPriority _delegatePriority;
        readonly TheDispatcherTimer _dispatcherTimer;
        Action _action;


        #region Constructors

#if NICENIS_UWP
        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="delegatePriority">The dispatcher priority to use for methods and properties of this class if the caller is not in the thread for dispatcher.</param>
        public DelayInvoker(Action action, TimeSpan delayTime, TheDispatcherPriority delegatePriority)
        {
            _action = action;
            _delegatePriority = delegatePriority;

            // Creates a timer.
            _dispatcherTimer = new TheDispatcherTimer();
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DelayInvoker(Action action, TimeSpan delayTime) : this(action, delayTime, DefaultDelegatePriority) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: 1 second delay time.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        public DelayInvoker(Action action) : this(action, DefaultDelayTime) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: a null action.
        /// </remarks>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DelayInvoker(TimeSpan delayTime) : this(null, delayTime) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: a null action, 1 second delay time.
        /// </remarks>
        public DelayInvoker() : this(null, DefaultDelayTime) { }
#else
        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="dispatcherPriority">The priority at which execute the action.</param>
        /// <param name="delegatePriority">The dispatcher priority to use for methods and properties of this class if the caller is not in the thread for dispatcher.</param>
        public DelayInvoker(TheDispatcher dispatcher, Action action, TimeSpan delayTime, TheDispatcherPriority dispatcherPriority, TheDispatcherPriority delegatePriority)
        {
            if (dispatcher == null)
                throw new ArgumentNullException(nameof(dispatcher));

            _dispatcher = dispatcher;
            _action = action;
            _delegatePriority = delegatePriority;

            // Creates a timer.
            _dispatcherTimer = new TheDispatcherTimer(dispatcherPriority, dispatcher);
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="dispatcherPriority">The priority at which execute the action.</param>
        public DelayInvoker(TheDispatcher dispatcher, Action action, TimeSpan delayTime, TheDispatcherPriority dispatcherPriority)
            : this(dispatcher, action, delayTime, dispatcherPriority, DefaultDelegatePriority) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// The priority is set to DispatcherPriority.Normal.
        /// </remarks>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DelayInvoker(TheDispatcher dispatcher, Action action, TimeSpan delayTime)
            : this(dispatcher, action, delayTime, DefaultDispatcherPriority) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the DispatcherPriority.Normal priority,
        /// 1 second delay time.
        /// </remarks>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        public DelayInvoker(TheDispatcher dispatcher, Action action) : this(dispatcher, action, DefaultDelayTime) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the DispatcherPriority.Normal priority,
        /// 1 second delay time, a null action.
        /// </remarks>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        public DelayInvoker(TheDispatcher dispatcher) : this(dispatcher, null) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses the dispatcher returned by the Dispatcher.CurrentDispatcher.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="dispatcherPriority">The priority at which execute the action.</param>
        /// <param name="delegatePriority">The dispatcher priority to use for methods and properties of this class if the caller is not in the thread for dispatcher.</param>
        public DelayInvoker(Action action, TimeSpan delayTime, TheDispatcherPriority dispatcherPriority, TheDispatcherPriority delegatePriority)
            : this(TheDispatcher.CurrentDispatcher, action, delayTime, dispatcherPriority, delegatePriority) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses the dispatcher returned by the Dispatcher.CurrentDispatcher.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="dispatcherPriority">The priority at which execute the action.</param>
        public DelayInvoker(Action action, TimeSpan delayTime, TheDispatcherPriority dispatcherPriority)
            : this(TheDispatcher.CurrentDispatcher, action, delayTime, dispatcherPriority) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the Dispatcher.CurrentDispatcher dispatcher,
        /// the DispatcherPriority.Normal priority.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DelayInvoker(Action action, TimeSpan delayTime) : this(TheDispatcher.CurrentDispatcher, action, delayTime) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the Dispatcher.CurrentDispatcher dispatcher,
        /// the DispatcherPriority.Normal priority, 1 second delay time.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        public DelayInvoker(Action action) : this(TheDispatcher.CurrentDispatcher, action) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the Dispatcher.CurrentDispatcher dispatcher,
        /// the DispatcherPriority.Normal priority, 1 second delay time, a null action.
        /// </remarks>
        public DelayInvoker() : this(TheDispatcher.CurrentDispatcher) { }
#endif

        #endregion


        #region DispatcherTimer_Tick

#if NICENIS_UWP
        private void DispatcherTimer_Tick(object sender, object e)
#else
        private void DispatcherTimer_Tick(object sender, EventArgs e)
#endif
        {
            _dispatcherTimer.Stop();
            _action?.Invoke();
        }

        #endregion


        #region Helpers

        /// <summary>
        /// Checks whether the current thread is the thread that the dispatcher is associated with.
        /// </summary>
        /// <returns>True if it is in the thread that the dispatcher is associated with; otherwise false.</returns>
        private bool IsInDispatcherThread()
        {
#if NICENIS_UWP
            return TheWindow.Current.Dispatcher.HasThreadAccess;
#else
            return _dispatcher.CheckAccess();
#endif
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting is canceled.
        /// </summary>
        /// <remarks>
        /// This method must be called in the thread that the dispatcher is associated with.
        /// </remarks>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        private void StartImpl(Action action, TimeSpan delayTime)
        {
            Debug.Assert(action != null);

            _dispatcherTimer.Stop();
            _dispatcherTimer.Interval = delayTime;
            _action = action;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting is canceled.
        /// </summary>
        /// <remarks>
        /// This method must be called in the thread that the dispatcher is associated with.
        /// </remarks>
        /// <param name="action">The action to execute with delay.</param>
        private void StartImpl(Action action)
        {
            Debug.Assert(action != null);

            _dispatcherTimer.Stop();
            _action = action;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting is canceled.
        /// </summary>
        /// <remarks>
        /// This method must be called in the thread that the dispatcher is associated with.
        /// </remarks>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        private void StartImpl(TimeSpan delayTime)
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting is canceled.
        /// </summary>
        /// <remarks>
        /// This method must be called in the thread that the dispatcher is associated with.
        /// </remarks>
        private void StartImpl()
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Start();
        }

        #endregion


        #region Public Methods

#if NICENIS_UWP
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public IAsyncAction StartAsync(Action action, TimeSpan delayTime)
#else
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DispatcherOperation StartAsync(Action action, TimeSpan delayTime)
#endif
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

#if NICENIS_UWP
            return TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => StartImpl(action, delayTime));
#else
            return _dispatcher.InvokeAsync(() => StartImpl(action, delayTime), _delegatePriority);
#endif
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public void Start(Action action, TimeSpan delayTime)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (IsInDispatcherThread())
            {
                StartImpl(action, delayTime);
            }
            else
            {
#if NICENIS_UWP
                TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => StartImpl(action, delayTime)).GetResults();
#else
                _dispatcher.Invoke(() => StartImpl(action, delayTime), _delegatePriority);
#endif
            }
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        [Obsolete("Instead, use the Start method.")]
        public void Begin(Action action, TimeSpan delayTime)
        {
            Start(action, delayTime);
        }

#if NICENIS_UWP
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        public IAsyncAction StartAsync(Action action)
#else
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        public DispatcherOperation StartAsync(Action action)
#endif
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

#if NICENIS_UWP
            return TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => StartImpl(action));
#else
            return _dispatcher.InvokeAsync(() => StartImpl(action), _delegatePriority);
#endif
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        public void Start(Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            if (IsInDispatcherThread())
            {
                StartImpl(action);
            }
            else
            {
#if NICENIS_UWP
                TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => StartImpl(action)).GetResults();
#else
                _dispatcher.Invoke(() => StartImpl(action), _delegatePriority);
#endif
            }
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        [Obsolete("Instead, use the Start method.")]
        public void Begin(Action action)
        {
            Start(action);
        }

#if NICENIS_UWP
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public IAsyncAction StartAsync(TimeSpan delayTime)
#else
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DispatcherOperation StartAsync(TimeSpan delayTime)
#endif
        {
#if NICENIS_UWP
            return TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => StartImpl(delayTime));
#else
            return _dispatcher.InvokeAsync(() => StartImpl(delayTime), _delegatePriority);
#endif
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public void Start(TimeSpan delayTime)
        {
            if (IsInDispatcherThread())
            {
                StartImpl(delayTime);
            }
            else
            {
#if NICENIS_UWP
                TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => StartImpl(delayTime)).GetResults();
#else
                _dispatcher.Invoke(() => StartImpl(delayTime), _delegatePriority);
#endif
            }
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        [Obsolete("Instead, use the Start method.")]
        public void Begin(TimeSpan delayTime)
        {
            Start(delayTime);
        }

#if NICENIS_UWP
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        public IAsyncAction StartAsync()
#else
        /// <summary>
        /// Starts a new delay execution asynchronously.
        /// The previous waiting can be canceled.
        /// </summary>
        public DispatcherOperation StartAsync()
#endif
        {
#if NICENIS_UWP
            return TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => StartImpl());
#else
            return _dispatcher.InvokeAsync(() => StartImpl(), _delegatePriority);
#endif
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        public void Start()
        {
            if (IsInDispatcherThread())
            {
                StartImpl();
            }
            else
            {
#if NICENIS_UWP
                TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, StartImpl).GetResults();
#else
                _dispatcher.Invoke(StartImpl, _delegatePriority);
#endif
            }
        }

        /// <summary>
        /// Starts a new delay execution.
        /// The previous waiting can be canceled.
        /// </summary>
        [Obsolete("Instead, use the Start method.")]
        public void Begin()
        {
            Start();
        }

#if NICENIS_UWP
        /// <summary>
        /// Starts a new delay execution asynchronously if it is not started.
        /// The previous waiting can be canceled.
        /// </summary>
        public IAsyncAction StartIfNotStartedAsync()
#else
        /// <summary>
        /// Starts a new delay execution asynchronously if it is not started.
        /// The previous waiting can be canceled.
        /// </summary>
        public DispatcherOperation StartIfNotStartedAsync()
#endif
        {
#if NICENIS_UWP
            return TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () =>
            {
                if (IsEnabled == false)
                    StartImpl();
            });
#else
            return _dispatcher.InvokeAsync(() =>
            {
                if (IsEnabled == false)
                    StartImpl();
            }
            , _delegatePriority);
#endif
        }

        /// <summary>
        /// Starts a new delay execution if it is not started.
        /// The previous waiting can be canceled.
        /// </summary>
        public void StartIfNotStarted()
        {
            if (IsInDispatcherThread())
            {
                if (IsEnabled == false)
                    StartImpl();
            }
            else
            {
#if NICENIS_UWP
                TheWindow.Current.Dispatcher.RunAsync
                (
                    _delegatePriority,
                    () =>
                    {
                        if (IsEnabled == false)
                            StartImpl();
                    }
                )
                .GetResults();
#else
                _dispatcher.Invoke
                (
                    () =>
                    {
                        if (IsEnabled == false)
                            StartImpl();
                    },
                    _delegatePriority
                );
#endif
            }
        }

#if NICENIS_UWP
        /// <summary>
        /// Cancels waiting asynchronously if exists.
        /// The action may not be not executed after this method is called.
        /// </summary>
        public IAsyncAction CancelAsync()
#else
        /// <summary>
        /// Cancels waiting asynchronously if exists.
        /// The action may not be not executed after this method is called.
        /// </summary>
        public DispatcherOperation CancelAsync()
#endif
        {
#if NICENIS_UWP
            return TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => _dispatcherTimer.Stop());
#else
            return _dispatcher.InvokeAsync(() => _dispatcherTimer.Stop(), _delegatePriority);
#endif
        }

        /// <summary>
        /// Cancels waiting if exists.
        /// The action may not executed after this method is called.
        /// </summary>
        public void Cancel()
        {
            if (IsInDispatcherThread())
            {
                _dispatcherTimer.Stop();
            }
            else
            {
#if NICENIS_UWP
                TheWindow.Current.Dispatcher.RunAsync(_delegatePriority, () => _dispatcherTimer.Stop()).GetResults();
#else
                _dispatcher.Invoke(() => _dispatcherTimer.Stop(), _delegatePriority);
#endif
            }
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets a value that indicates whether the DelayInvoker is waiting or not.
        /// </summary>
        public bool IsEnabled
        {
            get { return _dispatcherTimer.IsEnabled; }
            set
            {
                if (IsInDispatcherThread())
                {
                    if (value)
                        _dispatcherTimer.Start();
                    else
                        _dispatcherTimer.Stop();
                }
                else
                {
#if NICENIS_UWP
                    TheWindow.Current.Dispatcher.RunAsync
                    (
                        _delegatePriority,
                        () =>
                        {
                            if (value)
                                _dispatcherTimer.Start();
                            else
                                _dispatcherTimer.Stop();
                        }
                    )
                    .GetResults();
#else
                    _dispatcher.Invoke
                    (
                        () =>
                        {
                            if (value)
                                _dispatcherTimer.Start();
                            else
                                _dispatcherTimer.Stop();
                        },
                        _delegatePriority
                    );
#endif
                }
            }
        }

        /// <summary>
        /// The action to execute with delay.
        /// This value can be null.
        /// </summary>
        public Action Action
        {
            get { return _action; }
        }

        #endregion
    }
}
