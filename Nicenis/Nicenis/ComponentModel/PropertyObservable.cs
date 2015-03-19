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
    public class PropertyObservable : INotifyPropertyChanged
    {
        #region Constants

        /// <summary>
        /// The property name that represents all properties.
        /// </summary>
        public const string AllPropertyName = "";

        #endregion


        #region Constructors

        /// <summary>
        /// The static constructor.
        /// </summary>
        static PropertyObservable()
        {

#if !NICENIS_RT
#if DEBUG
            // Initializes the OpCode info.
            InitializeOpCodeInfos();
#endif
#endif
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public PropertyObservable() { }

        #endregion


        #region ToPropertyName Related

#if !NICENIS_RT
#if DEBUG
        #region Get OpCode Total Size Related

        /// <summary>
        /// Represents a OpCode info that is used to calculate the total byte size of an OpCode.
        /// </summary>
        private class OpCodeInfo
        {
        #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="opCode">The OpCode structure.</param>
            public OpCodeInfo(System.Reflection.Emit.OpCode opCode)
            {
                Debug.Assert(opCode != null);

                OpCode = BitConverter.GetBytes(opCode.Value);

                // If it is a 2 byte OpCode, the byte order must be reversed because the Value property is not in little-endian.
                if (opCode.Size > 1)
                    OpCode = OpCode.Reverse().ToArray();

                OpCodeSize = opCode.Size;

                switch (opCode.OperandType)
                {
                    case System.Reflection.Emit.OperandType.InlineNone:
#pragma warning disable 0618
                    case System.Reflection.Emit.OperandType.InlinePhi:
#pragma warning restore 0618
                        OperandSize = 0;
                        break;

                    case System.Reflection.Emit.OperandType.ShortInlineBrTarget:
                    case System.Reflection.Emit.OperandType.ShortInlineI:
                    case System.Reflection.Emit.OperandType.ShortInlineVar:
                        OperandSize = 1;
                        break;

                    case System.Reflection.Emit.OperandType.InlineVar:
                        OperandSize = 2;
                        break;

                    case System.Reflection.Emit.OperandType.InlineBrTarget:
                    case System.Reflection.Emit.OperandType.InlineField:
                    case System.Reflection.Emit.OperandType.InlineI:
                    case System.Reflection.Emit.OperandType.InlineMethod:
                    case System.Reflection.Emit.OperandType.InlineSig:
                    case System.Reflection.Emit.OperandType.InlineString:
                    case System.Reflection.Emit.OperandType.InlineSwitch:
                    case System.Reflection.Emit.OperandType.InlineTok:
                    case System.Reflection.Emit.OperandType.InlineType:
                    case System.Reflection.Emit.OperandType.ShortInlineR:
                        OperandSize = 4;
                        break;

                    case System.Reflection.Emit.OperandType.InlineI8:
                    case System.Reflection.Emit.OperandType.InlineR:
                        OperandSize = 8;
                        break;

                    default:
                        throw new InvalidOperationException(string.Format("An unknown OperandType \"{0}\" is found.", opCode.OperandType));
                }

                TotalSize = OpCodeSize + OperandSize;
            }

        #endregion


        #region Properties

            /// <summary>
            /// The OpCode.
            /// If the OpCode size is 1, the second byte is ignored.
            /// </summary>
            public byte[] OpCode { get; private set; }

            /// <summary>
            /// The OpCode size in byte.
            /// </summary>
            public int OpCodeSize { get; private set; }

            /// <summary>
            /// The Operand size of the OpCode in byte.
            /// </summary>
            public int OperandSize { get; private set; }

            /// <summary>
            /// The OpCode size including all related data in byte.
            /// </summary>
            public int TotalSize { get; private set; }

        #endregion
        }

        /// <summary>
        /// The readonly OpCode info array.
        /// This field is initialized in the InitializeOpCodeInfos method.
        /// </summary>
        private static OpCodeInfo[] OpCodeInfos;

        /// <summary>
        /// Initializes the OpCodeInfos field.
        /// This method must be called in the static constructor.
        /// </summary>
        private static void InitializeOpCodeInfos()
        {
            var opCodes = from fieldInfo in typeof(System.Reflection.Emit.OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static)
                          where fieldInfo.FieldType == typeof(System.Reflection.Emit.OpCode)
                          select (System.Reflection.Emit.OpCode)fieldInfo.GetValue(null);

            OpCodeInfos = opCodes.Select(p => new OpCodeInfo(p)).ToArray();
        }

        /// <summary>
        /// Returns the total OpCode size at the startIndex in the ilBytes.
        /// This size includes all related data size.
        /// </summary>
        /// <param name="ilBytes">The IL byte array.</param>
        /// <param name="startIndex">The start index.</param>
        /// <returns>The OpCode size including all related data in byte.</returns>
        private static int GetOpCodeTotalSize(byte[] ilBytes, int startIndex)
        {
            Debug.Assert(ilBytes != null);
            Debug.Assert(startIndex >= 0 && startIndex < ilBytes.Length);

            byte firstByte = ilBytes[startIndex];

            // If it is a one byte opcode.
            if (firstByte < 0xFE)
                return OpCodeInfos.First(p => p.OpCode[0] == firstByte).TotalSize;

            return OpCodeInfos.First
            (
                p => p.OpCode[0] == firstByte && p.OpCode[1] == ilBytes[startIndex + 1]
            )
            .TotalSize;
        }

        #endregion
#endif

        #region Property Name Cache Related

        #region PropertyNameCache

        /// <summary>
        /// Represents a property name cache for a property getter metadata token.
        /// </summary>
        private class PropertyNameCache
        {
            #region UnsetValue

            /// <summary>
            /// Represents that the property name is not set yet.
            /// </summary>
            public static string UnsetValue = null;

            #endregion


            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="metadataToken">The property getter metadata token.</param>
            /// <param name="propertyName">The property name.</param>
            public PropertyNameCache(int metadataToken, string propertyName)
            {
                Debug.Assert(string.IsNullOrWhiteSpace(propertyName) == false);

                MetadataToken = metadataToken;
                PropertyName = propertyName;
            }

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="metadataToken">The property getter metadata token.</param>
            public PropertyNameCache(int metadataToken)
            {
                MetadataToken = metadataToken;
                PropertyName = UnsetValue;
            }

            #endregion

            #region Properties

            /// <summary>
            /// The property getter metadata token.
            /// </summary>
            public int MetadataToken { get; private set; }

            /// <summary>
            /// The property name.
            /// If it is the UnsetValue, this means that this property is not set yet.
            /// </summary>
            public string PropertyName { get; set; }

            #endregion
        }

        #endregion


        PropertyNameCache[] _propertyNameCaches;
        int _propertyNameCacheCount = 0;

        /// <summary>
        /// Finds a property name cache associated with the specified property getter method metadata token.
        /// If it does not exist, a new added property name cache is returned with the UnsetValue property name.
        /// </summary>
        /// <param name="metadataToken">The property getter method metadata token.</param>
        /// <returns>The property name cache if it exists; otherwise null.</returns>
        private PropertyNameCache GetFromCache(int metadataToken)
        {
            // Starts binary search...
            int insertIndex = -1;
            if (_propertyNameCacheCount != 0)
            {
                int firstIndex = 0;
                int lastIndex = _propertyNameCacheCount - 1;

                while (true)
                {
                    // Gets the middle item and index.
                    int middleIndex = (firstIndex + lastIndex) / 2;
                    PropertyNameCache middleItem = _propertyNameCaches[middleIndex];

                    // Compares the metadata token.
                    int compareResult = middleItem.MetadataToken - metadataToken;

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

            // Creates a new property name cache instance.
            PropertyNameCache newItem = new PropertyNameCache(metadataToken);

            // Initializes the property name cache array.
            if (_propertyNameCaches == null)
                _propertyNameCaches = new PropertyNameCache[2];

            // If the array is full, expands the array.
            if (_propertyNameCacheCount == _propertyNameCaches.Length)
            {
                // Allocates a new array.
                PropertyNameCache[] newArray = new PropertyNameCache[_propertyNameCacheCount * 2];

                // Copies all item before the insertion position.
                Array.Copy
                (
                    sourceArray: _propertyNameCaches,
                    destinationArray: newArray,
                    length: insertIndex
                );

                // Saves the new item.
                newArray[insertIndex] = newItem;

                // Copies all item after the insertion position.
                Array.Copy
                (
                    sourceArray: _propertyNameCaches,
                    sourceIndex: insertIndex,
                    destinationArray: newArray,
                    destinationIndex: insertIndex + 1,
                    length: _propertyNameCacheCount - insertIndex
                );

                // Resets the property array.
                _propertyNameCaches = newArray;
            }
            else
            {
                // Shifts all items to insert the new item into the insertion position.
                Array.Copy
                (
                    sourceArray: _propertyNameCaches,
                    sourceIndex: insertIndex,
                    destinationArray: _propertyNameCaches,
                    destinationIndex: insertIndex + 1,
                    length: _propertyNameCacheCount - insertIndex
                );

                // Saves the new item.
                _propertyNameCaches[insertIndex] = newItem;
            }

            // Increases the count.
            _propertyNameCacheCount++;

            return newItem;
        }

        #endregion

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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13, Func<T14> propertyExpression14, Func<T15> propertyExpression15,
                Func<T16> propertyExpression16, Func<T17> propertyExpression17, Func<T18> propertyExpression18,
                Func<T19> propertyExpression19, Func<T20> propertyExpression20)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13, Func<T14> propertyExpression14, Func<T15> propertyExpression15,
                Func<T16> propertyExpression16, Func<T17> propertyExpression17, Func<T18> propertyExpression18,
                Func<T19> propertyExpression19)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13, Func<T14> propertyExpression14, Func<T15> propertyExpression15,
                Func<T16> propertyExpression16, Func<T17> propertyExpression17, Func<T18> propertyExpression18)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13, Func<T14> propertyExpression14, Func<T15> propertyExpression15,
                Func<T16> propertyExpression16, Func<T17> propertyExpression17)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13, Func<T14> propertyExpression14, Func<T15> propertyExpression15,
                Func<T16> propertyExpression16)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13, Func<T14> propertyExpression14, Func<T15> propertyExpression15)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13, Func<T14> propertyExpression14)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12,
                Func<T13> propertyExpression13)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
                Func<T> propertyExpression, Func<T2> propertyExpression2, Func<T3> propertyExpression3,
                Func<T4> propertyExpression4, Func<T5> propertyExpression5, Func<T6> propertyExpression6,
                Func<T7> propertyExpression7, Func<T8> propertyExpression8, Func<T9> propertyExpression9,
                Func<T10> propertyExpression10, Func<T11> propertyExpression11, Func<T12> propertyExpression12)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T> propertyExpression,
                Func<T2> propertyExpression2, Func<T3> propertyExpression3, Func<T4> propertyExpression4,
                Func<T5> propertyExpression5, Func<T6> propertyExpression6, Func<T7> propertyExpression7,
                Func<T8> propertyExpression8, Func<T9> propertyExpression9, Func<T10> propertyExpression10,
                Func<T11> propertyExpression11)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T> propertyExpression,
                Func<T2> propertyExpression2, Func<T3> propertyExpression3, Func<T4> propertyExpression4,
                Func<T5> propertyExpression5, Func<T6> propertyExpression6, Func<T7> propertyExpression7,
                Func<T8> propertyExpression8, Func<T9> propertyExpression9, Func<T10> propertyExpression10)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T> propertyExpression,
                Func<T2> propertyExpression2, Func<T3> propertyExpression3, Func<T4> propertyExpression4,
                Func<T5> propertyExpression5, Func<T6> propertyExpression6, Func<T7> propertyExpression7,
                Func<T8> propertyExpression8, Func<T9> propertyExpression9)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8>(Func<T> propertyExpression,
                Func<T2> propertyExpression2, Func<T3> propertyExpression3, Func<T4> propertyExpression4,
                Func<T5> propertyExpression5, Func<T6> propertyExpression6, Func<T7> propertyExpression7,
                Func<T8> propertyExpression8)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7>(Func<T> propertyExpression,
                Func<T2> propertyExpression2, Func<T3> propertyExpression3, Func<T4> propertyExpression4,
                Func<T5> propertyExpression5, Func<T6> propertyExpression6, Func<T7> propertyExpression7)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6>(Func<T> propertyExpression,
                Func<T2> propertyExpression2, Func<T3> propertyExpression3, Func<T4> propertyExpression4,
                Func<T5> propertyExpression5, Func<T6> propertyExpression6)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5>(Func<T> propertyExpression,
                Func<T2> propertyExpression2, Func<T3> propertyExpression3, Func<T4> propertyExpression4,
                Func<T5> propertyExpression5)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4>(Func<T> propertyExpression, Func<T2> propertyExpression2,
                Func<T3> propertyExpression3, Func<T4> propertyExpression4)
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3>(Func<T> propertyExpression, Func<T2> propertyExpression2,
                Func<T3> propertyExpression3)
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
        protected IEnumerable<string> ToPropertyName<T, T2>(Func<T> propertyExpression, Func<T2> propertyExpression2)
        {
            yield return ToPropertyName(propertyExpression);
            yield return ToPropertyName(propertyExpression2);
        }

        /// <summary>
        /// Returns the property name extracted from the lambda expression that returns the property.
        /// </summary>
        /// <typeparam name="T">The type of the property returned from the lambda expression.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <returns>The property name extracted.</returns>
        protected string ToPropertyName<T>(Func<T> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");

#if !DEBUG
            // Gets the metadata token of the property getter staring after 0x0228.
            int metadataToken = BitConverter.ToInt32(propertyExpression.Method.GetMethodBody().GetILAsByteArray(), 2);
#else
            // Gets the CIL byte array.
            byte[] ilBytes = propertyExpression.Method.GetMethodBody().GetILAsByteArray();

            // Finds the Call or Callvirt opcode index in the CIL byte array.
            int callOpcodeIndex = -1;
            for (int i = 0; i < ilBytes.Length; i++)
            {
                switch (ilBytes[i])
                {
                    case 0x28: // call
                    case 0x6F: // callvirt
                        callOpcodeIndex = i;
                        break;

                    default:
                        // Skips the current OpCode.
                        i += (GetOpCodeTotalSize(ilBytes, i) - 1);
                        break;
                }

                if (callOpcodeIndex != -1)
                    break;
            }

            // If there is no opocde
            if (callOpcodeIndex == -1)
                throw new InvalidOperationException("There is no Call or Callvirt opcode. You must use a simple lambda expression that returns a property such as \"() => Property\".");

            // Gets the metadata token of the property getter.
            int metadataToken = BitConverter.ToInt32(ilBytes, callOpcodeIndex + 1);
#endif

            // Gets the property name cache.
            PropertyNameCache propertyNameCache = GetFromCache(metadataToken);

            // If there is a property name
            if (propertyNameCache.PropertyName != PropertyNameCache.UnsetValue)
                return propertyNameCache.PropertyName;

            // Gets the property getter.
            MethodBase propertyGetter = propertyExpression.Method.Module.ResolveMethod(metadataToken);

            // If it is not a property getter.
            if (propertyGetter.IsSpecialName == false)
                throw new InvalidOperationException("Invalid lambda expression. You must use a simple lambda expression that returns a property such as \"() => Property\".");

            // Sets the property name
            propertyNameCache.PropertyName = propertyGetter.Name.Substring("get_".Length);

            // Returns the property name.
            return propertyNameCache.PropertyName;
        }
#else

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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19, T20>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18, T19>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17, T18>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, T17>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Expression<Func<T>> propertyExpression,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Expression<Func<T>> propertyExpression,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8, T9>(Expression<Func<T>> propertyExpression,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7, T8>(Expression<Func<T>> propertyExpression,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6, T7>(Expression<Func<T>> propertyExpression,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5, T6>(Expression<Func<T>> propertyExpression,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4, T5>(Expression<Func<T>> propertyExpression,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3, T4>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
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
        protected IEnumerable<string> ToPropertyName<T, T2, T3>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2,
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
        protected IEnumerable<string> ToPropertyName<T, T2>(Expression<Func<T>> propertyExpression, Expression<Func<T2>> propertyExpression2)
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
        protected string ToPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");

            var memberExpression = propertyExpression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("The Body of the propertyExpression must be a member access expression.");

            return memberExpression.Member.Name;
        }

#endif
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
                _propertyValues = new PropertyValue[2];

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

            // Gets the property value
            PropertyValue propertyValue = GetFromStorage(propertyName);

            // If the property value is not set, initializes it.
            if (propertyValue.Value == PropertyValue.UnsetValue)
                propertyValue.Value = initializer();

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
#if !NICENIS_RT
        protected T GetProperty<T>(Func<T> propertyExpression, Func<T> initializer)
#else
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression, Func<T> initializer)
#endif
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
#if !NICENIS_RT
        protected T GetProperty<T>(Func<T> propertyExpression)
#else
        protected T GetProperty<T>(Expression<Func<T>> propertyExpression)
#endif
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected virtual bool SetPropertyOnly<T>(string propertyName, T value, Action onChanged)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

            // Gets the property value.
            PropertyValue propertyValue = GetFromStorage(propertyName);

            // If the property value is not set, initializes it.
            if (propertyValue.Value == PropertyValue.UnsetValue)
                propertyValue.Value = default(T);

            // If the values are equal
            if (object.Equals(propertyValue.Value, value))
                return false;

            // Sets the property value.
            propertyValue.Value = value;

            // Calls the changed callback.
            if (onChanged != null)
                onChanged();

            return true;
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
            return SetPropertyOnly(propertyName, value, onChanged: null);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetPropertyOnly<T>(Func<T> propertyExpression, T value, Action onChanged)
#else
        protected bool SetPropertyOnly<T>(Expression<Func<T>> propertyExpression, T value, Action onChanged)
#endif
        {
            return SetPropertyOnly(ToPropertyName(propertyExpression), value, onChanged);
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
#if !NICENIS_RT
        protected bool SetPropertyOnly<T>(Func<T> propertyExpression, T value)
#else
        protected bool SetPropertyOnly<T>(Expression<Func<T>> propertyExpression, T value)
#endif
        {
            return SetPropertyOnly(ToPropertyName(propertyExpression), value, onChanged: null);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, T value, Action onChanged, IEnumerable<string> affectedPropertyNames)
        {
            if (affectedPropertyNames == null)
                throw new ArgumentNullException("affectedPropertyNames");

            foreach (string affectedPropertyName in affectedPropertyNames)
                if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                    throw new ArgumentException("The parameter affectedPropertyNames can not contain a string that is null or a whitespace string except an empty string.", "affectedPropertyNames");

            // If the property is changed
            if (SetProperty(propertyName, value, onChanged))
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
        protected bool SetProperty<T>(string propertyName, T value, IEnumerable<string> affectedPropertyNames)
        {
            return SetProperty(propertyName, value, onChanged: null, affectedPropertyNames: affectedPropertyNames);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, T value, Action onChanged, params string[] affectedPropertyNames)
        {
            return SetProperty(propertyName, value, onChanged, (IEnumerable<string>)affectedPropertyNames);
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
            return SetProperty(propertyName, value, onChanged: null, affectedPropertyNames: (IEnumerable<string>)affectedPropertyNames);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, T value, Action onChanged, string affectedPropertyName)
        {
            if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                throw new ArgumentException("The parameter affectedPropertyName can not be null or a whitespace string except an empty string.", "affectedPropertyName");

            // If the property is changed
            if (SetProperty(propertyName, value, onChanged))
            {
                // Raises a PropertyChanged event for the affected property name.
                OnPropertyChanged(affectedPropertyName);
                return true;
            }

            return false;
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
            return SetProperty(propertyName, value, onChanged: null, affectedPropertyName: affectedPropertyName);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, T value, Action onChanged)
        {
            // If the property is changed
            if (SetPropertyOnly(propertyName, value, onChanged))
            {
                // Raises a PropertyChanged event.
                OnPropertyChanged(propertyName);
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
        protected bool SetProperty<T>(string propertyName, T value)
        {
            return SetProperty(propertyName, value, onChanged: null);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value, Action onChanged, IEnumerable<string> affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, Action onChanged, IEnumerable<string> affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged, affectedPropertyNames);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value, IEnumerable<string> affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, IEnumerable<string> affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged: null, affectedPropertyNames: affectedPropertyNames);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value, Action onChanged, params string[] affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, Action onChanged, params string[] affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged, (IEnumerable<string>)affectedPropertyNames);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value, params string[] affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, params string[] affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged: null, affectedPropertyNames: (IEnumerable<string>)affectedPropertyNames);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value, Action onChanged, string affectedPropertyName)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, Action onChanged, string affectedPropertyName)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged, affectedPropertyName);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value, string affectedPropertyName)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, string affectedPropertyName)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged: null, affectedPropertyName: affectedPropertyName);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value, Action onChanged)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value, Action onChanged)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, T value)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, T value)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), value, onChanged: null);
        }

        #endregion

#if !NICENIS_4C

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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetCallerPropertyOnly<T>(T value, Action onChanged, [CallerMemberName] string propertyName = "")
        {
            return SetPropertyOnly(propertyName, value, onChanged);
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
            return SetPropertyOnly(propertyName, value, onChanged: null);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(T value, Action onChanged, IEnumerable<string> affectedPropertyNames, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, value, onChanged, affectedPropertyNames);
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
            return SetProperty(propertyName, value, onChanged: null, affectedPropertyNames: affectedPropertyNames);
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
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(T value, Action onChanged, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, value, onChanged);
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
            return SetProperty(propertyName, value, onChanged: null);
        }

        #endregion

#endif

        #region SetProperty with Local Storage Related

        /// <summary>
        /// Sets a value to the specified storage.
        /// This method does not raise a PropertyChanged event.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected virtual bool SetPropertyOnly<T>(ref T storage, T value, Action onChanged)
        {
            // If the values are equal
            if (object.Equals(storage, value))
                return false;

            // Sets the property value.
            storage = value;

            // Calls the changed callback.
            if (onChanged != null)
                onChanged();

            return true;
        }

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
            return SetPropertyOnly(ref storage, value, onChanged: null);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, Action onChanged, IEnumerable<string> affectedPropertyNames)
        {
            if (affectedPropertyNames == null)
                throw new ArgumentNullException("affectedPropertyNames");

            foreach (string affectedPropertyName in affectedPropertyNames)
                if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                    throw new ArgumentException("The parameter affectedPropertyNames can not contain a string that is null or a whitespace string except an empty string.", "affectedPropertyNames");

            // If the property is changed
            if (SetProperty(propertyName, ref storage, value, onChanged))
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
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
        {
            return SetProperty(propertyName, ref storage, value, onChanged: null, affectedPropertyNames: affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, Action onChanged, params string[] affectedPropertyNames)
        {
            return SetProperty(propertyName, ref storage, value, onChanged, (IEnumerable<string>)affectedPropertyNames);
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
            return SetProperty(propertyName, ref storage, value, onChanged: null, affectedPropertyNames: (IEnumerable<string>)affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name and the affected property name.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, Action onChanged, string affectedPropertyName)
        {
            if (affectedPropertyName != AllPropertyName && string.IsNullOrWhiteSpace(affectedPropertyName))
                throw new ArgumentException("The parameter affectedPropertyName can not be null or a whitespace string except an empty string.", "affectedPropertyName");

            // If the property is changed
            if (SetProperty(propertyName, ref storage, value, onChanged))
            {
                // Raises a PropertyChanged event for the affected property name.
                OnPropertyChanged(affectedPropertyName);
                return true;
            }

            return false;
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
            return SetProperty(propertyName, ref storage, value, onChanged: null, affectedPropertyName: affectedPropertyName);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, a PropertyChanged event is raised for the property name.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyName">The property name.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetProperty<T>(string propertyName, ref T storage, T value, Action onChanged)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentException("The parameter propertyName can not be null or a whitespace string.", "propertyName");

            // If the property is changed
            if (SetPropertyOnly(ref storage, value, onChanged))
            {
                // Raises a PropertyChanged event.
                OnPropertyChanged(propertyName);
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
        protected bool SetProperty<T>(string propertyName, ref T storage, T value)
        {
            return SetProperty(propertyName, ref storage, value, onChanged: null);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name extracted from the property expression and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value, Action onChanged, IEnumerable<string> affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, Action onChanged, IEnumerable<string> affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged, affectedPropertyNames);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged: null, affectedPropertyNames: affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name extracted from the property expression and the affected property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value, Action onChanged, params string[] affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, Action onChanged, params string[] affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged, (IEnumerable<string>)affectedPropertyNames);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value, params string[] affectedPropertyNames)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, params string[] affectedPropertyNames)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged: null, affectedPropertyNames: (IEnumerable<string>)affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name extracted from the property expression and the affected property name.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyName">The affected property name.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value, Action onChanged, string affectedPropertyName)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, Action onChanged, string affectedPropertyName)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged, affectedPropertyName);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value, string affectedPropertyName)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, string affectedPropertyName)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged: null, affectedPropertyName: affectedPropertyName);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, a PropertyChanged event is raised for the property name extracted from the property expression.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="propertyExpression">The lambda expression that returns the property.</param>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value, Action onChanged)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value, Action onChanged)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged);
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
#if !NICENIS_RT
        protected bool SetProperty<T>(Func<T> propertyExpression, ref T storage, T value)
#else
        protected bool SetProperty<T>(Expression<Func<T>> propertyExpression, ref T storage, T value)
#endif
        {
            return SetProperty(ToPropertyName(propertyExpression), ref storage, value, onChanged: null);
        }

        #endregion

#if !NICENIS_4C

        #region SetCallerProperty with Local Storage Related

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, PropertyChanged events are raised for the property name obtained by the CallerMemberName attribute and the affected property names.
        /// This method must be used in a property setter.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="affectedPropertyNames">The affected property names.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(ref T storage, T value, Action onChanged, IEnumerable<string> affectedPropertyNames, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, ref storage, value, onChanged, affectedPropertyNames);
        }

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
            return SetProperty(propertyName, ref storage, value, onChanged: null, affectedPropertyNames: affectedPropertyNames);
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed, a PropertyChanged event is raised for the property name obtained by the CallerMemberName attribute.
        /// This method must be used in a property setter.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="propertyName">The property name that is automatically set by the compiler. DO NOT SPECIFY THIS PARAMETER.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected bool SetCallerProperty<T>(ref T storage, T value, Action onChanged, [CallerMemberName] string propertyName = "")
        {
            return SetProperty(propertyName, ref storage, value, onChanged);
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
            return SetProperty(propertyName, ref storage, value, onChanged: null);
        }

        #endregion

#endif

        #region INotifyPropertyChanged Implementation Related

        /// <summary>
        /// Occurs when a property value is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


#if !NICENIS_4C
        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
#else
        /// <summary>
        /// Raises a PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
#endif
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


    #region WatchableObject

    /// <summary>
    /// Provides a base implementation for the INotifyPropertyChanged interface.
    /// This class is deprecated. Instead, use the PropertyObservable class.
    /// </summary>
    [Obsolete("Instead, use the PropertyObservable.")]
    public class WatchableObject : PropertyObservable
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WatchableObject() { }

        #endregion
    }

    #endregion
}
