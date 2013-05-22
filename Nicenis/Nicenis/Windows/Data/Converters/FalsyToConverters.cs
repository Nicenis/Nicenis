/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.08.22
 * Version	$Id$
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
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
    /// Provides utility methods related to FalsyToConverter series.
    /// </summary>
    public static class FalsyToConverterHelper
    {
        /// <summary>
        /// Indicates whether the specified value is a truthy value.
        /// </summary>
        /// <remarks>
        /// Truthy/Falsy concept is originated from the JavaScript.
        /// There are five values that is falsy: null, 0, false, an empty string and an empty collection.
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
                return (double)value != 0d;

            if (value is long)
                return (long)value != 0L;

            if (value is ICollection)
                return ((ICollection)value).Count != 0;

            if (value is IEnumerable)
                return ((IEnumerable)value).Cast<object>().Any();

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


    /// <summary>
    /// Returns Visibility.Collapsed if the input value is falsy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalsyToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !FalsyToConverterHelper.IsFalsy(value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns false if the input value is falsy; otherwise, true.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class FalsyToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !FalsyToConverterHelper.IsFalsy(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if the input value is falsy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalsyToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !FalsyToConverterHelper.IsFalsy(value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns true if the input value is falsy; otherwise, false.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class FalsyToTrueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return FalsyToConverterHelper.IsFalsy(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is falsy; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalsyToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !FalsyToConverterHelper.IsFalsy(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is falsy; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalsyToVisibleOtherwiseHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !FalsyToConverterHelper.IsFalsy(value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if all input values are falsy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AllFalsyToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns false if all input values are falsy; otherwise, true.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AllFalsyToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return !values.All(p => FalsyToConverterHelper.IsFalsy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if all input values are falsy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AllFalsyToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns true if all input values are falsy; otherwise, false.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AllFalsyToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => FalsyToConverterHelper.IsFalsy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are falsy; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AllFalsyToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are falsy; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AllFalsyToVisibleOtherwiseHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.All(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if there is a falsy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AnyFalsyToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns false if there is a falsy value in the input; otherwise, true.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AnyFalsyToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return !values.Any(p => FalsyToConverterHelper.IsFalsy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if there is a falsy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AnyFalsyToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns true if there is a falsy value in the input; otherwise, false.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AnyFalsyToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => FalsyToConverterHelper.IsFalsy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a falsy value in the input; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AnyFalsyToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a falsy value in the input; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="FalsyToConverterHelper.IsTruthy"/>
    public class AnyFalsyToVisibleOtherwiseHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            return values.Any(p => FalsyToConverterHelper.IsFalsy(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
