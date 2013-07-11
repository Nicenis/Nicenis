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
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Nicenis.Windows.Data.Converters
{
    /// <summary>
    /// Provides utility methods related to TruthyToConverter series.
    /// </summary>
    internal static class TruthyToConverterHelper
    {
        /// <summary>
        /// Indicates whether the specified value is a truthy value.
        /// </summary>
        /// <remarks>
        /// Truthy/Falsy concept is originated from the JavaScript.
        /// There are seven values that is falsy: null, 0, false, NaN, DBNull, an empty string and an empty collection.
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
                return (float)value != 0;

            if (value is decimal)
                return (decimal)value != 0m;

            return false;
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if the input value is truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TruthyToConverterHelper.IsTruthy(value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns false if the input value is truthy; otherwise, true.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class TruthyToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !TruthyToConverterHelper.IsTruthy(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if the input value is truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TruthyToConverterHelper.IsTruthy(value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns true if the input value is truthy; otherwise, false.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class TruthyToTrueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TruthyToConverterHelper.IsTruthy(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is truthy; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TruthyToConverterHelper.IsTruthy(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is truthy; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToVisibleOtherwiseHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TruthyToConverterHelper.IsTruthy(value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if all input values are truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AllTruthyToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns false if all input values are truthy; otherwise, true.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AllTruthyToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return !values.All(p => TruthyToConverterHelper.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if all input values are truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AllTruthyToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns true if all input values are truthy; otherwise, false.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AllTruthyToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => TruthyToConverterHelper.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are truthy; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AllTruthyToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are truthy; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AllTruthyToVisibleOtherwiseHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if there is a truthy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AnyTruthyToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns false if there is a truthy value in the input; otherwise, true.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AnyTruthyToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return !values.Any(p => TruthyToConverterHelper.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if there is a truthy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AnyTruthyToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns true if there is a truthy value in the input; otherwise, false.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AnyTruthyToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => TruthyToConverterHelper.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a truthy value in the input; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AnyTruthyToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a truthy value in the input; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="TruthyToConverterHelper.IsTruthy"/>
    public class AnyTruthyToVisibleOtherwiseHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => TruthyToConverterHelper.IsTruthy(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
