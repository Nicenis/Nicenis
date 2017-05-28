/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.09.18
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Nicenis
{
    #region WeakEventHandlerInfo Related

    /// <summary>
    /// Represents event handler information that is weak referenced.
    /// </summary>
    internal class WeakEventHandlerInfo
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instancel.
        /// </summary>
        /// <param name="target">The target instance if the event handler is a instance method; otherwise null.</param>
        /// <param name="methodInfo">The event handler method info.</param>
        public WeakEventHandlerInfo(object target, MethodInfo methodInfo)
        {
            Debug.Assert(methodInfo != null);

            WeakTarget = new WeakReference(target);
            MethodInfo = methodInfo;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// The target instance that is weak referenced.
        /// If the event handler is a static method, the target instance is always null.
        /// </summary>
        public WeakReference WeakTarget { get; }

        /// <summary>
        /// The event handler method info.
        /// </summary>
        public MethodInfo MethodInfo { get; }

        #endregion


        #region Equals Related

        public override int GetHashCode()
        {
            return WeakTarget.GetHashCode() ^ MethodInfo.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var info = obj as WeakEventHandlerInfo;

            return info != null
                && info.WeakTarget.Target == WeakTarget.Target
                && info.MethodInfo == MethodInfo;
        }

        #endregion
    }

    internal static class WeakEventHandlerInfoExtensions
    {
        /// <summary>
        /// Adds a weak event handler info.
        /// </summary>
        /// <param name="weakHandlerInfos">The target weak event handler info collection.</param>
        /// <param name="target">The target instance if the event handler is a instance method; otherwise null.</param>
        /// <param name="methodInfo">The event handler method info.</param>
        /// <returns>A new weak event handler info collection.</returns>
        public static IEnumerable<WeakEventHandlerInfo> Add(this IEnumerable<WeakEventHandlerInfo> weakHandlerInfos, object target, MethodInfo methodInfo)
        {
            if (weakHandlerInfos == null)
                throw new ArgumentNullException(nameof(weakHandlerInfos));

            if (methodInfo == null)
                throw new ArgumentNullException(nameof(methodInfo));

            var newWeakHandlerInfos = new WeakEventHandlerInfo[weakHandlerInfos.Count() + 1];

            // Copies existing event handler infos.
            int index = 0;
            foreach (var weakHandlerInfo in weakHandlerInfos)
                newWeakHandlerInfos[index++] = weakHandlerInfo;

            // Copies the new event handler info.
            newWeakHandlerInfos[index] = new WeakEventHandlerInfo(target, methodInfo);

            // Returns the weak event handler info collection.
            return newWeakHandlerInfos;
        }

        /// <summary>
        /// Adds weak event handler infos.
        /// </summary>
        /// <param name="weakHandlerInfos">The target weak event handler info collection.</param>
        /// <param name="weakHandlerInfosToAdd">The weak event handler info to add.</param>
        /// <returns>A new weak event handler info collection.</returns>
        public static IEnumerable<WeakEventHandlerInfo> Add(this IEnumerable<WeakEventHandlerInfo> weakHandlerInfos, IEnumerable<WeakEventHandlerInfo> weakHandlerInfosToAdd)
        {
            if (weakHandlerInfos == null)
                throw new ArgumentNullException(nameof(weakHandlerInfos));

            if (weakHandlerInfosToAdd == null)
                throw new ArgumentNullException(nameof(weakHandlerInfosToAdd));

            return weakHandlerInfos.Concat(weakHandlerInfosToAdd).ToArray();
        }

        /// <summary>
        /// Removes a weak event handler info.
        /// </summary>
        /// <param name="weakHandlerInfos">The target weak event handler info collection.</param>
        /// <param name="target">The target instance if the event handler is a instance method; otherwise null.</param>
        /// <param name="methodInfo">The event handler method info.</param>
        /// <returns>A new weak event handler info collection if the event handler info is removed; otherwise the target weak event handler info collection.</returns>
        public static IEnumerable<WeakEventHandlerInfo> Remove(this IEnumerable<WeakEventHandlerInfo> weakHandlerInfos, object target, MethodInfo methodInfo)
        {
            if (weakHandlerInfos == null)
                throw new ArgumentNullException(nameof(weakHandlerInfos));

            if (methodInfo == null)
                throw new ArgumentNullException(nameof(methodInfo));

            // Finds the weak event handler info to delete.
            var weakHandlerInfoToDelete = weakHandlerInfos.FirstOrDefault
            (
                weakHandlerInfo =>
                {
                    return weakHandlerInfo.WeakTarget.Target == target
                        && weakHandlerInfo.MethodInfo == methodInfo;
                }
            );

            // If there is no weak event handler info to delete...
            if (weakHandlerInfoToDelete == null)
                return weakHandlerInfos;

            var newWeakHandlerInfos = new WeakEventHandlerInfo[weakHandlerInfos.Count() - 1];
            int index = 0;
            foreach (var weakHandlerInfo in weakHandlerInfos)
            {
                // Skips the weak event handler info to delete.
                if (weakHandlerInfo == weakHandlerInfoToDelete)
                    continue;

                newWeakHandlerInfos[index++] = weakHandlerInfo;
            }

            // Returns the weak event handler info collection.
            return newWeakHandlerInfos;
        }

        /// <summary>
        /// Removes weak event handler infos.
        /// </summary>
        /// <param name="weakHandlerInfos">The target weak event handler info collection.</param>
        /// <param name="weakHandlerInfosToRemove">The weak event handler info to remove.</param>
        /// <returns>A new weak event handler info collection.</returns>
        public static IEnumerable<WeakEventHandlerInfo> Remove(this IEnumerable<WeakEventHandlerInfo> weakHandlerInfos, IEnumerable<WeakEventHandlerInfo> weakHandlerInfosToRemove)
        {
            if (weakHandlerInfos == null)
                throw new ArgumentNullException(nameof(weakHandlerInfos));

            if (weakHandlerInfosToRemove == null)
                throw new ArgumentNullException(nameof(weakHandlerInfosToRemove));

            if (weakHandlerInfos.Any() == false || weakHandlerInfosToRemove.Any() == false)
                return weakHandlerInfos;

            List<WeakEventHandlerInfo> newWeakHandlerInfos = null;
            List<WeakEventHandlerInfo> remainedWeakHandlerInfosToRemove = new List<WeakEventHandlerInfo>(weakHandlerInfosToRemove);

            foreach (WeakEventHandlerInfo weakHandlerInfo in weakHandlerInfos)
            {
                var found = remainedWeakHandlerInfosToRemove.FirstOrDefault(p => p.Equals(weakHandlerInfo));

                // If it is the event handler to remove
                if (found != null)
                {
                    // Removes the found item from the remained items collection.
                    remainedWeakHandlerInfosToRemove.Remove(found);
                    continue;
                }

                if (newWeakHandlerInfos == null)
                    newWeakHandlerInfos = new List<WeakEventHandlerInfo>();

                // Adds it to the new items collection.
                newWeakHandlerInfos.Add(weakHandlerInfo);
            }

            return newWeakHandlerInfos ?? Enumerable.Empty<WeakEventHandlerInfo>();
        }

        #region ToEventHandlerResult

        /// <summary>
        /// Provides result information for the ToEventHandler.
        /// </summary>
        public class ToEventHandlerResult
        {
            #region Constructors

            public ToEventHandlerResult(IEnumerable<WeakEventHandlerInfo> weakEventHandlerInfos, EventHandler eventHandler)
            {
                Debug.Assert(weakEventHandlerInfos != null);

                WeakEventHandlerInfos = weakEventHandlerInfos;
                EventHandler = eventHandler;
            }

            #endregion


            #region Public Properties

            /// <summary>
            /// The weak event handler infomation for alive references.
            /// This property is always not null.
            /// </summary>
            public IEnumerable<WeakEventHandlerInfo> WeakEventHandlerInfos { get; }

            /// <summary>
            /// The event handler for alive references.
            /// </summary>
            public EventHandler EventHandler { get; }

            #endregion
        }

        /// <summary>
        /// Provides result information for the ToEventHandler.
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        public class ToEventHandlerResult<TEventArgs>
#if !NICENIS_4C
        where TEventArgs : class
#else
        where TEventArgs : EventArgs
#endif
        {
            #region Constructors

            public ToEventHandlerResult(IEnumerable<WeakEventHandlerInfo> weakEventHandlerInfos, EventHandler<TEventArgs> eventHandler)
            {
                Debug.Assert(weakEventHandlerInfos != null);

                WeakEventHandlerInfos = weakEventHandlerInfos;
                EventHandler = eventHandler;
            }

            #endregion


            #region Public Properties

            /// <summary>
            /// The weak event handler infomation for alive references.
            /// This property is always not null.
            /// </summary>
            public IEnumerable<WeakEventHandlerInfo> WeakEventHandlerInfos { get; }

            /// <summary>
            /// The event handler for alive references.
            /// </summary>
            public EventHandler<TEventArgs> EventHandler { get; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Cleans up event handlers that the target objects are garbage collected.
        /// </summary>
        /// <param name="weakHandlerInfos">The target weak event handler info collection.</param>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        /// <param name="invokeHandler">If this parameter is true, alive event handlers are invoked.</param>
        /// <returns>A new weak event handler info collection if garbage collected event handler infos are removed; otherwise the target weak event handler info collection.</returns>
        public static IEnumerable<WeakEventHandlerInfo> Cleanup(this IEnumerable<WeakEventHandlerInfo> weakHandlerInfos, object sender, object args, bool invokeHandler)
        {
            if (weakHandlerInfos == null)
                throw new ArgumentNullException(nameof(weakHandlerInfos));

            List<WeakEventHandlerInfo> weakHandlerInfosToDelete = null;

            // For each weak handler info...
            foreach (var weakHandlerInfo in weakHandlerInfos)
            {
                // If the event handler is a static method...
                if (weakHandlerInfo.MethodInfo.IsStatic)
                {
                    // Calls the event handler.
                    if (invokeHandler)
                        weakHandlerInfo.MethodInfo.Invoke(null, new object[] { sender, args });
                }
                else
                {
                    // Gets the strong reference.
                    object target = weakHandlerInfo.WeakTarget.Target;

                    // If it is garbage collected..
                    if (target == null)
                    {
                        if (weakHandlerInfosToDelete == null)
                            weakHandlerInfosToDelete = new List<WeakEventHandlerInfo>();

                        // Collects the garbage collected event handler info.
                        weakHandlerInfosToDelete.Add(weakHandlerInfo);
                        continue;
                    }

                    // Calls the event handler.
                    if (invokeHandler)
                        weakHandlerInfo.MethodInfo.Invoke(target, new object[] { sender, args });
                }
            }

            // If no event handler info is garbage collected..
            if (weakHandlerInfosToDelete == null)
                return weakHandlerInfos;

            // If all event handlers are garbage collected..
            int weakHandlerInfoCount = weakHandlerInfos.Count();
            if (weakHandlerInfosToDelete.Count == weakHandlerInfoCount)
                return Enumerable.Empty<WeakEventHandlerInfo>();

            var newWeakHandlerInfos = new WeakEventHandlerInfo[weakHandlerInfoCount - weakHandlerInfosToDelete.Count];
            int index = 0;
            foreach (var weakHandlerInfo in weakHandlerInfos)
            {
                // Skips the event handler info garbage collected
                if (weakHandlerInfosToDelete.Contains(weakHandlerInfo))
                    continue;

                newWeakHandlerInfos[index++] = weakHandlerInfo;
            }

            // Returns the weak event handler info collection.
            return newWeakHandlerInfos;
        }
    }

    #endregion


    /// <summary>
    /// Provides storage for event handlers that garbage collector can collect.
    /// </summary>
    public class WeakEventHandler
    {
        IEnumerable<WeakEventHandlerInfo> _weakHandlerInfos;


        #region Constructors

        private WeakEventHandler(IEnumerable<WeakEventHandlerInfo> weakHandlerInfos)
        {
            Debug.Assert(weakHandlerInfos != null);
            _weakHandlerInfos = weakHandlerInfos;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEventHandler()
        {
            _weakHandlerInfos = Enumerable.Empty<WeakEventHandlerInfo>();
        }

        #endregion


        #region Public Operators

        /// <summary>
        /// Adds a event handler to the weak event handler.
        /// </summary>
        /// <remarks>
        /// If you add a static method or a lambda expression that does not access container class's instance member,
        /// it is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="weakEventHandler">The target weak event handler.</param>
        /// <param name="value">The event handler to add.</param>
        /// <returns>A new weak event handler.</returns>
        public static WeakEventHandler operator +(WeakEventHandler weakEventHandler, EventHandler value)
        {
            if (weakEventHandler == null)
                throw new ArgumentNullException(nameof(weakEventHandler));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            return new WeakEventHandler(weakEventHandler._weakHandlerInfos.Add(value.Target, value.Method));
#else
            return new WeakEventHandler(weakEventHandler._weakHandlerInfos.Add(value.Target, value.GetMethodInfo()));
#endif
        }

        /// <summary>
        /// Concatenate two weak event handler.
        /// </summary>
        /// <param name="left">The left weak event handler.</param>
        /// <param name="right">The right weak event handler.</param>
        /// <returns>The concatenated weak event handler.</returns>
        public static WeakEventHandler operator +(WeakEventHandler left, WeakEventHandler right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new WeakEventHandler(left._weakHandlerInfos.Add(right._weakHandlerInfos));
        }

        /// <summary>
        /// Removes a event handler to the weak event handler.
        /// </summary>
        /// <param name="weakEventHandler">The target weak event handler.</param>
        /// <param name="value">The event handler to remove.</param>
        /// <returns>A new weak event handler.</returns>
        public static WeakEventHandler operator -(WeakEventHandler weakEventHandler, EventHandler value)
        {
            if (weakEventHandler == null)
                throw new ArgumentNullException(nameof(weakEventHandler));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            return new WeakEventHandler(weakEventHandler._weakHandlerInfos.Remove(value.Target, value.Method));
#else
            return new WeakEventHandler(weakEventHandler._weakHandlerInfos.Remove(value.Target, value.GetMethodInfo()));
#endif
        }

        /// <summary>
        /// Removes the weak event handlers of right from the weak event handlers of left.
        /// </summary>
        /// <param name="left">The left weak event handler.</param>
        /// <param name="right">The right weak event handler.</param>
        /// <returns>A new weak event handler that does not contain the right weak event handler.</returns>
        public static WeakEventHandler operator -(WeakEventHandler left, WeakEventHandler right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new WeakEventHandler(left._weakHandlerInfos.Remove(right._weakHandlerInfos));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <remarks>
        /// If you add a static method or a lambda expression that does not access container class's instance member,
        /// it is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="value">The event handler to add.</param>
        public void Add(EventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            _weakHandlerInfos = _weakHandlerInfos.Add(value.Target, value.Method);
#else
            _weakHandlerInfos = _weakHandlerInfos.Add(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Adds weak event handlers of a WeakEventHandler instance.
        /// </summary>
        /// <remarks>
        /// If you add a static method or a lambda expression that does not access container class's instance member,
        /// it is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="value">The WeakEventHandler instance that contains weak event handlers.</param>
        public void Add(WeakEventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _weakHandlerInfos = _weakHandlerInfos.Add(value._weakHandlerInfos);
        }

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="value">The event handler to remove.</param>
        public void Remove(EventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            _weakHandlerInfos = _weakHandlerInfos.Remove(value.Target, value.Method);
#else
            _weakHandlerInfos = _weakHandlerInfos.Remove(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Removes weak event handlers of a WeakEventHandler instance.
        /// </summary>
        /// <param name="value">The WeakEventHandler instance that contains weak event handlers.</param>
        public void Remove(WeakEventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _weakHandlerInfos = _weakHandlerInfos.Remove(value._weakHandlerInfos);
        }

        /// <summary>
        /// Invokes event handlers.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        public void Invoke(object sender)
        {
            _weakHandlerInfos = _weakHandlerInfos.Cleanup(sender, EventArgs.Empty, invokeHandler: true);
        }

        /// <summary>
        /// Gets a cloned instance.
        /// </summary>
        public WeakEventHandler Clone()
        {
            _weakHandlerInfos = _weakHandlerInfos.Cleanup(null, EventArgs.Empty, invokeHandler: false);
            return new WeakEventHandler(_weakHandlerInfos.ToArray());
        }

        #endregion
    }

    /// <summary>
    /// Provides storage for event handlers that garbage collector can collect.
    /// </summary>
    /// <typeparam name="TEventArgs">The event argument type.</typeparam>
    public class WeakEventHandler<TEventArgs>
#if !NICENIS_4C
        where TEventArgs : class
#else
        where TEventArgs : EventArgs
#endif
    {
        IEnumerable<WeakEventHandlerInfo> _weakHandlerInfos;


        #region Constructors

        private WeakEventHandler(IEnumerable<WeakEventHandlerInfo> weakHandlerInfos)
        {
            Debug.Assert(weakHandlerInfos != null);
            _weakHandlerInfos = weakHandlerInfos;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEventHandler()
        {
            _weakHandlerInfos = Enumerable.Empty<WeakEventHandlerInfo>();
        }

        #endregion


        #region Public Operators

        /// <summary>
        /// Adds a event handler to the weak event handler.
        /// </summary>
        /// <remarks>
        /// If you add a static method or a lambda expression that does not access container class's instance member,
        /// it is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="weakEventHandler">The target weak event handler.</param>
        /// <param name="value">The event handler to add.</param>
        /// <returns>A new weak event handler.</returns>
        public static WeakEventHandler<TEventArgs> operator +(WeakEventHandler<TEventArgs> weakEventHandler, EventHandler<TEventArgs> value)
        {
            if (weakEventHandler == null)
                throw new ArgumentNullException(nameof(weakEventHandler));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            return new WeakEventHandler<TEventArgs>(weakEventHandler._weakHandlerInfos.Add(value.Target, value.Method));
#else
            return new WeakEventHandler<TEventArgs>(weakEventHandler._weakHandlerInfos.Add(value.Target, value.GetMethodInfo()));
#endif
        }

        /// <summary>
        /// Concatenate two weak event handler.
        /// </summary>
        /// <param name="left">The left weak event handler.</param>
        /// <param name="right">The right weak event handler.</param>
        /// <returns>The concatenated weak event handler.</returns>
        public static WeakEventHandler<TEventArgs> operator +(WeakEventHandler<TEventArgs> left, WeakEventHandler<TEventArgs> right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new WeakEventHandler<TEventArgs>(left._weakHandlerInfos.Add(right._weakHandlerInfos));
        }

        /// <summary>
        /// Removes a event handler to the weak event handler.
        /// </summary>
        /// <param name="weakEventHandler">The target weak event handler.</param>
        /// <param name="value">The event handler to remove.</param>
        /// <returns>A new weak event handler.</returns>
        public static WeakEventHandler<TEventArgs> operator -(WeakEventHandler<TEventArgs> weakEventHandler, EventHandler<TEventArgs> value)
        {
            if (weakEventHandler == null)
                throw new ArgumentNullException(nameof(weakEventHandler));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            return new WeakEventHandler<TEventArgs>(weakEventHandler._weakHandlerInfos.Remove(value.Target, value.Method));
#else
            return new WeakEventHandler<TEventArgs>(weakEventHandler._weakHandlerInfos.Remove(value.Target, value.GetMethodInfo()));
#endif
        }

        /// <summary>
        /// Removes the weak event handlers of right from the weak event handlers of left.
        /// </summary>
        /// <param name="left">The left weak event handler.</param>
        /// <param name="right">The right weak event handler.</param>
        /// <returns>A new weak event handler that does not contain the right weak event handler.</returns>
        public static WeakEventHandler<TEventArgs> operator -(WeakEventHandler<TEventArgs> left, WeakEventHandler<TEventArgs> right)
        {
            if (left == null)
                throw new ArgumentNullException(nameof(left));

            if (right == null)
                throw new ArgumentNullException(nameof(right));

            return new WeakEventHandler<TEventArgs>(left._weakHandlerInfos.Remove(right._weakHandlerInfos));
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <remarks>
        /// If you add a static method or a lambda expression that does not access container class's instance member,
        /// it is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="value">The event handler to add.</param>
        public void Add(EventHandler<TEventArgs> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            _weakHandlerInfos = _weakHandlerInfos.Add(value.Target, value.Method);
#else
            _weakHandlerInfos = _weakHandlerInfos.Add(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Adds weak event handlers of a WeakEventHandler instance.
        /// </summary>
        /// <remarks>
        /// If you add a static method or a lambda expression that does not access container class's instance member,
        /// it is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="value">The WeakEventHandler instance that contains weak event handlers.</param>
        public void Add(WeakEventHandler<TEventArgs> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _weakHandlerInfos = _weakHandlerInfos.Add(value._weakHandlerInfos);
        }

        /// <summary>
        /// Removes an event handler.
        /// </summary>
        /// <param name="value">The event handler to remove.</param>
        public void Remove(EventHandler<TEventArgs> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

#if !NICENIS_UWP
            _weakHandlerInfos = _weakHandlerInfos.Remove(value.Target, value.Method);
#else
            _weakHandlerInfos = _weakHandlerInfos.Remove(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Removes weak event handlers of a WeakEventHandler instance.
        /// </summary>
        /// <param name="value">The WeakEventHandler instance that contains weak event handlers.</param>
        public void Remove(WeakEventHandler<TEventArgs> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            _weakHandlerInfos = _weakHandlerInfos.Remove(value._weakHandlerInfos);
        }

        /// <summary>
        /// Invokes event handlers.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        public void Invoke(object sender, TEventArgs e)
        {
            _weakHandlerInfos = _weakHandlerInfos.Cleanup(sender, e, invokeHandler: true);
        }

        /// <summary>
        /// Gets a cloned instance.
        /// </summary>
        public WeakEventHandler<TEventArgs> Clone()
        {
            _weakHandlerInfos = _weakHandlerInfos.Cleanup(null, EventArgs.Empty, invokeHandler: false);
            return new WeakEventHandler<TEventArgs>(_weakHandlerInfos.ToArray());
        }

        #endregion
    }
}
