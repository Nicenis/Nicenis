/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.08.12
 * Version	$Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
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
        /// <param name="maxWidth">Resized target's maximum width.</param>
        /// <param name="resizeMode">Resize mode.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="isNewLeft">True if the newLeftOrRight is left; otherwise false.</param>
        /// <param name="newLeftOrRight">New left or right resulted by resize. If it is right, it is equal to the sum of the left and width.</param>
        /// <param name="newWidth">New width resulted by resize.</param>
        /// <returns>True if the width is changed.</returns>
        private static bool CalculateHorizontalResize(double left, double width, double minWidth, double maxWidth, BorderResizeMode resizeMode, double deltaX,
                                                                                    out bool isNewLeft, out double newLeftOrRight, out double newWidth)
        {
            // Initializes out variables.
            isNewLeft = true;
            newLeftOrRight = left;
            newWidth = width;

            // If not changed
            if (deltaX == 0d)
                return false;

            // If it is not related to horizontal resize
            if (resizeMode == BorderResizeMode.Top || resizeMode == BorderResizeMode.Bottom)
                return false;

            // If it is positioned left
            if (resizeMode == BorderResizeMode.Left || resizeMode == BorderResizeMode.TopLeft || resizeMode == BorderResizeMode.BottomLeft)
            {
                newWidth = Math.Max(width - deltaX, minWidth);

                // Saves the right.
                isNewLeft = false;
                newLeftOrRight = left + width;
            }
            else
            {
                newWidth = Math.Max(width + deltaX, minWidth);
            }

            // Adjusts not to exceed the max width.
            newWidth = Math.Min(newWidth, maxWidth);

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
        /// <param name="maxHeight">Resized target's maximum height.</param>
        /// <param name="resizeMode">Resize mode.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <param name="isNewTop">True if the newTopOrBottom is top; otherwise false.</param>
        /// <param name="newTopOrBottom">New top or bottom resulted by resize. If it is bottom, it is equal to the sum of the top and height.</param>
        /// <param name="newHeight">New height resulted by resize.</param>
        /// <returns>True if the height is changed.</returns>
        private static bool CalculateVerticalResize(double top, double height, double minHeight, double maxHeight, BorderResizeMode resizeMode, double deltaY,
                                                                                    out bool isNewTop, out double newTopOrBottom, out double newHeight)
        {
            // Initializes out variables.
            isNewTop = true;
            newTopOrBottom = top;
            newHeight = height;

            // If not changed
            if (deltaY == 0d)
                return false;

            // If it is not related to vertical resize
            if (resizeMode == BorderResizeMode.Left || resizeMode == BorderResizeMode.Right)
                return false;

            // If it is positioned top
            if (resizeMode == BorderResizeMode.Top || resizeMode == BorderResizeMode.TopLeft || resizeMode == BorderResizeMode.TopRight)
            {
                newHeight = Math.Max(height - deltaY, minHeight);

                // Saves the bottom.
                isNewTop = false;
                newTopOrBottom = top + height;
            }
            else
            {
                newHeight = Math.Max(height + deltaY, minHeight);
            }

            // Adjusts not to exceed the max height.
            newHeight = Math.Min(newHeight, maxHeight);

            // If it is not changed
            if (height == newHeight)
                return false;

            return true;
        }


        /// <summary>
        /// Resize window.
        /// </summary>
        /// <param name="window">Target window.</param>
        /// <param name="resizeMode">Resize mode.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the window is resized.</returns>
        private static bool ResizeWindow(Window window, BorderResizeMode resizeMode, double deltaX, double deltaY)
        {
            if (window == null)
                throw new ArgumentNullException("window");

            bool isNewLeft, isNewTop;
            double newLeftOrRight, newTopOrBottom, newWidth, newHeight;

            bool isResized = CalculateHorizontalResize
            (
                window.Left,
                window.ActualWidth,
                window.MinWidth,
                window.MaxWidth,
                resizeMode,
                deltaX,
                out isNewLeft,
                out newLeftOrRight,
                out newWidth
            );

            isResized = CalculateVerticalResize
            (
                window.Top,
                window.ActualHeight,
                window.MinHeight,
                window.MaxHeight,
                resizeMode,
                deltaY,
                out isNewTop,
                out newTopOrBottom,
                out newHeight
            ) || isResized;

            if (isResized)
            {
                // Window has inherent min width and height.
                // So the ActualWidth and ActualHeight must be used.
                window.Width = newWidth;
                window.Left = isNewLeft ? newLeftOrRight : newLeftOrRight - window.ActualWidth;

                window.Height = newHeight;
                window.Top = isNewTop ? newTopOrBottom : newTopOrBottom - window.ActualHeight;
            }

            return isResized;
        }

        /// <summary>
        /// Resize FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="resizeMode">Resize mode.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the FrameworkElement is resized.</returns>
        private static bool ResizeFrameworkElement(FrameworkElement element, BorderResizeMode resizeMode, double deltaX, double deltaY)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            bool isNewLeft, isNewTop;
            double newLeftOrRight, newTopOrBottom, newWidth, newHeight;

            bool isResized = CalculateHorizontalResize
            (
                Canvas.GetLeft(element),
                element.ActualWidth,
                element.MinWidth,
                element.MaxWidth,
                resizeMode,
                deltaX,
                out isNewLeft,
                out newLeftOrRight,
                out newWidth
            );

            isResized = CalculateVerticalResize
            (
                Canvas.GetTop(element),
                element.ActualHeight,
                element.MinHeight,
                element.MaxHeight,
                resizeMode,
                deltaY,
                out isNewTop,
                out newTopOrBottom,
                out newHeight
            ) || isResized;

            if (isResized)
            {
                // Do not use the ActualWidth and ActualHeight because it is not work.
                element.Width = newWidth;
                Canvas.SetLeft(element, isNewLeft ? newLeftOrRight : newLeftOrRight - newWidth);

                element.Height = newHeight;
                Canvas.SetTop(element, isNewTop ? newTopOrBottom : newTopOrBottom - newHeight);
            }

            return isResized;
        }


        /// <summary>
        /// Resize FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="resizeMode">Resize mode.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the FrameworkElement is resized.</returns>
        public static bool Resize(FrameworkElement element, BorderResizeMode resizeMode, double deltaX, double deltaY)
        {
            // Resizes the target element.
            Window window = element as Window;

            if (window != null)
                return ResizeWindow(window, resizeMode, deltaX, deltaY);

            return ResizeFrameworkElement(element, resizeMode, deltaX, deltaY);
        }

        /// <summary>
        /// Resize FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="resizeMode">Resize mode.</param>
        /// <param name="delta">Changed distance.</param>
        /// <returns>True if the FrameworkElement is resized.</returns>
        public static bool Resize(FrameworkElement element, BorderResizeMode resizeMode, Vector delta)
        {
            return Resize(element, resizeMode, delta.X, delta.Y);
        }

        /// <summary>
        /// Resize FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="resizeMode">Resize mode.</param>
        /// <param name="e">Thumb's DragDelta event argument.</param>
        /// <returns>True if the FrameworkElement is resized.</returns>
        public static bool Resize(FrameworkElement element, BorderResizeMode resizeMode, DragDeltaEventArgs e)
        {
            return Resize(element, resizeMode, e.HorizontalChange, e.VerticalChange);
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
        private static bool CalculateHorizontalMove(double left, double deltaX, out double newLeft)
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
        private static bool CalculateVerticalMove(double top, double deltaY, out double newTop)
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
        private static bool MoveWindow(Window window, double deltaX, double deltaY)
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
        /// Move FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the FrameworkElement is moved.</returns>
        private static bool MoveFrameworkElement(FrameworkElement element, double deltaX, double deltaY)
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
        /// Move FrameworkElement that is laid on Canvas.
        /// </summary>
        /// <param name="element">Target FrameworkElement.</param>
        /// <param name="deltaX">Distance that is changed horizontally.</param>
        /// <param name="deltaY">Distance that is changed vertically.</param>
        /// <returns>True if the FrameworkElement is moved.</returns>
        public static bool Move(FrameworkElement element, double deltaX, double deltaY)
        {
            // Moves the target element.
            Window window = element as Window;

            if (window != null)
                return MoveWindow(window, deltaX, deltaY);

            return MoveFrameworkElement(element, deltaX, deltaY);
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
