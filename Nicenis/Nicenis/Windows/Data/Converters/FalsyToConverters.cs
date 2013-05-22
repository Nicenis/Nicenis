/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.08.22
 * Version	$Id: FalsyToConverters.cs 24043 2013-05-21 14:49:03Z unknown $
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
    internal static class FalsyToConverterHelper
    {
        /// <summary>
        /// Truthy 값으로 인식되는 경우 true를 반환한다.
        /// null, 빈문자열, 0, false, 빈 컬랙션 등이 아니면 true 를 반환한다.
        /// </summary>
        /// <param name="value">검사할 값</param>
        /// <returns>Truthy 값인지 여부</returns>
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
        /// Falsy 값으로 인식되는 경우 true를 반환한다.
        /// null, 빈문자열, 0, false, 빈 컬랙션 등이 true 를 반환한다.
        /// </summary>
        /// <param name="value">검사할 값</param>
        /// <returns>Falsy 값인지 여부</returns>
        public static bool IsFalsy(object value)
        {
            return !IsTruthy(value);
        }
    }


    /// <summary>
    /// 값이 Falsy 이면 Visibility.Collapsed, 그렇지 않으면 Visibility.Visible 을 반환한다.
    /// </summary>
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
    /// 값이 Falsy 이면 false 를 반환한다.
    /// </summary>
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
    /// 값이 Falsy 이면 Visibility.Hidden, 그렇지 않으면 Visibility.Visible 을 반환한다.
    /// </summary>
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
    /// 값이 Falsy 이면 true 를 반환한다.
    /// </summary>
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
    /// 값이 Falsy 이면 Visibility.Visible, 그렇지 않으면 Visibility.Collapsed 를 반환한다.
    /// </summary>
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
    /// 값이 Falsy 이면 Visibility.Visible, 그렇지 않으면 Visibility.Hidden 를 반환한다.
    /// </summary>
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
    /// 값이 전부 Falsy 이면 Visibility.Collapsed, 그렇지 않으면 Visibility.Visible 을 반환한다.
    /// </summary>
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
    /// 값이 전부 Falsy 이면 false 를 반환한다.
    /// </summary>
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
    /// 값이 전부 Falsy 이면 Visibility.Hidden, 그렇지 않으면 Visibility.Visible 을 반환한다.
    /// </summary>
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
    /// 값이 전부 Falsy 이면 true 를 반환한다.
    /// </summary>
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
    /// 값이 전부 Falsy 이면 Visibility.Visible, 그렇지 않으면 Visibility.Collapsed 을 반환한다.
    /// </summary>
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
    /// 값이 전부 Falsy 이면 Visibility.Visible, 그렇지 않으면 Visibility.Hidden 을 반환한다.
    /// </summary>
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
    /// 값이 하나라도 Falsy 이면 Visibility.Collapsed, 그렇지 않으면 Visibility.Visible 을 반환한다.
    /// </summary>
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
    /// 값이 하나라도 Falsy 이면 false 를 반환한다.
    /// </summary>
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
    /// 값이 하나라도 Falsy 이면 Visibility.Hidden, 그렇지 않으면 Visibility.Visible 을 반환한다.
    /// </summary>
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
    /// 값이 하나라도 Falsy 이면 true 를 반환한다.
    /// </summary>
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
    /// 값이 하나라도 Falsy 이면 Visibility.Visible, 그렇지 않으면 Visibility.Collapsed 을 반환한다.
    /// </summary>
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
    /// 값이 하나라도 Falsy 이면 Visibility.Visible, 그렇지 않으면 Visibility.Hidden 을 반환한다.
    /// </summary>
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
