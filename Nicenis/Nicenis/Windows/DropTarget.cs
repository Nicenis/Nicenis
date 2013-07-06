/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.05.04
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows.Threading;
using System;
using System.Diagnostics;
using System.Windows;

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides functionalities related to drop target.
    /// </summary>
    public static class DropTarget
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

            DragHoverImplementation _dragHoverImplementation;

            /// <summary>
            /// The DragHoverImplementation.
            /// </summary>
            public DragHoverImplementation DragHoverImplementation
            {
                get
                {
                    if (_dragHoverImplementation == null)
                        _dragHoverImplementation = new DragHoverImplementation
                        (
                            _target,
                            DropTarget.PreviewDragHoverEvent,
                            DropTarget.DragHoverEvent,
                            DropTarget.IsDragHoverPropertyKey
                        );

                    return _dragHoverImplementation;
                }
            }


            DelayInvoker _leaveDelayInvoker;

            /// <summary>
            /// Delays the DragHoverImplementation.ProcessLeave call to ignore if any child element is involved.
            /// </summary>
            public DelayInvoker LeaveDelayInvoker
            {
                get
                {
                    if (_leaveDelayInvoker == null)
                    {
                        _leaveDelayInvoker = new DelayInvoker
                        (
                            () => ProcessLeave(_target),
                            TimeSpan.FromMilliseconds(50)
                        );
                    }

                    return _leaveDelayInvoker;
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
            typeof(DropTarget)
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
        /// The attached property to indicate whether the drop target related functionality is activated.
        /// </summary>
        public static readonly DependencyProperty IsActivatedProperty = DependencyProperty.RegisterAttached
        (
            "IsActivated",
            typeof(bool),
            typeof(DropTarget),
            new PropertyMetadata(false, IsActivatedProperty_Changed)
        );

        /// <summary>
        /// Gets a value that indicates whether the drop target related functionality is activated.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>True if it is activated; otherwise, false.</returns>
        public static bool GetIsActivated(UIElement obj)
        {
            return (bool)obj.GetValue(IsActivatedProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the drop target related functionality is activated.
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
            target.RemoveHandler(UIElement.PreviewDragEnterEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_PreviewDragEnter));
            target.PreviewDragOver -= IsActivatedProperty_PropertyHost_PreviewDragOver;
            target.RemoveHandler(UIElement.PreviewDragLeaveEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_PreviewDragLeave));
            target.RemoveHandler(UIElement.PreviewDropEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_PreviewDrop));

            if ((bool)e.NewValue)
            {
                // Attaches required event handlers.
                target.AddHandler(UIElement.PreviewDragEnterEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_PreviewDragEnter), true);
                target.PreviewDragOver += IsActivatedProperty_PropertyHost_PreviewDragOver;
                target.AddHandler(UIElement.PreviewDragLeaveEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_PreviewDragLeave), true);
                target.AddHandler(UIElement.PreviewDropEvent, new RoutedEventHandler(IsActivatedProperty_PropertyHost_PreviewDrop), true);
            }
        }

        private static void IsActivatedProperty_PropertyHost_PreviewDragEnter(object sender, RoutedEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Gets the context
            Context context = GetSafeContext(target);

            // If the LeaveDelayInvoker is enabled, it means that a child element is involved.
            // DragEnter and DragLeave that are occurred between a parent and a child element must be ignored.
            if (context.LeaveDelayInvoker.IsEnabled)
            {
                context.LeaveDelayInvoker.Cancel();
                return;
            }

            // Marks that it is drag over.
            SetIsDragOver(target, true);

            // Handles this event using the DragHoverImplementation.
            context.DragHoverImplementation.ProcessEnter();
        }

        private static void IsActivatedProperty_PropertyHost_PreviewDragOver(object sender, DragEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Handles this event using the DragHoverImplementation.
            GetSafeContext(target).DragHoverImplementation.ProcessOver
            (
                e.GetPosition(target),
                GetDragHoverEventMode(target),
                GetDragHoverTime(target),
                GetDragHoverWidth(target),
                GetDragHoverHeight(target)
            );
        }

        static void ProcessLeave(UIElement target)
        {
            Debug.Assert(target != null);

            // Marks that it is not drag over.
            SetIsDragOver(target, false);

            // Calls the DragHoverImplementation's ProcessLeave.
            GetSafeContext(target).DragHoverImplementation.ProcessLeave();
        }

        private static void IsActivatedProperty_PropertyHost_PreviewDragLeave(object sender, RoutedEventArgs e)
        {
            // Delays the leave processing to ignore if a child element is involved.
            (GetSafeContext((UIElement)sender)).LeaveDelayInvoker.Begin();
        }

        private static void IsActivatedProperty_PropertyHost_PreviewDrop(object sender, RoutedEventArgs e)
        {
            UIElement target = sender as UIElement;

            // Cancels the delayed leave if it is enabled.
            GetSafeContext(target).LeaveDelayInvoker.Cancel();

            // Executes the leave processing.
            ProcessLeave(target);
        }

        #endregion


        #region IsDragOver ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for a value that indicates whether the dragged item is over.
        /// </summary>
        private static readonly DependencyPropertyKey IsDragOverPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragOver",
            typeof(bool),
            typeof(DropTarget),
            new PropertyMetadata(false)
        );

        /// <summary>
        /// The readonly attached property for a value that indicates whether the dragged item is over.
        /// </summary>
        public static readonly DependencyProperty IsDragOverProperty = IsDragOverPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the dragged item is over.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A value that indicates whether the dragged item is over.</returns>
        public static bool GetIsDragOver(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragOverProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the dragged item is over.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the dragged item is over.</param>
        private static void SetIsDragOver(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragOverPropertyKey, value);
        }

        #endregion


        #region IsDragHover ReadOnly Attached Property

        /// <summary>
        /// The readonly attached property key for a value that indicates whether the dragged item is hover.
        /// </summary>
        private static readonly DependencyPropertyKey IsDragHoverPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragHover",
            typeof(bool),
            typeof(DropTarget),
            new PropertyMetadata(false)
        );

        /// <summary>
        /// The readonly attached property for a value that indicates whether the dragged item is hover.
        /// </summary>
        public static readonly DependencyProperty IsDragHoverProperty = IsDragHoverPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets a value that indicates whether the dragged item is hover.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the dragged item is hover.</param>
        public static bool GetIsDragHover(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragHoverProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the dragged item is hover.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that indicates whether the dragged item is hover.</param>
        private static void SetIsDragHover(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragHoverPropertyKey, value);
        }

        #endregion


        #region DragHoverEventMode Attached Property

        /// <summary>
        /// The attached property to describe how drag hover event is raised.
        /// </summary>
        /// <seealso cref="HoverEventMode"/>
        public static readonly DependencyProperty DragHoverEventModeProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverEventMode",
            typeof(HoverEventMode),
            typeof(DropTarget),
            new PropertyMetadata(HoverEventMode.Normal)
        );

        /// <summary>
        /// Gets a value that describes how drag hover event is raised.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>A value that describes how drag hover event is raised.</returns>
        /// <seealso cref="HoverEventMode"/>
        public static HoverEventMode GetDragHoverEventMode(DependencyObject obj)
        {
            return (HoverEventMode)obj.GetValue(DragHoverEventModeProperty);
        }

        /// <summary>
        /// Sets a value that describes how drag hover event is raised.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="value">A value that describes how drag hover event is raised.</param>
        /// <seealso cref="HoverEventMode"/>
        public static void SetDragHoverEventMode(DependencyObject obj, HoverEventMode value)
        {
            obj.SetValue(DragHoverEventModeProperty, value);
        }

        #endregion


        #region DragHoverTime Attached Property

        /// <summary>
        /// The attached property for the time, in milliseconds, that the dragged item must remain in the hover rectangle to generate a drag hover event.
        /// </summary>
        public static readonly DependencyProperty DragHoverTimeProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverTime",
            typeof(TimeSpan),
            typeof(DropTarget),
            new PropertyMetadata(SystemParameters.MouseHoverTime)
        );

        /// <summary>
        /// Gets the time, in milliseconds, that the dragged item must remain in the hover rectangle to generate a drag hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The time, in milliseconds, that the dragged item must remain in the hover rectangle to generate a drag hover event.</returns>
        public static TimeSpan GetDragHoverTime(DependencyObject obj)
        {
            return (TimeSpan)obj.GetValue(DragHoverTimeProperty);
        }

        /// <summary>
        /// Sets the time, in milliseconds, that the dragged item must remain in the hover rectangle to generate a drag hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The time, in milliseconds, that the dragged item must remain in the hover rectangle to generate a drag hover event.</returns>
        public static void SetDragHoverTime(DependencyObject obj, TimeSpan value)
        {
            obj.SetValue(DragHoverTimeProperty, value);
        }

        #endregion


        #region DragHoverWidth Attached Property

        /// <summary>
        /// The attached property for the width, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.
        /// </summary>
        public static readonly DependencyProperty DragHoverWidthProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverWidth",
            typeof(double),
            typeof(DropTarget),
            new PropertyMetadata(SystemParameters.MouseHoverWidth)
        );

        /// <summary>
        /// Gets the width, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The width, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.</returns>
        public static double GetDragHoverWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(DragHoverWidthProperty);
        }

        /// <summary>
        /// Sets the width, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The width, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.</returns>
        public static void SetDragHoverWidth(DependencyObject obj, double value)
        {
            obj.SetValue(DragHoverWidthProperty, value);
        }

        #endregion


        #region DragHoverHeight Attached Property

        /// <summary>
        /// The attached property for the height, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.
        /// </summary>
        public static readonly DependencyProperty DragHoverHeightProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverHeight",
            typeof(double),
            typeof(DropTarget),
            new PropertyMetadata(SystemParameters.MouseHoverHeight)
        );

        /// <summary>
        /// Gets the height, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The height, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.</returns>
        public static double GetDragHoverHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(DragHoverHeightProperty);
        }

        /// <summary>
        /// Sets the height, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <returns>The height, in pixels, of the rectangle within which the dragged item has to stay to generate a drag hover event.</returns>
        public static void SetDragHoverHeight(DependencyObject obj, double value)
        {
            obj.SetValue(DragHoverHeightProperty, value);
        }

        #endregion


        #region DragHover Event Related

        /// <summary>
        /// Identifies the PreviewDragHover routed event that is raised when dragged item is hover.
        /// </summary>
        public static readonly RoutedEvent PreviewDragHoverEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDragHover",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<HoverEventArgs>),
            typeof(DropTarget)
        );

        /// <summary>
        /// Adds an event handler for the PreviewDragHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(PreviewDragHoverEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewDragHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDragHoverEvent, handler);
        }


        /// <summary>
        /// Identifies the DragHover routed event that is raised when dragged item is hover.
        /// </summary>
        public static readonly RoutedEvent DragHoverEvent = EventManager.RegisterRoutedEvent
        (
            "DragHover",
            RoutingStrategy.Bubble,
            typeof(EventHandler<HoverEventArgs>),
            typeof(DropTarget)
        );

        /// <summary>
        /// Adds an event handler for the DragHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(DragHoverEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the DragHover event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(DragHoverEvent, handler);
        }

        #endregion
    }
}
