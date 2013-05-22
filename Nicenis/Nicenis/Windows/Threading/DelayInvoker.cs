/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.07.10
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Windows.Threading;

namespace Nicenis.Windows.Threading
{
    /// <summary>
    /// 일정 시간 지연 후 Dispatcher 에서 코드를 실행하는 클래스
    /// </summary>
    public class DelayInvoker
    {
        static readonly TimeSpan DefaultDelayTime = new TimeSpan(0, 0, 0, 1);
        const DispatcherPriority DefaultDispatcherPriority = DispatcherPriority.Normal;

        DispatcherTimer _dispatcherTimer;
        Action _action;


        #region Constructors

        /// <summary>
        /// DelayInvoker 를 생성한다.
        /// </summary>
        /// <param name="dispatcher">대상 Dispatcher</param>
        /// <param name="action">지연 시간 후 실행할 Action. null 허용</param>
        /// <param name="delayTime">지연 시간</param>
        /// <param name="dispatcherPriority">Dispatcher 우선순위</param>
        public DelayInvoker(Dispatcher dispatcher, Action action, TimeSpan delayTime, DispatcherPriority dispatcherPriority)
        {
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");

            _action = action;

            // 타이머 만들기
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
        /// DelayInvoker 를 생성한다.
        /// </summary>
        /// <param name="dispatcher">대상 Dispatcher</param>
        /// <param name="action">지연 시간 후 실행할 Action. null 허용</param>
        /// <param name="delayTime">지연 시간</param>
        public DelayInvoker(Dispatcher dispatcher, Action action, TimeSpan delayTime)
            : this(dispatcher, action, delayTime, DefaultDispatcherPriority) { }

        /// <summary>
        /// DelayInvoker 를 생성한다.
        /// </summary>
        /// <param name="dispatcher">대상 Dispatcher</param>
        /// <param name="action">지연 시간 후 실행할 Action. null 허용</param>
        public DelayInvoker(Dispatcher dispatcher, Action action) : this(dispatcher, action, DefaultDelayTime) { }

        /// <summary>
        /// DelayInvoker 를 생성한다.
        /// </summary>
        /// <param name="dispatcher">대상 Dispatcher</param>
        public DelayInvoker(Dispatcher dispatcher) : this(dispatcher, null) { }

        /// <summary>
        /// DelayInvoker 를 생성한다.
        /// 현재 스레드의 Dispatcher 를 사용한다.
        /// </summary>
        /// <param name="action">지연 시간 후 실행할 Action. null 허용</param>
        /// <param name="delayTime">지연 시간</param>
        /// <param name="dispatcherPriority">Dispatcher 우선순위</param>
        public DelayInvoker(Action action, TimeSpan delayTime, DispatcherPriority dispatcherPriority)
            : this(Dispatcher.CurrentDispatcher, action, delayTime, dispatcherPriority) { }

        /// <summary>
        /// DelayInvoker 를 생성한다.
        /// 현재 스레드의 Dispatcher 를 사용한다.
        /// </summary>
        /// <param name="action">지연 시간 후 실행할 Action. null 허용</param>
        /// <param name="delayTime">지연 시간</param>
        public DelayInvoker(Action action, TimeSpan delayTime) : this(Dispatcher.CurrentDispatcher, action, delayTime) { }

        /// <summary>
        /// DelayInvoker 를 생성한다.
        /// 현재 스레드의 Dispatcher 를 사용한다.
        /// </summary>
        /// <param name="action">지연 시간 후 실행할 Action. null 허용</param>
        public DelayInvoker(Action action) : this(Dispatcher.CurrentDispatcher, action) { }

        /// <summary>
        /// DelayInvoker 를 생성한다.
        /// 현재 스레드의 Dispatcher 를 사용한다.
        /// </summary>
        public DelayInvoker() : this(Dispatcher.CurrentDispatcher) { }

        #endregion


        #region Public Methods

        /// <summary>
        /// 지연 실행을 시작한다.
        /// 기존 지연 실행은 취소된다.
        /// </summary>
        /// <param name="action">실행할 Action. 기존 설정된 값은 이 값으로 변경된다. null 허용 안함</param>
        /// <param name="delayTime">지연 시간. 기존 설정된 값은 이 값으로 변경된다.</param>
        public void Begin(Action action, TimeSpan delayTime)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            _dispatcherTimer.Stop();
            _dispatcherTimer.Interval = delayTime;
            _action = action;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// 지연 실행을 시작한다.
        /// 기존 지연 실행은 취소된다.
        /// </summary>
        /// <param name="action">실행할 Action. 기존 설정된 Action 은 이 값으로 변경된다. null 허용 안함</param>
        public void Begin(Action action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            _dispatcherTimer.Stop();
            _action = action;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// 지연 실행을 시작한다.
        /// 기존 지연 실행은 취소된다.
        /// </summary>
        /// <param name="delayTime">지연 시간. 기존 설정된 값은 이 값으로 변경된다.</param>
        public void Begin(TimeSpan delayTime)
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Interval = delayTime;
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// 지연 실행을 시작한다.
        /// 기존 지연 실행은 취소된다.
        /// </summary>
        public void Begin()
        {
            _dispatcherTimer.Stop();
            _dispatcherTimer.Start();
        }

        /// <summary>
        /// 지연 실행을 취소한다.
        /// </summary>
        public void Cancel()
        {
            _dispatcherTimer.Stop();
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// 현재 지연 실행이 진행 중인지 여부를 가져오거나 설정한다.
        /// </summary>
        public bool IsEnabled
        {
            get { return _dispatcherTimer.IsEnabled; }
            set { _dispatcherTimer.IsEnabled = value; }
        }

        /// <summary>
        /// 설정된 Action.
        /// null 값이 반환될 수 있다.
        /// </summary>
        public Action Action
        {
            get { return _action; }
        }

        #endregion
    }
}
