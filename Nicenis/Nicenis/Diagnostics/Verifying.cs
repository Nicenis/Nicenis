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

namespace Nicenis.Diagnostics
{
    /// <summary>
    /// Verifies conditions.
    /// </summary>
    internal static class Verifying
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
    }
}
