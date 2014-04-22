/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.02.23
 * Version  $Id$
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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Nicenis.ComponentModel
{
    #region PropertyWatch

    /// <summary>
    /// Represents an event handler for property changed events.
    /// </summary>
    public class PropertyWatch
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="propertyName">The property name to watch. An empty string represents all properties.</param>
        /// <param name="action">The event handler that is called when the watched property is changed.</param>
        public PropertyWatch(string propertyName, Action<PropertyChangedEventArgs> action)
        {
            if (propertyName != "" && string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string except an empty string.", "propertyName");

            if (action == null)
                throw new ArgumentNullException("action");

            PropertyName = propertyName;
            Action = action;
        }

        #endregion


        #region Properties

        /// <summary>
        /// Gets the value indicating whether the Action is called for any property change.
        /// </summary>
        public bool IsAllPropertyWatch { get { return WatchableObject.IsAllPropertyName(PropertyName); } }

        /// <summary>
        /// Gets the property name to watch.
        /// An empty string represents all properties.
        /// It is always not null.
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Gets the event handler that is called when the watched property is changed.
        /// It is always not null.
        /// </summary>
        public Action<PropertyChangedEventArgs> Action { get; private set; }

        #endregion
    }

    #endregion


    /// <summary>
    /// Provides a base implementation for the INotifyPropertyChanged interface.
    /// </summary>
    [DataContract]
    public class WatchableObject : INotifyPropertyChanged
    {
        #region Storage Related

        #region KeyValue

        /// <summary>
        /// Represents a key/value pair.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        private class KeyValue<TKey, TValue>
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <param name="value">The value.</param>
            public KeyValue(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            #endregion


            #region Properties

            /// <summary>
            /// The key.
            /// </summary>
            public TKey Key { get; private set; }

            /// <summary>
            /// The value.
            /// </summary>
            public TValue Value { get; set; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Stores key/value pairs.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        private class Storage<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
        {
            List<KeyValue<TKey, TValue>> _keyValues = new List<KeyValue<TKey, TValue>>();


            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            public Storage() { }

            #endregion


            #region Publics

            /// <summary>
            /// Finds a key/value pair associated with the specified key.
            /// If it does not exist, null is returned.
            /// </summary>
            /// <param name="key">The key to find.</param>
            /// <returns>The key/value pair if it exists; otherwise null.</returns>
            public KeyValue<TKey, TValue> Find(TKey key)
            {
                return _keyValues.FirstOrDefault(p => object.Equals(p.Key, key));
            }

            /// <summary>
            /// Adds a new KeyValue pair.
            /// The added key must not be a duplicated key.
            /// </summary>
            /// <param name="keyValue">The KeyValue pair to add.</param>
            public void Add(KeyValue<TKey, TValue> keyValue)
            {
                Debug.Assert(keyValue != null);
                Debug.Assert(_keyValues.Any(p => p.Key.Equals(keyValue.Key)) == false);

                _keyValues.Add(keyValue);
            }

            #endregion


            #region IEnumerable Implementation Related

            public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
            {
                return _keyValues.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _keyValues.GetEnumerator();
            }

            #endregion
        }

        #endregion


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WatchableObject() { }

        #endregion


        #region ToPropertyName

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
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T14">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T15">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T16">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T17">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T18">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T19">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T20">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression18">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression19">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression20">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
            yield return ToPropertyName(propertyExpression14);
            yield return ToPropertyName(propertyExpression15);
            yield return ToPropertyName(propertyExpression16);
            yield return ToPropertyName(propertyExpression17);
            yield return ToPropertyName(propertyExpression18);
            yield return ToPropertyName(propertyExpression19);
            yield return ToPropertyName(propertyExpression20);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T14">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T15">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T16">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T17">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T18">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T19">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression18">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression19">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
            yield return ToPropertyName(propertyExpression14);
            yield return ToPropertyName(propertyExpression15);
            yield return ToPropertyName(propertyExpression16);
            yield return ToPropertyName(propertyExpression17);
            yield return ToPropertyName(propertyExpression18);
            yield return ToPropertyName(propertyExpression19);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T14">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T15">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T16">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T17">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T18">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression18">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
            yield return ToPropertyName(propertyExpression14);
            yield return ToPropertyName(propertyExpression15);
            yield return ToPropertyName(propertyExpression16);
            yield return ToPropertyName(propertyExpression17);
            yield return ToPropertyName(propertyExpression18);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T14">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T15">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T16">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T17">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
            yield return ToPropertyName(propertyExpression14);
            yield return ToPropertyName(propertyExpression15);
            yield return ToPropertyName(propertyExpression16);
            yield return ToPropertyName(propertyExpression17);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T14">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T15">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T16">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
            yield return ToPropertyName(propertyExpression14);
            yield return ToPropertyName(propertyExpression15);
            yield return ToPropertyName(propertyExpression16);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T14">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T15">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
            yield return ToPropertyName(propertyExpression14);
            yield return ToPropertyName(propertyExpression15);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T14">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
            yield return ToPropertyName(propertyExpression14);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T13">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
            yield return ToPropertyName(propertyExpression13);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T12">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12)
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
            yield return ToPropertyName(propertyExpression11);
            yield return ToPropertyName(propertyExpression12);
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
        /// <typeparam name="T10">The type of the property returned from the lambda expression.</typeparam>
        /// <typeparam name="T11">The type of the property returned from the lambda expression.</typeparam>
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
        /// <param name="propertyExpression11">The lambda expression that returns the property.</param>
        /// <returns>The property names extracted.</returns>
        protected static IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10,
                Expression<Func<T11>> propertyExpression11)
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
            yield return ToPropertyName(propertyExpression11);
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


        #region IsAllPropertyName

        /// <summary>
        /// The property name that represents all properties.
        /// </summary>
        public const string AllPropertyName = "";

        /// <summary>
        /// Returns true if the propertyName parameter represents all properties.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>True if it represents all properties; otherwise false.</returns>
        public static bool IsAllPropertyName(string propertyName)
        {
            return string.IsNullOrEmpty(propertyName);
        }

        #endregion


        #region GetProperty/SetProperty Related

        #region ValueStorage

        Storage<string, object> _valueStorage;

        /// <summary>
        /// The property value storage.
        /// The storage key is a property name, and the storage value is a property value.
        /// </summary>
        private Storage<string, object> ValueStorage
        {
            get { return _valueStorage ?? (_valueStorage = new Storage<string, object>()); }
        }

        #endregion

        /// <summary>
        /// Gets the property value specified by the property name.
        /// If it does not exist, the default is returned.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The property value if it exists; otherwise the default value.</returns>
        protected virtual T GetProperty<T>(string propertyName, T defaultValue = default(T))
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

            if (_valueStorage != null)
            {
                // If the property exists in the storage
                KeyValue<string, object> keyValue = _valueStorage.Find(propertyName);
                if (keyValue != null)
                    return (T)keyValue.Value;
            }

            return defaultValue;
        }

        /// <summary>
        /// Gets the property value specified by the property expression that is used to extract the property name.
        /// If it does not exist, the default is returned.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The property value if it exists; otherwise the default value.</returns>
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression, T defaultValue = default(T))
        {
            return GetProperty(ToPropertyName(propertyExpression), defaultValue);
        }

        /// <summary>
        /// Gets the property value specified by the property name.
        /// If it does not exist, the property value is set to the value returned by the initializer, and the value is returned.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="initializer">The initializer that returns the initialization value.</param>
        /// <returns>The property value if it exists; otherwise the value returned by the initializer.</returns>
        protected virtual T GetProperty<T>(string propertyName, Func<T> initializer)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

            if (initializer == null)
                throw new ArgumentNullException("initializer");

            // If the property does not exist in the storage
            KeyValue<string, object> keyValue = null;
            if (_valueStorage == null || (keyValue = _valueStorage.Find(propertyName)) == null)
            {
                // Initializes a new one.
                keyValue = new KeyValue<string, object>(propertyName, initializer());
                ValueStorage.Add(keyValue);
            }

            return (T)keyValue.Value;
        }

        /// <summary>
        /// Gets the property value specified by the property expression that is used to extract the property name.
        /// If it does not exist, the property value is set to the value returned by the initializer, and the value is returned.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="initializer">The initializer that returns the initialization value.</param>
        /// <returns>The property value if it exists; otherwise the value returned by the initializer.</returns>
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression, Func<T> initializer)
        {
            return GetProperty(ToPropertyName(propertyExpression), initializer);
        }


        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// This method does not raise a PropertyChanged event.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetPropertyOnly<T>(string propertyName, T value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

            // If the property does not exist in the storage
            KeyValue<string, object> keyValue = null;
            if (_valueStorage == null || (keyValue = _valueStorage.Find(propertyName)) == null)
            {
                // Initializes a new one.
                keyValue = new KeyValue<string, object>(propertyName, default(T));
                ValueStorage.Add(keyValue);
            }

            // If the values are equal
            if (object.Equals(keyValue.Value, value))
                return false;

            // Sets the property value.
            keyValue.Value = value;
            return true;
        }

        /// <summary>
        /// Sets a value to the property specified by the property expression that is used to extract the property name.
        /// This method does not raise a PropertyChanged event.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetPropertyOnly<T>(Expression<Func<T>> propertyExpression, T value)
        {
            return SetPropertyOnly(ToPropertyName(propertyExpression), value);
        }

        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, T value, IEnumerable<string> affectedPropertyNames)
        {
            // If the property is changed
            if (SetProperty(propertyName, value))
            {
                // Raises PropertyChanged events for the affected property names.
                OnPropertyChanged(affectedPropertyNames);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, T value, params string[] affectedPropertyNames)
        {
            return SetProperty(propertyName, value, (IEnumerable<string>)affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property name.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, T value, string affectedPropertyName)
        {
            // If the property is changed
            if (SetProperty(propertyName, value))
            {
                // Raises a PropertyChanged event for the affected property name.
                OnPropertyChanged(affectedPropertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// If it is changed, a PropertyChanged event are raised for the property name.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(string propertyName, T value)
        {
            // If the property is changed
            if (SetPropertyOnly(propertyName, value))
            {
                // Raises a PropertyChanged event.
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a value to the property specified by the property expression that is used to extract the property name.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, IEnumerable<string> affectedPropertyNames)
        {
            return SetProperty(ToPropertyName(propertyExpression), value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the property specified by the property expression that is used to extract the property name.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, params string[] affectedPropertyNames)
        {
            return SetProperty(ToPropertyName(propertyExpression), value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the property specified by the property expression that is used to extract the property name.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property name.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, string affectedPropertyName)
        {
            return SetProperty(ToPropertyName(propertyExpression), value, affectedPropertyName);
        }

        /// <summary>
        /// Sets a value to the property specified by the property expression that is used to extract the property name.
        /// If it is changed, a PropertyChanged event is raised for the property name.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value)
        {
            return SetProperty(ToPropertyName(propertyExpression), value);
        }

        #endregion


        #region GetCallerProperty/SetCallerProperty Related

        /// <summary>
        /// Gets the property value specified by the property name that is obtained by the CallerMemberName attribute in a property getter.
        /// If it does not exist, the default is returned.
        /// This method must be used in a property getter.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>The property value if it exists; otherwise the default value.</returns>
        protected T GetCallerProperty<T>(T defaultValue = default(T), [CallerMemberName] string propertyName = "")
        {
            return GetProperty(propertyName, defaultValue);
        }

        /// <summary>
        /// Gets the property value specified by the property name that is obtained by the CallerMemberName attribute in a property getter.
        /// If it does not exist, the property value is set to the value returned by the initializer, and the value is returned.
        /// This method must be used in a property getter.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="initializer">The initializer that returns the initialization value.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>The property value if it exists; otherwise the default value.</returns>
        protected T GetCallerProperty<T>(Func<T> initializer, [CallerMemberName] string propertyName = "")
        {
            return GetProperty(propertyName, initializer);
        }

        /// <summary>
        /// Sets a value to the property specified by the property name that is obtained by the CallerMemberName attribute in a property setter.
        /// This method does not raise a PropertyChanged event.
        /// This method must be used in a property setter.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetCallerPropertyOnly<T>(T value, [CallerMemberName] string propertyName = "")
        {
            return SetPropertyOnly(propertyName, value);
        }

        /// <summary>
        /// Sets a value to the property specified by the property name that is obtained by the CallerMemberName attribute in a property setter.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// This method must be used in a property setter.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(T value, IEnumerable<string> affectedPropertyNames, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the property specified by the property name that is obtained by the CallerMemberName attribute in a property setter.
        /// If it is changed, a PropertyChanged event is raised for the property name.
        /// This method must be used in a property setter.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(T value, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, value);
        }

        #endregion


        #region SetProperty with Local Storage Related

        /// <summary>
        /// Sets a value to the specified storage.
        /// This method does not raise a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetPropertyOnly<T>(ref T storage, T value)
        {
            // If the values are equal
            if (object.Equals(storage, value))
                return false;

            // Sets the property value.
            storage = value;
            return true;
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
        {
            // If the property is changed
            if (SetProperty(propertyName, ref storage, value))
            {
                // Raises PropertyChanged events for the affected property names.
                OnPropertyChanged(affectedPropertyNames);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, params string[] affectedPropertyNames)
        {
            return SetProperty(propertyName, ref storage, value, (IEnumerable<string>)affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property name.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, string affectedPropertyName)
        {
            // If the property is changed
            if (SetProperty(propertyName, ref storage, value))
            {
                // Raises a PropertyChanged event for the affected property name.
                OnPropertyChanged(affectedPropertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, a PropertyChanged event is raised for the property name.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(string propertyName, ref T storage, T value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

            // If the property is changed
            if (SetPropertyOnly(ref storage, value))
            {
                // Raises a PropertyChanged event.
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name extracted from the property expression and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name extracted from the property expression and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, params string[] affectedPropertyNames)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name extracted from the property expression and the affected property name.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, string affectedPropertyName)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, affectedPropertyName);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, a PropertyChanged event is raised for the property name extracted from the property expression.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value);
        }

        #endregion


        #region SetCallerProperty with Local Storage Related

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name obtained by the CallerMemberName attribute and the affected property names.
        /// This method must be used in a property setter.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(ref T storage, T value, IEnumerable<string> affectedPropertyNames, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, ref storage, value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, a PropertyChanged event is raised for the property name obtained by the CallerMemberName attribute.
        /// This method must be used in a property setter.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, ref storage, value);
        }

        #endregion


        #region Property Watch Related

        #region WatchStorage

        Storage<string, List<Action<PropertyChangedEventArgs>>> _watchStorage;

        /// <summary>
        /// The property watch storage.
        /// The storage key is a property name, and the storage value is a watch action list.
        /// </summary>
        private Storage<string, List<Action<PropertyChangedEventArgs>>> WatchStorage
        {
            get { return _watchStorage ?? (_watchStorage = new Storage<string, List<Action<PropertyChangedEventArgs>>>()); }
        }

        #endregion

        /// <summary>
        /// Enumerates property watches for the specified properties.
        /// </summary>
        /// <param name="propertyNames">The property names.</param>
        /// <returns>The property watches.</returns>
        protected IEnumerable<PropertyWatch> EnumeratePropertyWatch(IEnumerable<string> propertyNames)
        {
            if (propertyNames == null)
                throw new ArgumentNullException("propertyNames");

            foreach (string propertyName in propertyNames)
                foreach (PropertyWatch propertyWatch in EnumeratePropertyWatch(propertyName))
                    yield return propertyWatch;
        }

        /// <summary>
        /// Enumerates property watches for the specified properties.
        /// </summary>
        /// <param name="propertyNames">The property names.</param>
        /// <returns>The property watches.</returns>
        protected IEnumerable<PropertyWatch> EnumeratePropertyWatch(params string[] propertyNames)
        {
            return EnumeratePropertyWatch((IEnumerable<string>)propertyNames);
        }

        /// <summary>
        /// Enumerates property watches for the specified property.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The property watches.</returns>
        protected virtual IEnumerable<PropertyWatch> EnumeratePropertyWatch(string propertyName)
        {
            if (propertyName != "" && string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string except an empty string.", "propertyName");

            if (_watchStorage != null)
            {
                // If there is the action list, enumerates PropertyWatchs.
                KeyValue<string, List<Action<PropertyChangedEventArgs>>> keyValue = _watchStorage.Find(propertyName);
                if (keyValue != null)
                    return keyValue.Value.Select(p => new PropertyWatch(propertyName, p));
            }

            return Enumerable.Empty<PropertyWatch>();
        }

        /// <summary>
        /// Enumerates all property watches of this instance.
        /// </summary>
        /// <returns>The property watches.</returns>
        protected virtual IEnumerable<PropertyWatch> EnumeratePropertyWatch()
        {
            if (_watchStorage == null)
                yield break;

            foreach (KeyValue<string, List<Action<PropertyChangedEventArgs>>> pair in _watchStorage)
                foreach (Action<PropertyChangedEventArgs> watchAction in pair.Value)
                    yield return new PropertyWatch(pair.Key, watchAction);
        }

        /// <summary>
        /// Enumerates property watches for the specified property expression that is used to extract the property name.
        /// </summary>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <returns>The property watches.</returns>
        protected IEnumerable<PropertyWatch> EnumeratePropertyWatch<T>(Expression<Func<T>> propertyExpression)
        {
            return EnumeratePropertyWatch(ToPropertyName(propertyExpression));
        }


        /// <summary>
        /// Sets an action that is called when one of the specified properties is changed.
        /// If the action is already set for each property names, it does nothing.
        /// </summary>
        /// <param name="propertyNames">The property names to watch.</param>
        /// <param name="action">The action that is called when one of the properties is changed.</param>
        /// <returns>The number of actions that are newly set.</returns>
        protected int SetPropertyWatch(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> action)
        {
            if (propertyNames == null)
                throw new ArgumentNullException("propertyNames");

            if (action == null)
                throw new ArgumentNullException("action");

            int counter = 0;
            foreach (string propertyName in propertyNames)
            {
                // If the watch action is added, increases the counter.
                if (SetPropertyWatch(propertyName, action))
                    counter++;
            }

            return counter;
        }

        /// <summary>
        /// Sets an action that is called when the specified property is changed.
        /// If the property name is the AllPropertyName, the action is called when any property is changed.
        /// If the action is already set for the property name, it does nothing.
        /// </summary>
        /// <param name="propertyName">The property name to watch.</param>
        /// <param name="action">The action that is called when the property is changed.</param>
        /// <returns>True if the action is newly set; otherwise false.</returns>
        protected virtual bool SetPropertyWatch(string propertyName, Action<PropertyChangedEventArgs> action)
        {
            if (propertyName != "" && string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string except an empty string.", "propertyName");

            if (action == null)
                throw new ArgumentNullException("action");

            // If the watch action list does not exist
            KeyValue<string, List<Action<PropertyChangedEventArgs>>> keyValue = null;
            if (_watchStorage == null || (keyValue = _watchStorage.Find(propertyName)) == null)
            {
                // Initializes a new one.
                keyValue = new KeyValue<string, List<Action<PropertyChangedEventArgs>>>(propertyName, new List<Action<PropertyChangedEventArgs>>());
                WatchStorage.Add(keyValue);
            }
            else
            {
                // If the action already exists
                if (keyValue.Value.Contains(action))
                    return false;
            }

            // Adds the action.
            keyValue.Value.Add(action);
            return true;
        }

        /// <summary>
        /// Sets an action that is called when any property is changed.
        /// If the action is already set, it does nothing.
        /// </summary>
        /// <param name="action">The action that is called when any property is changed.</param>
        /// <returns>True if the action is newly set; otherwise false.</returns>
        protected bool SetPropertyWatch(Action<PropertyChangedEventArgs> action)
        {
            return SetPropertyWatch(AllPropertyName, action);
        }

        /// <summary>
        /// Sets an action that is called when the property specified by the property expression is changed.
        /// If the action is already set, it does nothing.
        /// </summary>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="action">The action that is called when the property is changed.</param>
        /// <returns>True if the action is newly set; otherwise false.</returns>
        protected bool SetPropertyWatch<T>(Expression<Func<T>> propertyExpression, Action<PropertyChangedEventArgs> action)
        {
            return SetPropertyWatch(ToPropertyName(propertyExpression), action);
        }


        /// <summary>
        /// Removes an action that is called when one of the specified properties is changed.
        /// If the action is already removed for each property names, it does nothing.
        /// </summary>
        /// <param name="propertyNames">The property names not to watch.</param>
        /// <param name="action">The action that is called when one of the properties is changed.</param>
        /// <returns>The number of actions that are removed.</returns>
        protected int RemovePropertyWatch(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> action)
        {
            if (propertyNames == null)
                throw new ArgumentNullException("propertyNames");

            if (action == null)
                throw new ArgumentNullException("action");

            int counter = 0;
            foreach (string propertyName in propertyNames)
            {
                // If the action is removed, increases the counter.
                if (RemovePropertyWatch(propertyName, action))
                    counter++;
            }

            return counter;
        }

        /// <summary>
        /// Removes an action that is called when the specified property is changed.
        /// If the property name is the AllPropertyName, the action that is called when any property is changed is removed.
        /// If the action is already removed, it does nothing.
        /// </summary>
        /// <param name="propertyName">The property name not to watch.</param>
        /// <param name="action">The action that is called when the property is changed.</param>
        /// <returns>True if the action is removed; otherwise false.</returns>
        protected virtual bool RemovePropertyWatch(string propertyName, Action<PropertyChangedEventArgs> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            if (_watchStorage != null)
            {
                // If there is the action list, removes the action from it.
                KeyValue<string, List<Action<PropertyChangedEventArgs>>> keyValue = _watchStorage.Find(propertyName);
                if (keyValue != null)
                    return keyValue.Value.Remove(action);
            }

            return false;
        }

        /// <summary>
        /// Removes an action that is called when the property specified by the property expression is changed.
        /// If the action is already removed, it does nothing.
        /// </summary>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="action">The action that is called when the property is changed.</param>
        /// <returns>True if the action is removed; otherwise false.</returns>
        protected bool RemovePropertyWatch<T>(Expression<Func<T>> propertyExpression, Action<PropertyChangedEventArgs> action)
        {
            return RemovePropertyWatch(ToPropertyName(propertyExpression), action);
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
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // Calls the property changed event handlers.
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            if (propertyChanged != null)
                propertyChanged(this, e);

            // If all properties are changed, calls all watch actions.
            IEnumerable<PropertyWatch> propertyWatches = IsAllPropertyName(propertyName)
                                                       ? EnumeratePropertyWatch()
                                                       : EnumeratePropertyWatch(propertyName).Concat(EnumeratePropertyWatch(AllPropertyName));

            // Calls the watch actions.
            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(e);
        }

        /// <summary>
        /// Raises PropertyChanged events.
        /// </summary>
        /// <param name="propertyNames">The property names that changed. Null is not allowed.</param>
        protected void OnPropertyChanged(IEnumerable<string> propertyNames)
        {
            if (propertyNames == null)
                throw new ArgumentNullException("propertyNames");

            foreach (string propertyName in propertyNames)
                OnPropertyChanged(propertyName);
        }

        /// <summary>
        /// Raises PropertyChanged events.
        /// </summary>
        /// <param name="propertyNames">The property names that changed. Null is not allowed.</param>
        protected void OnPropertyChanged(params string[] propertyNames)
        {
            OnPropertyChanged((IEnumerable<string>)propertyNames);
        }

        #endregion
    }
}
