/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.05.01
 * Version	$Id$
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
                get
                {
                    if (_hoverBehaviorImplementation == null)
                        _hoverBehaviorImplementation = new HoverBehaviorImplementation
                        (
                            _target,
                            HoverBehavior.PreviewHoverEvent,
                            HoverBehavior.HoverEvent,
                            HoverBehavior.IsHoverPropertyKey
                        );

                    return _hoverBehaviorImplementation;
                }
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
        /// <param name="value">A Context instance.</param>
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
            // Handles this event using the HoverBehaviorImplementation.
            GetSafeContext((UIElement)sender).HoverBehaviorImplementation.ProcessEnter();
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
                () => GetHoverTime(target)
            );
        }

        private static void IsActivatedProperty_PropertyHost_MouseLeave(object sender, RoutedEventArgs e)
        {
            // Handles this event using the HoverBehaviorImplementation.
            GetSafeContext((UIElement)sender).HoverBehaviorImplementation.ProcessLeave();
        }

        #endregion


        #region IsHover ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for a value that indicates whether the pointing device is hover.
        /// </summary>
        private static readonly DependencyPropertyKey IsHoverPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsHover",
            typeof(bool),
            typeof(HoverBehavior),
            new PropertyMetadata(false)
        );

        /// <summary>
        /// The readonly attached property for a value that indicates whether the pointing device is hover.
        /// </summary>
        public static readonly DependencyProperty IsHoverProperty = IsHoverPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the pointing device is hover.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the pointing device is hover.</param>
        public static bool GetIsHover(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHoverProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the pointing device is hover.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the pointing device is hover.</param>
        private static void SetIsHover(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHoverPropertyKey, value);
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
        /// <returns>The time, in milliseconds, that the pointing device must remain in the hover rectangle to generate a hover event.</returns>
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
        /// <returns>The width, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.</returns>
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
        /// <returns>The height, in pixels, of the rectangle within which the pointing device has to stay to generate a hover event.</returns>
        public static void SetHoverHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HoverHeightProperty, value);
        }

        #endregion


        #region Hover Event Related

        /// <summary>
        /// Identifies the PreviewHover routed event that is raised when pointing device is hover.
        /// </summary>
        public static readonly RoutedEvent PreviewHoverEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewHover",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<HoverEventArgs>),
            typeof(HoverBehavior)
        );

        /// <summary>
        /// Adds an event handler for the PreviewHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(PreviewHoverEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(PreviewHoverEvent, handler);
        }


        /// <summary>
        /// Identifies the Hover routed event that is raised when pointing device is hover.
        /// </summary>
        public static readonly RoutedEvent HoverEvent = EventManager.RegisterRoutedEvent
        (
            "Hover",
            RoutingStrategy.Bubble,
            typeof(EventHandler<HoverEventArgs>),
            typeof(HoverBehavior)
        );

        /// <summary>
        /// Adds an event handler for the Hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(HoverEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the Hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(HoverEvent, handler);
        }

        #endregion
    }
}
