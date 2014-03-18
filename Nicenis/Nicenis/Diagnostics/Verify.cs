/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.11.28
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Nicenis.Diagnostics
{
    /// <summary>
    /// Verifies conditions.
    /// </summary>
    internal static class Verify
    {
        /// <summary>
        /// Throws an exception if the parameter is null.
        /// </summary>
        /// <typeparam name="T">The parameter type.</typeparam>
        /// <param name="parameter">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public static void ParameterIsNotNull<T>(T parameter, string parameterName)
        {
            if (parameter == null)
                throw new ArgumentNullException(parameterName);
        }

        /// <summary>
        /// Throws an exception if the parameter is null or an empty collection.
        /// </summary>
        /// <typeparam name="T">The parameter collection item type.</typeparam>
        /// <param name="parameter">The parameter collection.</param>
        /// <param name="parameterName">The parameter name.</param>
        public static void ParameterIsNotNullAndEmptyCollection<T>(IEnumerable<T> parameter, string parameterName)
        {
            ParameterIsNotNull(parameter, parameterName);

            if (parameter.Any() == false)
                throw new ArgumentException(string.Format("The parameter {0} can not be an empty collection.", parameterName));
        }

        /// <summary>
        /// Throws an exception if the parameter is null or an empty string.
        /// </summary>
        /// <param name="parameter">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public static void ParameterIsNotNullAndEmpty(string parameter, string parameterName)
        {
            ParameterIsNotNull(parameter, parameterName);

            if (string.IsNullOrEmpty(parameter))
                throw new ArgumentException(string.Format("The parameter {0} can not be an empty string.", parameterName));
        }

        /// <summary>
        /// Throws an exception if the parameter is null or a whitespace string.
        /// </summary>
        /// <param name="parameter">The parameter value.</param>
        /// <param name="parameterName">The parameter name.</param>
        public static void ParameterIsNotNullAndWhiteSpace(string parameter, string parameterName)
        {
            ParameterIsNotNull(parameter, parameterName);

            if (string.IsNullOrWhiteSpace(parameter))
                throw new ArgumentException(string.Format("The parameter {0} can not be a whitespace string.", parameterName));
        }
    }
}
