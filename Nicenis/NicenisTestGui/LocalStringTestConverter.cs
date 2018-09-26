/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.09.26
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2018 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Globalization;
using System.Windows.Data;

namespace NicenisTestGui
{
    /// <summary>
    /// This converter is used to thest the LocalStringExtension.
    /// </summary>
    public class LocalStringTestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "--" + value?.ToString() + "--";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
