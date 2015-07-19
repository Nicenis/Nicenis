/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.02.23
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
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
    public class PropertyObservable : INotifyPropertyChanged
    {
        #region PropertyValueChangeEventArgs

        /// <summary>
        /// The event arguments for property value change related events.
        /// </summary>
        private class PropertyValueChangeEventArgs<T> : PropertyChangedEventArgs,
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
        private const string AllPropertyName = "";

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public PropertyObservable() { }

        #endregion


        #region ToPropertyName Related

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T4">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T5">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T6">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T7">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T8">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T9">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
            yield return ToPropertyName(propertyExpression4);
            yield return ToPropertyName(propertyExpression5);
            yield return ToPropertyName(propertyExpression6);
            yield return ToPropertyName(propertyExpression7);
            yield return ToPropertyName(propertyExpression8);
            yield return ToPropertyName(propertyExpression9);
            yield return ToPropertyName(propertyExpression10);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T4">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T5">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T6">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T7">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T8">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T9">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
            yield return ToPropertyName(propertyExpression4);
            yield return ToPropertyName(propertyExpression5);
            yield return ToPropertyName(propertyExpression6);
            yield return ToPropertyName(propertyExpression7);
            yield return ToPropertyName(propertyExpression8);
            yield return ToPropertyName(propertyExpression9);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T4">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T5">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T6">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T7">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T8">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
            yield return ToPropertyName(propertyExpression4);
            yield return ToPropertyName(propertyExpression5);
            yield return ToPropertyName(propertyExpression6);
            yield return ToPropertyName(propertyExpression7);
            yield return ToPropertyName(propertyExpression8);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T4">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T5">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T6">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T7">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
            yield return ToPropertyName(propertyExpression4);
            yield return ToPropertyName(propertyExpression5);
            yield return ToPropertyName(propertyExpression6);
            yield return ToPropertyName(propertyExpression7);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T4">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T5">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T6">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
            yield return ToPropertyName(propertyExpression4);
            yield return ToPropertyName(propertyExpression5);
            yield return ToPropertyName(propertyExpression6);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T4">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T5">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
            yield return ToPropertyName(propertyExpression4);
            yield return ToPropertyName(propertyExpression5);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T4">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
            yield return ToPropertyName(propertyExpression4);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T3">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
            yield return ToPropertyName(propertyExpression3);
        }

        /// <summary>
        /// Enumerates property names extracted from the lambda expressions that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T2">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
        }

        /// <summary>
        /// Returns the property name extracted from the lambda expression that return a property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <returns>The property name extracted.</returns>
        protected static string ToPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("The Body of the propertyExpression must be a member access expression.");

            return memberExpression.Member.Name;
        }

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
            public static object UnsetValue = new object();

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
            public string Name { get; private set; }

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

#if !NICENIS_4C
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


#if !NICENIS_4C
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


#if !NICENIS_4C
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
#else
        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed and the isHidden parameter is false, PropertyChanged events are raised for the property name and the related property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name.</param>
        /// <param name="onChanging">The callback that is called when the property value is changing. Null is allowed.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="related">The related property names.</param>
        /// <param name="isHidden">Whether to suppress raising the PropertyValueChanging, PropertyValueChanged and PropertyChanged events.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, string propertyName, Action<IPropertyValueChangingEventArgs<T>> onChanging = null, Action<IPropertyValueChangedEventArgs<T>> onChanged = null, IEnumerable<string> related = null, bool isHidden = false)
#endif
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
            if (args != null && object.Equals(args.OldValue, args.NewValue))
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
            PropertyValueChangingEventHandler propertyValueChanging = PropertyValueChanging;
            if (propertyValueChanging != null)
                propertyValueChanging(this, e);
        }

#if !NICENIS_4C
        /// <summary>
        /// Raises a PropertyValueChanging event.
        /// </summary>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected void OnPropertyValueChanging<T>(T oldValue, T newValue, [CallerMemberName] string propertyName = "")
#else
        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed.</param>
        protected void OnPropertyValueChanging<T>(T oldValue, T newValue, string propertyName)
#endif
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
            PropertyValueChangedEventHandler propertyValueChanged = PropertyValueChanged;
            if (propertyValueChanged != null)
                propertyValueChanged(this, e);
        }

#if !NICENIS_4C
        /// <summary>
        /// Raises a PropertyValueChanged event.
        /// </summary>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected void OnPropertyValueChanged<T>(T oldValue, T newValue, [CallerMemberName] string propertyName = "")
#else
        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="oldValue">The value of the property before the change.</param>
        /// <param name="newValue">The value of the property after the change.</param>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed.</param>
        protected void OnPropertyValueChanged<T>(T oldValue, T newValue, string propertyName)
#endif
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
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, e);
        }

#if !NICENIS_4C
        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
#else
        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed.</param>
        protected void OnPropertyChanged(string propertyName)
#endif
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
