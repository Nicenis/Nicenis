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
    /// Provides data for the PropertyObservable.PropertyValueChanged event.
    /// </summary>
    public interface IPropertyValueChangedEventArgs
    {
        /// <summary>
        /// Gets the name of the property that changed.
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        object OldValue { get; }

        /// <summary>
        /// Gets the value of the property after the change.
        /// </summary>
        object NewValue { get; }
    }
}
