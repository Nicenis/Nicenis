/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.03.21
 * Version  $Id$
 *
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicenis.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using System.ComponentModel;

namespace NicenisTests.ComponentModel
{
    [TestClass]
    public class WatchableObjectTests
    {
        #region Sample class

        class Sample : WatchableObject
        {
            #region Converted Methods From Protected To Public

            #region GetPropertyName Related

            public new static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
            {
                return Sample.GetPropertyName(propertyExpression);
            }

            #endregion

            #region IsEqualPropertyValue Related

            public new static bool IsEqualPropertyValue<T>(T left, T right)
            {
                return WatchableObject.IsEqualPropertyValue(left, right);
            }

            #endregion

            #region GetProperty Related

            public new T GetProperty<T>(string propertyName, T defaultValue = default(T))
            {
                return base.GetProperty(propertyName, defaultValue);
            }

            public new T GetProperty<T>(string propertyName, Func<T> initializer)
            {
                return base.GetProperty(propertyName, initializer);
            }

            #endregion

            #region SetProperty Related

            public new bool SetPropertyWithoutNotification<T>(string propertyName, T value)
            {
                return base.SetPropertyWithoutNotification(propertyName, value);
            }

            public new bool SetProperty<T>(string propertyName, T value, IEnumerable<string> affectedPropertyNames)
            {
                return base.SetProperty(propertyName, value, affectedPropertyNames);
            }

            public new bool SetProperty<T>(string propertyName, T value, string affectedPropertyName)
            {
                return base.SetProperty(propertyName, value, affectedPropertyName);
            }

            public new bool SetProperty<T>(string propertyName, T value)
            {
                return base.SetProperty(propertyName, value);
            }

            #endregion

            #region SetProperty with Local Storage Related

            public new bool SetPropertyWithoutNotification<T>(ref T storage, T value)
            {
                return base.SetPropertyWithoutNotification(ref storage, value);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
            {
                return base.SetProperty(propertyName, ref storage, value, affectedPropertyNames);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value, string affectedPropertyName)
            {
                return base.SetProperty(propertyName, ref storage, value, affectedPropertyName);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value)
            {
                return base.SetProperty(propertyName, ref storage, value);
            }

            #endregion

            #region EnumeratePropertyChangedCallback Related

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback(IEnumerable<string> propertyNames)
            {
                return base.EnumeratePropertyChangedCallback(propertyNames);
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback(string propertyName)
            {
                return base.EnumeratePropertyChangedCallback(propertyName);
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback()
            {
                return base.EnumeratePropertyChangedCallback();
            }


            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3)
            {
                return base.EnumeratePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3
                );
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
            {
                return base.EnumeratePropertyChangedCallback(propertyExpression, propertyExpression2);
            }

            public new IEnumerable<Action<PropertyChangedEventArgs>> EnumeratePropertyChangedCallback<T>(Expression<Func<T>> propertyExpression)
            {
                return base.EnumeratePropertyChangedCallback(propertyExpression);
            }

            #endregion

            #region SetPropertyChangedCallback Related

            public new int SetPropertyChangedCallback(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback(propertyNames, callback);
            }

            public new bool SetPropertyChangedCallback(string propertyName, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback(propertyName, callback);
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3,
                    callback
                );
            }

            public new int SetPropertyChangedCallback<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback(propertyExpression, propertyExpression2, callback);
            }

            public new bool SetPropertyChangedCallback<T>(Expression<Func<T>> propertyExpression, Action<PropertyChangedEventArgs> callback)
            {
                return base.SetPropertyChangedCallback(propertyExpression, callback);
            }

            #endregion

            #region RemovePropertyChangedCallback Related

            public new int RemovePropertyChangedCallback(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback(propertyNames, callback);
            }

            public new bool RemovePropertyChangedCallback(string propertyName, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback(propertyName, callback);
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback
                (
                    propertyExpression, propertyExpression2, propertyExpression3,
                    callback
                );
            }

            public new int RemovePropertyChangedCallback<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Action<PropertyChangedEventArgs> callback)
            {
                return base.RemovePropertyChangedCallback(propertyExpression, propertyExpression2, callback);
            }

            public new void RemovePropertyChangedCallback<T>(Expression<Func<T>> propertyExpression, Action<PropertyChangedEventArgs> callback)
            {
                base.RemovePropertyChangedCallback(propertyExpression, callback);
            }

            #endregion

            #region OnPropertyChanged Related

            public new void OnPropertyChanged(string propertyName)
            {
                base.OnPropertyChanged(propertyName);
            }

            public new void OnPropertyChanged(IEnumerable<string> propertyNames)
            {
                base.OnPropertyChanged(propertyNames);
            }

            #endregion

            #endregion

            #region ValueProperty & ReferenceProperty Related

            public int ValueProperty
            {
                get { return GetProperty(() => ValueProperty); }
                set { SetProperty(() => ValueProperty, value); }
            }

            public const int DefaultOfValuePropertyWithDefault = 10;

            public int ValuePropertyWithDefault
            {
                get { return GetProperty(() => ValuePropertyWithDefault, DefaultOfValuePropertyWithDefault); }
                set { SetProperty(() => ValuePropertyWithDefault, value); }
            }

            public int ValuePropertyWithoutNotification
            {
                get { return GetProperty(() => ValueProperty); }
                set { SetPropertyWithoutNotification(() => ValueProperty, value); }
            }

            int _valuePropertyWithLocalStorage;

            public int ValuePropertyWithLocalStorage
            {
                get { return _valuePropertyWithLocalStorage; }
                set { SetProperty(() => ValuePropertyWithLocalStorage, ref _valuePropertyWithLocalStorage, value); }
            }

            int _valuePropertyWithLocalStorageWithDefault = DefaultOfValuePropertyWithDefault;

            public int ValuePropertyWithLocalStorageWithDefault
            {
                get { return _valuePropertyWithLocalStorageWithDefault; }
                set { SetProperty(() => ValuePropertyWithLocalStorageWithDefault, ref _valuePropertyWithLocalStorageWithDefault, value); }
            }

            public string ReferenceProperty
            {
                get { return GetProperty(() => ReferenceProperty); }
                set { SetProperty(() => ReferenceProperty, value); }
            }

            public List<int> ReferencePropertyWithInitializer
            {
                get { return GetProperty(() => ReferencePropertyWithInitializer, () => new List<int>()); }
                set { SetProperty(() => ReferencePropertyWithInitializer, value); }
            }

            string _referencePropertyWithLocalStorage;

            public string ReferencePropertyWithLocalStorage
            {
                get { return _referencePropertyWithLocalStorage; }
                set { SetProperty(() => ReferencePropertyWithLocalStorage, ref _referencePropertyWithLocalStorage, value); }
            }

            #endregion

            #region TestProperty1 ~ TestProperty20

            public const int TestPropertyCount = 20;

            public class TestPropertyType1 { }
            public class TestPropertyType2 { }
            public class TestPropertyType3 { }
            public class TestPropertyType4 { }
            public class TestPropertyType5 { }
            public class TestPropertyType6 { }
            public class TestPropertyType7 { }
            public class TestPropertyType8 { }
            public class TestPropertyType9 { }
            public class TestPropertyType10 { }
            public class TestPropertyType11 { }
            public class TestPropertyType12 { }
            public class TestPropertyType13 { }
            public class TestPropertyType14 { }
            public class TestPropertyType15 { }
            public class TestPropertyType16 { }
            public class TestPropertyType17 { }
            public class TestPropertyType18 { }
            public class TestPropertyType19 { }
            public class TestPropertyType20 { }

            public TestPropertyType1 TestProperty1
            {
                get { return GetProperty(() => TestProperty1); }
                set { SetProperty(() => TestProperty1, value); }
            }

            public TestPropertyType2 TestProperty2
            {
                get { return GetProperty(() => TestProperty2); }
                set { SetProperty(() => TestProperty2, value); }
            }

            public TestPropertyType3 TestProperty3
            {
                get { return GetProperty(() => TestProperty3); }
                set { SetProperty(() => TestProperty3, value); }
            }

            public TestPropertyType4 TestProperty4
            {
                get { return GetProperty(() => TestProperty4); }
                set { SetProperty(() => TestProperty4, value); }
            }

            public TestPropertyType5 TestProperty5
            {
                get { return GetProperty(() => TestProperty5); }
                set { SetProperty(() => TestProperty5, value); }
            }

            public TestPropertyType6 TestProperty6
            {
                get { return GetProperty(() => TestProperty6); }
                set { SetProperty(() => TestProperty6, value); }
            }

            public TestPropertyType7 TestProperty7
            {
                get { return GetProperty(() => TestProperty7); }
                set { SetProperty(() => TestProperty7, value); }
            }

            public TestPropertyType8 TestProperty8
            {
                get { return GetProperty(() => TestProperty8); }
                set { SetProperty(() => TestProperty8, value); }
            }

            public TestPropertyType9 TestProperty9
            {
                get { return GetProperty(() => TestProperty9); }
                set { SetProperty(() => TestProperty9, value); }
            }

            public TestPropertyType10 TestProperty10
            {
                get { return GetProperty(() => TestProperty10); }
                set { SetProperty(() => TestProperty10, value); }
            }

            public TestPropertyType11 TestProperty11
            {
                get { return GetProperty(() => TestProperty11); }
                set { SetProperty(() => TestProperty11, value); }
            }

            public TestPropertyType12 TestProperty12
            {
                get { return GetProperty(() => TestProperty12); }
                set { SetProperty(() => TestProperty12, value); }
            }

            public TestPropertyType13 TestProperty13
            {
                get { return GetProperty(() => TestProperty13); }
                set { SetProperty(() => TestProperty13, value); }
            }

            public TestPropertyType14 TestProperty14
            {
                get { return GetProperty(() => TestProperty14); }
                set { SetProperty(() => TestProperty14, value); }
            }

            public TestPropertyType15 TestProperty15
            {
                get { return GetProperty(() => TestProperty15); }
                set { SetProperty(() => TestProperty15, value); }
            }

            public TestPropertyType16 TestProperty16
            {
                get { return GetProperty(() => TestProperty16); }
                set { SetProperty(() => TestProperty16, value); }
            }

            public TestPropertyType17 TestProperty17
            {
                get { return GetProperty(() => TestProperty17); }
                set { SetProperty(() => TestProperty17, value); }
            }

            public TestPropertyType18 TestProperty18
            {
                get { return GetProperty(() => TestProperty18); }
                set { SetProperty(() => TestProperty18, value); }
            }

            public TestPropertyType19 TestProperty19
            {
                get { return GetProperty(() => TestProperty19); }
                set { SetProperty(() => TestProperty19, value); }
            }

            public TestPropertyType20 TestProperty20
            {
                get { return GetProperty(() => TestProperty20); }
                set { SetProperty(() => TestProperty20, value); }
            }

            #endregion

            #region AffectedPropertyTest Series

            public int AffectedPropertyTest20
            {
                get { return GetProperty(() => AffectedPropertyTest20); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest20,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19, () => TestProperty20
                    );
                }
            }

            public int AffectedPropertyTest19
            {
                get { return GetProperty(() => AffectedPropertyTest19); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest19,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19
                    );
                }
            }

            public int AffectedPropertyTest18
            {
                get { return GetProperty(() => AffectedPropertyTest18); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest18,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18
                    );
                }
            }

            public int AffectedPropertyTest17
            {
                get { return GetProperty(() => AffectedPropertyTest17); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest17,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17
                    );
                }
            }

            public int AffectedPropertyTest16
            {
                get { return GetProperty(() => AffectedPropertyTest16); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest16,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16
                    );
                }
            }

            public int AffectedPropertyTest15
            {
                get { return GetProperty(() => AffectedPropertyTest15); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest15,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15
                    );
                }
            }

            public int AffectedPropertyTest14
            {
                get { return GetProperty(() => AffectedPropertyTest14); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest14,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14
                    );
                }
            }

            public int AffectedPropertyTest13
            {
                get { return GetProperty(() => AffectedPropertyTest13); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest13,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13
                    );
                }
            }

            public int AffectedPropertyTest12
            {
                get { return GetProperty(() => AffectedPropertyTest12); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest12,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12
                    );
                }
            }

            public int AffectedPropertyTest11
            {
                get { return GetProperty(() => AffectedPropertyTest11); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest11,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11
                    );
                }
            }

            public int AffectedPropertyTest10
            {
                get { return GetProperty(() => AffectedPropertyTest10); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest10,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10
                    );
                }
            }

            public int AffectedPropertyTest9
            {
                get { return GetProperty(() => AffectedPropertyTest9); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest9,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9
                    );
                }
            }

            public int AffectedPropertyTest8
            {
                get { return GetProperty(() => AffectedPropertyTest8); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest8,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8
                    );
                }
            }

            public int AffectedPropertyTest7
            {
                get { return GetProperty(() => AffectedPropertyTest7); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest7,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7
                    );
                }
            }

            public int AffectedPropertyTest6
            {
                get { return GetProperty(() => AffectedPropertyTest6); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest6,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6
                    );
                }
            }

            public int AffectedPropertyTest5
            {
                get { return GetProperty(() => AffectedPropertyTest5); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest5,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5
                    );
                }
            }

            public int AffectedPropertyTest4
            {
                get { return GetProperty(() => AffectedPropertyTest4); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest4,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4
                    );
                }
            }

            public int AffectedPropertyTest3
            {
                get { return GetProperty(() => AffectedPropertyTest3); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest3,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3
                    );
                }
            }

            public int AffectedPropertyTest2
            {
                get { return GetProperty(() => AffectedPropertyTest2); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest2,
                        value,
                        () => TestProperty1, () => TestProperty2
                    );
                }
            }

            public int AffectedPropertyTest1
            {
                get { return GetProperty(() => AffectedPropertyTest1); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest1,
                        value,
                        () => TestProperty1
                    );
                }
            }

            #endregion

            #region OnPropertyChangedTest Series

            public int OnPropertyChangedTest20
            {
                get { return GetProperty(() => OnPropertyChangedTest20); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest20, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17, () => TestProperty18, () => TestProperty19, () => TestProperty20
                        );
                    }
                }
            }

            public int OnPropertyChangedTest19
            {
                get { return GetProperty(() => OnPropertyChangedTest19); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest19, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17, () => TestProperty18, () => TestProperty19
                        );
                    }
                }
            }

            public int OnPropertyChangedTest18
            {
                get { return GetProperty(() => OnPropertyChangedTest18); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest18, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17, () => TestProperty18
                        );
                    }
                }
            }

            public int OnPropertyChangedTest17
            {
                get { return GetProperty(() => OnPropertyChangedTest17); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest17, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17
                        );
                    }
                }
            }

            public int OnPropertyChangedTest16
            {
                get { return GetProperty(() => OnPropertyChangedTest16); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest16, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16
                        );
                    }
                }
            }

            public int OnPropertyChangedTest15
            {
                get { return GetProperty(() => OnPropertyChangedTest15); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest15, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15
                        );
                    }
                }
            }

            public int OnPropertyChangedTest14
            {
                get { return GetProperty(() => OnPropertyChangedTest14); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest14, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14
                        );
                    }
                }
            }

            public int OnPropertyChangedTest13
            {
                get { return GetProperty(() => OnPropertyChangedTest13); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest13, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13
                        );
                    }
                }
            }

            public int OnPropertyChangedTest12
            {
                get { return GetProperty(() => OnPropertyChangedTest12); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest12, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12
                        );
                    }
                }
            }

            public int OnPropertyChangedTest11
            {
                get { return GetProperty(() => OnPropertyChangedTest11); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest11, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11
                        );
                    }
                }
            }

            public int OnPropertyChangedTest10
            {
                get { return GetProperty(() => OnPropertyChangedTest10); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest10, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10
                        );
                    }
                }
            }

            public int OnPropertyChangedTest9
            {
                get { return GetProperty(() => OnPropertyChangedTest9); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest9, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9
                        );
                    }
                }
            }

            public int OnPropertyChangedTest8
            {
                get { return GetProperty(() => OnPropertyChangedTest8); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest8, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8
                        );
                    }
                }
            }

            public int OnPropertyChangedTest7
            {
                get { return GetProperty(() => OnPropertyChangedTest7); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest7, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7
                        );
                    }
                }
            }

            public int OnPropertyChangedTest6
            {
                get { return GetProperty(() => OnPropertyChangedTest6); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest6, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6
                        );
                    }
                }
            }

            public int OnPropertyChangedTest5
            {
                get { return GetProperty(() => OnPropertyChangedTest5); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest5, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5
                        );
                    }
                }
            }

            public int OnPropertyChangedTest4
            {
                get { return GetProperty(() => OnPropertyChangedTest4); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest4, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4
                        );
                    }
                }
            }

            public int OnPropertyChangedTest3
            {
                get { return GetProperty(() => OnPropertyChangedTest3); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest3, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3
                        );
                    }
                }
            }

            public int OnPropertyChangedTest2
            {
                get { return GetProperty(() => OnPropertyChangedTest2); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest2, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2
                        );
                    }
                }
            }

            public int OnPropertyChangedTest1
            {
                get { return GetProperty(() => OnPropertyChangedTest1); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest1, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1
                        );
                    }
                }
            }

            #endregion

            #region AffectedPropertyTestInSetPropertyWithLocalStorage Series

            int _affectedPropertyTestInSetPropertyWithLocalStorage20;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage20
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage20; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage20,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage20,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19, () => TestProperty20
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage19;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage19
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage19; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage19,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage19,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage18;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage18
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage18; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage18,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage18,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage17;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage17
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage17; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage17,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage17,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage16;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage16
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage16; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage16,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage16,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage15;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage15
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage15; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage15,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage15,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage14;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage14
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage14; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage14,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage14,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage13;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage13
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage13; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage13,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage13,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage12;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage12
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage12; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage12,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage12,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage11;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage11
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage11; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage11,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage11,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage10;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage10
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage10; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage10,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage10,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage9;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage9
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage9; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage9,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage9,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage8;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage8
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage8; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage8,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage8,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage7;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage7
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage7; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage7,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage7,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage6;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage6
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage6; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage6,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage6,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage5;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage5
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage5; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage5,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage5,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage4;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage4
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage4; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage4,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage4,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage3;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage3
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage3; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage3,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage3,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage2;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage2
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage2; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage2,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage2,
                        value,
                        () => TestProperty1, () => TestProperty2
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage1;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage1
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage1; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage1,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage1,
                        value,
                        () => TestProperty1
                    );
                }
            }

            #endregion
        }

        #endregion


        #region Helpers

        private void SetPropertyByReflection(Sample sample, string propertyName, object value)
        {
            Assert.IsNotNull(sample);
            Assert.IsFalse(string.IsNullOrWhiteSpace(propertyName));

            sample.GetType().InvokeMember
            (
                name: propertyName,
                invokeAttr: BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty,
                binder: null,
                target: sample,
                args: new object[] { value }
            );
        }

        private void ChangeTestProperty(Sample sample, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int no = i + 1;

                SetPropertyByReflection
                (
                    sample: sample,
                    propertyName: "TestProperty" + no,
                    value: Activator.CreateInstance
                    (
                        assemblyName: null,
                        typeName: "NicenisTests.ComponentModel.WatchableObjectTests+Sample+TestPropertyType" + no
                    ).Unwrap()
                );
            }
        }

        private static int ExtractFirstNumberInPropertyName(string propertyName)
        {
            string numberString = "";
            foreach (char chr in propertyName)
            {
                if (!char.IsDigit(chr))
                {
                    if (numberString == "")
                        continue;

                    break;
                }

                numberString += chr;
            };

            return int.Parse(numberString);
        }

        #endregion


        #region IsEqualPropertyValue Related

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_same_values()
        {
            // arrange
            const int left = 10;
            const int right = 10;
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_false_for_different_values()
        {
            // arrange
            const int left = 10;
            const int right = 20;
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_same_references()
        {
            // arrange
            Sample left = new Sample();
            Sample right = left;
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_false_for_different_references()
        {
            // arrange
            Sample left = new Sample();
            Sample right = new Sample();
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_same_strings()
        {
            // arrange
            string left = "Test";
            string right = "Test";
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_different_strings()
        {
            // arrange
            string left = "Test";
            string right = "Haha";
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_false_for_null_and_non_null()
        {
            // arrange
            Sample left = null;
            Sample right = new Sample();
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_null_values()
        {
            // arrange
            Sample left = null;
            Sample right = null;
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        #endregion


        #region GetProperty Parameter Check Related

        [TestMethod]
        public void GetProperty_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty(propertyName, () => "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName, () => "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName, () => "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_null_initializer_is_passed()
        {
            // arrange
            string propertyName = "propertyName";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName, initializer: null);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "initializer");
        }

        #endregion


        #region SetPropertyWithoutNotification Parameter Check Related

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        #endregion


        #region SetProperty Parameter Check Related

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "Test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[0];
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[] { "test", null };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_empty_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[] { "test", "" };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_whitespace_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "Test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            string affectedPropertyName = null;
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            string affectedPropertyName = "";
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_affected_property_name_is_whitespace()
        {
            // arrange
            string propertyName = "ValueProperty";
            string affectedPropertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }


        [TestMethod]
        public void SetProperty_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        #endregion


        #region SetProperty with local storage Parameter Check Related

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string storage = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string storage = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string storage = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[0];
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", null };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_empty_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", "" };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_whitespace_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string storage = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string storage = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string storage = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            string affectedPropertyName = null;
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            string affectedPropertyName = "";
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_affected_property_name_is_whitespace()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            string affectedPropertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }


        [TestMethod]
        public void SetProperty_with_local_storage_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string storage = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string storage = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string storage = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        #endregion


        #region EnumeratePropertyChangedCallback Parameter Check Related

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_throw_exception_if_property_names_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyChangedCallback(propertyNames).Count();
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_not_throw_exception_if_property_names_is_empty_collection()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[0];
            Sample sample = new Sample();

            // act
            sample.EnumeratePropertyChangedCallback(propertyNames).Count();

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_throw_exception_if_property_names_contain_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", null };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyChangedCallback(propertyNames).Count();
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_throw_exception_if_property_names_contain_empty_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", "" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyChangedCallback(propertyNames).Count();
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_throw_exception_if_property_names_contain_whitespace_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyChangedCallback(propertyNames).Count();
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_throw_exception_if_property_name_is_null()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyChangedCallback(propertyName).Count();
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_throw_exception_if_property_name_is_empty_string()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyChangedCallback(propertyName).Count();
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void EnumeratePropertyChangedCallback_must_throw_exception_if_property_names_is_whitespace_string()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyChangedCallback(propertyName).Count();
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        #endregion


        #region SetPropertyChangedCallback Parameter Check Related

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_names_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = null;
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_names_is_empty_collection()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[0];
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_names_contain_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", null };
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_names_contain_emtpy_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", "" };
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_names_contain_whitespace_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", " " };
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_with_property_names_must_throw_exception_if_callback_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test" };
            Action<PropertyChangedEventArgs> callback = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "callback");
        }


        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_name_is_null()
        {
            // arrange
            string propertyName = null;
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_name_is_emtpy_string()
        {
            // arrange
            string propertyName = "";
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_property_name_is_whitespace_string()
        {
            // arrange
            string propertyName = " ";
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyChangedCallback_must_throw_exception_if_callback_is_null()
        {
            // arrange
            string propertyName = "test";
            Action<PropertyChangedEventArgs> callback = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "callback");
        }

        #endregion


        #region SetPropertyChangedCallback Test Related

        [TestMethod]
        public void PropertyChangedCallback_must_be_called_when_the_target_property_is_changed()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;

            // act
            sample.SetPropertyChangedCallback(() => sample.ValueProperty, p => counter++);
            sample.ValueProperty = newValue;
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void Duplicated_PropertyChangedCallback_must_not_be_called_when_the_target_property_is_changed()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> callback = p => counter++;

            // act
            sample.SetPropertyChangedCallback(() => sample.ValueProperty, callback);
            sample.SetPropertyChangedCallback(() => sample.ValueProperty, callback);
            sample.ValueProperty = newValue;
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void PropertyChangedCallback_must_support_multiple_properties()
        {
            // arrange
            const int newValue = 10;
            const string newReference = "test";
            Sample sample = new Sample();
            int counterForValue = 0;
            int counterForReference = 0;

            // act
            sample.SetPropertyChangedCallback(() => sample.ValueProperty, p => counterForValue++);
            sample.SetPropertyChangedCallback(() => sample.ReferenceProperty, p => counterForReference++);
            sample.ValueProperty = newValue;
            sample.ReferenceProperty = newReference;

            // assert
            Assert.AreEqual(1, counterForValue);
            Assert.AreEqual(1, counterForReference);
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_20_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 20;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_19_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 19;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_18_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 18;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_17_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 17;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_16_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 16;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_15_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 15;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_14_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 14;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_13_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 13;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_12_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 12;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_11_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 11;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_10_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 10;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_9_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 9;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_8_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 8;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_7_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 7;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_6_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 6;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_5_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 5;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_4_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 4;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_3_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 3;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_2_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 2;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyChangedCallback_for_1_parameter_name_must_succeed()
        {
            // arrange
            const int parameterNameCount = 1;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1,
                p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 1));
        }

        #endregion


        #region RemovePropertyChangedCallback Parameter Check Related

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_names_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = null;
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_names_is_empty_collection()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[0];
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_names_contain_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", null };
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_names_contain_emtpy_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", "" };
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_names_contain_whitespace_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", " " };
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_with_property_names_must_throw_exception_if_callback_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test" };
            Action<PropertyChangedEventArgs> callback = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyNames, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "callback");
        }


        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_name_is_null()
        {
            // arrange
            string propertyName = null;
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_name_is_emtpy_string()
        {
            // arrange
            string propertyName = "";
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_property_name_is_whitespace_string()
        {
            // arrange
            string propertyName = " ";
            Action<PropertyChangedEventArgs> callback = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_throw_exception_if_callback_is_null()
        {
            // arrange
            string propertyName = "test";
            Action<PropertyChangedEventArgs> callback = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyChangedCallback(propertyName, callback);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "callback");
        }

        #endregion


        #region RemovePropertyChangedCallback Test Related

        [TestMethod]
        public void RemovePropertyChangedCallback_must_remove_PropertyChangedCallback()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> callback = p => counter++;

            // act
            sample.SetPropertyChangedCallback(() => sample.ValueProperty, callback);
            sample.RemovePropertyChangedCallback(() => sample.ValueProperty, callback);
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(0, counter);
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_support_duplicated_call()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> callback = p => counter++;

            // act
            sample.SetPropertyChangedCallback(() => sample.ValueProperty, callback);
            sample.RemovePropertyChangedCallback(() => sample.ValueProperty, callback);
            sample.RemovePropertyChangedCallback(() => sample.ValueProperty, callback);
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(0, counter);
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_succeed_if_PropertyChangedCallback_is_not_set()
        {
            // arrange
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> callback = p => counter++;

            // act
            sample.RemovePropertyChangedCallback(() => sample.ValueProperty, callback);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_must_support_multiple_properties()
        {
            // arrange
            const int newValue = 10;
            const string newReference = "test";
            Sample sample = new Sample();
            int counterForValue = 0;
            int counterForReference = 0;
            Action<PropertyChangedEventArgs> callbackForValue = p => counterForValue++;
            Action<PropertyChangedEventArgs> callbackForReference = p => counterForReference++;

            // act
            sample.SetPropertyChangedCallback(() => sample.ValueProperty, callbackForValue);
            sample.SetPropertyChangedCallback(() => sample.ReferenceProperty, callbackForReference);
            sample.RemovePropertyChangedCallback(() => sample.ValueProperty, callbackForValue);
            sample.ValueProperty = newValue;
            sample.ReferenceProperty = newReference;

            // assert
            Assert.AreEqual(0, counterForValue);
            Assert.AreEqual(1, counterForReference);
        }


        [TestMethod]
        public void RemovePropertyChangedCallback_for_20_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 20;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_19_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 19;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_18_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 18;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_17_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 17;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_16_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 16;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_15_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 15;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_14_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 14;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_13_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 13;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_12_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 12;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_11_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 11;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_10_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 10;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_9_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 9;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_8_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 8;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_7_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 7;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_6_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 6;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_5_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 5;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_4_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 4;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_3_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 3;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_2_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 2;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1, () => sample.TestProperty2,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyChangedCallback_for_1_parameter_name_must_succeed()
        {
            // arrange
            const int parameterNameCount = 1;
            Sample sample = new Sample();
            int[] counters = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> callback = p => counters[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyChangedCallback
            (
                () => sample.TestProperty1,
                callback
            );
            sample.RemovePropertyChangedCallback
            (
                () => sample.TestProperty1,
                callback
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(counters.All(p => p == 0));
        }

        #endregion


        [TestMethod]
        public void Uninitialized_value_property_must_return_zero()
        {
            // arrange
            Sample sample = new Sample();

            // act
            int property = sample.ValueProperty;

            // assert
            Assert.AreEqual(0, property);
        }

        [TestMethod]
        public void Uninitialized_value_property_with_default_must_return_default()
        {
            // arrange
            Sample sample = new Sample();

            // act
            int property = sample.ValuePropertyWithDefault;

            // assert
            Assert.AreEqual(Sample.DefaultOfValuePropertyWithDefault, property);
        }

        [TestMethod]
        public void Set_value_property_and_get_it()
        {
            // arrange
            const int expected = 10;
            Sample sample = new Sample();

            // act
            sample.ValueProperty = expected;
            int property = sample.ValueProperty;

            // assert
            Assert.AreEqual(expected, property);
        }

        [TestMethod]
        public void Set_value_property_with_local_storage_and_get_it()
        {
            // arrange
            const int expected = 10;
            Sample sample = new Sample();

            // act
            sample.ValuePropertyWithLocalStorage = expected;
            int property = sample.ValuePropertyWithLocalStorage;

            // assert
            Assert.AreEqual(expected, property);
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_not_raise_PropertyChanged()
        {
            // arrange
            const int testInt = 100;
            int propertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, __) => propertyChangedCount++;

            // act
            sample.ValuePropertyWithoutNotification = testInt;
            sample.ValuePropertyWithoutNotification = testInt;

            // assert
            Assert.AreEqual(0, propertyChangedCount);
        }

        [TestMethod]
        public void Uninitialized_reference_property_must_return_null()
        {
            // arrange
            Sample sample = new Sample();

            // act
            string property = sample.ReferenceProperty;

            // assert
            Assert.AreEqual(null, property);
        }

        [TestMethod]
        public void Set_reference_property_and_get_it()
        {
            // arrange
            const string expected = "Test";
            Sample sample = new Sample();

            // act
            sample.ReferenceProperty = expected;
            string property = sample.ReferenceProperty;

            // assert
            Assert.AreEqual(expected, property);
        }

        [TestMethod]
        public void Uninitialized_reference_property_with_initializer_must_return_initialized_value()
        {
            // arrange
            Sample sample = new Sample();

            // act
            List<int> property = sample.ReferencePropertyWithInitializer;

            // assert
            Assert.IsNotNull(property);
        }

        [TestMethod]
        public void SetProperty_initializer_must_not_be_called_twice()
        {
            // arrange
            Sample sample = new Sample();

            // act
            List<int> property = sample.ReferencePropertyWithInitializer;
            List<int> property2 = sample.ReferencePropertyWithInitializer;

            // assert
            Assert.AreEqual(property, property2);
        }

        [TestMethod]
        public void SetProperty_initializer_must_not_be_called_if_property_is_initialized()
        {
            // arrange
            Sample sample = new Sample();

            // act
            sample.ReferencePropertyWithInitializer = null;
            List<int> property = sample.ReferencePropertyWithInitializer;

            // assert
            Assert.IsNull(property);
        }

        [TestMethod]
        public void SetProperty_must_not_interfere_other_property()
        {
            // arrange
            const int testInt = 1;
            const int testInt2 = 2;

            Sample sample = new Sample();

            // act
            sample.ValueProperty = testInt;
            sample.ValuePropertyWithDefault = testInt2;

            int propertyValue = sample.ValueProperty;
            int propertyValue2 = sample.ValuePropertyWithDefault;

            // assert
            Assert.AreEqual(testInt, propertyValue);
            Assert.AreEqual(testInt2, propertyValue2);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_not_interfere_other_property()
        {
            // arrange
            const int testInt = 1;
            const int testInt2 = 2;

            Sample sample = new Sample();

            // act
            sample.ValuePropertyWithLocalStorage = testInt;
            sample.ValuePropertyWithLocalStorageWithDefault = testInt2;

            int propertyValue = sample.ValuePropertyWithLocalStorage;
            int propertyValue2 = sample.ValuePropertyWithLocalStorageWithDefault;

            // assert
            Assert.AreEqual(testInt, propertyValue);
            Assert.AreEqual(testInt2, propertyValue2);
        }

        [TestMethod]
        public void PropertyChanged_must_be_raised_per_changed_property()
        {
            // arrange
            const int testInt = 1000;
            const string testString = "test";

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;
            int referencePropertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == "ValueProperty")
                    valuePropertyChangedCount++;

                if (e.PropertyName == "ReferenceProperty")
                    referencePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.ValueProperty = testInt;
            sample.ReferenceProperty = testString;

            // assert
            Assert.AreEqual(2, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
            Assert.AreEqual(1, referencePropertyChangedCount);
        }

        [TestMethod]
        public void PropertyChanged_must_not_be_raised_if_property_is_not_changed()
        {
            // arrange
            const int testInt = 1000;

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == "ValueProperty")
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.ValueProperty = testInt;
            sample.ValueProperty = testInt;

            // assert
            Assert.AreEqual(1, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_affected_properties_specified()
        {
            // arrange
            const int testInt = 1000;

            List<string> changedPropertyNames = new List<string>();

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) => changedPropertyNames.Add(e.PropertyName);

            for (int i = 0; i < Sample.TestPropertyCount; i++)
            {
                changedPropertyNames.Clear();
                int affectedPropertyCount = i + 1;
                string targetPropertyName = "AffectedPropertyTest" + affectedPropertyCount;

                // act
                SetPropertyByReflection(sample, targetPropertyName, testInt);
                SetPropertyByReflection(sample, targetPropertyName, testInt);

                // assert
                Assert.AreEqual(affectedPropertyCount + 1, changedPropertyNames.Count());
                Assert.IsTrue(changedPropertyNames.Count() == changedPropertyNames.Distinct().Count());
                Assert.IsTrue(changedPropertyNames.Contains(targetPropertyName));

                for (int j = 0; j < affectedPropertyCount; j++)
                    Assert.IsTrue(changedPropertyNames.Contains("TestProperty" + (j + 1)));
            }
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_affected_properties_specified()
        {
            // arrange
            const int testInt = 1000;

            List<string> changedPropertyNames = new List<string>();

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) => changedPropertyNames.Add(e.PropertyName);

            for (int i = 0; i < Sample.TestPropertyCount; i++)
            {
                changedPropertyNames.Clear();
                int affectedPropertyCount = i + 1;
                string targetPropertyName = "AffectedPropertyTestInSetPropertyWithLocalStorage" + affectedPropertyCount;

                // act
                SetPropertyByReflection(sample, targetPropertyName, testInt);
                SetPropertyByReflection(sample, targetPropertyName, testInt);

                // assert
                Assert.AreEqual(affectedPropertyCount + 1, changedPropertyNames.Count());
                Assert.IsTrue(changedPropertyNames.Count() == changedPropertyNames.Distinct().Count());
                Assert.IsTrue(changedPropertyNames.Contains(targetPropertyName));

                for (int j = 0; j < affectedPropertyCount; j++)
                    Assert.IsTrue(changedPropertyNames.Contains("TestProperty" + (j + 1)));
            }
        }

        [TestMethod]
        public void OnPropertyChanged_must_raise_PropertyChanged_for_specified_properties()
        {
            // arrange
            const int maxPropertyCount = 20;
            const int testInt = 1000;

            List<string> changedPropertyNames = new List<string>();

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) => changedPropertyNames.Add(e.PropertyName);

            for (int i = 0; i < maxPropertyCount; i++)
            {
                changedPropertyNames.Clear();
                int propertyCount = i + 1;
                string targetPropertyName = "OnPropertyChangedTest" + propertyCount;

                // act
                SetPropertyByReflection(sample, targetPropertyName, testInt);
                SetPropertyByReflection(sample, targetPropertyName, testInt);

                // assert
                Assert.AreEqual(propertyCount + 1, changedPropertyNames.Count());
                Assert.IsTrue(changedPropertyNames.Count() == changedPropertyNames.Distinct().Count());
                Assert.IsTrue(changedPropertyNames.Contains(targetPropertyName));

                for (int j = 0; j < propertyCount; j++)
                    Assert.IsTrue(changedPropertyNames.Contains("TestProperty" + (j + 1)));
            }
        }
    }
}
