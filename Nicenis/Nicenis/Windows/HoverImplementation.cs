/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.05.05
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Diagnostics;
using Nicenis.Windows.Threading;
using System;
using System.Diagnostics;
using System.Windows;

namespace Nicenis.Windows
{
    #region Hover Event Arguments Related

    /// <summary>
    /// Contains arguments for the Hover event.
    /// </summary>
    public class HoverEventArgs : RoutedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the HoverEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="basePosition">The base position for recognizing hover action.</param>
        /// <param name="baseTicks">The ticks when the BasePosition is set.</param>
        /// <param name="hoveredPosition">The position at which the hover event is occurred.</param>
        /// <param name="hoveredTicks">The ticks when the hover event is occurred.</param>
        internal HoverEventArgs(RoutedEvent routedEvent, object source,
                Point basePosition, long baseTicks, Point hoveredPosition, long hoveredTicks)
            : base(routedEvent, source)
        {
            BasePosition = basePosition;
            BaseTicks = baseTicks;
            HoveredPosition = hoveredPosition;
            HoveredTicks = hoveredTicks;
        }

        #endregion


        #region Properties

        /// <summary>
        /// The base position for recognizing hover action.
        /// </summary>
        public Point BasePosition { get; private set; }

        /// <summary>
        /// The ticks when the BasePosition is set.
        /// </summary>
        public long BaseTicks { get; private set; }

        /// <summary>
        /// The position at which the hover event is occurred.
        /// </summary>
        public Point HoveredPosition { get; private set; }

        /// <summary>
        /// The ticks when the hover event is occurred.
        /// </summary>
        public long HoveredTicks { get; private set; }

        #endregion
    }


    /// <summary>
    /// Contains arguments for the MouseHover event.
    /// </summary>
    public class MouseHoverEventArgs : HoverEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the MouseHoverEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="basePosition">The base position for recognizing hover action.</param>
        /// <param name="baseTicks">The ticks when the BasePosition is set.</param>
        /// <param name="hoveredPosition">The position at which the hover event is occurred.</param>
        /// <param name="hoveredTicks">The ticks when the hover event is occurred.</param>
        internal MouseHoverEventArgs(RoutedEvent routedEvent, object source,
                Point basePosition, long baseTicks, Point hoveredPosition, long hoveredTicks)
            : base(routedEvent, source, basePosition, baseTicks, hoveredPosition, hoveredTicks) { }

        #endregion
    }


    /// <summary>
    /// Contains arguments for the DragHover event.
    /// </summary>
    public class DragHoverEventArgs : HoverEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragHoverEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="basePosition">The base position for recognizing hover action.</param>
        /// <param name="baseTicks">The ticks when the BasePosition is set.</param>
        /// <param name="hoveredPosition">The position at which the hover event is occurred.</param>
        /// <param name="hoveredTicks">The ticks when the hover event is occurred.</param>
        internal DragHoverEventArgs(RoutedEvent routedEvent, object source,
                Point basePosition, long baseTicks, Point hoveredPosition, long hoveredTicks)
            : base(routedEvent, source, basePosition, baseTicks, hoveredPosition, hoveredTicks) { }

        #endregion
    }

    #endregion


    #region HoverEventMode

    /// <summary>
    /// Describe how the hover event is raised.
    /// </summary>
    public enum HoverEventMode
    {
        /// <summary>
        /// The hover event is raised when the hover condition is met
        /// and it is not raised again if pointing device is still in the target element.
        /// To raise the hover event again, the pointing device must be left out
        /// and reenter the target element and the hover condition is met.
        /// </summary>
        Once,

        /// <summary>
        /// The hover event is raised when the hover condition is met.
        /// </summary>
        Normal,

        /// <summary>
        /// The hover event is raised when the hover condition is met
        /// and it is repeated until the hover condition is broken.
        /// The interval is HoverTime.
        /// </summary>
        Repeat,
    }

    #endregion


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


        #region Constructors

        /// <summary>
        /// Initializes a new instance of the HoverImplementationBase class.
        /// </summary>
        /// <param name="target">The target element for the hover event.</param>
        internal HoverImplementationBase(UIElement target)
        {
            Verify.ParameterIsNotNull(target, "target");
            _target = target;
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
        /// Calls the hover callback action.
        /// </summary>
        /// <param name="hoverCallback">A callback action that is called when Hover is detected.</param>
        /// <param name="hoveredPositionInScreen">The hovered position in screen coordinates.</param>
        /// <param name="hoveredTicks">The hovered ticks.</param>
        protected void CallHoverCallback(Action<Point, long, Point, long> hoverCallback, Point hoveredPositionInScreen, long hoveredTicks)
        {
            Debug.Assert(hoverCallback != null);
            Debug.Assert(BasePositionInScreen != null);

            // Calls the callback action.
            hoverCallback
            (
                PointFromScreen(BasePositionInScreen.Value),
                BaseTicks,
                PointFromScreen(hoveredPositionInScreen),
                hoveredTicks
            );
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
        /// <param name="setIsHover">An action that sets a IsHover.</param>
        public virtual void ProcessEnter(Action<bool> setIsHover)
        {
            Verify.ParameterIsNotNull(setIsHover, "setIsHover");

            // Resets the base position.
            BasePositionInScreen = null;

            // Resets the raised flag.
            IsRaisedAfterEnter = false;

            // Sets ths IsHover to false.
            setIsHover(false);
        }

        /// <summary>
        /// Handles that a pointing device leaves the target UI element.
        /// This method must be called even if the leave event handler is already handled.
        /// </summary>
        /// <param name="setIsHover">An action that sets a IsHover.</param>
        public virtual void ProcessLeave(Action<bool> setIsHover)
        {
            Verify.ParameterIsNotNull(setIsHover, "setIsHover");

            // Sets ths IsHover to false.
            setIsHover(false);
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

        /// <summary>
        /// Initializes a new instance of the HoverBehaviorImplementation class.
        /// </summary>
        /// <param name="target">The target element for the hover event.</param>
        internal HoverBehaviorImplementation(UIElement target) : base(target) { }

        #endregion


        #region Public methods

        /// <summary>
        /// Handles that a pointing device enters the target UI element.
        /// This method must be called even if the enter event handler is already handled.
        /// </summary>
        /// <param name="setIsHover">An action that sets a IsHover.</param>
        public override void ProcessEnter(Action<bool> setIsHover)
        {
            base.ProcessEnter(setIsHover);

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
        /// <param name="setIsHover">An action that sets a IsHover.</param>
        /// <param name="hoverCallback">A callback action that is called when Hover is detected.</param>
        public void ProcessMove(Point currentPosition, double hoverWidth, double hoverHeight,
                                    Func<Point> getPosition, Func<HoverEventMode> getHoverEventMode, Func<TimeSpan> getHoverTime,
                                    Action<bool> setIsHover, Action<Point, long, Point, long> hoverCallback)
        {
            Verify.ParameterIsNotNull(getPosition, "getPosition");
            Verify.ParameterIsNotNull(getHoverEventMode, "getHoverEventMode");
            Verify.ParameterIsNotNull(getHoverTime, "getHoverTime");
            Verify.ParameterIsNotNull(setIsHover, "setIsHover");
            Verify.ParameterIsNotNull(hoverCallback, "hoverCallback");


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
            setIsHover(false);


            // If the hover event mode is once and the hover event is already raised in the target UI element.
            if (getHoverEventMode() == HoverEventMode.Once && IsRaisedAfterEnter)
                return;


            // Restarts the timer to raise Hover event.
            _hoverDelayInvoker.Value.Begin
            (
                () =>
                {
                    // Sets that it is hover.
                    setIsHover(true);

                    // Calls the hover callback.
                    CallHoverCallback(hoverCallback, PointToScreen(getPosition()), DateTime.Now.Ticks);

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
        /// <param name="setIsHover">An action that sets a IsHover.</param>
        public override void ProcessLeave(Action<bool> setIsHover)
        {
            base.ProcessLeave(setIsHover);

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

        /// <summary>
        /// Initializes a new instance of the DragHoverImplementation class.
        /// </summary>
        /// <param name="target">The target element for the hover event.</param>
        internal DragHoverImplementation(UIElement target) : base(target) { }

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
        /// <param name="setIsHover">An action that sets a IsHover.</param>
        public override void ProcessEnter(Action<bool> setIsHover)
        {
            base.ProcessEnter(setIsHover);

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
        /// <param name="setIsHover">An action that sets a IsHover.</param>
        /// <param name="hoverCallback">A callback action that is called when Hover is detected.</param>
        public void ProcessOver(Point currentPosition, HoverEventMode hoverEventMode, TimeSpan hoverTime, double hoverWidth, double hoverHeight,
                                    Action<bool> setIsHover, Action<Point, long, Point, long> hoverCallback)
        {
            Verify.ParameterIsNotNull(setIsHover, "setIsHover");
            Verify.ParameterIsNotNull(hoverCallback, "hoverCallback");


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
                setIsHover(false);
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
            setIsHover(true);

            // Calls the hover callback.
            CallHoverCallback(hoverCallback, currentPositionInScreen, currentTicks);

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
