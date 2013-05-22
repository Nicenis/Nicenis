/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.17
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
using System.Windows.Media;

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides moving by dragging.
    /// </summary>
    [TemplatePart(Name = "PART_Thumb", Type = typeof(Thumb))]
    public class DragMover : Control
    {
        Thumb _thumb;


        #region Contructors

        static DragMover()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DragMover), new FrameworkPropertyMetadata(typeof(DragMover)));

            // Reset defaults
            BackgroundProperty.OverrideMetadata(typeof(DragMover), new FrameworkPropertyMetadata(Brushes.Transparent));
        }

        public DragMover()
        {
            Loaded += DragMover_Loaded;
            Unloaded += DragMover_Unloaded;
        }

        #endregion


        #region Event Handlers

        void DragMover_Loaded(object sender, RoutedEventArgs e)
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

        void DragMover_Unloaded(object sender, RoutedEventArgs e)
        {
            // Clear visual tree related values
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


            // Convert the DragDeltaEventArgs into a Point.
            Point dragDelta = new Point(e.HorizontalChange, e.VerticalChange);


            // Raise the Moving event.
            MovingEventArgs movingEventArgs = new MovingEventArgs(Target, dragDelta);
            OnMoving(movingEventArgs);

            // If it is canceled
            if (movingEventArgs.Cancel)
                return;


            // Move the target element.
            if (Target is Window)
            {
                FrameworkElementHelper.Move((Window)Target, e);
            }
            else
            {
                FrameworkElementHelper.Move(Target, e);
            }


            // Raise the Moved event.
            OnMoved(new MovedEventArgs(Target, dragDelta));
        }

        #endregion


        #region Properties

        /// <summary>
        /// Marks the target FrameworkElement that is going to be moved.
        /// Any changes applied to this property is ignored after the DragMover is loaded.
        /// The target must be a FrameworkElement on a Canvas or a Window.
        /// If any parent element does not have this property that is true, the outer Window is used as the target.
        /// </summary>
        public static readonly DependencyProperty IsTargetProperty = DependencyProperty.RegisterAttached
        (
            "IsTarget",
            typeof(bool),
            typeof(DragMover),
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
        /// A DependencyPropertyKey for the target FameworkElement that is moved.
        /// </summary>
        private static readonly DependencyPropertyKey TargetPropertyKey = DependencyProperty.RegisterReadOnly
        (
            "Target",
            typeof(FrameworkElement),
            typeof(DragMover),
            new FrameworkPropertyMetadata()
        );

        /// <summary>
        /// A DependencyProperty for the target FameworkElement that is moved.
        /// </summary>
        public static readonly DependencyProperty TargetProperty = TargetPropertyKey.DependencyProperty;

        /// <summary>
        /// The target FameworkElement that is moved.
        /// This property is null until the DragMover is loaded.
        /// If this property is set any value, this property is not changed until the DragMover is unloaded.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            private set { SetValue(TargetPropertyKey, value); }
        }

        #endregion


        #region Moving event

        #region MovingEventArgs

        /// <summary>
        /// Provides event argument for the Moving event.
        /// </summary>
        public class MovingEventArgs : CancelEventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the MovingEventArgs class.
            /// </summary>
            /// <param name="target">Target element that is moving. It can be a Window.</param>
            /// <param name="dragDelta">Dragged distance.</param>
            public MovingEventArgs(FrameworkElement target, Point dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// Target element that is moving.
            /// It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

            /// <summary>
            /// Dragged distance.
            /// </summary>
            public Point DragDelta { get; private set; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Occurs just before DragMover moves target element.
        /// This event can be cancelled.
        /// </summary>
        public event EventHandler<MovingEventArgs> Moving;

        /// <summary>
        /// Raises the Moving event.
        /// </summary>
        /// <param name="e">A MovingEventArgs that contains the event data.</param>
        protected virtual void OnMoving(MovingEventArgs e)
        {
            if (Moving != null)
                Moving(this, e);
        }

        #endregion


        #region Moved event

        #region MovedEventArgs

        /// <summary>
        /// Provides event argument for the Moved event.
        /// </summary>
        public class MovedEventArgs : EventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the MovedEventArgs class.
            /// </summary>
            /// <param name="target">Target element that is moved. It can be a Window.</param>
            /// <param name="dragDelta">Dragged distance.</param>
            public MovedEventArgs(FrameworkElement target, Point dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// Target element that is moved.
            /// It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

            /// <summary>
            /// Dragged distance.
            /// </summary>
            public Point DragDelta { get; private set; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Occurs when DragMover moves target element.
        /// </summary>
        public event EventHandler<MovedEventArgs> Moved;

        /// <summary>
        /// Raises the Moved event.
        /// </summary>
        /// <param name="e">A MovedEventArgs that contains the event data.</param>
        protected virtual void OnMoved(MovedEventArgs e)
        {
            if (Moved != null)
                Moved(this, e);
        }

        #endregion
    }
}
