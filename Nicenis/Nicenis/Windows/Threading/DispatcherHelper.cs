/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.11.29
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Diagnostics;
using System;
using System.Windows.Threading;

namespace Nicenis.Windows.Threading
{
    /// <summary>
    /// Provides utility methods for Dispatcher.
    /// </summary>
    public static class DispatcherHelper
    {
        #region BeginInvoke Related

        /// <summary>
        /// Executes the specified delegate asynchronously at the specified priority on the thread the Dispatcher is associated with.
        /// </summary>
        /// <param name="dispatcher">The dispatcher to begin invoke</param>
        /// <param name="action">The Action to a method that takes parameters specified in args, which is pushed onto the Dispatcher event queue.</param>
        /// <param name="priority">The priority, relative to the other pending operations in the Dispatcher event queue, the specified method is invoked.</param>
        /// <returns>An object, which is returned immediately after BeginInvoke is called, that can be used to interact with the delegate as it is pending execution in the event queue.</returns>
        public static DispatcherOperation BeginInvoke(this Dispatcher dispatcher, Action action, DispatcherPriority priority)
        {
            Verifying.ParameterIsNotNull(dispatcher, "dispatcher");
            Verifying.ParameterIsNotNull(action, "action");

            return dispatcher.BeginInvoke(action, priority);
        }

        /// <summary>
        /// Executes the specified delegate asynchronously on the thread that the Dispatcher was created on.
        /// </summary>
        /// <param name="dispatcher">The dispatcher to begin invoke</param>
        /// <param name="action">The Action to a method that takes parameters specified in args, which is pushed onto the Dispatcher event queue.</param>
        /// <returns>An object, which is returned immediately after BeginInvoke is called, that can be used to interact with the delegate as it is pending execution in the event queue.</returns>
        public static DispatcherOperation BeginInvoke(this Dispatcher dispatcher, Action action)
        {
            Verifying.ParameterIsNotNull(dispatcher, "dispatcher");
            Verifying.ParameterIsNotNull(action, "action");

            return dispatcher.BeginInvoke(action);
        }

        #endregion


        #region Invoke Related

        /// <summary>
        /// Executes the specified delegate synchronously at the specified priority on the thread on which the Dispatcher is associated with.
        /// </summary>
        /// <param name="dispatcher">The dispatcher to invoke</param>
        /// <param name="action">The Action to a method that takes parameters specified in args, which is pushed onto the Dispatcher event queue.</param>
        /// <param name="priority">The priority, relative to the other pending operations in the Dispatcher event queue, the specified method is invoked.</param>
        /// <param name="timeout">The maximum amount of time to wait for the operation to complete.</param>
        /// <returns>An object, which is returned immediately after Invoke is called, that can be used to interact with the delegate as it is pending execution in the event queue.</returns>
        public static object Invoke(this Dispatcher dispatcher, Action action, TimeSpan timeout, DispatcherPriority priority)
        {
            Verifying.ParameterIsNotNull(dispatcher, "dispatcher");
            Verifying.ParameterIsNotNull(action, "action");

            return dispatcher.Invoke(action, timeout, priority);
        }

        /// <summary>
        /// Executes the specified delegate synchronously at the specified priority on the thread on which the Dispatcher is associated with.
        /// </summary>
        /// <param name="dispatcher">The dispatcher to invoke</param>
        /// <param name="action">The Action to a method that takes parameters specified in args, which is pushed onto the Dispatcher event queue.</param>
        /// <param name="priority">The priority, relative to the other pending operations in the Dispatcher event queue, the specified method is invoked.</param>
        /// <returns>An object, which is returned immediately after Invoke is called, that can be used to interact with the delegate as it is pending execution in the event queue.</returns>
        public static object Invoke(this Dispatcher dispatcher, Action action, DispatcherPriority priority)
        {
            Verifying.ParameterIsNotNull(dispatcher, "dispatcher");
            Verifying.ParameterIsNotNull(action, "action");

            return dispatcher.Invoke(action, priority);
        }

        /// <summary>
        /// Executes the specified delegate synchronously on the thread the Dispatcher is associated with.
        /// </summary>
        /// <param name="dispatcher">The dispatcher to invoke</param>
        /// <param name="action">The Action to a method that takes parameters specified in args, which is pushed onto the Dispatcher event queue.</param>
        /// <param name="timeout">The maximum amount of time to wait for the operation to complete.</param>
        /// <returns>An object, which is returned immediately after Invoke is called, that can be used to interact with the delegate as it is pending execution in the event queue.</returns>
        public static object Invoke(this Dispatcher dispatcher, Action action, TimeSpan timeout)
        {
            Verifying.ParameterIsNotNull(dispatcher, "dispatcher");
            Verifying.ParameterIsNotNull(action, "action");

            return dispatcher.Invoke(action, timeout);
        }

        /// <summary>
        /// Executes the specified delegate synchronously on the thread the Dispatcher is associated with.
        /// </summary>
        /// <param name="dispatcher">The dispatcher to invoke</param>
        /// <param name="action">The Action to a method that takes parameters specified in args, which is pushed onto the Dispatcher event queue.</param>
        /// <returns>An object, which is returned immediately after Invoke is called, that can be used to interact with the delegate as it is pending execution in the event queue.</returns>
        public static object Invoke(this Dispatcher dispatcher, Action action)
        {
            Verifying.ParameterIsNotNull(dispatcher, "dispatcher");
            Verifying.ParameterIsNotNull(action, "action");

            return dispatcher.Invoke(action);
        }

        #endregion
    }
}
