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
    /// Provides data for the PropertyObservable.PropertyValueChanging event.
    /// </summary>
    public interface IPropertyValueChangingEventArgs
    {
        /// <summary>
        /// Gets the name of the property that is changing.
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        object OldValue { get; }

        /// <summary>
        /// Gets or sets the value of the property that is about to change.
        /// </summary>
        object NewValue { get; set; }
    }
}
