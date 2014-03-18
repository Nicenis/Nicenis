/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.07.10
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Diagnostics;
using System;
using System.Windows.Threading;

namespace Nicenis.Windows.Threading
{
    /// <summary>
    /// Executes an action with delay on the Dispatcher's thread.
    /// </summary>
    public class DelayInvoker
    {
        static readonly TimeSpan DefaultDelayTime = new TimeSpan(0, 0, 0, 1);
        const DispatcherPriority DefaultDispatcherPriority = DispatcherPriority.Normal;

        DispatcherTimer _dispatcherTimer;
        Action _action;


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DelayInvoker class.
        /// </summary>
        /// <param name="dispatcher">The Dispatcher to execute the action.</param>
        /// <param name="action">The action to execute with delay. Null is allowed.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        /// <param name="dispatcherPriority">The priority at which execute the action.</param>
        public DelayInvoker(Dispatcher dispatcher, Action action, TimeSpan delayTime, DispatcherPriority dispatcherPriority)
        {
            Verify.ParameterIsNotNull(dispatcher, "dispatcher");

            _action = action;

            // Creates a timer.
            _dispatcherTimer = new DispatcherTimer(dispatcherPriority, dispatcher);
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Tick += (_, e) =>
            {
                _dispatcherTimer.Stop();

                if (_action != null)
                    _action();
            };
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

        #endregion


        #region Public Methods

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="action">The action to execute with delay.</param>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public void Begin(Action action, TimeSpan delayTime)
        {
            Verify.ParameterIsNotNull(action, "action");

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
        public void Begin(Action action)
        {
            Verify.ParameterIsNotNull(action, "action");

            _dispatcherTimer.Stop();
            _action = action;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        /// <param name="delayTime">Time to wait before executing the action.</param>
        public void Begin(TimeSpan delayTime)
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// Starts a new delay execution.
        /// Previous waiting is canceled.
        /// </summary>
        public void Begin()
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Start();
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
            set { _dispatcherTimer.IsEnabled = value; }
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
