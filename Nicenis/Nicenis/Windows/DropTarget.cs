/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.05.04
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows.Threading;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Nicenis.Windows
{
    public static class DropTarget
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
            /// Delays the DragHoverImplementation.ProcessLeave call to ignore if a child element is involved.
            /// </summary>
            public DelayInvoker LeaveDelayInvoker
            {
                get
                {
                    if (_leaveDelayInvoker == null)
                    {
                        _leaveDelayInvoker = new DelayInvoker
                        (
                            () =>
                            {
                                // Marks that it is not drag over.
                                SetIsDragOver(_target, false);

                                // Calls the ProcessLeave.
                                DragHoverImplementation.ProcessLeave();
                            },
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

        private static readonly DependencyProperty ContextProperty = DependencyProperty.RegisterAttached
        (
            "Context",
            typeof(Context),
            typeof(DropTarget)
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
            typeof(DropTarget),
            new PropertyMetadata(false, IsActivatedProperty_Changed)
        );

        public static bool GetIsActivated(UIElement obj)
        {
            return (bool)obj.GetValue(IsActivatedProperty);
        }

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

        private static void IsActivatedProperty_PropertyHost_PreviewDragLeave(object sender, RoutedEventArgs e)
        {
            // Delays the leave processing to ignore if a child element is involved.
            (GetSafeContext((UIElement)sender)).LeaveDelayInvoker.Begin();
        }

        private static void IsActivatedProperty_PropertyHost_PreviewDrop(object sender, RoutedEventArgs e)
        {
            // Gets the context
            Context context = GetSafeContext((UIElement)sender);

            // Cancels the delayed leave if it is enabled.
            context.LeaveDelayInvoker.Cancel();

            // Handles this event using the DragHoverImplementation.
            context.DragHoverImplementation.ProcessLeave();
        }

        #endregion


        #region IsDragOver ReadOnly Attached Property

        private static readonly DependencyPropertyKey IsDragOverPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragOver",
            typeof(bool),
            typeof(DropTarget),
            new PropertyMetadata(false)
        );

        public static readonly DependencyProperty IsDragOverProperty = IsDragOverPropertyKey.DependencyProperty;

        public static bool GetIsDragOver(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragOverProperty);
        }

        private static void SetIsDragOver(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragOverPropertyKey, value);
        }

        #endregion


        #region IsDragHover ReadOnly Attached Property

        private static readonly DependencyPropertyKey IsDragHoverPropertyKey = DependencyProperty.RegisterAttachedReadOnly
        (
            "IsDragHover",
            typeof(bool),
            typeof(DropTarget),
            new PropertyMetadata(false)
        );

        public static readonly DependencyProperty IsDragHoverProperty = IsDragHoverPropertyKey.DependencyProperty;

        public static bool GetIsDragHover(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragHoverProperty);
        }

        private static void SetIsDragHover(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragHoverPropertyKey, value);
        }

        #endregion


        #region DragHoverEventMode Attached Property

        public static readonly DependencyProperty DragHoverEventModeProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverEventMode",
            typeof(HoverEventMode),
            typeof(DropTarget),
            new PropertyMetadata(HoverEventMode.Normal)
        );

        public static HoverEventMode GetDragHoverEventMode(DependencyObject obj)
        {
            return (HoverEventMode)obj.GetValue(DragHoverEventModeProperty);
        }

        public static void SetDragHoverEventMode(DependencyObject obj, HoverEventMode value)
        {
            obj.SetValue(DragHoverEventModeProperty, value);
        }

        #endregion


        #region DragHoverTime Attached Property

        public static readonly DependencyProperty DragHoverTimeProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverTime",
            typeof(TimeSpan),
            typeof(DropTarget),
            new PropertyMetadata(SystemParameters.MouseHoverTime)
        );

        public static TimeSpan GetDragHoverTime(DependencyObject obj)
        {
            return (TimeSpan)obj.GetValue(DragHoverTimeProperty);
        }

        public static void SetDragHoverTime(DependencyObject obj, TimeSpan value)
        {
            obj.SetValue(DragHoverTimeProperty, value);
        }

        #endregion


        #region DragHoverWidth Attached Property

        public static readonly DependencyProperty DragHoverWidthProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverWidth",
            typeof(double),
            typeof(DropTarget),
            new PropertyMetadata(SystemParameters.MouseHoverWidth)
        );

        public static double GetDragHoverWidth(DependencyObject obj)
        {
            return (double)obj.GetValue(DragHoverWidthProperty);
        }

        public static void SetDragHoverWidth(DependencyObject obj, double value)
        {
            obj.SetValue(DragHoverWidthProperty, value);
        }

        #endregion


        #region DragHoverHeight Attached Property

        public static readonly DependencyProperty DragHoverHeightProperty = DependencyProperty.RegisterAttached
        (
            "DragHoverHeight",
            typeof(double),
            typeof(DropTarget),
            new PropertyMetadata(SystemParameters.MouseHoverHeight)
        );

        public static double GetDragHoverHeight(DependencyObject obj)
        {
            return (double)obj.GetValue(DragHoverHeightProperty);
        }

        public static void SetDragHoverHeight(DependencyObject obj, double value)
        {
            obj.SetValue(DragHoverHeightProperty, value);
        }

        #endregion


        #region DragHover event related

        public static readonly RoutedEvent PreviewDragHoverEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewDragHover",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<HoverEventArgs>),
            typeof(DropTarget)
        );

        public static void AddPreviewDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(PreviewDragHoverEvent, handler);
        }

        public static void RemovePreviewDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(PreviewDragHoverEvent, handler);
        }


        public static readonly RoutedEvent DragHoverEvent = EventManager.RegisterRoutedEvent
        (
            "DragHover",
            RoutingStrategy.Bubble,
            typeof(EventHandler<HoverEventArgs>),
            typeof(DropTarget)
        );

        public static void AddDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.AddHandler(DragHoverEvent, handler);
        }

        public static void RemoveDragHoverHandler(UIElement obj, EventHandler<HoverEventArgs> handler)
        {
            obj.RemoveHandler(DragHoverEvent, handler);
        }

        #endregion
    }
}
