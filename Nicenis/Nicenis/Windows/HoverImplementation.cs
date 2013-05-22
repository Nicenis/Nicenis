/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.05.05
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows.Threading;
using System;
using System.Diagnostics;
using System.Windows;

namespace Nicenis.Windows
{
    #region HoverImplementationBase

    /// <summary>
    /// Provides base implementation to raise the Hover event.
    /// This class is used to share hover related codes with others such as the DropTarget class.
    /// </summary>
    internal abstract class HoverImplementationBase
    {
        /// <summary>
        /// The target UI element to raise the hover event.
        /// This variable is set to non-null value in the Constructor.
        /// </summary>
        UIElement _target;

        /// <summary>
        /// The preview hover routed event.
        /// This variable is set to non-null value in the Constructor.
        /// </summary>
        RoutedEvent _previewHoverEvent;

        /// <summary>
        /// The hover routed event.
        /// This variable is set to non-null value in the Constructor.
        /// </summary>
        RoutedEvent _hoverEvent;

        /// <summary>
        /// The IsHover dependency property key.
        /// This variable is set to non-null value in the Constructor.
        /// </summary>
        DependencyPropertyKey _isHoverPropertyKey;


        #region Constructors

        internal HoverImplementationBase(UIElement target, RoutedEvent previewHoverEvent, RoutedEvent hoverEvent, DependencyPropertyKey isHoverPropertyKey)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            if (previewHoverEvent == null)
                throw new ArgumentNullException("previewHoverEvent");

            if (hoverEvent == null)
                throw new ArgumentNullException("hoverEvent");

            if (isHoverPropertyKey == null)
                throw new ArgumentNullException("isHoverPropertyKey");

            _target = target;
            _previewHoverEvent = previewHoverEvent;
            _hoverEvent = hoverEvent;
            _isHoverPropertyKey = isHoverPropertyKey;
        }

        #endregion


        #region Helpers

        /// <summary>
        /// Checks whether the move is hover or not.
        /// </summary>
        /// <param name="allowedMoveDistance">The size of a rectangle centered on the base position. The current position is recognized as hover if it is in this rectangle.</param>
        /// <param name="basePosition">The base position that is the center of the rectangle of the allowedMoveDistance.</param>
        /// <param name="currentPosition">The position to check.</param>
        /// <returns>True if it is hover, otherwise false.</returns>
        protected static bool IsHover(Vector allowedMoveDistance, Point basePosition, Point currentPosition)
        {
            return (Math.Abs(basePosition.X - currentPosition.X) < allowedMoveDistance.X / 2)
                && (Math.Abs(basePosition.Y - currentPosition.Y) < allowedMoveDistance.Y / 2);
        }

        /// <summary>
        /// Converts a Point in screen coordinates into a Point that represents the current coordinate system of the target UI element.
        /// </summary>
        /// <param name="point">The Point value in screen coordinates.</param>
        /// <returns>The converted Point value that represents the current coordinate system of the target UI element.</returns>
        protected Point PointFromScreen(Point point)
        {
            return _target.PointFromScreen(point);
        }

        /// <summary>
        /// Converts a Point that represents the current coordinate system of the target UI element into a Point in screen coordinates.
        /// </summary>
        /// <param name="point">The Point value that represents the current coordinate system of the target UI element.</param>
        /// <returns>The converted Point value in screen coordinates.</returns>
        protected Point PointToScreen(Point point)
        {
            return _target.PointToScreen(point);
        }

        /// <summary>
        /// Sets whether it is hover or not.
        /// </summary>
        /// <param name="isHover">whether it is hover or not.</param>
        protected void SetIsHover(bool isHover)
        {
            _target.SetValue(_isHoverPropertyKey, isHover);
        }

        /// <summary>
        /// Raises PreviewHoverEvent and HoverEvent.
        /// </summary>
        /// <param name="hoveredPositionInScreen">The hovered position in screen coordinates.</param>
        /// <param name="hoveredTicks">The hovered ticks.</param>
        protected void RaiseHoverEvent(Point hoveredPositionInScreen, long hoveredTicks)
        {
            Debug.Assert(BasePositionInScreen != null);

            // Creates an event argument.
            HoverEventArgs eventArgs = new HoverEventArgs
            (
                _previewHoverEvent,
                _target,
                PointFromScreen(BasePositionInScreen.Value),
                BaseTicks,
                PointFromScreen(hoveredPositionInScreen),
                hoveredTicks
            );

            // Raises the PreviewHoverEvent routed event.
            _target.RaiseEvent(eventArgs);

            // Raises the HoverEvent routed event.
            eventArgs.RoutedEvent = _hoverEvent;
            _target.RaiseEvent(eventArgs);
        }

        #endregion


        #region Properties

        /// <summary>
        /// The base position for recognizing hover action in screen coordinates.
        /// </summary>
        protected Point? BasePositionInScreen { get; set; }

        /// <summary>
        /// The ticks when the BasePositionInScreen is set.
        /// </summary>
        protected long BaseTicks { get; set; }

        /// <summary>
        /// Whether the Hover event is raised within the target UI element.
        /// This value is set to false if the pointing device is reenter.
        /// </summary>
        protected bool IsRaisedAfterEnter { get; set; }

        #endregion


        #region Public methods

        /// <summary>
        /// Handles that a pointing device enters the target UI element.
        /// This method must be called even if the enter event handler is already handled.
        /// </summary>
        public virtual void ProcessEnter()
        {
            // Resets the base position.
            BasePositionInScreen = null;

            // Resets the raised flag.
            IsRaisedAfterEnter = false;

            // Sets ths IsHover to false.
            SetIsHover(false);
        }

        /// <summary>
        /// Handles that a pointing device leaves the target UI element.
        /// This method must be called even if the leave event handler is already handled.
        /// </summary>
        public virtual void ProcessLeave()
        {
            // Sets ths IsHover to false.
            SetIsHover(false);
        }

        #endregion
    }

    #endregion


    #region HoverBehaviorImplementation

    /// <summary>
    /// Provides actual implementation to raise the Hover event.
    /// </summary>
    internal class HoverBehaviorImplementation : HoverImplementationBase
    {
        /// <summary>
        /// The DelayInvoker that raises the Hover event.
        /// </summary>
        Lazy<DelayInvoker> _hoverDelayInvoker = new Lazy<DelayInvoker>();


        #region Constructors

        internal HoverBehaviorImplementation(UIElement target, RoutedEvent previewHoverEvent, RoutedEvent hoverEvent, DependencyPropertyKey isHoverPropertyKey)
            : base(target, previewHoverEvent, hoverEvent, isHoverPropertyKey) { }

        #endregion


        #region Public methods

        /// <summary>
        /// Handles that a pointing device enters the target UI element.
        /// This method must be called even if the enter event handler is already handled.
        /// </summary>
        public override void ProcessEnter()
        {
            base.ProcessEnter();

            // Stops the timer.
            if (_hoverDelayInvoker.IsValueCreated)
                _hoverDelayInvoker.Value.Cancel();
        }

        /// <summary>
        /// Handles that a pointing device moves in the target UI element.
        /// </summary>
        /// <param name="currentPosition">The current pointing device position relative to the target UI element.</param>
        /// <param name="hoverWidth">A HoverWidth.</param>
        /// <param name="hoverHeight">A HoverHeight.</param>
        /// <param name="getPosition">A function that returns the current pointing device position relative to the target UI element. This function is called before the Hover event is raised.</param>
        /// <param name="getHoverEventMode">A function that returns a HoverEventMode.</param>
        /// <param name="getHoverTime">A function that returns a HoverTime.</param>
        public void ProcessMove(Point currentPosition, double hoverWidth, double hoverHeight,
                                    Func<Point> getPosition, Func<HoverEventMode> getHoverEventMode, Func<TimeSpan> getHoverTime)
        {
            if (getPosition == null)
                throw new ArgumentNullException("getPosition");

            if (getHoverEventMode == null)
                throw new ArgumentNullException("getHoverEventMode");

            if (getHoverTime == null)
                throw new ArgumentNullException("getHoverTime");


            // Gets the point in screen coordinates.
            Point currentPositionInScreen = PointToScreen(currentPosition);


            // Checks whether the current position is in the hover rectangle...
            Vector allowedMoveDistance = new Vector(hoverWidth, hoverHeight);
            if (BasePositionInScreen != null && IsHover(allowedMoveDistance, BasePositionInScreen.Value, currentPositionInScreen))
                return;


            // Resets the base position and the base ticks.
            BasePositionInScreen = currentPositionInScreen;
            BaseTicks = DateTime.Now.Ticks;

            // Sets that it is not hover.
            SetIsHover(false);


            // If the hover event mode is once and the hover event is already raised in the target UI element.
            if (getHoverEventMode() == HoverEventMode.Once && IsRaisedAfterEnter)
                return;


            // Restarts the timer to raise Hover event.
            _hoverDelayInvoker.Value.Begin
            (
                () =>
                {
                    // Sets that it is hover.
                    SetIsHover(true);

                    // Raises the hover event.
                    RaiseHoverEvent(PointToScreen(getPosition()), DateTime.Now.Ticks);

                    // Sets the raised flag.
                    IsRaisedAfterEnter = true;

                    // If the hover event mode is repeat, restarts the timer.
                    if (getHoverEventMode() == HoverEventMode.Repeat)
                        _hoverDelayInvoker.Value.Begin(getHoverTime());
                },
                getHoverTime()
            );
        }

        /// <summary>
        /// Handles that a pointing device leaves the target UI element.
        /// This method must be called even if the leave event handler is already handled.
        /// </summary>
        public override void ProcessLeave()
        {
            base.ProcessLeave();

            // Stops the timer.
            if (_hoverDelayInvoker.IsValueCreated)
                _hoverDelayInvoker.Value.Cancel();
        }

        #endregion
    }

    #endregion


    #region DragHoverBehaviorImplementation

    /// <summary>
    /// Provides actual implementation to raise the DragHover event.
    /// </summary>
    internal class DragHoverImplementation : HoverImplementationBase
    {
        /// <summary>
        /// Whether the Hover event is raised at the BasePosition.
        /// This value is set to false if the pointing device leaves the hover rectangle(HoverWidth, HoverHeight).
        /// </summary>
        bool _isRaisedAtBasePosition;


        #region Constructors

        internal DragHoverImplementation(UIElement target, RoutedEvent previewHoverEvent, RoutedEvent hoverEvent, DependencyPropertyKey isHoverPropertyKey)
            : base(target, previewHoverEvent, hoverEvent, isHoverPropertyKey) { }

        #endregion


        #region Helpers

        /// <summary>
        /// Checks whether the elapsed time is enough to be recognized as hover.
        /// </summary>
        /// <param name="minElapsedTicks">The minimum elapsed ticks to be recognized as hover.</param>
        /// <param name="baseTicks">The base (start) ticks.</param>
        /// <param name="currentTicks">The current ticks.</param>
        /// <returns>True if it is hover, otherwise false.</returns>
        private static bool IsHover(long minElapsedTicks, long baseTicks, long currentTicks)
        {
            return currentTicks - baseTicks > minElapsedTicks;
        }

        #endregion


        #region Public methods

        /// <summary>
        /// Handles that the dragged pointing device enters the target UI element.
        /// This method must be called even if the enter event handler is already handled.
        /// </summary>
        public override void ProcessEnter()
        {
            base.ProcessEnter();

            // Resets the raised flag.
            _isRaisedAtBasePosition = false;
        }

        /// <summary>
        /// Handles that the dragged pointing device is over in the target UI element.
        /// For reference the DragOver event is raised periodically.
        /// </summary>
        /// <param name="currentPosition">The current pointing device position relative to the target UI element.</param>
        /// <param name="hoverEventMode">A HoverEventMode.</param>
        /// <param name="hoverTime">A HoverTime.</param>
        /// <param name="hoverWidth">A HoverWidth.</param> 
        /// <param name="hoverHeight">A HoverHeight.</param>
        public void ProcessOver(Point currentPosition, HoverEventMode hoverEventMode, TimeSpan hoverTime, double hoverWidth, double hoverHeight)
        {
            // Gets the point in screen coordinates.
            Point currentPositionInScreen = PointToScreen(currentPosition);


            // Checks whether the current position is in the hover rectangle...
            Vector allowedMoveDistance = new Vector(hoverWidth, hoverHeight);
            if (BasePositionInScreen == null || !IsHover(allowedMoveDistance, BasePositionInScreen.Value, currentPositionInScreen))
            {
                // Resets the base position related values.
                BasePositionInScreen = currentPositionInScreen;
                BaseTicks = DateTime.Now.Ticks;
                _isRaisedAtBasePosition = false;

                // Sets that it is not hover.
                SetIsHover(false);
                return;
            }


            // If the hover event mode is once and the hover event is already raised in the target UI element.
            if (hoverEventMode == HoverEventMode.Once && IsRaisedAfterEnter)
                return;

            // If the hover event mode is normal and the hover event is already raised at the BasePosition
            if (hoverEventMode == HoverEventMode.Normal && _isRaisedAtBasePosition)
                return;


            // Checks whether the elapsed ticks are greater than the hover time.
            long currentTicks = DateTime.Now.Ticks;
            if (!IsHover(hoverTime.Ticks, BaseTicks, currentTicks))
                return;


            // Sets that it is hover.
            SetIsHover(true);

            // Raises the Hover event.
            RaiseHoverEvent(currentPositionInScreen, currentTicks);

            // Sets the raised flag.
            IsRaisedAfterEnter = true;
            _isRaisedAtBasePosition = true;


            // Resets the base ticks.
            BaseTicks = DateTime.Now.Ticks;
        }

        #endregion
    }

    #endregion
}
