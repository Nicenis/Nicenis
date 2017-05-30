/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.07.11
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
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

            if (value is string stringValue)
                return stringValue != "";

            if (value is bool boolValue)
                return boolValue;

            if (value is int intValue)
                return intValue != 0;

            if (value is double doubleValue)
                return doubleValue != 0d && !double.IsNaN(doubleValue);

            if (value is long longValue)
                return longValue != 0L;

            if (value is ICollection collectionValue)
                return collectionValue.Count != 0;

            if (value is IEnumerable enumerableValue)
                return enumerableValue.Cast<object>().Any();

            if (value is DBNull)
                return false;

            if (value is sbyte)
                return (sbyte)value != 0;

            if (value is byte byteValue)
                return byteValue != 0;

            if (value is short shortValue)
                return shortValue != 0;

            if (value is ushort ushortValue)
                return ushortValue != 0;

            if (value is uint uintValue)
                return uintValue != 0;

            if (value is float floatValue)
                return floatValue != 0f;

            if (value is decimal decimalValue)
                return decimalValue != 0m;

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
