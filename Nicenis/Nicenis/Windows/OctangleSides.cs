/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.11
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;

namespace Nicenis.Windows
{
    /// <summary>
    /// Represents 8 sides
    /// </summary>
    [Flags]
    public enum OctangleSides
    {
        /// <summary>
        /// Left side
        /// </summary>
        Left = 0x00000001,

        /// <summary>
        /// Top side
        /// </summary>
        Top = 0x00000002,

        /// <summary>
        /// Right side
        /// </summary>
        Right = 0x00000004,

        /// <summary>
        /// Bottom side
        /// </summary>
        Bottom = 0x00000008,

        /// <summary>
        /// Top left side
        /// </summary>
        TopLeft = 0x00000010,

        /// <summary>
        /// Top right side
        /// </summary>
        TopRight = 0x00000020,

        /// <summary>
        /// Bottom left side
        /// </summary>
        BottomLeft = 0x00000040,

        /// <summary>
        /// Bottom right side
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
        /// All sides
        /// </summary>
        All = Horizontal | Vertical | Diagonal | ReverseDiagonal,
    }
}
