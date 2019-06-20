/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.02.23
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Nicenis.ComponentModel
{
    /// <summary>
    /// Provides a base implementation for the INotifyPropertyChanged interface with a property value storage.
    /// </summary>
    [DataContract]
    public class PropertyObservable : PropertyObservableCore
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public PropertyObservable() { }

        #endregion


        #region GetProperty/SetProperty Related

        #region Property Value Storage Related

        #region PropertyValue

        /// <summary>
        /// Represents a property value.
        /// </summary>
        private class PropertyValue
        {
            #region UnsetValue

            /// <summary>
            /// Represents that the property value is not set yet.
            /// </summary>
            public static readonly object UnsetValue = new object();

            #endregion


            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="name">The property name.</param>
            /// <param name="value">The property value.</param>
            public PropertyValue(string name, object value)
            {
                Debug.Assert(string.IsNullOrWhiteSpace(name) == false);

                Name = name;
                Value = value;
            }

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="name">The property name.</param>
            public PropertyValue(string name)
            {
                Debug.Assert(string.IsNullOrWhiteSpace(name) == false);

                Name = name;
                Value = UnsetValue;
            }

            #endregion


            #region Properties

            /// <summary>
            /// The property name.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// The property value.
            /// If it is the UnsetValue, this means that this property is not set yet.
            /// </summary>
            public object Value { get; set; }

            #endregion
        }

        #endregion


        PropertyValue[] _propertyValues;
        int _propertyValueCount = 0;

        /// <summary>
        /// Finds a property value associated with the specified property name.
        /// If it does not exist, a new added property is returned with the UnsetValue value.
        /// </summary>
        /// <param name="propertyName">The property name to find.</param>
        /// <returns>The property value.</returns>
        private PropertyValue GetFromStorage(string propertyName)
        {
            Debug.Assert(string.IsNullOrWhiteSpace(propertyName) == false);

            // Starts binary search...
            int insertIndex = -1;
            if (_propertyValueCount != 0)
            {
                int firstIndex = 0;
                int lastIndex = _propertyValueCount - 1;

                while (true)
                {
                    // Gets the middle item and index.
                    int middleIndex = (firstIndex + lastIndex) / 2;
                    PropertyValue middleItem = _propertyValues[middleIndex];

                    // Compares the propertyName.
                    int compareResult = string.Compare(middleItem.Name, propertyName, StringComparison.Ordinal);

                    // If it is equal
                    if (compareResult == 0)
                        return middleItem;

                    // If there is no item to search
                    if (firstIndex == lastIndex)
                    {
                        // If the middle item is greater that the target item,
                        // the new item must be placed before the middle item.
                        if (compareResult > 0)
                            insertIndex = firstIndex;
                        else
                            insertIndex = firstIndex + 1;
                        break;
                    }

                    if (compareResult > 0)
                        lastIndex = middleIndex - 1;
                    else
                        firstIndex = middleIndex + 1;

                    // If the last index is less than the first index
                    if (lastIndex < firstIndex)
                    {
                        if (compareResult > 0)
                        {
                            // If the middleIndex and firstIndex are the same
                            // and the lastIndex is moved to the left of the firstIndex,
                            // the new item must be placed before the middle item.
                            insertIndex = firstIndex;
                        }
                        else
                        {
                            // If the middleIndex and lastIndex are the same
                            // and the firstIndex is moved to the right of the lastIndex,
                            // the new item must be placed after the middle item.
                            insertIndex = lastIndex + 1;
                        }
                        break;
                    }
                }
            }
            else
            {
                insertIndex = 0;
            }

            Debug.Assert(insertIndex != -1);

            // Creates a new property value instance.
            PropertyValue newItem = new PropertyValue(propertyName);

            // Initializes the property value array.
            if (_propertyValues == null)
                _propertyValues = new PropertyValue[4];

            // If the array is full, expands the array.
            if (_propertyValueCount == _propertyValues.Length)
            {
                // Allocates a new array.
                PropertyValue[] newArray = new PropertyValue[_propertyValueCount * 2];

                // Copies all item before the insertion position.
                Array.Copy
                (
                    sourceArray: _propertyValues,
                    destinationArray: newArray,
                    length: insertIndex
                );

                // Saves the new item.
                newArray[insertIndex] = newItem;

                // Copies all item after the insertion position.
                Array.Copy
                (
                    sourceArray: _propertyValues,
                    sourceIndex: insertIndex,
                    destinationArray: newArray,
                    destinationIndex: insertIndex + 1,
                    length: _propertyValueCount - insertIndex
                );

                // Resets the property array.
                _propertyValues = newArray;
            }
            else
            {
                // Shifts all items to insert the new item into the insertion position.
                Array.Copy
                (
                    sourceArray: _propertyValues,
                    sourceIndex: insertIndex,
                    destinationArray: _propertyValues,
                    destinationIndex: insertIndex + 1,
                    length: _propertyValueCount - insertIndex
                );

                // Saves the new item.
                _propertyValues[insertIndex] = newItem;
            }

            // Increases the count.
            _propertyValueCount++;

            return newItem;
        }

        #endregion

#if !NICENIS_NF4C
        /// <summary>
        /// Gets the property value specified by the property name.
        /// If it does not exist, the property value is set to the value returned by the getDefault, and the value is returned.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        /// <param name="getDefault">The function that returns the default value. Null is allowed.</param>
        /// <returns>The property value if it exists; otherwise the default value or the value returned by the getDefault if the getDefault is not null.</returns>
        protected virtual T GetProperty<T>([CallerMemberName] string propertyName = null, Func<T> getDefault = null)
#else
        /// <summary>
        /// Gets the property value specified by the property name.
        /// If it does not exist, the property value is set to the value returned by the getDefault, and the value is returned.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="getDefault">The function that returns the default value. Null is allowed.</param>
        /// <returns>The property value if it exists; otherwise the default value or the value returned by the getDefault if the getDefault is not null.</returns>
        protected virtual T GetProperty<T>(string propertyName, Func<T> getDefault = null)
#endif
        {
            Debug.Assert(string.IsNullOrWhiteSpace(propertyName) == false);

            // Gets the property value
            PropertyValue propertyValue = GetFromStorage(propertyName);

            // If the property value is not set, initializes it.
            if (propertyValue.Value == PropertyValue.UnsetValue)
            {
                T defaultValue = getDefault != null ? getDefault() : default(T);
                propertyValue.Value = defaultValue;
                return defaultValue;
            }

            return (T)propertyValue.Value;
        }

#if !NICENIS_NF4C
        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// If it is changed and the isHidden parameter is false, PropertyChanged events are raised for the property name and the related property names.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        /// <param name="onChanging">The callback that is called when the property value is changing. Null is allowed.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="related">The related property names. Null is allowed.</param>
        /// <param name="isHidden">Whether to suppress raising the PropertyValueChanging, PropertyValueChanged and PropertyChanged events.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(T value, [CallerMemberName] string propertyName = null, Action<IPropertyValueChangingEventArgs<T>> onChanging = null, Action<IPropertyValueChangedEventArgs<T>> onChanged = null, IEnumerable<string> related = null, bool isHidden = false)
#else
        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// If it is changed and the isHidden parameter is false, PropertyChanged events are raised for the property name and the related property names.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="onChanging">The callback that is called when the property value is changing. Null is allowed.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="related">The related property names. Null is allowed.</param>
        /// <param name="isHidden">Whether to suppress raising the PropertyValueChanging, PropertyValueChanged and PropertyChanged events.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(T value, string propertyName, Action<IPropertyValueChangingEventArgs<T>> onChanging = null, Action<IPropertyValueChangedEventArgs<T>> onChanged = null, IEnumerable<string> related = null, bool isHidden = false)
#endif
        {
            Debug.Assert(string.IsNullOrWhiteSpace(propertyName) == false);
            Debug.Assert(related == null || related.Any(p => p != AllPropertyName && string.IsNullOrWhiteSpace(p)) == false);

            // Gets the property value.
            PropertyValue propertyValue = GetFromStorage(propertyName);

            // Gets the old value.
            T oldValue;
            if (propertyValue.Value == PropertyValue.UnsetValue)
            {
                // If the property value is not set, initializes it.
                oldValue = default(T);
                propertyValue.Value = oldValue;
            }
            else
            {
                oldValue = (T)propertyValue.Value;
            }

            // If the values are equal
            if (Equals(oldValue, value))
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
            if (args != null && object.Equals(args.OldValue, args.NewValue))
                return false;

            // Sets the property value.
            propertyValue.Value = value;

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
    }
}
