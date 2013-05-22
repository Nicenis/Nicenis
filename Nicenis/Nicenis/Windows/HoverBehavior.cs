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
        #region Inner types

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

        private static readonly DependencyProperty ContextProperty = DependencyProperty.RegisterAttached
        (
            "Context",
            typeof(Context),
            typeof(HoverBehavior)
        );

        private static Context GetContext(DependencyObject obj)
        {
            return (Context)obj.GetValue(ContextProperty);
        }

        private static void SetContext(DependencyObject obj, Context value)
        {
            obj.SetValue(ContextProperty, value);
        }

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

        public static readonly DependencyProperty IsActivatedProperty = DependencyProperty.RegisterAttached
        (
            "IsActivated",
            typeof(bool),
            typeof(HoverBehavior),
            new PropertyMetadata(false, HoverBehavior_IsActivatedChanged)
        );

        public static bool GetIsActivated(UIElement obj)
        {
            return (bool)obj.GetValue(IsActivatedProperty);
        }

        public static void SetIsActivated(UIElement obj, bool value)
        {
            obj.SetValue(IsActivatedProperty, value);
        }

        private static void HoverBehavior_IsActivatedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIElement target = d as UIElement;

            // Detaches the previous event handlers if it exists.
            target.RemoveHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(HoverBehavior_IsActivated_MouseEnter));
            target.PreviewMouseMove -= HoverBehavior_IsActivated_PreviewMouseMove;
            target.RemoveHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(HoverBehavior_IsActivated_MouseLeave));

            if ((bool)e.NewValue)
            {
                // Attaches required event handlers.
                target.AddHandler(UIElement.MouseEnterEvent, new RoutedEventHandler(HoverBehavior_IsActivated_MouseEnter), true);
                target.PreviewMouseMove += HoverBehavior_IsActivated_PreviewMouseMove;
                target.AddHandler(UIElement.MouseLeaveEvent, new RoutedEventHandler(HoverBehavior_IsActivated_MouseLeave), true);
            }
        }

        private static void HoverBehavior_IsActivated_MouseEnter(object sender, RoutedEventArgs e)
        {
            // Handles this event using the HoverBehaviorImplementation.
            GetSafeContext((UIElement)sender).HoverBehaviorImplementation.ProcessEnter();
        }

        private static void HoverBehavior_IsActivated_PreviewMouseMove(object sender, MouseEventArgs e)
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

        private static void HoverBehavior_IsActivated_MouseLeave(object sender, RoutedEventArgs e)
        {
            // Handles this event using the HoverBehaviorImplementation.
            GetSafeContext((UIElement)sender).HoverBehaviorImplementation.ProcessLeave();
        }

        #endregion


        #region IsHover ReadOnly Attached Property

        private static readonly DependencyPropertyKey IsHoverPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsHover",
            typeof(bool),
            typeof(HoverBehavior),
            new PropertyMetadata(false)
        );

        public static readonly DependencyProperty IsHoverProperty = IsHoverPropertyKey.DependencyProperty;

        public static bool GetIsHover(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHoverProperty);
        }

        private static void SetIsHover(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHoverPropertyKey, value);
        }

        #endregion


        #region HoverEventMode Attached Property

        public static readonly DependencyProperty HoverEventModeProperty = DependencyProperty.RegisterAttached
        (
            "HoverEventMode",
            typeof(HoverEventMode),
            typeof(HoverBehavior),
            new PropertyMetadata(HoverEventMode.Normal)
        );

        public static HoverEventMode GetHoverEventMode(DependencyObject obj)
        {
            return (HoverEventMode)obj.GetValue(HoverEventModeProperty);
        }

        public static void SetHoverEventMode(DependencyObject obj, HoverEventMode value)
        {
            obj.SetValue(HoverEventModeProperty, value);
        }

        #endregion


        #region HoverTime Attached Property

        public static readonly DependencyProperty HoverTimeProperty = DependencyProperty.RegisterAttached
        (
            "HoverTime",
            typeof(TimeSpan),
            typeof(HoverBehavior),
            new PropertyMetadata(SystemParameters.MouseHoverTime)
        );

        public static TimeSpan GetHoverTime(DependencyObject obj)
        {
            return (TimeSpan)obj.GetValue(HoverTimeProperty);
        }

        public static void SetHoverTime(DependencyObject obj, TimeSpan value)
        {
            obj.SetValue(HoverTimeProperty, value);
        }

        #endregion


        #region HoverHeight Attached Property

        public static readonly DependencyProperty HoverWidthProperty = DependencyProperty.RegisterAttached
        (
            "HoverWidth",
            typeof(double),
            typeof(HoverBehavior),
            new PropertyMetadata(SystemParameters.MouseHoverWidth)
        );

        public static double GetHoverWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(HoverWidthProperty);
        }

        public static void SetHoverWidth(DependencyObject obj, double value)
        {
            obj.SetValue(HoverWidthProperty, value);
        }

        #endregion


        #region HoverHeight Attached Property

        public static readonly DependencyProperty HoverHeightProperty = DependencyProperty.RegisterAttached
        (
            "HoverHeight",
            typeof(double),
            typeof(HoverBehavior),
            new PropertyMetadata(SystemParameters.MouseHoverHeight)
        );

        public static double GetHoverHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(HoverHeightProperty);
        }

        public static void SetHoverHeight(DependencyObject obj, double value)
        {
            obj.SetValue(HoverHeightProperty, value);
        }

        #endregion


        #region Hover event related

        public static readonly RoutedEvent PreviewHoverEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewHover",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<HoverEventArgs>),
            typeof(HoverBehavior)
        );

        public static void AddPreviewHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(PreviewHoverEvent, handler);
        }

        public static void RemovePreviewHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(PreviewHoverEvent, handler);
        }


        public static readonly RoutedEvent HoverEvent = EventManager.RegisterRoutedEvent
        (
            "Hover",
            RoutingStrategy.Bubble,
            typeof(EventHandler<HoverEventArgs>),
            typeof(HoverBehavior)
        );

        public static void AddHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(HoverEvent, handler);
        }

        public static void RemoveHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(HoverEvent, handler);
        }

        #endregion
    }
}
