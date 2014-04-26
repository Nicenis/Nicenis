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
    /// <summary>
    /// Provides a base implementation for the INotifyPropertyChanged interface.
    /// </summary>
    [DataContract]
    public class WatchableObject : INotifyPropertyChanged
    {
        #region Constants

        /// <summary>
        /// The property name that represents all properties.
        /// </summary>
        public const string AllPropertyName = "";

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


        #region GetProperty/SetProperty Related

        #region Property Value Storage Related

        #region PropertyValue

        /// <summary>
        /// Represents a property value.
        /// </summary>
        private class PropertyValue
        {
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

            #endregion


            #region Properties

            /// <summary>
            /// The property name.
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// The property value.
            /// </summary>
            public object Value { get; set; }

            #endregion
        }

        #endregion


        List<PropertyValue> _propertyValueStorage;

        /// <summary>
        /// Finds a property value associated with the specified property name.
        /// If it does not exist, null is returned.
        /// </summary>
        /// <param name="propertyName">The property name to find.</param>
        /// <returns>The property value if it exists; otherwise null.</returns>
        private PropertyValue FindFromStorage(string propertyName)
        {
            Debug.Assert(string.IsNullOrWhiteSpace(propertyName) == false);

            if (_propertyValueStorage == null)
                return null;

            foreach (PropertyValue propertyValue in _propertyValueStorage)
            {
                if (propertyValue.Name.Length != propertyName.Length)
                    continue;

                if (propertyValue.Name == propertyName)
                    return propertyValue;
            }

            return null;
        }

        /// <summary>
        /// Adds a new property value.
        /// The added property name must not be a duplicated property name.
        /// </summary>
        /// <param name="propertyValue">The property value to add.</param>
        private void AddToStorage(PropertyValue propertyValue)
        {
            Debug.Assert(propertyValue != null);

            if (_propertyValueStorage == null)
                _propertyValueStorage = new List<PropertyValue>();

            Debug.Assert(_propertyValueStorage.Any(p => p.Name == propertyValue.Name) == false);
            _propertyValueStorage.Add(propertyValue);
        }

        #endregion

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
            PropertyValue propertyValue = null;
            if ((propertyValue = FindFromStorage(propertyName)) == null)
            {
                // Initializes a new one.
                propertyValue = new PropertyValue(propertyName, initializer());
                AddToStorage(propertyValue);
            }

            return (T)propertyValue.Value;
        }

        /// <summary>
        /// Gets the property value specified by the property name.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The property value if it exists; otherwise default(T).</returns>
        protected T GetProperty<T>(string propertyName)
        {
            return GetProperty<T>(propertyName, () => default(T));
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
        /// Gets the property value specified by the property expression that is used to extract the property name.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <returns>The property value if it exists; otherwise default(T).</returns>
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression)
        {
            return GetProperty<T>(ToPropertyName(propertyExpression));
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
            PropertyValue propertyValue = null;
            if ((propertyValue = FindFromStorage(propertyName)) == null)
            {
                // Initializes a new one.
                propertyValue = new PropertyValue(propertyName, default(T));
                AddToStorage(propertyValue);
            }

            // If the values are equal
            if (object.Equals(propertyValue.Value, value))
                return false;

            // Sets the property value.
            propertyValue.Value = value;
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
            if (affectedPropertyNames == null)
                throw new ArgumentNullException("affectedPropertyNames");

            foreach (string affectedPropertyName in affectedPropertyNames)
                if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                    throw new ArgumentException("The parameter affectedPropertyNames can not contain a string that is null or a whitespace string except an empty string.", "affectedPropertyNames");

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
            if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                throw new ArgumentException("The parameter affectedPropertyName can not be null or a whitespace string except an empty string.", "affectedPropertyName");

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
        /// Gets the property value specified by the property name that is obtained by the CallerMemberName attribute in a property getter.
        /// If it does not exist, default(T) is returned.
        /// This method must be used in a property getter.
        /// </summary>
        /// <remarks>
        /// This method searches the internal storage for the property value.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>The property value if it exists; otherwise default(T).</returns>
        protected T GetCallerProperty<T>([CallerMemberName] string propertyName = "")
        {
            return GetProperty<T>(propertyName);
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
            if (affectedPropertyNames == null)
                throw new ArgumentNullException("affectedPropertyNames");

            foreach (string affectedPropertyName in affectedPropertyNames)
                if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                    throw new ArgumentException("The parameter affectedPropertyNames can not contain a string that is null or a whitespace string except an empty string.", "affectedPropertyNames");

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
            if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                throw new ArgumentException("The parameter affectedPropertyName can not be null or a whitespace string except an empty string.", "affectedPropertyName");

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
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
