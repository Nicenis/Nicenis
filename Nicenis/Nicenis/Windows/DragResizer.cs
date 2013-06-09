/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.10
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Nicenis.Windows
{
    /// <summary>
    /// Resizes a Window or a FrameworkElement on a Canvas by dragging.
    /// </summary>
    /// <remarks>
    /// The IsTarget attached property is used to specified an element to resize.
    /// If no element is speicifed as a target, the hosting Window becomes the target.
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
    public class DragResizer : Control
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
            Loaded += DragResizer_Loaded;
            Unloaded += DragResizer_Unloaded;
        }

        #endregion


        #region Event Handlers

        void DragResizer_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTarget();
        }

        void DragResizer_Unloaded(object sender, RoutedEventArgs e)
        {
            // Clears visual tree related values
            Target = null;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _leftThumb = GetTemplateChild("PART_LeftThumb") as Thumb;
            if (_leftThumb != null)
            {
                _leftThumb.DragDelta -= LeftSide_DragDelta;
                _leftThumb.DragDelta += LeftSide_DragDelta;
            }

            _leftTopThumb = GetTemplateChild("PART_LeftTopThumb") as Thumb;
            if (_leftTopThumb != null)
            {
                _leftTopThumb.DragDelta -= TopLeftSide_DragDelta;
                _leftTopThumb.DragDelta += TopLeftSide_DragDelta;
            }

            _leftBottomThumb = GetTemplateChild("PART_LeftBottomThumb") as Thumb;
            if (_leftBottomThumb != null)
            {
                _leftBottomThumb.DragDelta -= BottomLeftSide_DragDelta;
                _leftBottomThumb.DragDelta += BottomLeftSide_DragDelta;
            }


            _rightThumb = GetTemplateChild("PART_RightThumb") as Thumb;
            if (_rightThumb != null)
            {
                _rightThumb.DragDelta -= RightSide_DragDelta;
                _rightThumb.DragDelta += RightSide_DragDelta;
            }

            _rightTopThumb = GetTemplateChild("PART_RightTopThumb") as Thumb;
            if (_rightTopThumb != null)
            {
                _rightTopThumb.DragDelta -= TopRightSide_DragDelta;
                _rightTopThumb.DragDelta += TopRightSide_DragDelta;
            }

            _rightBottomThumb = GetTemplateChild("PART_RightBottomThumb") as Thumb;
            if (_rightBottomThumb != null)
            {
                _rightBottomThumb.DragDelta -= BottomRightSide_DragDelta;
                _rightBottomThumb.DragDelta += BottomRightSide_DragDelta;
            }


            _topThumb = GetTemplateChild("PART_TopThumb") as Thumb;
            if (_topThumb != null)
            {
                _topThumb.DragDelta -= TopSide_DragDelta;
                _topThumb.DragDelta += TopSide_DragDelta;
            }

            _topLeftThumb = GetTemplateChild("PART_TopLeftThumb") as Thumb;
            if (_topLeftThumb != null)
            {
                _topLeftThumb.DragDelta -= TopLeftSide_DragDelta;
                _topLeftThumb.DragDelta += TopLeftSide_DragDelta;
            }

            _topRightThumb = GetTemplateChild("PART_TopRightThumb") as Thumb;
            if (_topRightThumb != null)
            {
                _topRightThumb.DragDelta -= TopRightSide_DragDelta;
                _topRightThumb.DragDelta += TopRightSide_DragDelta;
            }


            _bottomThumb = GetTemplateChild("PART_BottomThumb") as Thumb;
            if (_bottomThumb != null)
            {
                _bottomThumb.DragDelta -= BottomSide_DragDelta;
                _bottomThumb.DragDelta += BottomSide_DragDelta;
            }

            _bottomLeftThumb = GetTemplateChild("PART_BottomLeftThumb") as Thumb;
            if (_bottomLeftThumb != null)
            {
                _bottomLeftThumb.DragDelta -= BottomLeftSide_DragDelta;
                _bottomLeftThumb.DragDelta += BottomLeftSide_DragDelta;
            }

            _bottomRightThumb = GetTemplateChild("PART_BottomRightThumb") as Thumb;
            if (_bottomRightThumb != null)
            {
                _bottomRightThumb.DragDelta -= BottomRightSide_DragDelta;
                _bottomRightThumb.DragDelta += BottomRightSide_DragDelta;
            }


            // Adjusts thumb enablements
            AdjustThumbEnablement();
        }

        void LeftSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Left, e);
        }

        void TopSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Top, e);
        }

        void RightSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Right, e);
        }

        void BottomSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.Bottom, e);
        }

        void TopLeftSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.TopLeft, e);
        }

        void TopRightSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.TopRight, e);
        }

        void BottomLeftSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.BottomLeft, e);
        }

        void BottomRightSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(BorderResizeMode.BottomRight, e);
        }

        #endregion


        #region Properties

        /// <summary>
        /// The attached property to specify a FrameworkElement that is going to be resized.
        /// The IsTarget property is evaluated only when the DragResizer is loaded or the UpdateTarget method is called.
        /// The target must be a Window or a FrameworkElement that is on a Canvas.
        /// If there is no specified target element, the hosting Window is used as the target.
        /// </summary>
        public static readonly DependencyProperty IsTargetProperty = DependencyProperty.RegisterAttached
        (
            "IsTarget",
            typeof(bool),
            typeof(DragResizer),
            new FrameworkPropertyMetadata(false)
        );

        /// <summary>
        /// Gets a value that indicates whether the element is set as the target to resize.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <returns>True if it is set as the target to resize; otherwise, false.</returns>
        public static bool GetIsTarget(FrameworkElement element)
        {
            return (bool)element.GetValue(IsTargetProperty);
        }

        /// <summary>
        /// Sets a value that indicates whether the element is set as the target to resize.
        /// </summary>
        /// <param name="element">The target element.</param>
        /// <param name="isTarget">A value that indicates whether the element is set as the target to resize.</param>
        public static void SetIsTarget(FrameworkElement element, bool isTarget)
        {
            element.SetValue(IsTargetProperty, isTarget);
        }


        /// <summary>
        /// The dependency property key for the target FrameworkElement that is specified by the IsTarget attached property.
        /// </summary>
        private static readonly DependencyPropertyKey TargetPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "Target",
            typeof(FrameworkElement),
            typeof(DragResizer),
            new FrameworkPropertyMetadata()
        );

        /// <summary>
        /// The DependencyProperty for the target FrameworkElement that is specified by the IsTarget attached property.
        /// </summary>
        public static readonly DependencyProperty TargetProperty = TargetPropertyKey.DependencyProperty;

        /// <summary>
        /// Gets the target FrameworkElement that is specified by the IsTarget attached property.
        /// </summary>
        /// <remarks>
        /// This property is set when the DragResizer is loaded or the UpdateTarget method is called.
        /// </remarks>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            private set { SetValue(TargetPropertyKey, value); }
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
            ResizingEventArgs resizingEventArgs = new ResizingEventArgs(Target, mode, dragDelta);
            OnResizing(resizingEventArgs);

            // If it is canceled
            if (resizingEventArgs.Cancel)
                return;

            // Resizes the target element.
            FrameworkElementHelper.Resize(Target, mode, e);

            // Raises the Resized event.
            OnResized(new ResizedEventArgs(Target, mode, dragDelta));
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

        /// <summary>
        /// Updates the Target to resize.
        /// This method finds a FrameworkElement of which the IsTarget attached property is true.
        /// If it is found, the FrameworkElement is to be a new Target.
        /// Otherwise, the hosting Window becomes a new Target.
        /// </summary>
        public void UpdateTarget()
        {
            // Finds a Window or a target FrameworkElement.
            Target = this.VisualAncestors().FirstOrDefault
            (
                p => (p is Window)
                    ||
                    ((p is FrameworkElement) && GetIsTarget((FrameworkElement)p))
            )
            as FrameworkElement;
        }

        #endregion


        #region Resizing event

        #region ResizingEventArgs

        /// <summary>
        /// Contains arguments for the Resizing event.
        /// </summary>
        public class ResizingEventArgs : CancelEventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the ResizingEventArgs class.
            /// </summary>
            /// <param name="target">The target element that is related. It can be a Window.</param>
            /// <param name="mode">The resize mode.</param>
            /// <param name="dragDelta">The dragged distance.</param>
            public ResizingEventArgs(FrameworkElement target, BorderResizeMode mode, Vector dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                Mode = mode;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// Gets the target element that is related. It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

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
        /// Occurs when the Target element is about to resize.
        /// </summary>
        public event EventHandler<ResizingEventArgs> Resizing;

        /// <summary>
        /// Raises the Resizing event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnResizing(ResizingEventArgs e)
        {
            if (Resizing != null)
                Resizing(this, e);
        }

        #endregion


        #region Resized event

        #region ResizedEventArgs

        /// <summary>
        /// Contains arguments for the Resized event.
        /// </summary>
        public class ResizedEventArgs : EventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the ResizedEventArgs class.
            /// </summary>
            /// <param name="target">The target element that is related. It can be a Window.</param>
            /// <param name="mode">The resize mode.</param>
            /// <param name="dragDelta">The dragged distance.</param>
            public ResizedEventArgs(FrameworkElement target, BorderResizeMode mode, Vector dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                Mode = mode;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// Gets the target element that is related. It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

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
        /// Occurs when the Target element is resized.
        /// </summary>
        public event EventHandler<ResizedEventArgs> Resized;

        /// <summary>
        /// Raises the Resized event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected virtual void OnResized(ResizedEventArgs e)
        {
            if (Resized != null)
                Resized(this, e);
        }

        #endregion
    }
}
