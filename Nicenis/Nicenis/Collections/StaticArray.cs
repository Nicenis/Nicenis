/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.08.12
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

namespace Nicenis.Collections
{
    /// <summary>
    /// Provides functionalities related to static array.
    /// </summary>
    public static class StaticArray
    {
        #region StaticArrayHolder

        /// <summary>
        /// Internal holder for static empty arrays.
        /// </summary>
        /// <remarks>
        /// Reference:
        /// http://stackoverflow.com/questions/151936/does-an-empty-array-in-net-use-any-space
        /// </remarks>
        /// <typeparam name="T">The element type of the array.</typeparam>
        private static class StaticArrayHolder<T>
        {
            /// <summary>
            /// The singleton empty array.
            /// </summary>
            public static readonly T[] Empty = new T[0];
        }

        #endregion

        /// <summary>
        /// Returns the singleton empty array.
        /// </summary>
        /// <typeparam name="T">The element type of the array.</typeparam>
        /// <returns>The singleton empty array.</returns>
        public static T[] Empty<T>()
        {
            return StaticArrayHolder<T>.Empty;
        }
    }
}
