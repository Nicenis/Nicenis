/*
 * Author   JO Hyeong-Ryeol
 * Since    2017.11.21
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * Originated from PropertyObservable.cs.
 * 
 * Copyright (C) 2017 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Nicenis.ComponentModel
{
    #region Related Types

    /// <summary>
    /// Provides data for a property value changing event handler.
    /// </summary>
    public interface IPropertyValueChangingEventArgs<T>
    {
        /// <summary>
        /// Gets the name of the property that is changing.
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        T OldValue { get; }

        /// <summary>
        /// Gets or sets the value of the property that is about to change.
        /// </summary>
        T NewValue { get; set; }
    }

    /// <summary>
    /// Provides data for a property value changed event handler.
    /// </summary>
    public interface IPropertyValueChangedEventArgs<T>
    {
        /// <summary>
        /// Gets the name of the property that changed.
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// Gets the value of the property before the change.
        /// </summary>
        T OldValue { get; }

        /// <summary>
        /// Gets the value of the property after the change.
        /// </summary>
        T NewValue { get; }
    }

    /// <summary>
    /// Provides data for a property value changing event handler.
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

    /// <summary>
    /// Provides data for a property value changed event handler.
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

    #endregion


    /// <summary>
    /// Provides a base implementation for the INotifyPropertyChanged interface.
    /// </summary>
    [DataContract]
    public class PropertyObservableCore : INotifyPropertyChanged
    {
        #region PropertyValueChangeEventArgs

        /// <summary>
        /// The event arguments for property value change related events.
        /// </summary>
        internal class PropertyValueChangeEventArgs<T> : PropertyChangedEventArgs,
                IPropertyValueChangingEventArgs<T>, IPropertyValueChangedEventArgs<T>, IPropertyValueChangingEventArgs, IPropertyValueChangedEventArgs
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="propertyName">The name of the property.</param>
            /// <param name="oldValue">The value of the property before the change.</param>
            /// <param name="newValue">The value of the property after the change.</param>
            public PropertyValueChangeEventArgs(string propertyName, T oldValue, T newValue)
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
            public T OldValue { get; private set; }

            /// <summary>
            /// Gets or sets the value of the property after the change.
            /// </summary>
            public T NewValue { get; set; }

            #endregion


            #region IPropertyValueChangingEventArgs Implementation

            string IPropertyValueChangingEventArgs.PropertyName
            {
                get { return PropertyName; }
            }

            object IPropertyValueChangingEventArgs.OldValue
            {
                get { return OldValue; }
            }

            object IPropertyValueChangingEventArgs.NewValue
            {
                get { return NewValue; }
                set { NewValue = (T)value; }
            }

            #endregion


            #region IPropertyValueChangedEventArgs Implementation

            string IPropertyValueChangedEventArgs.PropertyName
            {
                get { return PropertyName; }
            }

            object IPropertyValueChangedEventArgs.OldValue
            {
                get { return OldValue; }
            }

            object IPropertyValueChangedEventArgs.NewValue
            {
                get { return NewValue; }
            }

            #endregion
        }

        #endregion


        #region Constants

        /// <summary>
        /// The property name that represents all properties.
        /// </summary>
        internal const string AllPropertyName = "";

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public PropertyObservableCore() { }

        #endregion


        #region SetProperty Related

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed and the isHidden parameter is false, PropertyChanged events are raised for the property name and the related property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        /// <param name="onChanging">The callback that is called when the property value is changing. Null is allowed.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="related">The related property names.</param>
        /// <param name="isHidden">Whether to suppress raising the PropertyValueChanging, PropertyValueChanged and PropertyChanged events.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null, Action<IPropertyValueChangingEventArgs<T>> onChanging = null, Action<IPropertyValueChangedEventArgs<T>> onChanged = null, IEnumerable<string> related = null, bool isHidden = false)
        {
            Debug.Assert(string.IsNullOrWhiteSpace(propertyName) == false);
            Debug.Assert(related == null || related.Any(p => p != AllPropertyName && string.IsNullOrWhiteSpace(p)) == false);

            // Gets the old value.
            T oldValue = storage;

            // If the values are equal
            if (object.Equals(oldValue, value))
                return false;

            PropertyValueChangeEventArgs<T> args = null;

            // Raises a PropertyValueChanging event.
            if (isHidden == false)
            {
                args = new PropertyValueChangeEventArgs<T>(propertyName, oldValue, value);
                OnPropertyValueChanging(args);
                value = args.NewValue;
            }

            // Calls the changing callback.
            if (onChanging != null)
            {
                if (args == null)
                    args = new PropertyValueChangeEventArgs<T>(propertyName, oldValue, value);

                onChanging(args);
                value = args.NewValue;
            }

            // If the values are equal
            if (args != null && Equals(args.OldValue, args.NewValue))
                return false;

            // Sets the property value.
            storage = value;

            // Calls the changed callback.
            if (onChanged != null)
            {
                if (args == null)
                    args = new PropertyValueChangeEventArgs<T>(propertyName, oldValue, value);

                onChanged(args);
            }

            if (isHidden == false)
            {
                // Raises a PropertyValueChanged and PropertyChanged event.
                OnPropertyValueChanged(args);
                OnPropertyChanged(args);

                // Raises PropertyChanged events for the related property names.
                if (related != null)
                    OnPropertyChanged(related);
            }

            return true;
        }

        #endregion


        #region PropertyValueChanging

        /// <summary>
        /// The event handler delegate for the PropertyValueChanging event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void PropertyValueChangingEventHandler(object sender, IPropertyValueChangingEventArgs e);

        /// <summary>
        /// Occurs when a property value is changing by the SetProperty methods.
        /// </summary>
        public event PropertyValueChangingEventHandler PropertyValueChanging;

        /// <summary>
        /// Raises a PropertyValueChanging event.
        /// </summary>
        /// <param name="e">The property value changed event arguments.</param>
        protected virtual void OnPropertyValueChanging(IPropertyValueChangingEventArgs e)
        {
            Debug.Assert(e != null);

            // Calls the property value changing event handlers.
            PropertyValueChanging?.Invoke(this, e);
        }

        /// <summary>
        /// Raises a PropertyValueChanging event.
        /// </summary>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected void OnPropertyValueChanging<T>(T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            OnPropertyValueChanging(new PropertyValueChangeEventArgs<T>(propertyName, oldValue, newValue));
        }

        #endregion


        #region PropertyValueChanged

        /// <summary>
        /// The event handler delegate for the PropertyValueChanged event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void PropertyValueChangedEventHandler(object sender, IPropertyValueChangedEventArgs e);

        /// <summary>
        /// Occurs when a property value is changed by the SetProperty methods.
        /// </summary>
        public event PropertyValueChangedEventHandler PropertyValueChanged;

        /// <summary>
        /// Raises a PropertyValueChanged event.
        /// </summary>
        /// <param name="e">The property value changed event arguments.</param>
        protected virtual void OnPropertyValueChanged(IPropertyValueChangedEventArgs e)
        {
            Debug.Assert(e != null);

            // Calls the property value changed event handlers.
            PropertyValueChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises a PropertyValueChanged event.
        /// </summary>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected void OnPropertyValueChanged<T>(T oldValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            OnPropertyValueChanged(new PropertyValueChangeEventArgs<T>(propertyName, oldValue, newValue));
        }

        #endregion


        #region INotifyPropertyChanged Implementation Related

        /// <summary>
        /// Occurs when a property value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="e">The property changed event arguments.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            Debug.Assert(e != null);

            // Calls the property changed event handlers.
            PropertyChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises PropertyChanged events.
        /// </summary>
        /// <param name="propertyNames">The property names that changed.</param>
        protected void OnPropertyChanged(IEnumerable<string> propertyNames)
        {
            Debug.Assert(propertyNames != null);

            foreach (string propertyName in propertyNames)
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises PropertyChanged events.
        /// </summary>
        /// <param name="propertyNames">The property names that changed.</param>
        protected void OnPropertyChanged(params string[] propertyNames)
        {
            Debug.Assert(propertyNames != null);

            foreach (string propertyName in propertyNames)
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
