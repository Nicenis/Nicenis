/*
 * Author   JO Hyeong-Ryeol
 * Since    2019.02.06
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2019 JO Hyeong-Ryeol. All rights reserved.
 */

using NicenisTestGui.Properties;

namespace NicenisTestGui.VolatileBindingTest
{
    public enum VolatileBindingTestEnum
    {
        Welcome,
    }

    /// <summary>
    /// Provides extension methods for the VolatileBindingTestEnum.
    /// </summary>
    public static class VolatileBindingTestEnumExtensions
    {
        public static string ToLoalizedString(this VolatileBindingTestEnum? value)
        {
            switch (value)
            {
                case VolatileBindingTestEnum.Welcome:
                    return MainStrings.Welcome;
            }

            return value.ToString();
        }
    }
}
