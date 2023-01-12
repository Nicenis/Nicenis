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
    /// Returns Visibility.Collapsed if the input value is true; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TrueToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTrue(value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if the input value is true; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class TrueToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !Booleany.IsTrue(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if the input value is true; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TrueToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTrue(value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is true; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TrueToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTrue(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is true; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TrueToVisibleHConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTrue(value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if all input values are true; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AllTrueToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsTrue(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if all input values are true; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AllTrueToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return !values.All(p => Booleany.IsTrue(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if all input values are true; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AllTrueToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsTrue(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if all input values are true; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AllTrueToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsTrue(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are true; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AllTrueToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsTrue(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are true; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AllTrueToVisibleHConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.All(p => Booleany.IsTrue(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if there is a True value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AnyTrueToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsTrue(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if there is a True value in the input; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AnyTrueToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return !values.Any(p => Booleany.IsTrue(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if there is a True value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AnyTrueToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsTrue(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if there is a True value in the input; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AnyTrueToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsTrue(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a True value in the input; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AnyTrueToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsTrue(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a True value in the input; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsTrue"/>
    public class AnyTrueToVisibleHConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));

            return values.Any(p => Booleany.IsTrue(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

#pragma warning restore 1591    // Restores the warning for missing XML comment.
}
