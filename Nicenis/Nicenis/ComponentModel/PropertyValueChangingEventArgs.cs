/*
 * Author   JO Hyeong-Ryeol
 * Since    2015.06.28
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2015 JO Hyeong-Ryeol. All rights reserved.
 */

using System.ComponentModel;

namespace Nicenis.ComponentModel
{
    /// <summary>
    /// Provides data for the PropertyObservable.PropertyValueChanging event.
    /// </summary>
    public class PropertyValueChangingEventArgs : PropertyChangedEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        public PropertyValueChangingEventArgs(string propertyName, object oldValue, object newValue)
            : base(propertyName)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        public object OldValue { get; private set; }

        /// <summary>
        /// Gets the value of the property after the change.
        /// </summary>
        public object NewValue { get; set; }

        #endregion
    }
}
