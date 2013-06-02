/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.08.12
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides functionalities related to FrameworkElement.
    /// </summary>
    internal static class FrameworkElementHelper
    {
        #region Related to resize

        /// <summary>
        /// Calculate horizontal resize.
        /// </summary>
        /// <param name="left">Resized target's left.</param>
        /// <param name="width">Resized target's width.</param>
        /// <param name="minWidth">Resized target's minimum width.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="newLeft">New left resulted by resize.</param>
        /// <param name="newWidth">New width resulted by resize.</param>
        /// <returns>True if the width is changed.</returns>
        public static bool CalculateHorizontalResize(double left, double width, double minWidth, OctangleSide targetSide, double deltaX, out double newLeft, out double newWidth)
        {
            // calculated left & width
            newLeft = left;
            newWidth = width;

            // If not changed
            if (deltaX == 0d)
                return false;

            // If it is not related to horizontal resize
            if (targetSide == OctangleSide.Top || targetSide == OctangleSide.Bottom)
                return false;

            // If it is sides positioned left
            if (targetSide == OctangleSide.Left || targetSide == OctangleSide.TopLeft || targetSide == OctangleSide.BottomLeft)
            {
                newWidth = Math.Max(width - deltaX, minWidth);

                // Position is also needed to be adjusted.
                newLeft = left - (newWidth - width);
            }
            else
            {
                newWidth = Math.Max(width + deltaX, minWidth);
            }

            // If it is not changed
            if (width == newWidth)
                return false;

            return true;
        }

        /// <summary>
        /// Calculate vertical resize.
        /// </summary>
        /// <param name="top">Resized target's top.</param>
        /// <param name="height">Resized target's height.</param>
        /// <param name="minHeight">Resized target's minimum height.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <param name="newTop">New top resulted by resize.</param>
        /// <param name="newHeight">New height resulted by resize.</param>
        /// <returns>True if the height is changed.</returns>
        public static bool CalculateVerticalResize(double top, double height, double minHeight, OctangleSide targetSide, double deltaY, out double newTop, out double newHeight)
        {
            // calculated top & height
            newTop = top;
            newHeight = height;

            // If not changed
            if (deltaY == 0d)
                return false;

            // If it is not related to vertical resize
            if (targetSide == OctangleSide.Left || targetSide == OctangleSide.Right)
                return false;

            // If it is sides positioned top
            if (targetSide == OctangleSide.Top || targetSide == OctangleSide.TopLeft || targetSide == OctangleSide.TopRight)
            {
                newHeight = Math.Max(height - deltaY, minHeight);

                // Position is also needed to be adjusted.
                newTop = top - (newHeight - height);
            }
            else
            {
                newHeight = Math.Max(height + deltaY, minHeight);
            }

            // If it is not changed
            if (height == newHeight)
                return false;

            return true;
        }


        /// <summary>
        /// Resize window.
        /// </summary>
        /// <param name="window">Target window.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the window is resized.</returns>
        public static bool Resize(Window window, OctangleSide targetSide, double deltaX, double deltaY)
        {
            if (window == null)
                throw new ArgumentNullException("window");

            double newLeft, newTop, newWidth, newHeight;

            bool isResized = CalculateHorizontalResize(window.Left, window.ActualWidth, window.MinWidth, targetSide, deltaX, out newLeft, out newWidth);
            isResized = CalculateVerticalResize(window.Top, window.ActualHeight, window.MinHeight, targetSide, deltaY, out newTop, out newHeight) || isResized;

            if (isResized)
            {
                window.Left = newLeft;
                window.Top = newTop;
                window.Width = newWidth;
                window.Height = newHeight;
            }

            return isResized;
        }

        /// <summary>
        /// Resize window.
        /// </summary>
        /// <param name="window">Target window.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="delta">Changed distance.</param>
        /// <returns>True if the window is resized.</returns>
        public static bool Resize(Window window, OctangleSide targetSide, Vector delta)
        {
            return Resize(window, targetSide, delta.X, delta.Y);
        }

        /// <summary>
        /// Resize window.
        /// </summary>
        /// <param name="window">Target window.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="e">Thumb's DragDelta event argument.</param>
        /// <returns>True if the window is resized.</returns>
        public static bool Resize(Window window, OctangleSide targetSide, DragDeltaEventArgs e)
        {
            return Resize(window, targetSide, e.HorizontalChange, e.VerticalChange);
        }


        /// <summary>
        /// Resize FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the FrameworkElement is resized.</returns>
        public static bool Resize(FrameworkElement element, OctangleSide targetSide, double deltaX, double deltaY)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            double newLeft, newTop, newWidth, newHeight;

            bool isResized = CalculateHorizontalResize(Canvas.GetLeft(element), element.ActualWidth, element.MinWidth, targetSide, deltaX, out newLeft, out newWidth);
            isResized = CalculateVerticalResize(Canvas.GetTop(element), element.ActualHeight, element.MinHeight, targetSide, deltaY, out newTop, out newHeight) || isResized;

            if (isResized)
            {
                Canvas.SetLeft(element, newLeft);
                Canvas.SetTop(element, newTop);
                element.Width = newWidth;
                element.Height = newHeight;
            }

            return isResized;
        }

        /// <summary>
        /// Resize FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="delta">Changed distance.</param>
        /// <returns>True if the FrameworkElement is resized.</returns>
        public static bool Resize(FrameworkElement element, OctangleSide targetSide, Vector delta)
        {
            return Resize(element, targetSide, delta.X, delta.Y);
        }

        /// <summary>
        /// Resize FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="targetSide">Side that is related to resize.</param>
        /// <param name="e">Thumb's DragDelta event argument.</param>
        /// <returns>True if the FrameworkElement is resized.</returns>
        public static bool Resize(FrameworkElement element, OctangleSide targetSide, DragDeltaEventArgs e)
        {
            return Resize(element, targetSide, e.HorizontalChange, e.VerticalChange);
        }

        #endregion


        #region Related to move

        /// <summary>
        /// Calculate horizontal move.
        /// </summary>
        /// <param name="left">Moved target's left.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="newLeft">New left resulted by move.</param>
        /// <returns>True if the left is changed.</returns>
        public static bool CalculateHorizontalMove(double left, double deltaX, out double newLeft)
        {
            // calculated left & width
            newLeft = left + deltaX;

            // If not changed
            if (deltaX == 0d)
                return false;

            return true;
        }

        /// <summary>
        /// Calculate vertical move.
        /// </summary>
        /// <param name="top">Moved target's top.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <param name="newTop">New top resulted by move.</param>
        /// <returns>True if the top is changed.</returns>
        public static bool CalculateVerticalMove(double top, double deltaY, out double newTop)
        {
            // calculated left & width
            newTop = top + deltaY;

            // If not changed
            if (deltaY == 0d)
                return false;

            return true;
        }


        /// <summary>
        /// Move window.
        /// </summary>
        /// <param name="window">Target window.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the window is moved.</returns>
        public static bool Move(Window window, double deltaX, double deltaY)
        {
            if (window == null)
                throw new ArgumentNullException("window");

            double newLeft, newTop;

            bool isMoved = CalculateHorizontalMove(window.Left, deltaX, out newLeft);
            isMoved = CalculateVerticalMove(window.Top, deltaY, out newTop) || isMoved;

            if (isMoved)
            {
                window.Left = newLeft;
                window.Top = newTop;
            }

            return isMoved;
        }

        /// <summary>
        /// Move window.
        /// </summary>
        /// <param name="window">Target window.</param>
        /// <param name="delta">Changed distance.</param>
        /// <returns>True if the window is moved.</returns>
        public static bool Move(Window window, Vector delta)
        {
            return Move(window, delta.X, delta.Y);
        }

        /// <summary>
        /// Move window.
        /// </summary>
        /// <param name="window">Target window.</param>
        /// <param name="e">Thumb's DragDelta event argument.</param>
        /// <returns>True if the window is moved.</returns>
        public static bool Move(Window window, DragDeltaEventArgs e)
        {
            return Move(window, e.HorizontalChange, e.VerticalChange);
        }


        /// <summary>
        /// Move FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the FrameworkElement is moved.</returns>
        public static bool Move(FrameworkElement element, double deltaX, double deltaY)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            double newLeft, newTop;

            bool isMoved = CalculateHorizontalMove(Canvas.GetLeft(element), deltaX, out newLeft);
            isMoved = CalculateVerticalMove(Canvas.GetTop(element), deltaY, out newTop) || isMoved;

            if (isMoved)
            {
                Canvas.SetLeft(element, newLeft);
                Canvas.SetTop(element, newTop);
            }

            return isMoved;
        }

        /// <summary>
        /// Move FrameworkElement that is laid on Canvas
        /// </summary>
        /// <param name="element">Target FrameworkElement</param>
        /// <param name="delta">Changed distance</param>
        /// <returns>True if the FrameworkElement is moved</returns>
        public static bool Move(FrameworkElement element, Vector delta)
        {
            return Move(element, delta.X, delta.Y);
        }

        /// <summary>
        /// Move FrameworkElement that is laid on Canvas
        /// </summary>
        /// <param name="element">Target FrameworkElement</param>
        /// <param name="e">Thumb's DragDelta event argument</param>
        /// <returns>True if the FrameworkElement is moved</returns>
        public static bool Move(FrameworkElement element, DragDeltaEventArgs e)
        {
            return Move(element, e.HorizontalChange, e.VerticalChange);
        }

        #endregion
    }
}
