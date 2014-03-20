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

using Nicenis.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Nicenis.ComponentModel
{
    /// <summary>
    /// 
    /// </summary>
    public class WatchableObject : INotifyPropertyChanged
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WatchableObject() { }

        #endregion


        #region GetPropertyName

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
            yield return GetPropertyName(propertyExpression14);
            yield return GetPropertyName(propertyExpression15);
            yield return GetPropertyName(propertyExpression16);
            yield return GetPropertyName(propertyExpression17);
            yield return GetPropertyName(propertyExpression18);
            yield return GetPropertyName(propertyExpression19);
            yield return GetPropertyName(propertyExpression20);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
            yield return GetPropertyName(propertyExpression14);
            yield return GetPropertyName(propertyExpression15);
            yield return GetPropertyName(propertyExpression16);
            yield return GetPropertyName(propertyExpression17);
            yield return GetPropertyName(propertyExpression18);
            yield return GetPropertyName(propertyExpression19);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
            yield return GetPropertyName(propertyExpression14);
            yield return GetPropertyName(propertyExpression15);
            yield return GetPropertyName(propertyExpression16);
            yield return GetPropertyName(propertyExpression17);
            yield return GetPropertyName(propertyExpression18);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
            yield return GetPropertyName(propertyExpression14);
            yield return GetPropertyName(propertyExpression15);
            yield return GetPropertyName(propertyExpression16);
            yield return GetPropertyName(propertyExpression17);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
            yield return GetPropertyName(propertyExpression14);
            yield return GetPropertyName(propertyExpression15);
            yield return GetPropertyName(propertyExpression16);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
            yield return GetPropertyName(propertyExpression14);
            yield return GetPropertyName(propertyExpression15);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
            yield return GetPropertyName(propertyExpression14);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
            yield return GetPropertyName(propertyExpression13);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
            yield return GetPropertyName(propertyExpression12);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10,
                Expression<Func<T11>> propertyExpression11)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
            yield return GetPropertyName(propertyExpression11);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
            yield return GetPropertyName(propertyExpression10);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
            yield return GetPropertyName(propertyExpression9);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                Expression<Func<T8>> propertyExpression8)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
            yield return GetPropertyName(propertyExpression8);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
            yield return GetPropertyName(propertyExpression7);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
            yield return GetPropertyName(propertyExpression6);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5>(Expression<Func<T>> propertyExpression,
                Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                Expression<Func<T5>> propertyExpression5)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
            yield return GetPropertyName(propertyExpression5);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3, T4>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
            yield return GetPropertyName(propertyExpression4);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2, T3>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
            yield return GetPropertyName(propertyExpression3);
        }

        protected static IEnumerable<string> GetPropertyName<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
        {
            yield return GetPropertyName(propertyExpression);
            yield return GetPropertyName(propertyExpression2);
        }

        protected static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            Verify.ParameterIsNotNull(propertyExpression, "propertyExpression");

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("The Body of the propertyExpression must be a member access expression.");

            return memberExpression.Member.Name;
        }

        #endregion


        #region Get/Set Property Related

        #region Storage Related

        SortedList<string, object> _valueDictionary;

        /// <summary>
        /// The dictionary to store property value.
        /// The dictionary key is property name, and the dictionary value is property value.
        /// </summary>
        private SortedList<string, object> ValueDictionary
        {
            get { return _valueDictionary ?? (_valueDictionary = new SortedList<string, object>()); }
        }

        /// <summary>
        /// Gets the property value specified by the property name in the storage.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value returned.</param>
        /// <returns>True if the property is found in the internal storage; otherwise false.</returns>
        private bool GetPropertyFromStorage<T>(string propertyName, out T value)
        {
            Verify.ParameterIsNotNullAndWhiteSpace(propertyName, "propertyName");

            // Tries to retrieve the value if it exists.
            if (_valueDictionary != null)
            {
                object rawValue;
                if (_valueDictionary.TryGetValue(propertyName, out rawValue))
                {
                    value = (T)rawValue;
                    return true;
                }
            }

            // If the property is not found
            value = default(T);
            return false;
        }

        /// <summary>
        /// Sets the value to the property specified by the property name in the storage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        private void SetPropertyToStorage<T>(string propertyName, T value)
        {
            Verify.ParameterIsNotNullAndWhiteSpace(propertyName, "propertyName");
            ValueDictionary[propertyName] = value;
        }

        #endregion

        /// <summary>
        /// Gets the property value specified by the property name.
        /// If it does not exist, the default is returned.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The property value if it exists; otherwise the default value.</returns>
        protected virtual T GetProperty<T>(string propertyName, T defaultValue = default(T))
        {
            // Returns the property value if it exists
            T value;
            if (GetPropertyFromStorage(propertyName, out value))
                return value;

            // Returns the default if the property does not exist.
            return defaultValue;
        }

        /// <summary>
        /// Gets the property value specified by the property expression.
        /// If it does not exist, the default is returned.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The property value if it exists; otherwise the default value.</returns>
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression, T defaultValue = default(T))
        {
            return GetProperty(GetPropertyName(propertyExpression), defaultValue);
        }

        /// <summary>
        /// Gets the property value specified by the property name.
        /// If it does not exist, the property value is set to the value returned by the initializer,
        /// and the value is returned.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="initializer">The initializer that returns initialization value.</param>
        /// <returns>The property value if it exists; otherwise the value returned by the initializer.</returns>
        protected virtual T GetProperty<T>(string propertyName, Func<T> initializer)
        {
            Verify.ParameterIsNotNull(initializer, "initializer");

            // Returns the property value if it exists
            T value;
            if (GetPropertyFromStorage(propertyName, out value))
                return value;

            // Initializes the property value
            value = initializer();
            SetPropertyToStorage(propertyName, value);

            // Returns the initialized vaule.
            return value;
        }

        /// <summary>
        /// Gets the property value specified by the property expression.
        /// If it does not exist, the property value is set to the value returned by the initializer,
        /// and the value is returned.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        /// <param name="initializer">The initializer that returns initialization value.</param>
        /// <returns>The property value if it exists; otherwise the value returned by the initializer.</returns>
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression, Func<T> initializer)
        {
            return GetProperty(GetPropertyName(propertyExpression), initializer);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected bool SetPropertyWithoutNotification<T>(string propertyName, T value)
        {
            Verify.ParameterIsNotNullAndWhiteSpace(propertyName, "propertyName");

            // Gets the property value.
            T oldValue = (T)GetType().InvokeMember
            (
                name: propertyName,
                invokeAttr: BindingFlags.Public
                          | BindingFlags.NonPublic
                          | BindingFlags.Instance
                          | BindingFlags.GetProperty,
                binder: null,
                target: this,
                args: null
            );

            // If the old and new value are null, it means they are the same.
            if (oldValue == null && value == null)
                return false;

            // If the old and new value are not null, compares the values.
            if (oldValue != null && value != null && oldValue.Equals(value))
                return false;

            // Sets the property value.
            SetPropertyToStorage(propertyName, value);
            return true;
        }

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

        protected bool SetProperty<T>(string propertyName, T value, params string[] affectedPropertyNames)
        {
            return SetProperty(propertyName, value, (IEnumerable<string>)affectedPropertyNames);
        }

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

        protected virtual bool SetProperty<T>(string propertyName, T value)
        {
            // If the property is changed
            if (SetPropertyWithoutNotification(propertyName, value))
            {
                // Raises PropertyChanged event.
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18,
                Expression<Func<T20>> affectedPropertyExpression19, Expression<Func<T21>> affectedPropertyExpression20)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18, affectedPropertyExpression19, affectedPropertyExpression20
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18,
                Expression<Func<T20>> affectedPropertyExpression19)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18, affectedPropertyExpression19
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                Expression<Func<T17>> affectedPropertyExpression16)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                Expression<Func<T14>> affectedPropertyExpression13)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                Expression<Func<T11>> affectedPropertyExpression10)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                Expression<Func<T8>> affectedPropertyExpression7)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6, T7>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5, T6>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4, T5>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                Expression<Func<T5>> affectedPropertyExpression4)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4
                )
            );
        }

        protected bool SetProperty<T, T2, T3, T4>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3
                )
            );
        }

        protected bool SetProperty<T, T2, T3>(
                Expression<Func<T>> propertyExpression, T value,
                Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2)
        {
            // Sets the property value.
            return SetProperty
            (
                propertyName: GetPropertyName(propertyExpression),
                value: value,
                affectedPropertyNames: GetPropertyName
                (
                    affectedPropertyExpression, affectedPropertyExpression2
                )
            );
        }

        protected bool SetProperty<T, T2>(Expression<Func<T>> propertyExpression, T value, Expression<Func<T2>> affectedPropertyExpression2)
        {
            return SetProperty(GetPropertyName(propertyExpression), value, GetPropertyName(affectedPropertyExpression2));
        }

        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value)
        {
            return SetProperty(GetPropertyName(propertyExpression), value);
        }

        #endregion


        #region Property Changed Callback Related

        #region Storage Related

        SortedList<string, List<Action>> _changedCallbackDictionary;

        /// <summary>
        /// The dictionary to store property changed callback.
        /// The dictionary key is property name, and the dictionary value is property changed callback list.
        /// </summary>
        private SortedList<string, List<Action>> ChangedCallbackDictionary
        {
            get { return _changedCallbackDictionary ?? (_changedCallbackDictionary = new SortedList<string, List<Action>>()); }
        }

        private List<Action> GetChangedCallbackList(string propertyName)
        {
            Verify.ParameterIsNotNullAndWhiteSpace(propertyName, "propertyName");

            if (_changedCallbackDictionary != null)
            {
                // Gets the changed callback list.
                List<Action> changedCallbackList;
                if (_changedCallbackDictionary.TryGetValue(propertyName, out changedCallbackList))
                    return changedCallbackList;
            }

            return null;
        }

        private List<Action> GetOrCreateChangedCallbackList(string propertyName)
        {
            Verify.ParameterIsNotNullAndWhiteSpace(propertyName, "propertyName");

            // Gets the changed callback list.
            List<Action> changedCallbackList;
            if (ChangedCallbackDictionary.TryGetValue(propertyName, out changedCallbackList))
                return changedCallbackList;

            // Creats a new list.
            return ChangedCallbackDictionary[propertyName] = new List<Action>();
        }

        #endregion

        protected IEnumerable<Action> EnumeratePropertyChangedCallback(IEnumerable<string> propertyNames)
        {
            Verify.ParameterIsNotNull(propertyNames, "propertyNames");

            // If the changed callback dictionary is not created
            if (_changedCallbackDictionary == null)
                yield break;

            foreach (string propertyName in propertyNames)
                foreach (Action callback in EnumeratePropertyChangedCallback(propertyName))
                    yield return callback;
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback(params string[] propertyNames)
        {
            return EnumeratePropertyChangedCallback((IEnumerable<string>)propertyNames);
        }

        protected virtual IEnumerable<Action> EnumeratePropertyChangedCallback(string propertyName)
        {
            // Gets the changed callback list.
            IEnumerable<Action> changedCallbackList = GetChangedCallbackList(propertyName);

            // If there is changed callbacks
            if (changedCallbackList != null)
                return changedCallbackList;

            // If there is no changed callback
            return Enumerable.Empty<Action>();
        }

        protected virtual IEnumerable<Action> EnumeratePropertyChangedCallback()
        {
            if (_changedCallbackDictionary == null)
                yield break;

            foreach (List<Action> callbacks in _changedCallbackDictionary.Values)
                foreach (Action callback in callbacks)
                    yield return callback;
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3, T4>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2, T3>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3)
        {
            return EnumeratePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3
                )
            );
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
        {
            return EnumeratePropertyChangedCallback(GetPropertyName(propertyExpression, propertyExpression2));
        }

        protected IEnumerable<Action> EnumeratePropertyChangedCallback<T>(Expression<Func<T>> propertyExpression)
        {
            return EnumeratePropertyChangedCallback(GetPropertyName(propertyExpression));
        }


        protected int SetPropertyChangedCallback(IEnumerable<string> propertyNames, Action callback)
        {
            Verify.ParameterIsNotNull(propertyNames, "propertyNames");
            Verify.ParameterIsNotNull(callback, "callback");

            int counter = 0;
            foreach (string propertyName in propertyNames)
            {
                // If the changed callback is added, increases the counter.
                if (SetPropertyChangedCallback(propertyName, callback))
                    counter++;
            }

            return counter;
        }

        protected virtual bool SetPropertyChangedCallback(string propertyName, Action callback)
        {
            Verify.ParameterIsNotNull(callback, "callback");

            // Gets the changed callback list.
            List<Action> callbackList = GetOrCreateChangedCallbackList(propertyName);

            // If the changed callback already exists
            if (callbackList.Contains(callback))
                return false;

            // Adds the changed callback.
            callbackList.Add(callback);
            return true;
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4, T5>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3, T4>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2, T3>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Action callback)
        {
            return SetPropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3
                ),
                callback
            );
        }

        protected int SetPropertyChangedCallback<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Action callback)
        {
            return SetPropertyChangedCallback(GetPropertyName(propertyExpression, propertyExpression2), callback);
        }

        protected bool SetPropertyChangedCallback<T>(Expression<Func<T>> propertyExpression, Action callback)
        {
            return SetPropertyChangedCallback(GetPropertyName(propertyExpression), callback);
        }


        protected int RemovePropertyChangedCallback(IEnumerable<string> propertyNames, Action callback)
        {
            Verify.ParameterIsNotNull(propertyNames, "propertyNames");
            Verify.ParameterIsNotNull(callback, "callback");

            // If the changed callback dictionary is not created
            if (_changedCallbackDictionary == null)
                return 0;

            int counter = 0;
            foreach (string propertyName in propertyNames)
            {
                // If the callback is removed, increases the counter.
                if (RemovePropertyChangedCallback(propertyName, callback))
                    counter++;
            }

            return counter;
        }

        protected virtual bool RemovePropertyChangedCallback(string propertyName, Action callback)
        {
            Verify.ParameterIsNotNull(callback, "callback");

            // Gets the changed callbacks list.
            List<Action> callbackList = GetChangedCallbackList(propertyName);
            if (callbackList == null)
                return false;

            // Removes the changed callback.
            return callbackList.Remove(callback);
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4, T5>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3, T4>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2, T3>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Action callback)
        {
            return RemovePropertyChangedCallback
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3
                ),
                callback
            );
        }

        protected int RemovePropertyChangedCallback<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Action callback)
        {
            return RemovePropertyChangedCallback(GetPropertyName(propertyExpression, propertyExpression2), callback);
        }

        protected void RemovePropertyChangedCallback<T>(Expression<Func<T>> propertyExpression, Action callback)
        {
            RemovePropertyChangedCallback(GetPropertyName(propertyExpression), callback);
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
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Calls the property changed event handlers.
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));

            // If all properties are changed, calls all property changed callbacks.
            IEnumerable<Action> callbacks = string.IsNullOrEmpty(propertyName)
                                          ? EnumeratePropertyChangedCallback()
                                          : EnumeratePropertyChangedCallback(propertyName);

            // Calls the property changed callbacks.
            foreach (Action callback in callbacks)
                callback();
        }

        /// <summary>
        /// Raises PropertyChanged events.
        /// </summary>
        /// <param name="propertyNames">The property names that changed. Null is not allowed.</param>
        protected void OnPropertyChanged(IEnumerable<string> propertyNames)
        {
            Verify.ParameterIsNotNullAndEmptyCollection(propertyNames, "propertyNames");

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

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <typeparam name="T14">The type of the property that changed.</typeparam>
        /// <typeparam name="T15">The type of the property that changed.</typeparam>
        /// <typeparam name="T16">The type of the property that changed.</typeparam>
        /// <typeparam name="T17">The type of the property that changed.</typeparam>
        /// <typeparam name="T18">The type of the property that changed.</typeparam>
        /// <typeparam name="T19">The type of the property that changed.</typeparam>
        /// <typeparam name="T20">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression18">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression19">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression20">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14,
                Expression<Func<T15>> propertyExpression15, Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17,
                Expression<Func<T18>> propertyExpression18, Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <typeparam name="T14">The type of the property that changed.</typeparam>
        /// <typeparam name="T15">The type of the property that changed.</typeparam>
        /// <typeparam name="T16">The type of the property that changed.</typeparam>
        /// <typeparam name="T17">The type of the property that changed.</typeparam>
        /// <typeparam name="T18">The type of the property that changed.</typeparam>
        /// <typeparam name="T19">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression18">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression19">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14,
                Expression<Func<T15>> propertyExpression15, Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17,
                Expression<Func<T18>> propertyExpression18, Expression<Func<T19>> propertyExpression19)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <typeparam name="T14">The type of the property that changed.</typeparam>
        /// <typeparam name="T15">The type of the property that changed.</typeparam>
        /// <typeparam name="T16">The type of the property that changed.</typeparam>
        /// <typeparam name="T17">The type of the property that changed.</typeparam>
        /// <typeparam name="T18">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression18">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14,
                Expression<Func<T15>> propertyExpression15, Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17,
                Expression<Func<T18>> propertyExpression18)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <typeparam name="T14">The type of the property that changed.</typeparam>
        /// <typeparam name="T15">The type of the property that changed.</typeparam>
        /// <typeparam name="T16">The type of the property that changed.</typeparam>
        /// <typeparam name="T17">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression17">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14,
                Expression<Func<T15>> propertyExpression15, Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <typeparam name="T14">The type of the property that changed.</typeparam>
        /// <typeparam name="T15">The type of the property that changed.</typeparam>
        /// <typeparam name="T16">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression16">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14,
                Expression<Func<T15>> propertyExpression15, Expression<Func<T16>> propertyExpression16)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <typeparam name="T14">The type of the property that changed.</typeparam>
        /// <typeparam name="T15">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression15">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14,
                Expression<Func<T15>> propertyExpression15)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <typeparam name="T14">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression14">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <typeparam name="T13">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression13">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12, Expression<Func<T13>> propertyExpression13)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <typeparam name="T12">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression12">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11,
                Expression<Func<T12>> propertyExpression12)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <typeparam name="T11">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression11">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <typeparam name="T10">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression10">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <typeparam name="T9">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression9">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8,
                Expression<Func<T9>> propertyExpression9)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <typeparam name="T8">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression8">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <typeparam name="T7">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression7">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <typeparam name="T6">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression6">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5, T6>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5,
                Expression<Func<T6>> propertyExpression6)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <typeparam name="T5">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression5">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4, T5>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <typeparam name="T4">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression4">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3, T4>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <typeparam name="T3">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression3">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2, T3>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                Expression<Func<T3>> propertyExpression3)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <typeparam name="T2">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        /// <param name="propertyExpression2">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
        {
            OnPropertyChanged
            (
                GetPropertyName
                (
                    propertyExpression, propertyExpression2
                )
            );
        }

        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The type of the property that changed.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property that changed.</param>
        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            OnPropertyChanged(GetPropertyName(propertyExpression));
        }

        #endregion
    }
}
