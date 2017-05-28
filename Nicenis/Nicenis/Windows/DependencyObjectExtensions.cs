/*
 * Author   JO Hyeong-Ryeol
 * Since    2012.11.25
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2012 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Nicenis.Windows
{
    /// <summary>
    /// Provides extension methods for the DepencencyObject.
    /// </summary>
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Returns a collection of elements that contains the visual ancestors of the DependencyObject.
        /// Each element is the visual parent of the previous element except the first element which is the visual parent of the target DependencyObject.
        /// </summary>
        /// <param name="dependencyObject">The target DependencyObject.</param>
        /// <returns>The collection of elements that contains the visual ancestors.</returns>
        public static IEnumerable<DependencyObject> VisualAncestors(this DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
                throw new ArgumentNullException(nameof(dependencyObject));

            DependencyObject current = VisualTreeHelper.GetParent(dependencyObject);

            while (current != null)
            {
                yield return current;
                current = VisualTreeHelper.GetParent(current);
            }
        }
    }
}
