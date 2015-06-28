/*
 * Author   JO Hyeong-Ryeol
 * Since    2015.06.28
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2015 JO Hyeong-Ryeol. All rights reserved.
 */

namespace Nicenis.ComponentModel
{
    /// <summary>
    /// Provides data for a changed value.
    /// </summary>
    public interface IValueChangedEventArgs<T>
    {
        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        T OldValue { get; }

        /// <summary>
        /// Gets the value of the property after the change.
        /// </summary>
        T NewValue { get; }
    }
}
