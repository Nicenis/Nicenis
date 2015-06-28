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
    /// Provides data for a value that is about to change.
    /// </summary>
    public interface IValueChangingEventArgs<T>
    {
        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        T OldValue { get; }

        /// <summary>
        /// Gets or sets the value of the property that is about to change.
        /// </summary>
        T NewValue { get; set; }
    }
}
