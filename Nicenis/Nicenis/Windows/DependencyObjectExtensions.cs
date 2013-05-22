/*
 * Author	JO Hyeong-Ryeol
 * Since	2012.11.25
 * Version	$Id$
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
    /// Provides extension methods for DepencencyObject.
    /// </summary>
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Returns a collection of elements that contains the visual ancestors of the DependencyObject.
        /// Each element is the visual parent of the previous element except the first element which is the visual parent of the target DependencyObject.
        /// </summary>
        /// <param name="dependencyObject">Target DependencyObject.</param>
        /// <returns>A collection of elements that contains the visual ancestors.</returns>
        public static IEnumerable<DependencyObject> VisualAncestors(this DependencyObject dependencyObject)
        {
            if (dependencyObject == null)
                throw new ArgumentNullException("dependencyObject");

            DependencyObject current = VisualTreeHelper.GetParent(dependencyObject);

            while (current != null)
            {
                yield return current;
                current = VisualTreeHelper.GetParent(current);
            }
        }
    }
}
