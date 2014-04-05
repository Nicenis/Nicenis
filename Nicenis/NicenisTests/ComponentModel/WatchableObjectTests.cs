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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicenis.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace NicenisTests.ComponentModel
{
    [TestClass]
    public class WatchableObjectTests
    {
        #region Sample Classes

        class Sample : WatchableObject
        {
            #region Converted Methods From Protected To Public

            #region GetPropertyName Related

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T>> propertyExpression,
                    Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                    Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                    Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10,
                    Expression<Func<T11>> propertyExpression11)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T>> propertyExpression,
                    Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                    Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                    Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Expression<Func<T10>> propertyExpression10)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T>> propertyExpression,
                    Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                    Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                    Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T>> propertyExpression,
                    Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                    Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7,
                    Expression<Func<T8>> propertyExpression8)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T>> propertyExpression,
                    Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                    Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Expression<Func<T7>> propertyExpression7)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5, T6>(Expression<Func<T>> propertyExpression,
                    Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                    Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4, T5>(Expression<Func<T>> propertyExpression,
                    Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4,
                    Expression<Func<T5>> propertyExpression5)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3, T4>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                    Expression<Func<T3>> propertyExpression3, Expression<Func<T4>> propertyExpression4)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2, T3>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
                    Expression<Func<T3>> propertyExpression3)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2, propertyExpression3
                );
            }

            public new static IEnumerable<string> GetPropertyName<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
            {
                return WatchableObject.GetPropertyName
                (
                    propertyExpression, propertyExpression2
                );
            }

            public new static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
            {
                return WatchableObject.GetPropertyName(propertyExpression);
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

            public new T GetProperty<T>(Expression<Func<T>> propertyExpression, T defaultValue = default(T))
            {
                return base.GetProperty(propertyExpression, defaultValue);
            }

            public new T GetProperty<T>(string propertyName, Func<T> initializer)
            {
                return base.GetProperty(propertyName, initializer);
            }

            public new T GetProperty<T>(Expression<Func<T>> propertyExpression, Func<T> initializer)
            {
                return base.GetProperty(propertyExpression, initializer);
            }

            #endregion

            #region SetProperty Related

            public new bool SetPropertyWithoutNotification<T>(string propertyName, T value)
            {
                return base.SetPropertyWithoutNotification(propertyName, value);
            }

            public new bool SetPropertyWithoutNotification<T>(Expression<Func<T>> propertyExpression, T value)
            {
                return base.SetPropertyWithoutNotification(propertyExpression, value);
            }

            public new bool SetProperty<T>(string propertyName, T value, IEnumerable<string> affectedPropertyNames)
            {
                return base.SetProperty(propertyName, value, affectedPropertyNames);
            }

            public new bool SetProperty<T>(string propertyName, T value, params string[] affectedPropertyNames)
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

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18,
                    Expression<Func<T20>> affectedPropertyExpression19, Expression<Func<T21>> affectedPropertyExpression20)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18, affectedPropertyExpression19, affectedPropertyExpression20
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18,
                    Expression<Func<T20>> affectedPropertyExpression19)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18, affectedPropertyExpression19
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4
                );
            }

            public new bool SetProperty<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3
                );
            }

            public new bool SetProperty<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression, affectedPropertyExpression2
                );
            }

            public new bool SetProperty<T, T2>(
                    Expression<Func<T>> propertyExpression, T value,
                    Expression<Func<T2>> affectedPropertyExpression)
            {
                return base.SetProperty
                (
                    propertyExpression, value,
                    affectedPropertyExpression
                );
            }

            public new bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value)
            {
                return base.SetProperty(propertyExpression, value);
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

            public new bool SetProperty<T>(string propertyName, ref T storage, T value, params string[] affectedPropertyNames)
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

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20, T21>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18,
                    Expression<Func<T20>> affectedPropertyExpression19, Expression<Func<T21>> affectedPropertyExpression20)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18, affectedPropertyExpression19, affectedPropertyExpression20
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18,
                    Expression<Func<T20>> affectedPropertyExpression19)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18, affectedPropertyExpression19
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17, Expression<Func<T19>> affectedPropertyExpression18)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17, affectedPropertyExpression18
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16, Expression<Func<T18>> affectedPropertyExpression17)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16, affectedPropertyExpression17
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15,
                    Expression<Func<T17>> affectedPropertyExpression16)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15,
                    affectedPropertyExpression16
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14, Expression<Func<T16>> affectedPropertyExpression15)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14, affectedPropertyExpression15
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13, Expression<Func<T15>> affectedPropertyExpression14)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13, affectedPropertyExpression14
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12,
                    Expression<Func<T14>> affectedPropertyExpression13)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12, affectedPropertyExpression13
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11, Expression<Func<T13>> affectedPropertyExpression12)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11, affectedPropertyExpression12
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10, Expression<Func<T12>> affectedPropertyExpression11)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10,
                    affectedPropertyExpression11
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9,
                    Expression<Func<T11>> affectedPropertyExpression10)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9, affectedPropertyExpression10
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8, Expression<Func<T10>> affectedPropertyExpression9)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8, affectedPropertyExpression9
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7, Expression<Func<T9>> affectedPropertyExpression8)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7, affectedPropertyExpression8
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6,
                    Expression<Func<T8>> affectedPropertyExpression7)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6, affectedPropertyExpression7
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5, Expression<Func<T7>> affectedPropertyExpression6)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5,
                    affectedPropertyExpression6
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4, Expression<Func<T6>> affectedPropertyExpression5)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4, affectedPropertyExpression5
                );
            }

            public new bool SetProperty<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3,
                    Expression<Func<T5>> affectedPropertyExpression4)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3, affectedPropertyExpression4
                );
            }

            public new bool SetProperty<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2, Expression<Func<T4>> affectedPropertyExpression3)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2, affectedPropertyExpression3
                );
            }

            public new bool SetProperty<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression, Expression<Func<T3>> affectedPropertyExpression2)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression, affectedPropertyExpression2
                );
            }

            public new bool SetProperty<T, T2>(
                    Expression<Func<T>> propertyExpression, ref T storage, T value,
                    Expression<Func<T2>> affectedPropertyExpression)
            {
                return base.SetProperty
                (
                    propertyExpression, ref storage, value,
                    affectedPropertyExpression
                );
            }

            public new bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value)
            {
                return base.SetProperty(propertyExpression, ref storage, value);
            }

            #endregion

            #region EnumeratePropertyWatch Related

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch(IEnumerable<string> propertyNames)
            {
                return base.EnumeratePropertyWatch(propertyNames);
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch(string propertyName)
            {
                return base.EnumeratePropertyWatch(propertyName);
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch()
            {
                return base.EnumeratePropertyWatch();
            }


            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3)
            {
                return base.EnumeratePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3
                );
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
            {
                return base.EnumeratePropertyWatch(propertyExpression, propertyExpression2);
            }

            public new IEnumerable<PropertyWatch> EnumeratePropertyWatch<T>(Expression<Func<T>> propertyExpression)
            {
                return base.EnumeratePropertyWatch(propertyExpression);
            }

            #endregion

            #region SetPropertyWatch Related

            public new int SetPropertyWatch(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch(propertyNames, action);
            }

            public new bool SetPropertyWatch(string propertyName, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch(propertyName, action);
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3,
                    action
                );
            }

            public new int SetPropertyWatch<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch(propertyExpression, propertyExpression2, action);
            }

            public new bool SetPropertyWatch<T>(Expression<Func<T>> propertyExpression, Action<PropertyChangedEventArgs> action)
            {
                return base.SetPropertyWatch(propertyExpression, action);
            }

            #endregion

            #region RemovePropertyWatch Related

            public new int RemovePropertyWatch(IEnumerable<string> propertyNames, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch(propertyNames, action);
            }

            public new bool RemovePropertyWatch(string propertyName, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch(propertyName, action);
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Expression<Func<T20>> propertyExpression20, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19, propertyExpression20,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18,
                    Expression<Func<T19>> propertyExpression19, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18, propertyExpression19,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Expression<Func<T18>> propertyExpression18, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17, propertyExpression18,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Expression<Func<T17>> propertyExpression17, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16, propertyExpression17,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15,
                    Expression<Func<T16>> propertyExpression16, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    propertyExpression16,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Expression<Func<T15>> propertyExpression15, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14, propertyExpression15,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Expression<Func<T14>> propertyExpression14, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13, propertyExpression14,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12,
                    Expression<Func<T13>> propertyExpression13, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12, propertyExpression13,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Expression<Func<T12>> propertyExpression12, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11, propertyExpression12,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Expression<Func<T11>> propertyExpression11, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    propertyExpression11,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9,
                    Expression<Func<T10>> propertyExpression10, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9, propertyExpression10,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8, T9>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Expression<Func<T9>> propertyExpression9, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8, propertyExpression9,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7, T8>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Expression<Func<T8>> propertyExpression8, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7, propertyExpression8,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6, T7>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6,
                    Expression<Func<T7>> propertyExpression7, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6, propertyExpression7,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5, T6>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Expression<Func<T6>> propertyExpression6, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    propertyExpression6,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4, T5>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Expression<Func<T5>> propertyExpression5, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4, propertyExpression5,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3, T4>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3,
                    Expression<Func<T4>> propertyExpression4, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3, propertyExpression4,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2, T3>(
                    Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Expression<Func<T3>> propertyExpression3, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch
                (
                    propertyExpression, propertyExpression2, propertyExpression3,
                    action
                );
            }

            public new int RemovePropertyWatch<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2, Action<PropertyChangedEventArgs> action)
            {
                return base.RemovePropertyWatch(propertyExpression, propertyExpression2, action);
            }

            public new void RemovePropertyWatch<T>(Expression<Func<T>> propertyExpression, Action<PropertyChangedEventArgs> action)
            {
                base.RemovePropertyWatch(propertyExpression, action);
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

            public string ReferenceProperty
            {
                get { return GetProperty(() => ReferenceProperty); }
                set { SetProperty(() => ReferenceProperty, value); }
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
        }

        [DataContract]
        class SerializationSample : WatchableObject
        {
            [DataMember]
            public int TestValue
            {
                get { return GetProperty(() => TestValue); }
                set { SetProperty(() => TestValue, value); }
            }

            [DataMember]
            public string TestString
            {
                get { return GetProperty(() => TestString, "Test String"); }
                set { SetProperty(() => TestString, value); }
            }
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


        #region GetProperty Test Related

        [TestMethod]
        public void GetProperty_must_return_default_value_if_it_is_not_set()
        {
            // arrange
            Sample sample = new Sample();

            // act
            int property = sample.GetProperty(() => sample.ValueProperty);

            // assert
            Assert.AreEqual(default(int), property);
        }

        [TestMethod]
        public void GetProperty_must_return_default_value_specified_if_it_is_not_set()
        {
            // arrange
            const int defaultValue = 10;
            Sample sample = new Sample();

            // act
            int property = sample.GetProperty(() => sample.ValueProperty, defaultValue);

            // assert
            Assert.AreEqual(defaultValue, property);
        }

        [TestMethod]
        public void GetProperty_must_return_default_reference_if_it_is_not_set()
        {
            // arrange
            Sample sample = new Sample();

            // act
            string property = sample.ReferenceProperty;

            // assert
            Assert.AreEqual(default(string), property);
        }

        [TestMethod]
        public void GetProperty_must_return_initialized_value_if_it_is_not_set()
        {
            // arrange
            const int initializedValue = 10;
            Sample sample = new Sample();

            // act
            int property = sample.GetProperty(() => sample.ValueProperty, () => initializedValue);

            // assert
            Assert.AreEqual(initializedValue, property);
        }

        [TestMethod]
        public void GetProperty_must_not_call_initializer_twice()
        {
            // arrange
            const int initializedValue = 10;
            const int expectedInitializerCallCount = 1;
            Sample sample = new Sample();
            int initializerCallCount = 0;
            Func<int> initializer = () =>
            {
                initializerCallCount++;
                return initializedValue;
            };

            // act
            sample.GetProperty(() => sample.ValueProperty, initializer);
            sample.GetProperty(() => sample.ValueProperty, initializer);

            // assert
            Assert.AreEqual(initializerCallCount, expectedInitializerCallCount);
        }

        [TestMethod]
        public void GetProperty_must_not_call_initializer_if_it_is_set()
        {
            // arrange
            const int setValue = 100;
            const int initializedValue = 10;
            const int expectedInitializerCallCount = 0;
            Sample sample = new Sample();
            int initializerCallCount = 0;

            // act
            sample.SetProperty(() => sample.ValueProperty, setValue);
            sample.GetProperty(() => sample.ValueProperty, () =>
            {
                initializerCallCount++;
                return initializedValue;
            });

            // assert
            Assert.AreEqual(initializerCallCount, expectedInitializerCallCount);
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


        #region SetProperty Test Related

        [TestMethod]
        public void SetPropertyWithoutNotification_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();

            // act
            sample.SetPropertyWithoutNotification(() => sample.ValueProperty, testValue);
            int propertyValue = sample.GetProperty(() => sample.ValueProperty);

            // assert
            Assert.AreEqual(propertyValue, testValue);
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_not_raise_PropertyChanged()
        {
            // arrange
            const int testValue = 100;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            sample.PropertyChanged += (_, __) => propertyChangedCount++;

            // act
            sample.SetPropertyWithoutNotification(() => sample.ValueProperty, testValue);
            sample.SetPropertyWithoutNotification(() => sample.ValueProperty, testValue);

            // assert
            Assert.AreEqual(0, propertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();

            // act
            sample.SetProperty(() => sample.ValueProperty, testValue);
            int propertyValue = sample.GetProperty(() => sample.ValueProperty);

            // assert
            Assert.AreEqual(propertyValue, testValue);
        }

        [TestMethod]
        public void SetProperty_must_set_reference_properly()
        {
            // arrange
            const string testReference = "Test";
            Sample sample = new Sample();

            // act
            sample.SetProperty(() => sample.ReferenceProperty, testReference);
            string propertyReference = sample.GetProperty(() => sample.ReferenceProperty);

            // assert
            Assert.AreEqual(propertyReference, testReference);
        }

        [TestMethod]
        public void SetProperty_must_support_multiple_properties()
        {
            // arrange
            const int testValue = 10;
            const string testReference = "Test";

            Sample sample = new Sample();

            // act
            sample.SetProperty(() => sample.ValueProperty, testValue);
            sample.SetProperty(() => sample.ReferenceProperty, testReference);

            int propertyValue = sample.GetProperty(() => sample.ValueProperty);
            string propertyReference = sample.GetProperty(() => sample.ReferenceProperty);

            // assert
            Assert.AreEqual(testValue, propertyValue);
            Assert.AreEqual(testReference, propertyReference);
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == Sample.GetPropertyName(() => sample.ValueProperty))
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(() => sample.ValueProperty, testValue);

            // assert
            Assert.AreEqual(1, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_not_raise_PropertyChanged_if_it_is_not_changed()
        {
            // arrange
            const int testValue = default(int);

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == Sample.GetPropertyName(() => sample.ValueProperty))
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(() => sample.ValueProperty, testValue);

            // assert
            Assert.AreEqual(0, propertyChangedCount);
            Assert.AreEqual(0, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_20_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 21;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_19_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 20;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_18_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 19;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_17_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 18;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_16_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 17;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_15_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 16;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_14_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 15;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_13_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 14;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_12_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 13;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_11_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 12;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_10_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 11;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_9_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 10;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_8_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 9;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_7_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 8;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_6_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 7;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_5_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 6;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_4_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 5;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_3_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 4;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_2_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 3;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_1_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 2;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, testValue,
                () => sample.TestProperty1
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
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


        #region SetProperty with local storage Test Related

        [TestMethod]
        public void SetPropertyWithoutNotification_with_local_storage_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();
            int valueStorage = 0;

            // act
            sample.SetPropertyWithoutNotification(ref valueStorage, testValue);

            // assert
            Assert.AreEqual(valueStorage, testValue);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();
            int valueStorage = 0;

            // act
            sample.SetProperty(() => sample.ValueProperty, ref valueStorage, testValue);

            // assert
            Assert.AreEqual(valueStorage, testValue);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_set_reference_properly()
        {
            // arrange
            const string testReference = "Test";
            Sample sample = new Sample();
            string referenceStorage = null;

            // act
            sample.SetProperty(() => sample.ReferenceProperty, ref referenceStorage, testReference);

            // assert
            Assert.AreEqual(referenceStorage, testReference);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_support_multiple_properties()
        {
            // arrange
            const int testValue = 10;
            const string testReference = "Test";

            Sample sample = new Sample();
            int valueStorage = 0;
            string referenceStorage = null;

            // act
            sample.SetProperty(() => sample.ValueProperty, ref valueStorage, testValue);
            sample.SetProperty(() => sample.ReferenceProperty, ref referenceStorage, testReference);

            // assert
            Assert.AreEqual(testValue, valueStorage);
            Assert.AreEqual(testReference, referenceStorage);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            int valueStorage = 0;
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == Sample.GetPropertyName(() => sample.ValueProperty))
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(() => sample.ValueProperty, ref valueStorage, testValue);

            // assert
            Assert.AreEqual(1, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_not_raise_PropertyChanged_if_it_is_not_changed()
        {
            // arrange
            const int testValue = default(int);

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            int valueStorage = 0;
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == Sample.GetPropertyName(() => sample.ValueProperty))
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(() => sample.ValueProperty, ref valueStorage, testValue);

            // assert
            Assert.AreEqual(0, propertyChangedCount);
            Assert.AreEqual(0, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_20_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 21;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_19_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 20;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_18_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 19;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_17_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 18;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_16_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 17;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_15_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 16;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_14_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 15;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_13_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 14;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_12_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 13;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_11_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 12;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_10_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 11;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_9_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 10;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_8_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 9;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_7_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 8;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_6_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 7;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_5_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 6;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_4_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 5;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_3_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 4;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_2_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 3;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1, () => sample.TestProperty2
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_1_affected_property_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 2;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != Sample.GetPropertyName(() => sample.ValueProperty))
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                () => sample.ValueProperty, ref valueStorage, testValue,
                () => sample.TestProperty1
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        #endregion


        #region EnumeratePropertyWatch Parameter Check Related

        [TestMethod]
        public void EnumeratePropertyWatch_must_throw_exception_if_property_names_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyWatch(propertyNames).Count();
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
        public void EnumeratePropertyWatch_must_not_throw_exception_if_property_names_is_empty_collection()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[0];
            Sample sample = new Sample();

            // act
            sample.EnumeratePropertyWatch(propertyNames).Count();

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnumeratePropertyWatch_must_throw_exception_if_property_names_contain_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", null };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyWatch(propertyNames).Count();
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
        public void EnumeratePropertyWatch_must_not_throw_exception_if_property_names_contain_empty_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", "" };
            Sample sample = new Sample();

            // act
            sample.EnumeratePropertyWatch(propertyNames).Count();

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnumeratePropertyWatch_must_throw_exception_if_property_names_contain_whitespace_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyWatch(propertyNames).Count();
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
        public void EnumeratePropertyWatch_must_throw_exception_if_property_name_is_null()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyWatch(propertyName).Count();
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
        public void EnumeratePropertyWatch_must_not_throw_exception_if_property_name_is_empty_string()
        {
            // arrange
            string propertyName = "";
            Sample sample = new Sample();

            // act
            sample.EnumeratePropertyWatch(propertyName).Count();

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EnumeratePropertyWatch_must_throw_exception_if_property_names_is_whitespace_string()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.EnumeratePropertyWatch(propertyName).Count();
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


        #region EnumeratePropertyWatch Test Related

        [TestMethod]
        public void EnumeratePropertyWatch_must_enumerate_watch_action_for_a_property()
        {
            // arrange
            Sample sample = new Sample();
            int counter = 0;
            string propertyName = Sample.GetPropertyName(() => sample.TestProperty1);

            // act
            sample.SetPropertyWatch(propertyName, p =>
            {
                if (p.PropertyName == propertyName)
                    counter++;
            });

            foreach (PropertyWatch info in sample.EnumeratePropertyWatch(propertyName))
                info.Action(new PropertyChangedEventArgs(info.PropertyName));

            // assert
            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void EnumeratePropertyWatch_must_support_multiple_properties()
        {
            // arrange
            Sample sample = new Sample();
            int counter = 0, counter2 = 0;
            string propertyName = Sample.GetPropertyName(() => sample.TestProperty1);
            string propertyName2 = Sample.GetPropertyName(() => sample.TestProperty2);

            // act
            sample.SetPropertyWatch(propertyName, p =>
            {
                if (p.PropertyName == propertyName)
                    counter++;
            });

            sample.SetPropertyWatch(propertyName2, p =>
            {
                if (p.PropertyName == propertyName2)
                    counter2++;
            });

            foreach (PropertyWatch info in sample.EnumeratePropertyWatch(propertyName))
                info.Action(new PropertyChangedEventArgs(propertyName));

            foreach (PropertyWatch info in sample.EnumeratePropertyWatch(propertyName2))
                info.Action(new PropertyChangedEventArgs(propertyName2));

            // assert
            Assert.AreEqual(1, counter);
            Assert.AreEqual(1, counter2);
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_20_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 20;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_19_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 19;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_18_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 18;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_17_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 17;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_16_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 16;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_15_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 15;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_14_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 14;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_13_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 13;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_12_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 12;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_11_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 11;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_10_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 10;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_9_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 9;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_8_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 8;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_7_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 7;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_6_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 6;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_5_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 5;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_4_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 4;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_3_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 3;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for_2_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 2;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void EnumeratePropertyWatch_for12_parameter_name_must_succeed()
        {
            // arrange
            const int parameterNameCount = 1;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            IEnumerable<PropertyWatch> propertyWatches = sample.EnumeratePropertyWatch
            (
                () => sample.TestProperty1
            );

            foreach (PropertyWatch propertyWatch in propertyWatches)
                propertyWatch.Action(new PropertyChangedEventArgs(propertyWatch.PropertyName));

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        #endregion


        #region SetPropertyWatch Parameter Check Related

        [TestMethod]
        public void SetPropertyWatch_must_throw_exception_if_property_names_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = null;
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyNames, action);
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
        public void SetPropertyWatch_must_throw_exception_if_property_names_is_empty_collection()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[0];
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyNames, action);
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
        public void SetPropertyWatch_must_throw_exception_if_property_names_contain_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", null };
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyNames, action);
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
        public void SetPropertyWatch_must_not_throw_exception_if_property_names_contain_emtpy_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", "" };
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Sample sample = new Sample();

            // act
            sample.SetPropertyWatch(propertyNames, action);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetPropertyWatch_must_throw_exception_if_property_names_contain_whitespace_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", " " };
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyNames, action);
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
        public void SetPropertyWatch_with_property_names_must_throw_exception_if_action_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test" };
            Action<PropertyChangedEventArgs> action = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyNames, action);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "action");
        }


        [TestMethod]
        public void SetPropertyWatch_must_throw_exception_if_property_name_is_null()
        {
            // arrange
            string propertyName = null;
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyName, action);
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
        public void SetPropertyWatch_must_not_throw_exception_if_property_name_is_emtpy_string()
        {
            // arrange
            string propertyName = "";
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Sample sample = new Sample();

            // act
            sample.SetPropertyWatch(propertyName, action);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetPropertyWatch_must_throw_exception_if_property_name_is_whitespace_string()
        {
            // arrange
            string propertyName = " ";
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyName, action);
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
        public void SetPropertyWatch_must_throw_exception_if_action_is_null()
        {
            // arrange
            string propertyName = "test";
            Action<PropertyChangedEventArgs> action = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWatch(propertyName, action);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "action");
        }

        #endregion


        #region SetPropertyWatch Test Related

        [TestMethod]
        public void Watch_Action_must_be_called_when_the_target_property_is_changed()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;

            // act
            sample.SetPropertyWatch(() => sample.ValueProperty, p => counter++);
            sample.ValueProperty = newValue;
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void Duplicated_Watch_Action_must_not_be_called_when_the_target_property_is_changed()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> action = p => counter++;

            // act
            sample.SetPropertyWatch(() => sample.ValueProperty, action);
            sample.SetPropertyWatch(() => sample.ValueProperty, action);
            sample.ValueProperty = newValue;
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(1, counter);
        }

        [TestMethod]
        public void Watch_Action_must_support_multiple_properties()
        {
            // arrange
            const int newValue = 10;
            const string newReference = "test";
            Sample sample = new Sample();
            int counterForValue = 0;
            int counterForReference = 0;

            // act
            sample.SetPropertyWatch(() => sample.ValueProperty, p => counterForValue++);
            sample.SetPropertyWatch(() => sample.ReferenceProperty, p => counterForReference++);
            sample.ValueProperty = newValue;
            sample.ReferenceProperty = newReference;

            // assert
            Assert.AreEqual(1, counterForValue);
            Assert.AreEqual(1, counterForReference);
        }

        [TestMethod]
        public void Watch_Action_for_all_property_must_be_called_when_any_target_property_is_changed()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;
            int counterForValue = 0;

            // act
            sample.SetPropertyWatch(WatchableObject.AllPropertyName, p => counter++);
            sample.SetPropertyWatch(() => sample.ValueProperty, p => counterForValue++);
            sample.ValueProperty = newValue;
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(1, counter);
            Assert.AreEqual(1, counterForValue);
        }

        [TestMethod]
        public void SetPropertyWatch_for_20_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 20;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_19_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 19;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_18_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 18;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_17_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 17;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_16_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 16;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_15_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 15;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_14_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 14;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_13_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 13;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_12_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 12;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_11_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 11;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_10_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 10;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_9_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 9;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_8_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 8;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_7_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 7;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_6_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 6;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_5_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 5;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_4_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 4;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_3_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 3;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_2_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 2;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetPropertyWatch_for_1_parameter_name_must_succeed()
        {
            // arrange
            const int parameterNameCount = 1;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1,
                p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 1));
        }

        #endregion


        #region RemovePropertyWatch Parameter Check Related

        [TestMethod]
        public void RemovePropertyWatch_must_throw_exception_if_property_names_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = null;
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyNames, action);
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
        public void RemovePropertyWatch_must_throw_exception_if_property_names_is_empty_collection()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[0];
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyNames, action);
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
        public void RemovePropertyWatch_must_throw_exception_if_property_names_contain_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", null };
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyNames, action);
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
        public void RemovePropertyWatch_must_not_throw_exception_if_property_names_contain_emtpy_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", "" };
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Sample sample = new Sample();

            // act
            sample.RemovePropertyWatch(propertyNames, action);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemovePropertyWatch_must_throw_exception_if_property_names_contain_whitespace_string()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test", " " };
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyNames, action);
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
        public void RemovePropertyWatch_with_property_names_must_throw_exception_if_action_is_null()
        {
            // arrange
            IEnumerable<string> propertyNames = new string[] { "test" };
            Action<PropertyChangedEventArgs> action = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyNames, action);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "action");
        }


        [TestMethod]
        public void RemovePropertyWatch_must_throw_exception_if_property_name_is_null()
        {
            // arrange
            string propertyName = null;
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyName, action);
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
        public void RemovePropertyWatch_must_not_throw_exception_if_property_name_is_emtpy_string()
        {
            // arrange
            string propertyName = "";
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Sample sample = new Sample();

            // act
            sample.RemovePropertyWatch(propertyName, action);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemovePropertyWatch_must_throw_exception_if_property_name_is_whitespace_string()
        {
            // arrange
            string propertyName = " ";
            Action<PropertyChangedEventArgs> action = p => Console.WriteLine("");
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyName, action);
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
        public void RemovePropertyWatch_must_throw_exception_if_action_is_null()
        {
            // arrange
            string propertyName = "test";
            Action<PropertyChangedEventArgs> action = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.RemovePropertyWatch(propertyName, action);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "action");
        }

        #endregion


        #region RemovePropertyWatch Test Related

        [TestMethod]
        public void RemovePropertyWatch_must_remove_Watch_Action()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> action = p => counter++;

            // act
            sample.SetPropertyWatch(() => sample.ValueProperty, action);
            sample.RemovePropertyWatch(() => sample.ValueProperty, action);
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(0, counter);
        }

        [TestMethod]
        public void RemovePropertyWatch_must_support_duplicated_call()
        {
            // arrange
            const int newValue = 10;
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> action = p => counter++;

            // act
            sample.SetPropertyWatch(() => sample.ValueProperty, action);
            sample.RemovePropertyWatch(() => sample.ValueProperty, action);
            sample.RemovePropertyWatch(() => sample.ValueProperty, action);
            sample.ValueProperty = newValue;

            // assert
            Assert.AreEqual(0, counter);
        }

        [TestMethod]
        public void RemovePropertyWatch_must_succeed_if_Watch_Action_is_not_set()
        {
            // arrange
            Sample sample = new Sample();
            int counter = 0;
            Action<PropertyChangedEventArgs> action = p => counter++;

            // act
            sample.RemovePropertyWatch(() => sample.ValueProperty, action);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemovePropertyWatch_must_support_multiple_properties()
        {
            // arrange
            const int newValue = 10;
            const string newReference = "test";
            Sample sample = new Sample();
            int counterForValue = 0;
            int counterForReference = 0;
            Action<PropertyChangedEventArgs> actionForValue = p => counterForValue++;
            Action<PropertyChangedEventArgs> actionForReference = p => counterForReference++;

            // act
            sample.SetPropertyWatch(() => sample.ValueProperty, actionForValue);
            sample.SetPropertyWatch(() => sample.ReferenceProperty, actionForReference);
            sample.RemovePropertyWatch(() => sample.ValueProperty, actionForValue);
            sample.ValueProperty = newValue;
            sample.ReferenceProperty = newReference;

            // assert
            Assert.AreEqual(0, counterForValue);
            Assert.AreEqual(1, counterForReference);
        }


        [TestMethod]
        public void RemovePropertyWatch_for_20_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 20;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19, () => sample.TestProperty20,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_19_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 19;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18, () => sample.TestProperty19,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_18_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 18;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17, () => sample.TestProperty18,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_17_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 17;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                () => sample.TestProperty17,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_16_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 16;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15, () => sample.TestProperty16,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_15_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 15;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14, () => sample.TestProperty15,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_14_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 14;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13, () => sample.TestProperty14,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_13_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 13;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                () => sample.TestProperty13,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_12_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 12;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11, () => sample.TestProperty12,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_11_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 11;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10, () => sample.TestProperty11,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_10_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 10;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9, () => sample.TestProperty10,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_9_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 9;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                () => sample.TestProperty9,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_8_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 8;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7, () => sample.TestProperty8,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_7_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 7;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6, () => sample.TestProperty7,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_6_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 6;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5, () => sample.TestProperty6,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_5_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 5;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                () => sample.TestProperty5,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_4_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 4;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3, () => sample.TestProperty4,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_3_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 3;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2, () => sample.TestProperty3,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_2_parameter_names_must_succeed()
        {
            // arrange
            const int parameterNameCount = 2;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1, () => sample.TestProperty2,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        [TestMethod]
        public void RemovePropertyWatch_for_1_parameter_name_must_succeed()
        {
            // arrange
            const int parameterNameCount = 1;
            Sample sample = new Sample();
            int[] propertyChangedCounts = new int[parameterNameCount];
            Action<PropertyChangedEventArgs> action = p => propertyChangedCounts[ExtractFirstNumberInPropertyName(p.PropertyName) - 1]++;

            // act
            sample.SetPropertyWatch
            (
                () => sample.TestProperty1,
                action
            );
            sample.RemovePropertyWatch
            (
                () => sample.TestProperty1,
                action
            );

            ChangeTestProperty(sample, parameterNameCount);

            // assert
            Assert.IsTrue(propertyChangedCounts.All(p => p == 0));
        }

        #endregion


        #region DataContract Serialization Test Related

        [TestMethod]
        public void DataContractSerializer_must_be_supported()
        {
            // arrange
            const int testValue = 20;
            const string testString = "haha";
            SerializationSample sample = new SerializationSample();

            // act
            sample.TestValue = testValue;
            sample.TestString = testString;

            MemoryStream memoryStream = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(SerializationSample));
            serializer.WriteObject(memoryStream, sample);

            memoryStream.Position = 0;
            SerializationSample deserialized = (SerializationSample)serializer.ReadObject(memoryStream);

            // assert
            Assert.AreEqual(sample.TestValue, deserialized.TestValue);
            Assert.AreEqual(sample.TestString, deserialized.TestString);
        }

        #endregion
    }
}
