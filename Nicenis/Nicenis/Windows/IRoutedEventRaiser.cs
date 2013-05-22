/*
 * Author	JO Hyeong-Ryeol
 * Since	2013.05.05
 * Version	$Id$
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Windows;

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides the RaiseEvent method that raises a routed event.
    /// </summary>
    public interface IRoutedEventRaiser
    {
        /// <summary>
        /// An alternate source that will be reported when the event is handled. This pre-populates the Source property.
        /// </summary>
        object Source { get; }

        /// <summary>
        /// Raises the routed event that is specified by the RoutedEventArgs.RoutedEvent property within the provided RoutedEventArgs.
        /// </summary>
        /// <param name="e">An instance of the RoutedEventArgs class that contains the identifier for the event to raise.</param>
        void RaiseEvent(RoutedEventArgs e);
    }


    #region RoutedEventRaiser

    /// <summary>
    /// Provides default IRoutedEventRaiser implementation for known types.
    /// </summary>
    public static class RoutedEventRaiser
    {
        #region InputElementWrapper

        /// <summary>
        /// Provides default IRoutedEventRaiser implementation for InputElementWrapper.
        /// </summary>
        private class InputElementWrapper : IRoutedEventRaiser
        {
            /// <summary>
            /// A IInputElement instance to call the RaiseEvent method.
            /// This variable is set to non-null value in the Constructor.
            /// </summary>
            IInputElement _inputElement;

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the InputElementWrapper class.
            /// </summary>
            /// <param name="inputElement">A IInputElement instance to call the RaiseEvent method. Null is not allowed.</param>
            public InputElementWrapper(IInputElement inputElement)
            {
                if (inputElement == null)
                    throw new ArgumentNullException("inputElement");

                _inputElement = inputElement;
            }

            #endregion

            #region IRoutedEventRaiser

            /// <summary>
            /// An alternate source that will be reported when the event is handled. This pre-populates the Source property.
            /// </summary>
            public object Source { get { return _inputElement; } }

            /// <summary>
            /// Raises the routed event that is specified by the RoutedEventArgs.RoutedEvent property within the provided RoutedEventArgs.
            /// </summary>
            /// <param name="e">An instance of the RoutedEventArgs class that contains the identifier for the event to raise.</param>
            public void RaiseEvent(RoutedEventArgs e)
            {
                _inputElement.RaiseEvent(e);
            }

            #endregion
        }

        #endregion


        #region Create

        /// <summary>
        /// Returns a default IRoutedEventRaiser implementation based on the specified IInputElement.
        /// </summary>
        /// <param name="inputElement">A IInputElement instance for IRoutedEventRaiser implementation. Null is not allowed.</param>
        /// <returns>A default IRoutedEventRaiser implementation.</returns>
        public static IRoutedEventRaiser Create(IInputElement inputElement)
        {
            return new InputElementWrapper(inputElement);
        }

        #endregion
    }

    #endregion
}
