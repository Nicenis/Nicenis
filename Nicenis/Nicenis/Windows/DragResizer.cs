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
    /// Provides resizing by dragging.
    /// BorderThickness property is used for the size of internal thumbs.
    /// </summary>
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

        static DragResizer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragResizer), new FrameworkPropertyMetadata(typeof(DragResizer)));

            // Reset defaults
            BorderThicknessProperty.OverrideMetadata(typeof(DragResizer), new FrameworkPropertyMetadata(new Thickness(4)));
            BackgroundProperty.OverrideMetadata(typeof(DragResizer), new FrameworkPropertyMetadata(null));
        }

        public DragResizer()
        {
            Loaded += DragResizer_Loaded;
            Unloaded += DragResizer_Unloaded;
        }

        #endregion


        #region Event Handlers

        void DragResizer_Loaded(object sender, RoutedEventArgs e)
        {
            // Find a window or FrameworkElement that has true IsTarget
            Target = this.VisualAncestors().FirstOrDefault
            (
                p => (p is Window)
                    ||
                    ((p is FrameworkElement) && GetIsTarget((FrameworkElement)p))
            )
            as FrameworkElement;
        }

        void DragResizer_Unloaded(object sender, RoutedEventArgs e)
        {
            // Clear visual tree related values
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


            // Adjust thumb enablements
            AdjustThumbEnablement();
        }

        void LeftSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.Left, e);
        }

        void TopSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.Top, e);
        }

        void RightSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.Right, e);
        }

        void BottomSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.Bottom, e);
        }

        void TopLeftSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.TopLeft, e);
        }

        void TopRightSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.TopRight, e);
        }

        void BottomLeftSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.BottomLeft, e);
        }

        void BottomRightSide_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Resize(OctangleSide.BottomRight, e);
        }

        #endregion


        #region Helpers

        /// <summary>
        /// Resize the target.
        /// </summary>
        /// <param name="targetSide">side that is dragged.</param>
        /// <param name="e">DragDelta event argument.</param>
        private void Resize(OctangleSide targetSide, DragDeltaEventArgs e)
        {
            if (Target == null)
                return;

            // Convert the DragDeltaEventArgs into a Point.
            Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);


            // Raise the Resizing event.
            ResizingEventArgs resizingEventArgs = new ResizingEventArgs(Target, targetSide, dragDelta);
            OnResizing(resizingEventArgs);

            // If it is canceled
            if (resizingEventArgs.Cancel)
                return;


            // Resize the target element.
            if (Target is Window)
            {
                FrameworkElementHelper.Resize((Window)Target, targetSide, e);
            }
            else
            {
                FrameworkElementHelper.Resize(Target, targetSide, e);
            }


            // Raise the Resized event.
            OnResized(new ResizedEventArgs(Target, targetSide, dragDelta));
        }

        /// <summary>
        /// Adjust thumb enablements.
        /// </summary>
        private void AdjustThumbEnablement()
        {
            if (_leftThumb != null)
                _leftThumb.IsEnabled = _leftThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.Left);

            if (_leftTopThumb != null)
                _leftTopThumb.IsEnabled = _leftTopThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.TopLeft);

            if (_leftBottomThumb != null)
                _leftBottomThumb.IsEnabled = _leftBottomThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.BottomLeft);


            if (_rightThumb != null)
                _rightThumb.IsEnabled = _rightThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.Right);

            if (_rightTopThumb != null)
                _rightTopThumb.IsEnabled = _rightTopThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.TopRight);

            if (_rightBottomThumb != null)
                _rightBottomThumb.IsEnabled = _rightBottomThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.BottomRight);


            if (_topThumb != null)
                _topThumb.IsEnabled = _topThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.Top);

            if (_topLeftThumb != null)
                _topLeftThumb.IsEnabled = _topLeftThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.TopLeft);

            if (_topRightThumb != null)
                _topRightThumb.IsEnabled = _topRightThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.TopRight);


            if (_bottomThumb != null)
                _bottomThumb.IsEnabled = _bottomThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.Bottom);

            if (_bottomLeftThumb != null)
                _bottomLeftThumb.IsEnabled = _bottomLeftThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.BottomLeft);

            if (_bottomRightThumb != null)
                _bottomRightThumb.IsEnabled = _bottomRightThumb.IsHitTestVisible = Sides.HasFlag(OctangleSides.BottomRight);
        }

        #endregion


        #region Properties

        /// <summary>
        /// Marks the target FrameworkElement that is going to be resized.
        /// Any changes applied to this property is ignored after the DragResizer is loaded.
        /// The target must be a FrameworkElement on a Canvas or a Window.
        /// If any parent element does not have this property that is true, the outer Window is used as the target.
        /// </summary>
        public static readonly DependencyProperty IsTargetProperty = DependencyProperty.RegisterAttached
        (
            "IsTarget",
            typeof(bool),
            typeof(DragResizer),
            new FrameworkPropertyMetadata(false)
        );

        public static bool GetIsTarget(FrameworkElement element)
        {
            return (bool)element.GetValue(IsTargetProperty);
        }

        public static void SetIsTarget(FrameworkElement element, bool isTarget)
        {
            element.SetValue(IsTargetProperty, isTarget);
        }


        /// <summary>
        /// A DependencyPropertyKey for the target FameworkElement that is resized.
        /// </summary>
        private static readonly DependencyPropertyKey TargetPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "Target",
            typeof(FrameworkElement),
            typeof(DragResizer),
            new FrameworkPropertyMetadata()
        );

        /// <summary>
        /// A DependencyProperty for the target FameworkElement that is resized.
        /// </summary>
        public static readonly DependencyProperty TargetProperty = TargetPropertyKey.DependencyProperty;

        /// <summary>
        /// The target FameworkElement that is resized.
        /// This property is null until the DragResizer is loaded.
        /// If this property is set any value, this property is not changed until the DragResizer is unloaded.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            private set { SetValue(TargetPropertyKey, value); }
        }


        /// <summary>
        /// Sides that is draggable for resizing.
        /// </summary>
        public static readonly DependencyProperty SidesProperty = DependencyProperty.Register
        (
            "Sides",
            typeof(OctangleSides),
            typeof(DragResizer),
            new FrameworkPropertyMetadata
            (
                OctangleSides.All,
                SidesProperty_Changed
            )
        );

        private static void SidesProperty_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Adjust thumb enablements
            ((DragResizer)d).AdjustThumbEnablement();
        }

        /// <summary>
        /// Sides that is draggable for resizing.
        /// </summary>
        public OctangleSides Sides
        {
            get { return (OctangleSides)GetValue(SidesProperty); }
            set { SetValue(SidesProperty, value); }
        }

        #endregion


        #region Resizing event

        #region ResizingEventArgs

        /// <summary>
        /// Provides event argument for the Resizing event.
        /// </summary>
        public class ResizingEventArgs : CancelEventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the ResizingEventArgs class.
            /// </summary>
            /// <param name="target">Target element that is resizing. It can be a Window.</param>
            /// <param name="side">Side that is dragged.</param>
            /// <param name="dragDelta">Dragged distance.</param>
            public ResizingEventArgs(FrameworkElement target, OctangleSide side, Point dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                Side = side;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// Target element that is resizing.
            /// It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

            /// <summary>
            /// Side that is dragged.
            /// </summary>
            public OctangleSide Side { get; private set; }

            /// <summary>
            /// Dragged distance.
            /// </summary>
            public Point DragDelta { get; private set; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Occurs just before DragResizer resizes target element.
        /// This event can be cancelled.
        /// </summary>
        public event EventHandler<ResizingEventArgs> Resizing;

        /// <summary>
        /// Raises the Resizing event.
        /// </summary>
        /// <param name="e">A ResizingEventArgs that contains the event data.</param>
        protected virtual void OnResizing(ResizingEventArgs e)
        {
            if (Resizing != null)
                Resizing(this, e);
        }

        #endregion


        #region Resized event

        #region ResizedEventArgs

        /// <summary>
        /// Provides event argument for the Resized event.
        /// </summary>
        public class ResizedEventArgs : EventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the ResizedEventArgs class.
            /// </summary>
            /// <param name="target">Target element that is resized. It can be a Window.</param>
            /// <param name="side">Side that is dragged.</param>
            /// <param name="dragDelta">Dragged distance.</param>
            public ResizedEventArgs(FrameworkElement target, OctangleSide side, Point dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                Side = side;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// Target element that is resized.
            /// It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

            /// <summary>
            /// Side that is dragged.
            /// </summary>
            public OctangleSide Side { get; private set; }

            /// <summary>
            /// Dragged distance.
            /// </summary>
            public Point DragDelta { get; private set; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Occurs when DragResizer resizes target element.
        /// </summary>
        public event EventHandler<ResizedEventArgs> Resized;

        /// <summary>
        /// Raises the Resized event.
        /// </summary>
        /// <param name="e">A ResizedEventArgs that contains the event data.</param>
        protected virtual void OnResized(ResizedEventArgs e)
        {
            if (Resized != null)
                Resized(this, e);
        }

        #endregion
    }
}
