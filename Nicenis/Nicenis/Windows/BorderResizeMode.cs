/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.08.12
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;

namespace Nicenis.Windows
{
    /// <summary>
    /// Represents border resize mode.
    /// </summary>
    public enum BorderResizeMode
    {
        /// <summary>
        /// Resize by dragging the left edge.
        /// </summary>
        Left,

        /// <summary>
        /// Resize by dragging the top edge.
        /// </summary>
        Top,

        /// <summary>
        /// Resize by dragging the right edge.
        /// </summary>
        Right,

        /// <summary>
        /// Resize by dragging the bottom edge.
        /// </summary>
        Bottom,

        /// <summary>
        /// Resize by dragging the top left corner.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Resize by dragging the top right corner.
        /// </summary>
        TopRight,

        /// <summary>
        /// Resize by dragging the bottom left corner.
        /// </summary>
        BottomLeft,

        /// <summary>
        /// Resize by dragging the bottom right corner.
        /// </summary>
        BottomRight,
    }


    /// <summary>
    /// Represents bitwise-ored border resize modes.
    /// </summary>
    [Flags]
    public enum BorderResizeModes
    {
        /// <summary>
        /// Resize by dragging the left edge.
        /// </summary>
        Left = 0x00000001,

        /// <summary>
        /// Resize by dragging the top edge.
        /// </summary>
        Top = 0x00000002,

        /// <summary>
        /// Resize by dragging the right edge.
        /// </summary>
        Right = 0x00000004,

        /// <summary>
        /// Resize by dragging the bottom edge.
        /// </summary>
        Bottom = 0x00000008,

        /// <summary>
        /// Resize by dragging the top left corner.
        /// </summary>
        TopLeft = 0x00000010,

        /// <summary>
        /// Resize by dragging the top right corner.
        /// </summary>
        TopRight = 0x00000020,

        /// <summary>
        /// Resize by dragging the bottom left corner.
        /// </summary>
        BottomLeft = 0x00000040,

        /// <summary>
        /// Resize by dragging the bottom right corner.
        /// </summary>
        BottomRight = 0x00000080,


        /// <summary>
        /// Left | Right
        /// </summary>
        Horizontal = Left | Right,

        /// <summary>
        /// Top | Bottom
        /// </summary>
        Vertical = Top | Bottom,

        /// <summary>
        /// BottomLeft | TopRight
        /// </summary>
        Diagonal = BottomLeft | TopRight,

        /// <summary>
        /// TopLeft | BottomRight
        /// </summary>
        ReverseDiagonal = TopLeft | BottomRight,

        /// <summary>
        /// TopLeft | TopRight | BottomLeft | BottomRight
        /// </summary>
        Corners = Diagonal | ReverseDiagonal,


        /// <summary>
        /// All modes.
        /// </summary>
        All = Horizontal | Vertical | Corners,

        /// <summary>
        /// No mode.
        /// </summary>
        None = 0x00000000,
    }
}
