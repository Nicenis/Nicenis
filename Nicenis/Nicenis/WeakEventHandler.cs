/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.09.18
 * Version  $Id$
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
    #region WeakEventHandlerBase

    /// <summary>
    /// Provides base implementation for WeakEventHandler.
    /// </summary>
    /// <remarks>
    /// Internal Use Only.
    /// </remarks>
    public abstract class WeakEventHandlerBase
    {
        #region WeakEventHandlerInfo

        /// <summary>
        /// Represents event handler information that is weak referenced.
        /// </summary>
        class WeakEventHandlerInfo
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
            public WeakReference WeakTarget { get; private set; }

            /// <summary>
            /// The event handler method info.
            /// </summary>
            public MethodInfo MethodInfo { get; private set; }

            #endregion
        }

        #endregion


        IEnumerable<WeakEventHandlerInfo> _weakHandlerInfos = Enumerable.Empty<WeakEventHandlerInfo>();


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEventHandlerBase() { }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds a weak event handler info.
        /// </summary>
        /// <remarks>
        /// If you add a static method or a lambda expression that does not access container class's instance member,
        /// it is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="target">The target instance if the event handler is a instance method; otherwise null.</param>
        /// <param name="methodInfo">The event handler method info.</param>
        protected void InternalAdd(object target, MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            var weakHandlerInfos = _weakHandlerInfos;
            var newWeakHandlerInfos = new WeakEventHandlerInfo[weakHandlerInfos.Count() + 1];

            // Copies existing event handler infos.
            int index = 0;
            foreach (var weakHandlerInfo in weakHandlerInfos)
                newWeakHandlerInfos[index++] = weakHandlerInfo;

            // Copies the new event handler info.
            newWeakHandlerInfos[index] = new WeakEventHandlerInfo(target, methodInfo);

            // Updates the weak event handler info collection.
            _weakHandlerInfos = newWeakHandlerInfos;
        }

        /// <summary>
        /// Removes a weak event handler info.
        /// </summary>
        /// <param name="target">The target instance if the event handler is a instance method; otherwise null.</param>
        /// <param name="methodInfo">The event handler method info.</param>
        protected void InternalRemove(object target, MethodInfo methodInfo)
        {
            if (methodInfo == null)
                throw new ArgumentNullException("methodInfo");

            // Finds the weak event handler info to delete.
            var weakHandlerInfos = _weakHandlerInfos;
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
                return;

            var newWeakHandlerInfos = new WeakEventHandlerInfo[weakHandlerInfos.Count() - 1];
            int index = 0;
            foreach (var weakHandlerInfo in weakHandlerInfos)
            {
                // Skips the weak event handler info to delete.
                if (weakHandlerInfo == weakHandlerInfoToDelete)
                    continue;

                newWeakHandlerInfos[index++] = weakHandlerInfo;
            }

            // Updates the weak event handler info collection.
            _weakHandlerInfos = newWeakHandlerInfos;
        }

        /// <summary>
        /// Raises an event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments.</param>
        protected void InternalRaise(object sender, object args)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (args == null)
                throw new ArgumentNullException("args");

            var weakHandlerInfos = _weakHandlerInfos;
            List<WeakEventHandlerInfo> weakHandlerInfosToDelete = null; ;

            // For each weak handler info...
            foreach (var weakHandlerInfo in weakHandlerInfos)
            {
                // If the event handler is a static method...
                if (weakHandlerInfo.MethodInfo.IsStatic)
                {
                    // Calls the event handler.
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
                    weakHandlerInfo.MethodInfo.Invoke(target, new object[] { sender, args });
                }
            }

            // If no event handler info is garbage collected..
            if (weakHandlerInfosToDelete == null)
                return;

            // If all event handlers are garbage collected..
            int weakHandlerInfoCount = weakHandlerInfos.Count();
            if (weakHandlerInfosToDelete.Count == weakHandlerInfoCount)
            {
                _weakHandlerInfos = Enumerable.Empty<WeakEventHandlerInfo>();
                return;
            }

            var newWeakHandlerInfos = new WeakEventHandlerInfo[weakHandlerInfoCount - weakHandlerInfosToDelete.Count];
            int index = 0;
            foreach (var weakHandlerInfo in weakHandlerInfos)
            {
                // Skips the event handler info garbage collected
                if (weakHandlerInfosToDelete.Contains(weakHandlerInfo))
                    continue;

                newWeakHandlerInfos[index++] = weakHandlerInfo;
            }

            // Updates the weak event handler info collection.
            _weakHandlerInfos = newWeakHandlerInfos;
        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Provides storage for event handlers that garbage collector can collect.
    /// </summary>
    public class WeakEventHandler : WeakEventHandlerBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEventHandler() { }

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
                throw new ArgumentNullException("value");

#if !NICENIS_RT
            InternalAdd(value.Target, value.Method);
#else
            InternalAdd(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Removes the event handler.
        /// </summary>
        /// <param name="value">The event handler to remove.</param>
        public void Remove(EventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

#if !NICENIS_RT
            InternalRemove(value.Target, value.Method);
#else
            InternalRemove(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Raises an event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        public void Raise(object sender)
        {
            InternalRaise(sender, EventArgs.Empty);
        }

        #endregion
    }

    /// <summary>
    /// Provides storage for event handlers that garbage collector can collect.
    /// </summary>
    /// <typeparam name="TEventArgs">The event argument type.</typeparam>
    public class WeakEventHandler<TEventArgs> : WeakEventHandlerBase
#if !NICENIS_4C
        where TEventArgs : class
#else
        where TEventArgs : EventArgs
#endif
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEventHandler() { }

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
                throw new ArgumentNullException("value");

#if !NICENIS_RT
            InternalAdd(value.Target, value.Method);
#else
            InternalAdd(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Removes the event handler.
        /// </summary>
        /// <param name="value">The event handler to remove.</param>
        public void Remove(EventHandler<TEventArgs> value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

#if !NICENIS_RT
            InternalRemove(value.Target, value.Method);
#else
            InternalRemove(value.Target, value.GetMethodInfo());
#endif
        }

        /// <summary>
        /// Raises an event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        public void Raise(object sender, TEventArgs e)
        {
            InternalRaise(sender, e);
        }

        #endregion
    }
}
