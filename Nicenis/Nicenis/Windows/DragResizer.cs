/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.10
 * Version	$Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Nicenis.Windows
{
    #region DragResizer Event Arguments Related

    /// <summary>
    /// Internal Use Only.
    /// The base class for DragResizer related event argument classes.
    /// </summary>
    public abstract class DragResizerEventArgsBase : RoutedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of the DragResizerEventArgsBase class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        internal DragResizerEventArgsBase(RoutedEvent routedEvent, object source, FrameworkElement target)
            : base(routedEvent, source)
        {
            if (target == null)
                throw new ArgumentNullException("target");

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
    /// Contains arguments for the Resizing event.
    /// </summary>
    public class DragResizerResizingEventArgs : DragResizerEventArgsBase
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of the ResizingEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="mode">The resize mode.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        public DragResizerResizingEventArgs(RoutedEvent routedEvent, object source, FrameworkElement target, BorderResizeMode mode, Vector dragDelta)
            : base(routedEvent, source, target)
        {
            Mode = mode;
            DragDelta = dragDelta;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the resize should be canceled.
        /// </summary>
        public bool Cancel { get; set; }

        /// <summary>
        /// The resize mode.
        /// </summary>
        public BorderResizeMode Mode { get; private set; }

        /// <summary>
        /// Gets or sets the dragged distance.
        /// </summary>
        public Vector DragDelta { get; set; }

        #endregion
    }

    /// <summary>
    /// Contains arguments for the Resized event.
    /// </summary>
    public class DragResizerResizedEventArgs : DragResizerEventArgsBase
    {
        #region Constructors

        /// <summary>
        /// Initialize a new instance of the ResizedEventArgs class.
        /// </summary>
        /// <param name="routedEvent">The routed event identifier for this instance of the RoutedEventArgs class.</param>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="mode">The resize mode.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        public DragResizerResizedEventArgs(RoutedEvent routedEvent, object source, FrameworkElement target, BorderResizeMode mode, Vector dragDelta)
            : base(routedEvent, source, target)
        {
            Mode = mode;
            DragDelta = dragDelta;
        }

        #endregion


        #region Properties

        /// <summary>
        /// The resize mode.
        /// </summary>
        public BorderResizeMode Mode { get; private set; }

        /// <summary>
        /// Gets the dragged distance.
        /// </summary>
        public Vector DragDelta { get; private set; }

        #endregion
    }

    #endregion


    /// <summary>
    /// Resizes a Window or a FrameworkElement on a Canvas by dragging.
    /// </summary>
    /// <remarks>
    /// The BorderThickness property is used for the size of internal thumbs.
    /// </remarks>
    [TemplatePart(Name = "PART_LeftThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_LeftTopThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_LeftBottomThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_RightThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_RightTopThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_RightBottomThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_TopThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_TopLeftThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_TopRightThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_BottomThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_BottomLeftThumb", Type = typeof(Thumb))]
    [TemplatePart(Name = "PART_BottomRightThumb", Type = typeof(Thumb))]
    public class DragResizer : ContentControl
    {
        Thumb _leftThumb, _leftTopThumb, _leftBottomThumb;
        Thumb _rightThumb, _rightTopThumb, _rightBottomThumb;
        Thumb _topThumb, _topLeftThumb, _topRightThumb;
        Thumb _bottomThumb, _bottomLeftThumb, _bottomRightThumb;


        #region Constructors

        /// <summary>
        /// The static constructor.
        /// </summary>
        static DragResizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragResizer), new FrameworkPropertyMetadata(typeof(DragResizer)));

            // Makes it hollow by default except border.
            BorderThicknessProperty.OverrideMetadata(typeof(DragResizer), new FrameworkPropertyMetadata(new Thickness(4)));
            BackgroundProperty.OverrideMetadata(typeof(DragResizer), new FrameworkPropertyMetadata(null));
        }

        /// <summary>
        /// Initializes a new instance of the DragResizer class.
        /// </summary>
        public DragResizer()
        {
        }

        #endregion


        #region Event Handlers

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _leftThumb = GetTemplateChild("PART_LeftThumb") as Thumb;
            if (_leftThumb != null)
            {
                _leftThumb.DragDelta -= LeftThumb_DragDelta;
                _leftThumb.DragDelta += LeftThumb_DragDelta;
            }

            _leftTopThumb = GetTemplateChild("PART_LeftTopThumb") as Thumb;
            if (_leftTopThumb != null)
            {
                _leftTopThumb.DragDelta -= TopLeftThumb_DragDelta;
                _leftTopThumb.DragDelta += TopLeftThumb_DragDelta;
            }

            _leftBottomThumb = GetTemplateChild("PART_LeftBottomThumb") as Thumb;
            if (_leftBottomThumb != null)
            {
                _leftBottomThumb.DragDelta -= BottomLeftThumb_DragDelta;
                _leftBottomThumb.DragDelta += BottomLeftThumb_DragDelta;
            }


            _rightThumb = GetTemplateChild("PART_RightThumb") as Thumb;
            if (_rightThumb != null)
            {
                _rightThumb.DragDelta -= RightThumb_DragDelta;
                _rightThumb.DragDelta += RightThumb_DragDelta;
            }

            _rightTopThumb = GetTemplateChild("PART_RightTopThumb") as Thumb;
            if (_rightTopThumb != null)
            {
                _rightTopThumb.DragDelta -= TopRightThumb_DragDelta;
                _rightTopThumb.DragDelta += TopRightThumb_DragDelta;
            }

            _rightBottomThumb = GetTemplateChild("PART_RightBottomThumb") as Thumb;
            if (_rightBottomThumb != null)
            {
                _rightBottomThumb.DragDelta -= BottomRightThumb_DragDelta;
                _rightBottomThumb.DragDelta += BottomRightThumb_DragDelta;
            }


            _topThumb = GetTemplateChild("PART_TopThumb") as Thumb;
            if (_topThumb != null)
            {
                _topThumb.DragDelta -= TopThumb_DragDelta;
                _topThumb.DragDelta += TopThumb_DragDelta;
            }

            _topLeftThumb = GetTemplateChild("PART_TopLeftThumb") as Thumb;
            if (_topLeftThumb != null)
            {
                _topLeftThumb.DragDelta -= TopLeftThumb_DragDelta;
                _topLeftThumb.DragDelta += TopLeftThumb_DragDelta;
            }

            _topRightThumb = GetTemplateChild("PART_TopRightThumb") as Thumb;
            if (_topRightThumb != null)
            {
                _topRightThumb.DragDelta -= TopRightThumb_DragDelta;
                _topRightThumb.DragDelta += TopRightThumb_DragDelta;
            }


            _bottomThumb = GetTemplateChild("PART_BottomThumb") as Thumb;
            if (_bottomThumb != null)
            {
                _bottomThumb.DragDelta -= BottomThumb_DragDelta;
                _bottomThumb.DragDelta += BottomThumb_DragDelta;
            }

            _bottomLeftThumb = GetTemplateChild("PART_BottomLeftThumb") as Thumb;
            if (_bottomLeftThumb != null)
            {
                _bottomLeftThumb.DragDelta -= BottomLeftThumb_DragDelta;
                _bottomLeftThumb.DragDelta += BottomLeftThumb_DragDelta;
            }

            _bottomRightThumb = GetTemplateChild("PART_BottomRightThumb") as Thumb;
            if (_bottomRightThumb != null)
            {
                _bottomRightThumb.DragDelta -= BottomRightThumb_DragDelta;
                _bottomRightThumb.DragDelta += BottomRightThumb_DragDelta;
            }


            // Adjusts thumb enablements
            AdjustThumbEnablement();
        }

        void LeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Left, e);
        }

        void TopThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Top, e);
        }

        void RightThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Right, e);
        }

        void BottomThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Bottom, e);
        }

        void TopLeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.TopLeft, e);
        }

        void TopRightThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.TopRight, e);
        }

        void BottomLeftThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.BottomLeft, e);
        }

        void BottomRightThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.BottomRight, e);
        }

        #endregion


        #region Properties

        /// <summary>
        /// The dependency property for the target to resize.
        /// </summary>
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register
        (
            "Target",
            typeof(FrameworkElement),
            typeof(DragResizer)
        );

        /// <summary>
        /// Gets or sets the target to resize.
        /// The target must be a Window or a FrameworkElement in a Canvas.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }


        /// <summary>
        /// The dependency property for the value that indicates allowed resize modes.
        /// </summary>
        public static readonly DependencyProperty ResizeModesProperty = DependencyProperty.Register
        (
            "ResizeModes",
            typeof(BorderResizeModes),
            typeof(DragResizer),
            new FrameworkPropertyMetadata
            (
                BorderResizeModes.All,
                ResizeModesProperty_Changed
            )
        );

        private static void ResizeModesProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Adjusts thumb enablements
            ((DragResizer)d).AdjustThumbEnablement();
        }

        /// <summary>
        /// Gets or sets a value that indicates allowed resize modes.
        /// </summary>
        public BorderResizeModes ResizeModes
        {
            get { return (BorderResizeModes)GetValue(ResizeModesProperty); }
            set { SetValue(ResizeModesProperty, value); }
        }

        #endregion


        #region Methods

        /// <summary>
        /// Resizes the target.
        /// </summary>
        /// <param name="mode">The resize mode.</param>
        /// <param name="e">The event arguments.</param>
        private void Resize(BorderResizeMode mode, DragDeltaEventArgs e)
        {
            if (Target == null)
                return;

            // Converts the DragDeltaEventArgs into a Vector.
            Vector dragDelta = new Vector(e.HorizontalChange, e.VerticalChange);

            // Raises the Resizing event.
            if (!RaiseResizingEvent(this, Target, mode, ref dragDelta))
                return;

            // Resizes the target element.
            FrameworkElementHelper.Resize(Target, mode, dragDelta);

            // Raises the Resized event.
            RaiseResizedEvent(this, Target, mode, dragDelta);
        }

        /// <summary>
        /// Adjusts thumb enablements.
        /// </summary>
        private void AdjustThumbEnablement()
        {
            if (_leftThumb != null)
                _leftThumb.IsEnabled = _leftThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.Left);

            if (_leftTopThumb != null)
                _leftTopThumb.IsEnabled = _leftTopThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.TopLeft);

            if (_leftBottomThumb != null)
                _leftBottomThumb.IsEnabled = _leftBottomThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.BottomLeft);


            if (_rightThumb != null)
                _rightThumb.IsEnabled = _rightThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.Right);

            if (_rightTopThumb != null)
                _rightTopThumb.IsEnabled = _rightTopThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.TopRight);

            if (_rightBottomThumb != null)
                _rightBottomThumb.IsEnabled = _rightBottomThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.BottomRight);


            if (_topThumb != null)
                _topThumb.IsEnabled = _topThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.Top);

            if (_topLeftThumb != null)
                _topLeftThumb.IsEnabled = _topLeftThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.TopLeft);

            if (_topRightThumb != null)
                _topRightThumb.IsEnabled = _topRightThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.TopRight);


            if (_bottomThumb != null)
                _bottomThumb.IsEnabled = _bottomThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.Bottom);

            if (_bottomLeftThumb != null)
                _bottomLeftThumb.IsEnabled = _bottomLeftThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.BottomLeft);

            if (_bottomRightThumb != null)
                _bottomRightThumb.IsEnabled = _bottomRightThumb.IsHitTestVisible = ResizeModes.HasFlag(BorderResizeModes.BottomRight);
        }

        #endregion


        #region Resizing Event Related

        /// <summary>
        /// Identifies the PreviewResizing routed event. 
        /// </summary>
        public static readonly RoutedEvent PreviewResizingEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewResizing",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragResizerResizingEventArgs>),
            typeof(DragResizer)
        );

        /// <summary>
        /// Adds an event handler for the PreviewResizing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewResizingHandler(UIElement obj, EventHandler<DragResizerResizingEventArgs> handler)
        {
            obj.AddHandler(PreviewResizingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewResizing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewResizingHandler(UIElement obj, EventHandler<DragResizerResizingEventArgs> handler)
        {
            obj.RemoveHandler(PreviewResizingEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is about to resize.
        /// </summary>
        public event EventHandler<DragResizerResizingEventArgs> PreviewResizing
        {
            add { AddHandler(PreviewResizingEvent, value); }
            remove { RemoveHandler(PreviewResizingEvent, value); }
        }


        /// <summary>
        /// Identifies the Resizing routed event. 
        /// </summary>
        public static readonly RoutedEvent ResizingEvent = EventManager.RegisterRoutedEvent
        (
            "Resizing",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragResizerResizingEventArgs>),
            typeof(DragResizer)
        );

        /// <summary>
        /// Adds an event handler for the Resizing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddResizingHandler(UIElement obj, EventHandler<DragResizerResizingEventArgs> handler)
        {
            obj.AddHandler(ResizingEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the Resizing event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveResizingHandler(UIElement obj, EventHandler<DragResizerResizingEventArgs> handler)
        {
            obj.RemoveHandler(ResizingEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is about to resize.
        /// </summary>
        public event EventHandler<DragResizerResizingEventArgs> Resizing
        {
            add { AddHandler(ResizingEvent, value); }
            remove { RemoveHandler(ResizingEvent, value); }
        }


        /// <summary>
        /// Raises PreviewResizingEvent and ResizingEvent.
        /// </summary>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="resizeMode">The resize mode.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        /// <returns>True if it is not canceled; otherwise false.</returns>
        private static bool RaiseResizingEvent(UIElement source, FrameworkElement target, BorderResizeMode resizeMode, ref Vector dragDelta)
        {
            Debug.Assert(source != null);
            Debug.Assert(target != null);

            // Creates an event argument.
            DragResizerResizingEventArgs eventArgs = new DragResizerResizingEventArgs
            (
                PreviewResizingEvent,
                source,
                target,
                resizeMode,
                dragDelta
            );

            // Raises the PreviewResizing routed event.
            source.RaiseEvent(eventArgs);

            // Raises the Resizing routed event.
            eventArgs.RoutedEvent = ResizingEvent;
            source.RaiseEvent(eventArgs);

            // Saves the delta.
            dragDelta = eventArgs.DragDelta;

            // If user cancels the move
            if (eventArgs.Cancel)
                return false;

            return true;
        }

        #endregion


        #region Resized Event Related

        /// <summary>
        /// Identifies the PreviewResized routed event. 
        /// </summary>
        public static readonly RoutedEvent PreviewResizedEvent = EventManager.RegisterRoutedEvent
        (
            "PreviewResized",
            RoutingStrategy.Tunnel,
            typeof(EventHandler<DragResizerResizedEventArgs>),
            typeof(DragResizer)
        );

        /// <summary>
        /// Adds an event handler for the PreviewResized event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddPreviewResizedHandler(UIElement obj, EventHandler<DragResizerResizedEventArgs> handler)
        {
            obj.AddHandler(PreviewResizedEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the PreviewResized event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemovePreviewResizedHandler(UIElement obj, EventHandler<DragResizerResizedEventArgs> handler)
        {
            obj.RemoveHandler(PreviewResizedEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is moved.
        /// </summary>
        public event EventHandler<DragResizerResizedEventArgs> PreviewResized
        {
            add { AddHandler(PreviewResizedEvent, value); }
            remove { RemoveHandler(PreviewResizedEvent, value); }
        }


        /// <summary>
        /// Identifies the ResizedEvent routed event. 
        /// </summary>
        public static readonly RoutedEvent ResizedEvent = EventManager.RegisterRoutedEvent
        (
            "Resized",
            RoutingStrategy.Bubble,
            typeof(EventHandler<DragResizerResizedEventArgs>),
            typeof(DragResizer)
        );

        /// <summary>
        /// Adds an event handler for the Resized event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void AddResizedHandler(UIElement obj, EventHandler<DragResizerResizedEventArgs> handler)
        {
            obj.AddHandler(ResizedEvent, handler);
        }

        /// <summary>
        /// Removes the event handler for the Resized event.
        /// </summary>
        /// <param name="obj">The target element.</param>
        /// <param name="handler">The event handler.</param>
        public static void RemoveResizedHandler(UIElement obj, EventHandler<DragResizerResizedEventArgs> handler)
        {
            obj.RemoveHandler(ResizedEvent, handler);
        }

        /// <summary>
        /// Occurs when the Target element is resized.
        /// </summary>
        public event EventHandler<DragResizerResizedEventArgs> Resized
        {
            add { AddHandler(ResizedEvent, value); }
            remove { RemoveHandler(ResizedEvent, value); }
        }


        /// <summary>
        /// Raises PreviewResizedEvent and ResizedEvent.
        /// </summary>
        /// <param name="source">An alternate source that will be reported when the event is handled. This pre-populates the Source property.</param>
        /// <param name="target">The target element that is related. It can be a Window.</param>
        /// <param name="resizeMode">The resize mode.</param>
        /// <param name="dragDelta">The dragged distance.</param>
        private static void RaiseResizedEvent(UIElement source, FrameworkElement target, BorderResizeMode resizeMode, Vector dragDelta)
        {
            Debug.Assert(source != null);
            Debug.Assert(target != null);

            // Creates an event argument.
            DragResizerResizedEventArgs eventArgs = new DragResizerResizedEventArgs
            (
                PreviewResizedEvent,
                source,
                target,
                resizeMode,
                dragDelta
            );

            // Raises the PreviewResized routed event.
            source.RaiseEvent(eventArgs);

            // Raises the Resized routed event.
            eventArgs.RoutedEvent = ResizedEvent;
            source.RaiseEvent(eventArgs);
        }

        #endregion
    }
}
