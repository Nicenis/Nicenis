/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.17
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Nicenis.Windows
{
    #region DragMover event arguments related

    /// <summary>
    /// Internal Use Only. The base class for DragMover related event argument classes.
    /// </summary>
    public abstract class DragMoverEventArgsBase : RoutedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of the DragMoverEventArgsBase class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        internal DragMoverEventArgsBase(RoutedEvent routedEvent, object source, FrameworkElement target, Vector dragDelta)
            : base(routedEvent, source)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            Target = target;
            DragDelta = dragDelta;
        }

        #endregion


        #region Properties

        /// <summary>
        /// The target element that is related. It can be a Window.
        /// </summary>
        public FrameworkElement Target { get; private set; }

        /// <summary>
        /// The dragged distance.
        /// </summary>
        public Vector DragDelta { get; private set; }

        #endregion
    }

    /// <summary>
    /// Contains arguments for the Moving event.
    /// </summary>
    public class DragMoverMovingEventArgs : DragMoverEventArgsBase
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of the DragMoverMovingEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        internal DragMoverMovingEventArgs(RoutedEvent routedEvent, object source, FrameworkElement target, Vector dragDelta)
            : base(routedEvent, source, target, dragDelta) { }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the move should be canceled.
        /// </summary>
        public bool Cancel { get; set; }

        #endregion
    }


    /// <summary>
    /// Contains arguments for the Moved event.
    /// </summary>
    public class DragMoverMovedEventArgs : DragMoverEventArgsBase
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of the DragMoverMovedEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        internal DragMoverMovedEventArgs(RoutedEvent routedEvent, object source, FrameworkElement target, Vector dragDelta)
            : base(routedEvent, source, target, dragDelta) { }

        #endregion
    }

    #endregion


    /// <summary>
    /// Moves a Window or a FrameworkElement on a Canvas by dragging.
    /// </summary>
    /// <remarks>
    /// The IsTarget attached property is used to specified an element to move.
    /// If no element is speicifed as a target, the hosting Window becomes the target.
    /// </remarks>
    [TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    public class DragMover : Control
    {
        Thumb _thumb;


        #region Contructors

        /// <summary>
        /// The static constructor.
        /// </summary>
        static DragMover()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragMover), new FrameworkPropertyMetadata(typeof(DragMover)));

            // Makes it transparent by default.
            BackgroundProperty.OverrideMetadata(typeof(DragMover), new FrameworkPropertyMetadata(Brushes.Transparent));
        }

        /// <summary>
        /// Initializes a new instance of the DragMover class.
        /// </summary>
        public DragMover()
        {
            Loaded += DragMover_Loaded;
            Unloaded += DragMover_Unloaded;
        }

        #endregion


        #region Event Handlers

        void DragMover_Loaded(object sender, RoutedEventArgs e)
        {
            // Finds a window or a target FrameworkElement.
            Target = this.VisualAncestors().FirstOrDefault
            (
                p => (p is Window)
                    ||
                    ((p is FrameworkElement) && GetIsTarget((FrameworkElement)p))
            )
            as FrameworkElement;
        }

        void DragMover_Unloaded(object sender, RoutedEventArgs e)
        {
            // Clears visual tree related values.
            Target = null;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _thumb = GetTemplateChild("PART_Thumb") as Thumb;
            if (_thumb != null)
            {
                _thumb.DragDelta -= Thumb_DragDelta;
                _thumb.DragDelta += Thumb_DragDelta;
            }
        }

        void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (Target == null)
                return;

            // Converts the DragDeltaEventArgs into a Vector.
            Vector dragDelta = new Vector(e.HorizontalChange, e.VerticalChange);

            // Raises the Moving event.
            if (!RaiseMovingEvent(this, Target, dragDelta))
                return;

            // Moves the target element.
            FrameworkElementHelper.Move(Target, e);

            // Raises the Moved event.
            RaiseMovedEvent(this, Target, dragDelta);
        }

        #endregion


        #region Properties

        /// <summary>
        /// The attached property to specify a FrameworkElement that is going to be moved.
        /// Any changes to this property is ignored after the DragMover is loaded.
        /// The target must be a Window or a FrameworkElement that is on a Canvas.
        /// If there is no specified target element, the hosting Window is used as the target.
        /// </summary>
        public static readonly DependencyProperty IsTargetProperty = DependencyProperty.RegisterAttached
        (
            "IsTarget",
            typeof(bool),
            typeof(DragMover),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// Gets a value that indicates whether the element is set as the target to move.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <returns>True if it is set as the target to move; otherwise, false.</returns>
        public static bool GetIsTarget(FrameworkElement element)
        {
            return (bool)element.GetValue(IsTargetProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the element is set as the target to move.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="isTarget">A value that indicates whether the element is set as the target to move.</param>
        public static void SetIsTarget(FrameworkElement element, bool isTarget)
        {
            element.SetValue(IsTargetProperty, isTarget);
        }


        /// <summary>
        /// The dependency property key for the target FameworkElement that is specified by the IsTarget attached property.
        /// </summary>
        private static readonly DependencyPropertyKey TargetPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "Target",
            typeof(FrameworkElement),
            typeof(DragMover),
            new FrameworkPropertyMetadata()
        );

        /// <summary>
        /// The DependencyProperty for the target FameworkElement that is specified by the IsTarget attached property.
        /// </summary>
        public static readonly DependencyProperty TargetProperty = TargetPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the target FameworkElement that is specified by the IsTarget attached property.
        /// </summary>
        /// <remarks>
        /// This property is null if the DragMover is not loaded.
        /// If it is set any value, it is not changed until the DragMover is unloaded.
        /// </remarks>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            private set { SetValue(TargetPropertyKey, value); }
        }

        #endregion


        #region Moving event related

        public static readonly RoutedEvent PreviewMovingEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewMoving",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragMoverMovingEventArgs>),
            typeof(DragMover)
        );

        public static void AddPreviewMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.AddHandler(PreviewMovingEvent, handler);
        }

        public static void RemovePreviewMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.RemoveHandler(PreviewMovingEvent, handler);
        }


        public static readonly RoutedEvent MovingEvent = EventManager.RegisterRoutedEvent
        (
            "Moving",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragMoverMovingEventArgs>),
            typeof(DragMover)
        );

        public static void AddMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.AddHandler(MovingEvent, handler);
        }

        public static void RemoveMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.RemoveHandler(MovingEvent, handler);
        }


        /// <summary>
        /// Raises PreviewMovingEvent and MovingEvent.
        /// </summary>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        /// <returns>True if it is not canceled; otherwise false.</returns>
        private static bool RaiseMovingEvent(UIElement source, FrameworkElement target, Vector dragDelta)
        {
            Debug.Assert(source != null);
            Debug.Assert(target != null);

            // Creates an event argument.
            DragMoverMovingEventArgs eventArgs = new DragMoverMovingEventArgs
            (
                PreviewMovingEvent,
                source,
                target,
                dragDelta
            );

            // Raises the PreviewMoving routed event.
            source.RaiseEvent(eventArgs);

            // Raises the Moving routed event.
            eventArgs.RoutedEvent = MovingEvent;
            source.RaiseEvent(eventArgs);

            // If user cancels the move
            if (eventArgs.Cancel)
                return false;

            return true;
        }

        #endregion


        #region Moved event related

        public static readonly RoutedEvent PreviewMovedEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewMoved",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragMoverMovedEventArgs>),
            typeof(DragMover)
        );

        public static void AddPreviewMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.AddHandler(PreviewMovedEvent, handler);
        }

        public static void RemovePreviewMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.RemoveHandler(PreviewMovedEvent, handler);
        }


        public static readonly RoutedEvent MovedEvent = EventManager.RegisterRoutedEvent
        (
            "Moved",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragMoverMovedEventArgs>),
            typeof(DragMover)
        );

        public static void AddMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.AddHandler(MovedEvent, handler);
        }

        public static void RemoveMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.RemoveHandler(MovedEvent, handler);
        }


        /// <summary>
        /// Raises PreviewMovedEvent and MovedEvent.
        /// </summary>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        private static void RaiseMovedEvent(UIElement source, FrameworkElement target, Vector dragDelta)
        {
            Debug.Assert(source != null);
            Debug.Assert(target != null);

            // Creates an event argument.
            DragMoverMovedEventArgs eventArgs = new DragMoverMovedEventArgs
            (
                PreviewMovedEvent,
                source,
                target,
                dragDelta
            );

            // Raises the PreviewMoved routed event.
            source.RaiseEvent(eventArgs);

            // Raises the Moved routed event.
            eventArgs.RoutedEvent = MovedEvent;
            source.RaiseEvent(eventArgs);
        }

        #endregion
    }
}
