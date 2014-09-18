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
using System.Linq;

namespace Nicenis
{
    #region WeakEventImplementation

    /// <summary>
    /// Provides most implementation for WeakEvent.
    /// </summary>
    /// <typeparam name="TEventHandler">The event handler type.</typeparam>
    internal class WeakEventImplementation<TEventHandler> where TEventHandler : class
    {
        IEnumerable<WeakReference> _weakHandlers = Enumerable.Empty<WeakReference>();


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEventImplementation() { }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <remarks>
        /// If you add a lambda expression that does not access container class's instance member,
        /// the lambda expression is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="value">The event handler to add.</param>
        public void Add(TEventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            var weakHandlers = _weakHandlers;
            var newWeakHandlers = new WeakReference[weakHandlers.Count() + 1];

            // Copies existing event handlers.
            int index = 0;
            foreach (var weakHandler in weakHandlers)
                newWeakHandlers[index++] = weakHandler;

            // Copies the new event handler.
            newWeakHandlers[index] = new WeakReference(value);

            // Updatea the weak event handler collection.
            _weakHandlers = newWeakHandlers;
        }

        /// <summary>
        /// Removes the event handler.
        /// </summary>
        /// <param name="value">The event handler to remove.</param>
        public void Remove(TEventHandler value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            // Finds the weak event handler to delete.
            var weakHandlers = _weakHandlers;
            var weakHandlerToDelete = weakHandlers.FirstOrDefault
            (
                weakHandler =>
                {
                    TEventHandler handler = weakHandler.Target as TEventHandler;
                    if (handler == null)
                        return false;

                    return handler.Equals(value);
                }
            );

            // If there is no weak event handler to delete...
            if (weakHandlerToDelete == null)
                return;

            var newWeakHandlers = new WeakReference[weakHandlers.Count() - 1];
            int index = 0;
            foreach (var weakHandler in weakHandlers)
            {
                // Skips the weak event handler to delete.
                if (weakHandler == weakHandlerToDelete)
                    continue;

                newWeakHandlers[index++] = weakHandler;
            }

            // Updatea the weak event handler collection.
            _weakHandlers = newWeakHandlers;
        }

        /// <summary>
        /// Raises the event.
        /// </summary>
        /// <param name="invoker">The action that calls the event handler.</param>
        public void Raise(Action<TEventHandler> invoker)
        {
            if (invoker == null)
                throw new ArgumentNullException("invoker");

            var weakHandlers = _weakHandlers;
            List<WeakReference> weakHandlersToDelete = null; ;

            // For each weak handler...
            foreach (var weakHandler in weakHandlers)
            {
                TEventHandler handler = weakHandler.Target as TEventHandler;
                if (handler == null)
                {
                    if (weakHandlersToDelete == null)
                        weakHandlersToDelete = new List<WeakReference>();

                    // Collects the garbage collected event handler.
                    weakHandlersToDelete.Add(weakHandler);
                    continue;
                }

                // Invokes the event handler.
                invoker(handler);
            }

            // If there is no event handler garbage collected
            if (weakHandlersToDelete == null)
                return;

            // If all event handlers are garbage collected
            int weakHandlerCount = weakHandlers.Count();
            if (weakHandlersToDelete.Count == weakHandlerCount)
            {
                _weakHandlers = Enumerable.Empty<WeakReference>();
                return;
            }

            var newWeakHandlers = new WeakReference[weakHandlerCount - weakHandlersToDelete.Count];
            int index = 0;
            foreach (var weakHandler in weakHandlers)
            {
                // Skips the event handler garbage collected
                if (weakHandlersToDelete.Contains(weakHandler))
                    continue;

                newWeakHandlers[index++] = weakHandler;
            }

            // Updatea the weak event handler collection.
            _weakHandlers = newWeakHandlers;
        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Provides storage for event handlers that garbage collector can collect.
    /// </summary>
    public class WeakEvent
    {
        WeakEventImplementation<EventHandler> _implementation = new WeakEventImplementation<EventHandler>();


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEvent() { }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <remarks>
        /// If you add a lambda expression that does not access container class's instance member,
        /// the lambda expression is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="value">The event handler to add.</param>
        public void Add(EventHandler value)
        {
            _implementation.Add(value);
        }

        /// <summary>
        /// Removes the event handler.
        /// </summary>
        /// <param name="value">The event handler to remove.</param>
        public void Remove(EventHandler value)
        {
            _implementation.Remove(value);
        }

        /// <summary>
        /// Raises an event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        public void Raise(object sender)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            _implementation.Raise(handler => handler(sender, EventArgs.Empty));
        }

        #endregion
    }

    /// <summary>
    /// Provides storage for event handlers that garbage collector can collect.
    /// </summary>
    /// <typeparam name="TEventArgs">The event argument type.</typeparam>
    public class WeakEvent<TEventArgs>
#if !NICENIS_4C
        where TEventArgs : class
#else
        where TEventArgs : EventArgs
#endif
    {
        WeakEventImplementation<EventHandler<TEventArgs>> _implementation = new WeakEventImplementation<EventHandler<TEventArgs>>();


        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public WeakEvent() { }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds an event handler.
        /// </summary>
        /// <remarks>
        /// If you add a lambda expression that does not access container class's instance member,
        /// the lambda expression is not automatically removed even if the container class instance is garbage collected.
        /// </remarks>
        /// <param name="value">The event handler to add.</param>
        public void Add(EventHandler<TEventArgs> value)
        {
            _implementation.Add(value);
        }

        /// <summary>
        /// Removes the event handler.
        /// </summary>
        /// <param name="value">The event handler to remove.</param>
        public void Remove(EventHandler<TEventArgs> value)
        {
            _implementation.Remove(value);
        }

        /// <summary>
        /// Raises an event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        public void Raise(object sender, TEventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException("sender");

            if (e == null)
                throw new ArgumentNullException("e");

            _implementation.Raise(handler => handler(sender, e));
        }

        #endregion
    }
}
