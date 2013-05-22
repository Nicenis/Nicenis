/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.05.05
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System.Diagnostics;
using System.Windows;

namespace Nicenis.Windows
{
    public class HoverEventArgs : RoutedEventArgs
    {
        #region Constructors

        internal HoverEventArgs(RoutedEvent routedEvent, object source,
                Point basePosition, long baseTicks, Point hoveredPosition, long hoveredTicks)
            : base(routedEvent, source)
        {
            BasePosition = basePosition;
            BaseTicks = baseTicks;
            HoveredPosition = hoveredPosition;
            HoveredTicks = hoveredTicks;
        }

        #endregion


        #region Properties

        /// <summary>
        /// The base position for recognizing hover action.
        /// </summary>
        public Point BasePosition { get; private set; }

        /// <summary>
        /// The ticks when the BasePosition is set.
        /// </summary>
        public long BaseTicks { get; private set; }

        /// <summary>
        /// The position at which the hover event is occurred.
        /// </summary>
        public Point HoveredPosition { get; private set; }

        /// <summary>
        /// The ticks when the hover event is occurred.
        /// </summary>
        public long HoveredTicks { get; private set; }

        #endregion
    }
}
