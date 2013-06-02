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
            MovingEventArgs movingEventArgs = new MovingEventArgs(Target, dragDelta);
            OnMoving(movingEventArgs);

            // If it is canceled
            if (movingEventArgs.Cancel)
                return;


            // Moves the target element.
            Window window = Target as Window;

            if (window != null)
                FrameworkElementHelper.Move(window, e);
            else
                FrameworkElementHelper.Move(Target, e);


            // Raises the Moved event.
            OnMoved(new MovedEventArgs(Target, dragDelta));
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


        #region Moving event

        #region MovingEventArgs

        /// <summary>
        /// The event arguments for the Moving event.
        /// </summary>
        public class MovingEventArgs : CancelEventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the MovingEventArgs class.
            /// </summary>
            /// <param name="target">The target element that is about to move. It can be a Window.</param>
            /// <param name="dragDelta">The dragged distance.</param>
            public MovingEventArgs(FrameworkElement target, Vector dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// The target element that is about to move.
            /// It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

            /// <summary>
            /// The dragged distance.
            /// </summary>
            public Vector DragDelta { get; private set; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Occurs just before the DragMover moves target element.
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
        /// The event argument for the Moved event.
        /// </summary>
        public class MovedEventArgs : EventArgs
        {
            #region Constructors

            /// <summary>
            /// Initialize a new instance of the MovedEventArgs class.
            /// </summary>
            /// <param name="target">The target element that is moved. It can be a Window.</param>
            /// <param name="dragDelta">The dragged distance.</param>
            public MovedEventArgs(FrameworkElement target, Vector dragDelta)
            {
                if (target == null)
                    throw new ArgumentNullException("target");

                Target = target;
                DragDelta = dragDelta;
            }

            #endregion


            #region Properties

            /// <summary>
            /// The target element that is moved. It can be a Window.
            /// It can be a Window.
            /// </summary>
            public FrameworkElement Target { get; private set; }

            /// <summary>
            /// The dragged distance.
            /// </summary>
            public Vector DragDelta { get; private set; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Occurs when the DragMover moves the target element.
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
