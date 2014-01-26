/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.07.11
 * Version	$Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections;
using System.Linq;

namespace Nicenis
{
    /// <summary>
    /// Provides utility methods related to Truthy and Falsy.
    /// </summary>
    public static class Booleany
    {
        /// <summary>
        /// Indicates whether the specified value is a truthy value.
        /// </summary>
        /// <remarks>
        /// The truthy/falsy concept is originated from the JavaScript.
        /// There are seven values that are falsy: null, 0, false, NaN, DBNull, an empty string and an empty collection.
        /// </remarks>
        /// <param name="value">The value to evaluate.</param>
        /// <returns>True if it is a truthy value; otherwise, false.</returns>
        public static bool IsTruthy(object value)
        {
            if (value == null)
                return false;

            if (value is string)
                return (string)value != "";

            if (value is bool)
                return (bool)value;

            if (value is int)
                return (int)value != 0;

            if (value is double)
            {
                double doubleValue = (double)value;
                return doubleValue != 0d && !double.IsNaN(doubleValue);
            }

            if (value is long)
                return (long)value != 0L;

            if (value is ICollection)
                return ((ICollection)value).Count != 0;

            if (value is IEnumerable)
                return ((IEnumerable)value).Cast<object>().Any();

            if (value is DBNull)
                return false;

            if (value is sbyte)
                return (sbyte)value != 0;

            if (value is byte)
                return (byte)value != 0;

            if (value is short)
                return (short)value != 0;

            if (value is ushort)
                return (ushort)value != 0;

            if (value is uint)
                return (uint)value != 0;

            if (value is float)
                return (float)value != 0f;

            if (value is decimal)
                return (decimal)value != 0m;

            return true;
        }

        /// <summary>
        /// Indicates whether the specified value is a falsy value.
        /// </summary>
        /// <seealso cref="IsTruthy"/>
        /// <param name="value">The value to evaluate.</param>
        /// <returns>True if it is a falsy value; otherwise, false.</returns>
        public static bool IsFalsy(object value)
        {
            return !IsTruthy(value);
        }
    }
}
