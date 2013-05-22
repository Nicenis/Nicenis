/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.05.05
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

namespace Nicenis.Windows
{
    public enum HoverEventMode
    {
        /// <summary>
        /// The hover event is raised when the hover condition is met
        /// and it is not raised again if pointing device is still in the target element.
        /// To raise the hover event again, the pointing device must be left out
        /// and reenter the target element and the hover condition is met.
        /// </summary>
        Once,

        /// <summary>
        /// The hover event is raised when the hover condition is met.
        /// </summary>
        Normal,

        /// <summary>
        /// The hover event is raised when the hover condition is met
        /// and it is repeated until the hover condition is broken.
        /// The interval is HoverTime.
        /// </summary>
        Repeat,
    }
}