/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.11.17
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Diagnostics;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Nicenis.Windows
{
    #region DragMover Event Arguments Related

    /// <summary>
    /// Internal Use Only.
    /// The base class for DragMover related event argument classes.
    /// </summary>
    public abstract class DragMoverEventArgsBase : RoutedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragMoverEventArgsBase class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        internal DragMoverEventArgsBase(RoutedEvent routedEvent, object source, FrameworkElement target)
            : base(routedEvent, source)
        {
            Verify.ParameterIsNotNull(target, "target");
            Target = target;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets the target element that is related. It can be a Window.
        /// </summary>
        public FrameworkElement Target { get; private set; }

        #endregion
    }

    /// <summary>
    /// Contains arguments for the Moving event.
    /// </summary>
    public class DragMoverMovingEventArgs : DragMoverEventArgsBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragMoverMovingEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        internal DragMoverMovingEventArgs(RoutedEvent routedEvent, object source, FrameworkElement target, Vector dragDelta)
            : base(routedEvent, source, target)
        {
            DragDelta = dragDelta;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the move should be canceled.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// Gets or sets the dragged distance.
        /// </summary>
        public Vector DragDelta { get; set; }

        #endregion
    }

    /// <summary>
    /// Contains arguments for the Moved event.
    /// </summary>
    public class DragMoverMovedEventArgs : DragMoverEventArgsBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the DragMoverMovedEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        internal DragMoverMovedEventArgs(RoutedEvent routedEvent, object source, FrameworkElement target, Vector dragDelta)
            : base(routedEvent, source, target)
        {
            DragDelta = dragDelta;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets the dragged distance.
        /// </summary>
        public Vector DragDelta { get; private set; }

        #endregion
    }

    #endregion


    /// <summary>
    /// Moves a Window or a FrameworkElement on a Canvas by dragging.
    /// </summary>
    [TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    public class DragMover : ContentControl
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
        }

        #endregion


        #region Event Handlers

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call ApplyTemplate.
        /// </summary>
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

            // Adjusts the delta not to exceed the defined min-max positions.
            AdjustDeltaForMinMaxPositions(ref dragDelta);

            // Raises the Moving event.
            if (!RaiseMovingEvent(this, Target, ref dragDelta))
                return;

            // Moves the target element.
            FrameworkElementHelper.Move(Target, dragDelta);

            // Raises the Moved event.
            RaiseMovedEvent(this, Target, dragDelta);
        }

        #endregion


        #region Properties

        /// <summary>
        /// The dependency property for the target to move.
        /// </summary>
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register
        (
            "Target",
            typeof(FrameworkElement),
            typeof(DragMover),
            new PropertyMetadata(null, TargetProperty_Changed)
        );

        /// <summary>
        /// Gets or sets the target to move.
        /// The target must be a Window or a FrameworkElement in a Canvas.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        private static void TargetProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DragMover dragMover = (DragMover)d;

            FrameworkElement oldTarget = e.OldValue as FrameworkElement;
            if (oldTarget != null)
                oldTarget.Loaded -= dragMover.TargetProperty_Target_Loaded;

            FrameworkElement newTarget = e.NewValue as FrameworkElement;
            if (newTarget != null)
            {
                newTarget.Loaded -= dragMover.TargetProperty_Target_Loaded;
                newTarget.Loaded += dragMover.TargetProperty_Target_Loaded;
            }
        }

        void TargetProperty_Target_Loaded(object sender, RoutedEventArgs e)
        {
            // Adjusts not to exceed the defined min-max positions.
            AdjustForMinMaxPositions();
        }


        /// <summary>
        /// The dependency property for the minimum left that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MinLeftProperty = DependencyProperty.Register
        (
            "MinLeft",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.NegativeInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the minimum left that the Target can move.
        /// </summary>
        public double MinLeft
        {
            get { return (double)GetValue(MinLeftProperty); }
            set { SetValue(MinLeftProperty, value); }
        }

        /// <summary>
        /// The dependency property for the maximum left that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MaxLeftProperty = DependencyProperty.Register
        (
            "MaxLeft",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.PositiveInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the maximum left that the Target can move.
        /// </summary>
        public double MaxLeft
        {
            get { return (double)GetValue(MaxLeftProperty); }
            set { SetValue(MaxLeftProperty, value); }
        }


        /// <summary>
        /// The dependency property for the minimum top that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MinTopProperty = DependencyProperty.Register
        (
            "MinTop",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.NegativeInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the minimum top that the Target can move.
        /// </summary>
        public double MinTop
        {
            get { return (double)GetValue(MinTopProperty); }
            set { SetValue(MinTopProperty, value); }
        }

        /// <summary>
        /// The dependency property for the maximum top that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MaxTopProperty = DependencyProperty.Register
        (
            "MaxTop",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.PositiveInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the maximum top that the Target can move.
        /// </summary>
        public double MaxTop
        {
            get { return (double)GetValue(MaxTopProperty); }
            set { SetValue(MaxTopProperty, value); }
        }


        /// <summary>
        /// The dependency property for the minimum right that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MinRightProperty = DependencyProperty.Register
        (
            "MinRight",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.NegativeInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the minimum right that the Target can move.
        /// </summary>
        public double MinRight
        {
            get { return (double)GetValue(MinRightProperty); }
            set { SetValue(MinRightProperty, value); }
        }

        /// <summary>
        /// The dependency property for the maximum right that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MaxRightProperty = DependencyProperty.Register
        (
            "MaxRight",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.PositiveInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the maximum right that the Target can move.
        /// </summary>
        public double MaxRight
        {
            get { return (double)GetValue(MaxRightProperty); }
            set { SetValue(MaxRightProperty, value); }
        }


        /// <summary>
        /// The dependency property for the minimum bottom that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MinBottomProperty = DependencyProperty.Register
        (
            "MinBottom",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.NegativeInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the minimum bottom that the Target can move.
        /// </summary>
        public double MinBottom
        {
            get { return (double)GetValue(MinBottomProperty); }
            set { SetValue(MinBottomProperty, value); }
        }

        /// <summary>
        /// The dependency property for the maximum bottom that the Target can move.
        /// </summary>
        public static readonly DependencyProperty MaxBottomProperty = DependencyProperty.Register
        (
            "MaxBottom",
            typeof(double),
            typeof(DragMover),
            new FrameworkPropertyMetadata(double.PositiveInfinity, MinMaxPositionRelatedProperties_Changed)
        );

        /// <summary>
        /// Gets or sets a value that indicates the maximum bottom that the Target can move.
        /// </summary>
        public double MaxBottom
        {
            get { return (double)GetValue(MaxBottomProperty); }
            set { SetValue(MaxBottomProperty, value); }
        }


        /// <summary>
        /// The changed event handlers for the min-max position related properties.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The event arguments.</param>
        private static void MinMaxPositionRelatedProperties_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Adjusts not to exceed the defined min-max positions.
            ((DragMover)d).AdjustForMinMaxPositions();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Adjusts the delta not to exceed the defined min-max positions.
        /// </summary>
        /// <param name="dragDelta">The drag delta to adjust.</param>
        private void AdjustDeltaForMinMaxPositions(ref Vector dragDelta)
        {
            if (Target == null)
                return;

            // To use layout related properties the Target must be loaded.
            if (!Target.IsLoaded)
                return;

            // Gets the Target's left and top.
            double targetLeft, targetTop;

            Window window = Target as Window;
            if (window != null)
            {
                targetLeft = window.Left;
                targetTop = window.Top;
            }
            else
            {
                targetLeft = Canvas.GetLeft(Target);
                targetTop = Canvas.GetTop(Target);
            }

            // Gets the Target's width and height.
            double targetWidth = Target.ActualWidth;
            double targetHeight = Target.ActualHeight;

            // Adjusts the delta for the defined min-max positions.
            if (targetLeft + targetWidth + dragDelta.X > MaxRight)
                dragDelta.X = MaxRight - targetLeft - targetWidth;

            if (targetLeft + targetWidth + dragDelta.X < MinRight)
                dragDelta.X = MinRight - targetLeft - targetWidth;

            if (targetTop + targetHeight + dragDelta.Y > MaxBottom)
                dragDelta.Y = MaxBottom - targetTop - targetHeight;

            if (targetTop + targetHeight + dragDelta.Y < MinBottom)
                dragDelta.Y = MinBottom - targetTop - targetHeight;

            if (targetLeft + dragDelta.X > MaxLeft)
                dragDelta.X = MaxLeft - targetLeft;

            if (targetLeft + dragDelta.X < MinLeft)
                dragDelta.X = MinLeft - targetLeft;

            if (targetTop + dragDelta.Y > MaxTop)
                dragDelta.Y = MaxTop - targetTop;

            if (targetTop + dragDelta.Y < MinTop)
                dragDelta.Y = MinTop - targetTop;
        }

        /// <summary>
        /// Adjusts not to exceed the defined min-max positions.
        /// </summary>
        private void AdjustForMinMaxPositions()
        {
            if (Target == null)
                return;

            // Gets the delta that is not exceed the defined min-max positions.
            Vector delta = new Vector();
            AdjustDeltaForMinMaxPositions(ref delta);

            // Applies the delta.
            FrameworkElementHelper.Move(Target, delta);
        }

        #endregion


        #region Moving Event Related

        /// <summary>
        /// Identifies the PreviewMoving routed event. 
        /// </summary>
        public static readonly RoutedEvent PreviewMovingEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewMoving",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragMoverMovingEventArgs>),
            typeof(DragMover)
        );

        /// <summary>
        /// Adds an event handler for the PreviewMoving event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.AddHandler(PreviewMovingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewMoving event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.RemoveHandler(PreviewMovingEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is about to move.
        /// </summary>
        public event EventHandler<DragMoverMovingEventArgs> PreviewMoving
        {
            add { AddHandler(PreviewMovingEvent, value); }
            remove { RemoveHandler(PreviewMovingEvent, value); }
        }


        /// <summary>
        /// Identifies the Moving routed event. 
        /// </summary>
        public static readonly RoutedEvent MovingEvent = EventManager.RegisterRoutedEvent
        (
            "Moving",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragMoverMovingEventArgs>),
            typeof(DragMover)
        );

        /// <summary>
        /// Adds an event handler for the Moving event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.AddHandler(MovingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the Moving event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveMovingHandler(UIElement obj, EventHandler<DragMoverMovingEventArgs> handler)
        {
            obj.RemoveHandler(MovingEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is about to move.
        /// </summary>
        public event EventHandler<DragMoverMovingEventArgs> Moving
        {
            add { AddHandler(MovingEvent, value); }
            remove { RemoveHandler(MovingEvent, value); }
        }


        /// <summary>
        /// Raises PreviewMovingEvent and MovingEvent.
        /// </summary>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        /// <returns>True if it is not canceled; otherwise false.</returns>
        private static bool RaiseMovingEvent(UIElement source, FrameworkElement target, ref Vector dragDelta)
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

            // Saves the delta.
            dragDelta = eventArgs.DragDelta;

            // If user cancels the move
            if (eventArgs.Cancel)
                return false;

            return true;
        }

        #endregion


        #region Moved Event Related

        /// <summary>
        /// Identifies the PreviewMoved routed event. 
        /// </summary>
        public static readonly RoutedEvent PreviewMovedEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewMoved",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragMoverMovedEventArgs>),
            typeof(DragMover)
        );

        /// <summary>
        /// Adds an event handler for the PreviewMoved event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.AddHandler(PreviewMovedEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewMoved event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.RemoveHandler(PreviewMovedEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is moved.
        /// </summary>
        public event EventHandler<DragMoverMovedEventArgs> PreviewMoved
        {
            add { AddHandler(PreviewMovedEvent, value); }
            remove { RemoveHandler(PreviewMovedEvent, value); }
        }


        /// <summary>
        /// Identifies the MovedEvent routed event. 
        /// </summary>
        public static readonly RoutedEvent MovedEvent = EventManager.RegisterRoutedEvent
        (
            "Moved",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragMoverMovedEventArgs>),
            typeof(DragMover)
        );

        /// <summary>
        /// Adds an event handler for the Moved event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.AddHandler(MovedEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the Moved event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveMovedHandler(UIElement obj, EventHandler<DragMoverMovedEventArgs> handler)
        {
            obj.RemoveHandler(MovedEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is moved.
        /// </summary>
        public event EventHandler<DragMoverMovedEventArgs> Moved
        {
            add { AddHandler(MovedEvent, value); }
            remove { RemoveHandler(MovedEvent, value); }
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
