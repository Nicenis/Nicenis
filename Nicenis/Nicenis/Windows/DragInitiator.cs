/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.06.18
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Diagnostics;
using System.Windows.Input;

namespace Nicenis.Windows
{
    /// <summary>
    /// Defines drag initiator.
    /// </summary>
    public enum DragInitiator
    {
        /// <summary>
        /// The left mouse button.
        /// </summary>
        MouseLeftButton = 0x00000001,

        /// <summary>
        /// The middle mouse button.
        /// </summary>
        MouseMiddleButton = 0x00000002,

        /// <summary>
        /// The right mouse button.
        /// </summary>
        MouseRightButton = 0x00000004,

        /// <summary>
        /// The first extended mouse button.
        /// </summary>
        MouseXButton1 = 0x00000008,

        /// <summary>
        /// The second extended mouse button.
        /// </summary>
        MouseXButton2 = 0x00000010,
    }

    /// <summary>
    /// Defines bitwise-ored drag initiators.
    /// </summary>
    [Flags]
    public enum DragInitiators
    {
        /// <summary>
        /// The left mouse button.
        /// </summary>
        MouseLeftButton = DragInitiator.MouseLeftButton,

        /// <summary>
        /// The middle mouse button.
        /// </summary>
        MouseMiddleButton = DragInitiator.MouseMiddleButton,

        /// <summary>
        /// The right mouse button.
        /// </summary>
        MouseRightButton = DragInitiator.MouseRightButton,

        /// <summary>
        /// The first extended mouse button.
        /// </summary>
        MouseXButton1 = DragInitiator.MouseXButton1,

        /// <summary>
        /// The second extended mouse button.
        /// </summary>
        MouseXButton2 = DragInitiator.MouseXButton2,

        /// <summary>
        /// All mouse related drag initiators.
        /// </summary>
        Mouse = MouseLeftButton
                | MouseMiddleButton
                | MouseRightButton
                | MouseXButton1
                | MouseXButton2,

        /// <summary>
        /// The default.
        /// </summary>
        Default = MouseLeftButton,

        /// <summary>
        /// All drag initiators.
        /// </summary>
        All = Mouse,
    }

    /// <summary>
    /// Provides utility methods for DragInitiator.
    /// </summary>
    public static class DragInitiatorHelper
    {
        /// <summary>
        /// Converts a MouseButton enumeration to a DragInitiator enumeration.
        /// </summary>
        /// <param name="mouseButton">The MouseButton enumeration.</param>
        /// <returns>The converted DragInitiator.</returns>
        public static DragInitiator ToDragInitiator(this MouseButton mouseButton)
        {
            switch (mouseButton)
            {
                case MouseButton.Left:
                    return DragInitiator.MouseLeftButton;

                case MouseButton.Middle:
                    return DragInitiator.MouseMiddleButton;

                case MouseButton.Right:
                    return DragInitiator.MouseRightButton;

                case MouseButton.XButton1:
                    return DragInitiator.MouseXButton1;

                case MouseButton.XButton2:
                    return DragInitiator.MouseXButton2;
            }

            throw new InvalidOperationException
            (
                string.Format("The MouseButton '{0}' is unknown.", mouseButton.ToString())
            );
        }

        /// <summary>
        /// Converts a MouseButton enumeration to a DragInitiators enumeration.
        /// </summary>
        /// <param name="mouseButton">The MouseButton enumeration.</param>
        /// <returns>The converted DragInitiators.</returns>
        public static DragInitiators ToDragInitiators(this MouseButton mouseButton)
        {
            return (DragInitiators)ToDragInitiator(mouseButton);
        }

        /// <summary>
        /// Converts a DragInitiator enumeration to a DragInitiators enumeration.
        /// </summary>
        /// <param name="dragInitiator">The DragInitiator enumeration.</param>
        /// <returns>The converted DragInitiators.</returns>
        public static DragInitiators ToDragInitiators(this DragInitiator dragInitiator)
        {
            return (DragInitiators)dragInitiator;
        }

        /// <summary>
        /// Converts a DragInitiator enumeration to a MouseButton enumeration.
        /// </summary>
        /// <param name="dragInitiator">The DragInitiator enumeration.</param>
        /// <returns>The converted MouseButton.</returns>
        public static MouseButton ToMouseButton(this DragInitiator dragInitiator)
        {
            switch (dragInitiator)
            {
                case DragInitiator.MouseLeftButton:
                    return MouseButton.Left;

                case DragInitiator.MouseMiddleButton:
                    return MouseButton.Middle;

                case DragInitiator.MouseRightButton:
                    return MouseButton.Right;

                case DragInitiator.MouseXButton1:
                    return MouseButton.XButton1;

                case DragInitiator.MouseXButton2:
                    return MouseButton.XButton2;
            }

            throw new InvalidOperationException
            (
                string.Format
                (
                    "The DragInitiator '{0}' can not be converted into MouseButton.",
                    dragInitiator.ToString()
                )
            );
        }

        /// <summary>
        /// Returns whether device state specified by the dragInitiator is active.
        /// </summary>
        /// <param name="dragInitiator">The DragInitiator enumeration.</param>
        /// <returns>True if it is active; otherwise false.</returns>
        internal static bool IsActive(this DragInitiator dragInitiator)
        {
            switch (dragInitiator)
            {
                case DragInitiator.MouseLeftButton:
                    return Mouse.LeftButton == MouseButtonState.Pressed;

                case DragInitiator.MouseMiddleButton:
                    return Mouse.MiddleButton == MouseButtonState.Pressed;

                case DragInitiator.MouseRightButton:
                    return Mouse.RightButton == MouseButtonState.Pressed;

                case DragInitiator.MouseXButton1:
                    return Mouse.XButton1 == MouseButtonState.Pressed;

                case DragInitiator.MouseXButton2:
                    return Mouse.XButton2 == MouseButtonState.Pressed;
            }

            return false;
        }
    }
}