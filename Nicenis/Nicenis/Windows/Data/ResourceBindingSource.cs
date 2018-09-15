/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.09.01
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2018 JO Hyeong-Ryeol. All rights reserved.
 */

using System.ComponentModel;
using System.Diagnostics;
using System.Resources;
using System.Windows.Threading;

namespace Nicenis.Windows.Data
{
    /// <summary>
    /// A ResourceManager wrapper for binding engine.
    /// This class is thread-safe.
    /// </summary>
    /// <remarks>
    /// This class is inspired by the following article:
    /// https://codinginfinity.me/post/2015-05-10/localization_of_a_wpf_app_the_simple_approach
    /// </remarks>
    internal class ResourceBindingSource : INotifyPropertyChanged
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="resourceManager">A related resource manager.</param>
        /// <param name="dispatcher">A related dispacher.</param>
        public ResourceBindingSource(ResourceManager resourceManager, Dispatcher dispatcher)
        {
            Debug.Assert(resourceManager != null);
            Debug.Assert(dispatcher != null);

            ResourceManager = resourceManager;
            Dispatcher = dispatcher;
        }

        #endregion


        #region Helpers

        /// <summary>
        /// The related resource manager.
        /// This property is always not null.
        /// </summary>
        public ResourceManager ResourceManager { get; }

        /// <summary>
        /// The related dispacher.
        /// This property is always not null.
        /// </summary>
        public Dispatcher Dispatcher { get; }

        /// <summary>
        /// The indexer implementation for binding engine.
        /// </summary>
        /// <param name="key">The name of the resource to retrieve.</param>
        /// <returns>The value of the resource localized for the caller's current UI culture, or null if name cannot be found in a resource set.</returns>
        public string this[string key]
        {
            get { return ResourceManager.GetString(key); }
        }

        static readonly PropertyChangedEventArgs _allPropertyChangedEventArgs = new PropertyChangedEventArgs(null);

        /// <summary>
        /// Raises an event to notify that all properties are changed.
        /// </summary>
        public void RaiseAllPropertyChanged()
        {
            PropertyChanged?.Invoke(this, _allPropertyChangedEventArgs);
        }

        #endregion


        #region INotifyPropertyChanged Implementation

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
