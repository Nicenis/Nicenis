/*
 * Author   JO Hyeong-Ryeol
 * Since    2015.06.26
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2015 JO Hyeong-Ryeol. All rights reserved.
 */

using System;

namespace Nicenis.ComponentModel
{
    /// <summary>
    /// Provides data for value changes.
    /// </summary>
    public class ValueChangedEventArgs<T> : EventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        public ValueChangedEventArgs(T oldValue, T newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        public T OldValue { get; private set; }

        /// <summary>
        /// Gets the value of the property after the change.
        /// </summary>
        public T NewValue { get; private set; }

        #endregion
    }
}
