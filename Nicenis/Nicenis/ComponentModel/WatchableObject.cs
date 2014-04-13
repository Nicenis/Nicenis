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
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Nicenis.ComponentModel
{
    #region PropertyWatch

    /// <summary>
    /// Represents a callback that is called when the watched property value has changed.
    /// </summary>
    public class PropertyWatch
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="propertyName">The property name to watch. An empty string means that all properties are watched.</param>
        /// <param name="action">The callback that is called when the watched property value has changed.</param>
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
        /// Gets a value indicating whether it is all property watch.
        /// </summary>
        public bool IsAllPropertyWatch { get { return WatchableObject.IsAllPropertyName(PropertyName); } }

        /// <summary>
        /// Gets the property name to watch.
        /// If all properties are watched, an empty string is returned.
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Gets the callback that is called when the watched property value has changed.
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
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WatchableObject() { }

        #endregion


        #region ToPropertyName

        /// <summary>
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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
        /// Returns the property names extracted from the lambda expressions that return a property.
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

        #region Storage Related

        SortedList<string, object> _valueDictionary;

        /// <summary>
        /// The dictionary to store property values.
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
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

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
        /// If the property is not in the storage, it is added. Otherwise it replaces the existing value.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        private void SetPropertyToStorage<T>(string propertyName, T value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

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
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The property value if it exists; otherwise the default value.</returns>
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression, T defaultValue = default(T))
        {
            return GetProperty(ToPropertyName(propertyExpression), defaultValue);
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
            if (initializer == null)
                throw new ArgumentNullException("initializer");

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
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="initializer">The initializer that returns initialization value.</param>
        /// <returns>The property value if it exists; otherwise the value returned by the initializer.</returns>
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression, Func<T> initializer)
        {
            return GetProperty(ToPropertyName(propertyExpression), initializer);
        }


        /// <summary>
        /// Sets a property value without raising a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetPropertyWithoutNotification<T>(string propertyName, T value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

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

            // If the values are equal
            if (object.Equals(oldValue, value))
                return false;

            // Sets the property value.
            SetPropertyToStorage(propertyName, value);
            return true;
        }

        /// <summary>
        /// Sets a property value without raising a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetPropertyWithoutNotification<T>(Expression<Func<T>> propertyExpression, T value)
        {
            return SetPropertyWithoutNotification(ToPropertyName(propertyExpression), value);
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
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
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
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
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected property.
        /// </summary>
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
        /// Sets a property value.
        /// If it is changed, a PropertyChanged event is raised for the property.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(string propertyName, T value)
        {
            // If the property is changed
            if (SetPropertyWithoutNotification(propertyName, value))
            {
                // Raises a PropertyChanged event.
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
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
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
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
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected property.
        /// </summary>
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
        /// Sets a property value.
        /// If it is changed, a PropertyChanged event is raised for the property.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value)
        {
            return SetProperty(ToPropertyName(propertyExpression), value);
        }

        #endregion


        #region SetProperty with Local Storage Related

        /// <summary>
        /// Sets a property value without raising a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetPropertyWithoutNotification<T>(ref T storage, T value)
        {
            // If the values are equal
            if (object.Equals(storage, value))
                return false;

            // Sets the property value.
            storage = value;
            return true;
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
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
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, params string[] affectedPropertyNames)
        {
            return SetProperty(propertyName, ref storage, value, (IEnumerable<string>)affectedPropertyNames);
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected property.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
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
        /// Sets a property value.
        /// If it is changed, a PropertyChanged event is raised for the property.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected virtual bool SetProperty<T>(string propertyName, ref T storage, T value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

            // If the property is changed
            if (SetPropertyWithoutNotification(ref storage, value))
            {
                // Raises a PropertyChanged event.
                OnPropertyChanged(propertyName);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected properties.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, params string[] affectedPropertyNames)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, affectedPropertyNames);
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, PropertyChanged events are raised for the property and the affected property.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, string affectedPropertyName)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, affectedPropertyName);
        }

        /// <summary>
        /// Sets a property value.
        /// If it is changed, a PropertyChanged event is raised for the property.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage for the property value.</param>
        /// <param name="value">The property value.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value)
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value);
        }

        #endregion


        #region Property Watch Related

        #region Storage Related

        SortedList<string, List<Action<PropertyChangedEventArgs>>> _watchDictionary;

        /// <summary>
        /// The dictionary to store property watches.
        /// The dictionary key is property name, and the dictionary value is watch action list.
        /// </summary>
        private SortedList<string, List<Action<PropertyChangedEventArgs>>> WatchDictionary
        {
            get { return _watchDictionary ?? (_watchDictionary = new SortedList<string, List<Action<PropertyChangedEventArgs>>>()); }
        }

        /// <summary>
        /// Gets the watch action list for the property.
        /// If there is no watch action list, null is returned.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The watch action list if it exists; otherwise null.</returns>
        private List<Action<PropertyChangedEventArgs>> GetWatchActionList(string propertyName)
        {
            if (propertyName != "" && string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string except an empty string.", "propertyName");

            if (_watchDictionary != null)
            {
                // Gets the watch action list.
                List<Action<PropertyChangedEventArgs>> watchActionList;
                if (_watchDictionary.TryGetValue(propertyName, out watchActionList))
                    return watchActionList;
            }

            return null;
        }

        /// <summary>
        /// Gets the watch action list for the property.
        /// If there is no watch action list, a new list is created.
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The watch action list.</returns>
        private List<Action<PropertyChangedEventArgs>> GetOrCreateWatchActionList(string propertyName)
        {
            if (propertyName != "" && string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string except an empty string.", "propertyName");

            // Gets the watch action list.
            List<Action<PropertyChangedEventArgs>> watchActionList;
            if (WatchDictionary.TryGetValue(propertyName, out watchActionList))
                return watchActionList;

            // Creats a new list.
            return WatchDictionary[propertyName] = new List<Action<PropertyChangedEventArgs>>();
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
            // Gets the watch action list.
            IEnumerable<Action<PropertyChangedEventArgs>> watchActionList = GetWatchActionList(propertyName);

            // If there is watch actions
            if (watchActionList != null)
                return watchActionList.Select(p => new PropertyWatch(propertyName, p));

            // If there is no watch action
            return Enumerable.Empty<PropertyWatch>();
        }

        /// <summary>
        /// Enumerates all property watches of this instance.
        /// </summary>
        /// <returns>The property watches.</returns>
        protected virtual IEnumerable<PropertyWatch> EnumeratePropertyWatch()
        {
            if (_watchDictionary == null)
                yield break;

            foreach (KeyValuePair<string, List<Action<PropertyChangedEventArgs>>> pair in _watchDictionary)
                foreach (Action<PropertyChangedEventArgs> watchAction in pair.Value)
                    yield return new PropertyWatch(pair.Key, watchAction);
        }

        /// <summary>
        /// Enumerates property watches for the specified property.
        /// </summary>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <returns>The property watches.</returns>
        protected IEnumerable<PropertyWatch> EnumeratePropertyWatch<T>(Expression<Func<T>> propertyExpression)
        {
            return EnumeratePropertyWatch(ToPropertyName(propertyExpression));
        }


        /// <summary>
        /// Sets an action that is called when one of the specified properties is changed.
        /// If the action is already set, it does nothing.
        /// </summary>
        /// <param name="propertyNames">The property names to set a property watch.</param>
        /// <param name="action">The action that is called when one of the properties is changed.</param>
        /// <returns>The number of property watches that are newly set.</returns>
        protected int SetPropertyWatch(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> action)
        {
            if (propertyNames == null)
                throw new ArgumentNullException("propertyNames");

            if (propertyNames.Any() == false)
                throw new ArgumentException("The parameter propertyNames can not be an empty collection.");

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
        /// If the property name is the AllPropertyName, the action is called for any property changes.
        /// If the action is already set, it does nothing.
        /// </summary>
        /// <param name="propertyName">The property name to set a property watch.</param>
        /// <param name="action">The action that is called when the property is changed.</param>
        /// <returns>True if the action is newly set; otherwise false.</returns>
        protected virtual bool SetPropertyWatch(string propertyName, Action<PropertyChangedEventArgs> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Gets the watch action list.
            List<Action<PropertyChangedEventArgs>> watchActionList = GetOrCreateWatchActionList(propertyName);

            // If the action already exists
            if (watchActionList.Contains(action))
                return false;

            // Adds the action.
            watchActionList.Add(action);
            return true;
        }

        /// <summary>
        /// Sets an action that is called when any property is changed.
        /// </summary>
        /// <param name="action">The action that is called when any property is changed.</param>
        /// <returns>True if the action is newly set; otherwise false.</returns>
        protected bool SetPropertyWatch(Action<PropertyChangedEventArgs> action)
        {
            return SetPropertyWatch(AllPropertyName, action);
        }

        /// <summary>
        /// Sets an action that is called when the specified property is changed.
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
        /// </summary>
        /// <param name="propertyNames">The property names to remove a property watch.</param>
        /// <param name="action">The action that is called when one of the properties is changed.</param>
        /// <returns>The number of actions that are removed.</returns>
        protected int RemovePropertyWatch(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> action)
        {
            if (propertyNames == null)
                throw new ArgumentNullException("propertyNames");

            if (propertyNames.Any() == false)
                throw new ArgumentException("The parameter propertyNames can not be an empty collection.");

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
        /// If the property name is the AllPropertyName, the action for any property changes is removed.
        /// If there is no registered action, it does nothing.
        /// </summary>
        /// <param name="propertyName">The property name to set a property watch.</param>
        /// <param name="action">The action that is called when the property is changed.</param>
        /// <returns>True if the action is removed; otherwise false.</returns>
        protected virtual bool RemovePropertyWatch(string propertyName, Action<PropertyChangedEventArgs> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");

            // Gets the watch action list.
            List<Action<PropertyChangedEventArgs>> watchActionList = GetWatchActionList(propertyName);
            if (watchActionList == null)
                return false;

            // Removes the action.
            return watchActionList.Remove(action);
        }

        /// <summary>
        /// Removes an action that is called when the specified property is changed.
        /// If there is no registered action, it does nothing.
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
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
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

            if (propertyNames.Any() == false)
                throw new ArgumentException("The parameter propertyNames can not be an empty collection.");

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
