/*
 * Author   JO Hyeong-Ryeol
 * Since    2019.01.23
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2019 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Globalization;
using System.Windows.Data;

namespace NicenisTestGui.VolatileBindingTest
{
    /// <summary>
    /// This converter is used to test the VolatileBindingExtension.
    /// </summary>
    public class VolatileBindingTestConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as VolatileBindingTestEnum?).ToLoalizedString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
