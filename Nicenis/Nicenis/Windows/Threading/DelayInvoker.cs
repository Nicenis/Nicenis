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

#if !NICENIS_RT
using System.Windows.Threading;
#else
using Windows.UI.Xaml;
using Dispatcher = Windows.UI.Core.CoreDispatcher;
#endif

namespace Nicenis.Windows.Threading
{
    /// <summary>
    /// Executes an action with delay on the Dispatcher's thread.
    /// </summary>
    public class DelayInvoker
    {
#if !NICENIS_RT
        const DispatcherPriority DefaultDispatcherPriority = DispatcherPriority.Normal;
#endif

        static readonly TimeSpan DefaultDelayTime = new TimeSpan(0, 0, 0, 1);

        DispatcherTimer _dispatcherTimer;
        Action _action;


        #region Constructors

#if !NICENIS_RT

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="dispatcherPriority">The priority at which execute the action.</param>
        public DelayInvoker(Dispatcher dispatcher, Action action, TimeSpan delayTime, DispatcherPriority dispatcherPriority)
        {
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");

            _action = action;

            // Creates a timer.
            _dispatcherTimer = new DispatcherTimer(dispatcherPriority, dispatcher);
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// The priority is set to DispatcherPriority.Normal.
        /// </remarks>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DelayInvoker(Dispatcher dispatcher, Action action, TimeSpan delayTime)
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
        public DelayInvoker(Dispatcher dispatcher, Action action) : this(dispatcher, action, DefaultDelayTime) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the DispatcherPriority.Normal priority,
        /// 1 second delay time, a null action.
        /// </remarks>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        public DelayInvoker(Dispatcher dispatcher) : this(dispatcher, null) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses the dispatcher returned by the Dispatcher.CurrentDispatcher.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="dispatcherPriority">The priority at which execute the action.</param>
        public DelayInvoker(Action action, TimeSpan delayTime, DispatcherPriority dispatcherPriority)
            : this(Dispatcher.CurrentDispatcher, action, delayTime, dispatcherPriority) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the Dispatcher.CurrentDispatcher dispatcher,
        /// the DispatcherPriority.Normal priority.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DelayInvoker(Action action, TimeSpan delayTime) : this(Dispatcher.CurrentDispatcher, action, delayTime) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the Dispatcher.CurrentDispatcher dispatcher,
        /// the DispatcherPriority.Normal priority, 1 second delay time.
        /// </remarks>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        public DelayInvoker(Action action) : this(Dispatcher.CurrentDispatcher, action) { }

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <remarks>
        /// This constructor uses default values: the Dispatcher.CurrentDispatcher dispatcher,
        /// the DispatcherPriority.Normal priority, 1 second delay time, a null action.
        /// </remarks>
        public DelayInvoker() : this(Dispatcher.CurrentDispatcher) { }

#else
        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public DelayInvoker(Action action, TimeSpan delayTime)
        {
            _action = action;

            // Creates a timer.
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Tick += DispatcherTimer_Tick;
        }

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

#endif

        #endregion


        #region DispatcherTimer_Tick

#if !NICENIS_RT
        private void DispatcherTimer_Tick(object sender, EventArgs e)
#else
        private void DispatcherTimer_Tick(object sender, object e)
#endif
        {
            _dispatcherTimer.Stop();

            Action action = _action;
            if (action != null)
                action();
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public void Start(Action action, TimeSpan delayTime)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            _dispatcherTimer.Stop();
            _dispatcherTimer.Interval = delayTime;
            _action = action;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        [Obsolete("Instead, use the Start method.")]
        public void Begin(Action action, TimeSpan delayTime)
        {
            Start(action, delayTime);
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        public void Start(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            _dispatcherTimer.Stop();
            _action = action;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        [Obsolete("Instead, use the Start method.")]
        public void Begin(Action action)
        {
            Start(action);
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public void Start(TimeSpan delayTime)
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        [Obsolete("Instead, use the Start method.")]
        public void Begin(TimeSpan delayTime)
        {
            Start(delayTime);
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        public void Start()
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution if it is not started.
        /// </summary>
        public void StartIfNotStarted()
        {
            // If it is already started...
            if (IsEnabled)
                return;

            Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        [Obsolete("Instead, use the Start method.")]
        public void Begin()
        {
            Start();
        }

        /// <summary>
        /// Cancels the waiting.
        /// The action is not executed after this method is called.
        /// </summary>
        public void Cancel()
        {
            _dispatcherTimer.Stop();
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
                if (value)
                    _dispatcherTimer.Start();
                else
                    _dispatcherTimer.Stop();
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
