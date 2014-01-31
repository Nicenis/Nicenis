/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.07.11
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Diagnostics;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Nicenis.Windows.Data.Converters
{
#pragma warning disable 1591    // Disables the warning for missing XML comment.

    /// <summary>
    /// Returns Visibility.Collapsed if the input value is truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToCollapsedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTruthy(value) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if the input value is truthy; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class TruthyToFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !Booleany.IsTruthy(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if the input value is truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTruthy(value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if the input value is truthy; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(bool))]
    public class TruthyToTrueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTruthy(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is truthy; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTruthy(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if the input value is truthy; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class TruthyToVisibleOtherwiseHiddenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Booleany.IsTruthy(value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if all input values are truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AllTruthyToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.All(p => Booleany.IsTruthy(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if all input values are truthy; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AllTruthyToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return !values.All(p => Booleany.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if all input values are truthy; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AllTruthyToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.All(p => Booleany.IsTruthy(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if all input values are truthy; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AllTruthyToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.All(p => Booleany.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are truthy; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AllTruthyToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.All(p => Booleany.IsTruthy(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if all input values are truthy; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AllTruthyToVisibleOtherwiseHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.All(p => Booleany.IsTruthy(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Collapsed if there is a truthy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AnyTruthyToCollapsedConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.Any(p => Booleany.IsTruthy(p)) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns false if there is a truthy value in the input; otherwise, true.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AnyTruthyToFalseConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return !values.Any(p => Booleany.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Hidden if there is a truthy value in the input; otherwise, Visibility.Visible.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AnyTruthyToHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.Any(p => Booleany.IsTruthy(p)) ? Visibility.Hidden : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns true if there is a truthy value in the input; otherwise, false.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AnyTruthyToTrueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.Any(p => Booleany.IsTruthy(p));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a truthy value in the input; otherwise, Visibility.Collapsed.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AnyTruthyToVisibleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.Any(p => Booleany.IsTruthy(p)) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }


    /// <summary>
    /// Returns Visibility.Visible if there is a truthy value in the input; otherwise, Visibility.Hidden.
    /// </summary>
    /// <seealso cref="Booleany.IsTruthy"/>
    public class AnyTruthyToVisibleOtherwiseHiddenConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Verifying.ParameterIsNotNull(values, "values");
            return values.Any(p => Booleany.IsTruthy(p)) ? Visibility.Visible : Visibility.Hidden;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

#pragma warning restore 1591    // Restores the warning for missing XML comment.
}
