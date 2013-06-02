/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.06.32
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NicenisTestGui
{
    /// <summary>
    /// The window to test the DragMover window.
    /// </summary>
    public partial class DragMoverTestWindow : Window
    {
        public DragMoverTestWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adjusts the dragDelta for constraining the element's location within the container.
        /// </summary>
        /// <param name="container">The container of the element.</param>
        /// <param name="element">The element to move.</param>
        /// <param name="dragDelta">The drag delta.</param>
        /// <returns>The adjusted dragDelta.</returns>
        Vector AdjustToBeWithinContainer(Rect container, Rect element, Vector dragDelta)
        {
            if (element.Left + dragDelta.X + element.Width > container.Width)
                dragDelta.X = -(element.Left + element.Width - container.Width);

            if (element.Top + dragDelta.Y + element.Height > container.Height)
                dragDelta.Y = -(element.Top + element.Height - container.Height);

            if (element.Left + dragDelta.X < container.Left)
                dragDelta.X = container.Left - element.Left;

            if (element.Top + dragDelta.Y < container.Top)
                dragDelta.Y = container.Top - element.Top;

            return dragDelta;
        }

        private void WindowWithinWorkArea_Moving(object sender, Nicenis.Windows.DragMoverMovingEventArgs e)
        {
            e.DragDelta = AdjustToBeWithinContainer
            (
                SystemParameters.WorkArea,
                new Rect(Left, Top, ActualWidth, ActualHeight),
                e.DragDelta
            );
        }

        private void ElementWithinCanvas_Moving(object sender, Nicenis.Windows.DragMoverMovingEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;

            e.DragDelta = AdjustToBeWithinContainer
            (
                new Rect(0, 0, canvas.ActualWidth, canvas.ActualHeight),
                new Rect(Canvas.GetLeft(element), Canvas.GetTop(element), element.ActualWidth, element.ActualHeight),
                e.DragDelta
            );
        }
    }
}
