/*
 * Author   JO Hyeong-Ryeol
 * Since    2023.01.13
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2023 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Nicenis.Windows.Data.Converters
{
#pragma warning disable 1591    // Disables the warning for missing XML comment.

    /// <summary>
    /// Returns Visibility.Collapsed if the input value is false; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalseToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsFalse(value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if the input value is false; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class FalseToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !Booleany.IsFalse(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if the input value is false; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalseToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsFalse(value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if the input value is false; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class FalseToTrueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsFalse(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is false; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalseToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsFalse(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is false; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class FalseToVisibleHConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsFalse(value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if all input values are false; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AllFalseToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsFalse(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if all input values are false; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AllFalseToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return !values.All(p => Booleany.IsFalse(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if all input values are false; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AllFalseToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsFalse(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if all input values are false; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AllFalseToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsFalse(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are false; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AllFalseToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsFalse(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are false; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AllFalseToVisibleHConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsFalse(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if there is a falsy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AnyFalseToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsFalse(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if there is a falsy value in the input; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AnyFalseToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return !values.Any(p => Booleany.IsFalse(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if there is a falsy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AnyFalseToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsFalse(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if there is a falsy value in the input; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AnyFalseToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsFalse(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a falsy value in the input; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AnyFalseToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsFalse(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a falsy value in the input; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsFalse"/>
    public class AnyFalseToVisibleHConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsFalse(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

#pragma warning restore 1591    // Restores the warning for missing XML comment.
}
