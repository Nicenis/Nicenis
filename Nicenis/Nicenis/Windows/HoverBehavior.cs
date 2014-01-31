/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.05.01
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides functionalities related to hover.
    /// </summary>
    public static class HoverBehavior
    {
        #region Inner Types

        /// <summary>
        /// The storage to save context related information.
        /// </summary>
        private class Context
        {
            /// <summary>
            /// The target element to raise the hover event.
            /// This variable is set to non-null value in the Constructor.
            /// </summary>
            UIElement _target;


            #region Constructors

            /// <summary>
            /// Initializes a new instance of the Context class.
            /// </summary>
            /// <param name="target">The target element to raise the hover event. Null is not allowed.</param>
            public Context(UIElement target)
            {
                Debug.Assert(target != null);
                _target = target;
            }

            #endregion


            #region Members

            HoverBehaviorImplementation _hoverBehaviorImplementation;

            /// <summary>
            /// The HoverBehaviorImplementation.
            /// </summary>
            public HoverBehaviorImplementation HoverBehaviorImplementation
            {
                get { return _hoverBehaviorImplementation ?? (_hoverBehaviorImplementation = new HoverBehaviorImplementation(_target)); }
            }

            #endregion
        }

        #endregion


        #region Context Attached Property

        /// <summary>
        /// The attached property to store internal context information.
        /// </summary>
        private static readonly DependencyProperty ContextProperty = DependencyProperty.RegisterAttached
        (
            "Context",
            typeof(Context),
            typeof(HoverBehavior)
        );

        /// <summary>
        /// Gets a value that stores internal context information.
        /// </summary>
        /// <param name="obj">A DependencyObject instance.</param>
        /// <returns>A Context instance.</returns>
        private static Context GetContext(DependencyObject obj)
        {
            return (Context)obj.GetValue(ContextProperty);
        }

        /// <summary>
        /// Sets a value that stores internal context information.
        /// </summary>
        /// <param name="obj">A DependencyObject instance.</param>
        /// <param name="value">A Context instance.</param>
        private static void SetContext(DependencyObject obj, Context value)
        {
            obj.SetValue(ContextProperty, value);
        }

        /// <summary>
        /// Gets a value that stores internal context information.
        /// If it is not set, new context is created and set.
        /// </summary>
        /// <param name="obj">A DependencyObject instance.</param>
        private static Context GetSafeContext(UIElement obj)
        {
            Debug.Assert(obj != null);

            Context context = GetContext(obj);

            if (context == null)
                SetContext(obj, context = new Context(obj));

            return context;
        }

        #endregion


        #region IsActivated Attached Property

        /// <summary>
        /// The attached property to indicate whether the hover behavior is activated.
        /// </summary>
        public static readonly DependencyProperty IsActivatedProperty = DependencyProperty.RegisterAttached
        (
            "IsActivated",
            typeof(bool),
            typeof(HoverBehavior),
            new PropertyMetadata(false, IsActivatedProperty_Changed)
        );

        /// <summary>
        /// Gets a value that indicates whether the hover behavior is activated.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>True if it is activated; otherwise, false.</returns>
        public static bool GetIsActivated(UIElement obj)
        {
            return (bool)obj.GetValue(IsActivatedProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the hover behavior is activated.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the drop target related functionality is activated.</param>
        public static void SetIsActivated(UIElement obj, bool value)
        {
            obj.SetValue(IsActivatedProperty, value);
        }

        private static void IsActivatedProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement target = d as UIElement;

            // Detaches the previous event handlers if it exists.
            target.RemoveHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_MouseEnter));
            target.PreviewMouseMove -= IsActivatedProperty_PropertyHost_PreviewMouseMove;
            target.RemoveHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_MouseLeave));

            if ((bool)e.NewValue)
            {
                // Attaches required event handlers.
                target.AddHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_MouseEnter), true);
                target.PreviewMouseMove += IsActivatedProperty_PropertyHost_PreviewMouseMove;
                target.AddHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_MouseLeave), true);
            }
        }

        private static void IsActivatedProperty_PropertyHost_MouseEnter(object sender, RoutedEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Handles this event using the HoverBehaviorImplementation.
            GetSafeContext(target).HoverBehaviorImplementation.ProcessEnter
            (
                isHover => SetIsMouseHover(target, isHover)
            );
        }

        private static void IsActivatedProperty_PropertyHost_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Handles this event using the HoverBehaviorImplementation.
            GetSafeContext(target).HoverBehaviorImplementation.ProcessMove
            (
                e.GetPosition(target),
                GetHoverWidth(target),
                GetHoverHeight(target),
                () => Mouse.GetPosition(target),
                () => GetHoverEventMode(target),
                () => GetHoverTime(target),
                isHover => SetIsMouseHover(target, isHover),
                (basePosition, baseTicks, hoveredPosition, hoveredTicks) =>
                {
                    // Creates an event argument.
                    MouseHoverEventArgs eventArgs = new MouseHoverEventArgs
                    (
                        PreviewMouseHoverEvent,
                        target,
                        basePosition,
                        baseTicks,
                        hoveredPosition,
                        hoveredTicks
                    );

                    // Raises the PreviewMouseHoverEvent routed event.
                    target.RaiseEvent(eventArgs);

                    // Raises the MouseHoverEvent routed event.
                    eventArgs.RoutedEvent = MouseHoverEvent;
                    target.RaiseEvent(eventArgs);
                }
            );
        }

        private static void IsActivatedProperty_PropertyHost_MouseLeave(object sender, RoutedEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Handles this event using the HoverBehaviorImplementation.
            GetSafeContext(target).HoverBehaviorImplementation.ProcessLeave
            (
                isHover => SetIsMouseHover(target, isHover)
            );
        }

        #endregion


        #region IsMouseHover ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for a value that indicates whether the mouse is hovering in the target element.
        /// </summary>
        private static readonly DependencyPropertyKey IsMouseHoverPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsMouseHover",
            typeof(bool),
            typeof(HoverBehavior),
            new PropertyMetadata(false)
        );

        /// <summary>
        /// The readonly attached property for a value that indicates whether the mouse is hovering in the target element.
        /// </summary>
        public static readonly DependencyProperty IsMouseHoverProperty = IsMouseHoverPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the mouse is hovering in the target element.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A value that indicates whether the mouse is hovering in the target element.</returns>
        public static bool GetIsMouseHover(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMouseHoverProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the mouse is hovering in the target element.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the mouse is hovering in the target element.</param>
        private static void SetIsMouseHover(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMouseHoverPropertyKey, value);
        }

        #endregion


        #region HoverEventMode Attached Property

        /// <summary>
        /// The attached property to describe how hover event is raised.
        /// </summary>
        /// <seealso cref="HoverEventMode"/>
        public static readonly DependencyProperty HoverEventModeProperty = DependencyProperty.RegisterAttached
        (
            "HoverEventMode",
            typeof(HoverEventMode),
            typeof(HoverBehavior),
            new PropertyMetadata(HoverEventMode.Normal)
        );

        /// <summary>
        /// Gets a value that describes how hover event is raised.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A value that describes how hover event is raised.</returns>
        /// <seealso cref="HoverEventMode"/>
        public static HoverEventMode GetHoverEventMode(DependencyObject obj)
        {
            return (HoverEventMode)obj.GetValue(HoverEventModeProperty);
        }

        /// <summary>
        /// Sets a value that describes how hover event is raised.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that describes how hover event is raised.</param>
        /// <seealso cref="HoverEventMode"/>
        public static void SetHoverEventMode(DependencyObject obj, HoverEventMode value)
        {
            obj.SetValue(HoverEventModeProperty, value);
        }

        #endregion


        #region HoverTime Attached Property

        /// <summary>
        /// The attached property for the time, in milliseconds, that the pointing device must remain in the hover rectangle to generate a hover event.
        /// </summary>
        public static readonly DependencyProperty HoverTimeProperty = DependencyProperty.RegisterAttached
        (
            "HoverTime",
            typeof(TimeSpan),
            typeof(HoverBehavior),
            new PropertyMetadata(SystemParameters.MouseHoverTime)
        );

        /// <summary>
        /// Gets the time, in milliseconds, that the pointing device must remain in the hover rectangle to generate a hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The time, in milliseconds, that the pointing device must remain in the hover rectangle to generate a hover event.</returns>
        public static TimeSpan GetHoverTime(DependencyObject obj)
        {
            return (TimeSpan)obj.GetValue(HoverTimeProperty);
        }

        /// <summary>
        /// Sets the time, in milliseconds, that the pointing device must remain in the hover rectangle to generate a hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The time, in milliseconds, that the pointing device must remain in the hover rectangle to generate a hover event.</param>
        public static void SetHoverTime(DependencyObject obj, TimeSpan value)
        {
            obj.SetValue(HoverTimeProperty, value);
        }

        #endregion


        #region HoverHeight Attached Property

        /// <summary>
        /// The attached property for the width, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.
        /// </summary>
        public static readonly DependencyProperty HoverWidthProperty = DependencyProperty.RegisterAttached
        (
            "HoverWidth",
            typeof(double),
            typeof(HoverBehavior),
            new PropertyMetadata(SystemParameters.MouseHoverWidth)
        );

        /// <summary>
        /// Gets the width, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The width, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.</returns>
        public static double GetHoverWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(HoverWidthProperty);
        }

        /// <summary>
        /// Sets the width, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The width, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.</param>
        public static void SetHoverWidth(DependencyObject obj, double value)
        {
            obj.SetValue(HoverWidthProperty, value);
        }

        #endregion


        #region HoverHeight Attached Property

        /// <summary>
        /// The attached property for the height, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.
        /// </summary>
        public static readonly DependencyProperty HoverHeightProperty = DependencyProperty.RegisterAttached
        (
            "HoverHeight",
            typeof(double),
            typeof(HoverBehavior),
            new PropertyMetadata(SystemParameters.MouseHoverHeight)
        );

        /// <summary>
        /// Gets the height, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The height, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.</returns>
        public static double GetHoverHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HoverHeightProperty);
        }

        /// <summary>
        /// Sets the height, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">The height, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.</param>
        public static void SetHoverHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HoverHeightProperty, value);
        }

        #endregion


        #region MouseHover Event Related

        /// <summary>
        /// Identifies the PreviewMouseHover routed event that is raised when the mouse is hover.
        /// </summary>
        public static readonly RoutedEvent PreviewMouseHoverEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewMouseHover",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<MouseHoverEventArgs>),
            typeof(HoverBehavior)
        );

        /// <summary>
        /// Adds an event handler for the PreviewMouseHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewMouseHoverHandler(UIElement obj, EventHandler<MouseHoverEventArgs> handler)
        {
            obj.AddHandler(PreviewMouseHoverEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewMouseHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewMouseHoverHandler(UIElement obj, EventHandler<MouseHoverEventArgs> handler)
        {
            obj.RemoveHandler(PreviewMouseHoverEvent, handler);
        }


        /// <summary>
        /// Identifies the MouseHover routed event that is raised when the mouse is hover.
        /// </summary>
        public static readonly RoutedEvent MouseHoverEvent = EventManager.RegisterRoutedEvent
        (
            "MouseHover",
            RoutingStrategy.Bubble,
            typeof(EventHandler<MouseHoverEventArgs>),
            typeof(HoverBehavior)
        );

        /// <summary>
        /// Adds an event handler for the MouseHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddMouseHoverHandler(UIElement obj, EventHandler<MouseHoverEventArgs> handler)
        {
            obj.AddHandler(MouseHoverEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the MouseHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveMouseHoverHandler(UIElement obj, EventHandler<MouseHoverEventArgs> handler)
        {
            obj.RemoveHandler(MouseHoverEvent, handler);
        }

        #endregion
    }
}
