/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.09.01
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2018 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Threading;

namespace Nicenis.Windows.Data
{
    /// <summary>
    /// Returns a resource string in a ResourceManager.
    /// </summary>
    [MarkupExtensionReturnType(typeof(string))]
    public class LocalStringExtension : MarkupExtension
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="name">A string that specifies a localized resource string.</param>
        /// <param name="resource">A ResourceManager that provides resource strings.</param>
        public LocalStringExtension(string name, ResourceManager resource)
        {
            Name = name;
            Resource = resource;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets a string that specifies a localized resource string.
        /// </summary>
        [ConstructorArgument("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a ResourceManager that provides resource strings.
        /// </summary>
        [ConstructorArgument("resource")]
        public ResourceManager Resource { get; set; }

        /// <summary>
        /// Gets or sets a string that specifies how to format the localized resource string.
        /// </summary>
        [DefaultValue(null)]
        public string StringFormat { get; set; }

        /// <summary>
        /// Gets or sets the converter to use.
        /// </summary>
        [DefaultValue(null)]
        public IValueConverter Converter { get; set; }

        /// <summary>
        /// Gets or sets the parameter to pass to the System.Windows.Data.Binding.Converter.
        /// </summary>
        [DefaultValue(null)]
        public object ConverterParameter { get; set; }

        /// <summary>
        /// Gets or sets the culture in which to evaluate the converter.
        /// </summary>
        [DefaultValue(null)]
        [TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
        public CultureInfo ConverterCulture { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Refreshes resource strings in the current UI thread.
        /// </summary>
        /// <remarks>
        /// This method must be called in a UI thread that is associated with the LocalStringExtension.
        /// </remarks>
        public static void RefreshAsync()
        {
            if (_threadResourceBindingSources == null)
                return;

            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException($"The {nameof(RefreshAsync)} requires a Dispatcher in the current thread.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return;

            foreach (var source in _threadResourceBindingSources)
                source.RaiseAllPropertyChanged();
        }

        /// <summary>
        /// Refreshes resource strings in all UI threads.
        /// This method is thread-safe.
        /// </summary>
        /// <remarks>
        /// If the application uses multiple UI threads, this method refreshes all related UI threads.
        /// </remarks>
        public static void RefreshAllAsync()
        {
            lock (_resourceBindingSourcesLocker)
            {
                if (_resourceBindingSources == null)
                    return;

                foreach (var source in _resourceBindingSources)
                {
                    if (source.Dispatcher.HasShutdownStarted || source.Dispatcher.HasShutdownFinished)
                        continue;

                    source.Dispatcher.BeginInvoke(new Action(() => source.RaiseAllPropertyChanged()));
                }
            }
        }

        #endregion


        #region ProvideValue

        /// <summary>
        /// When implemented in a derived class, returns an object that is provided as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>The object value to set on the property where the extension is applied.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            if (Resource == null)
                return Name;

            var source = CreateOrGetResourceBindingSource(Resource);
            if (source == null)
                return null;

            var binding = new Binding("[" + Name + "]")
            {
                StringFormat = StringFormat,
                Source = source,
                Mode = BindingMode.OneWay,
                Converter = Converter,
                ConverterParameter = ConverterParameter,
                ConverterCulture = ConverterCulture,
            };
            return binding.ProvideValue(serviceProvider);
        }

        #endregion


        #region Helpers

        #region ResourceBindingSource

        /// <summary>
        /// A ResourceManager wrapper for binding engine.
        /// This class is thread-safe.
        /// </summary>
        /// <remarks>
        /// This class is inspired by the following article:
        /// https://codinginfinity.me/post/2015-05-10/localization_of_a_wpf_app_the_simple_approach
        /// </remarks>
        private class ResourceBindingSource : INotifyPropertyChanged
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

        #endregion

        static readonly object _resourceBindingSourcesLocker = new object();
        static List<ResourceBindingSource> _resourceBindingSources;
        [ThreadStatic] static List<ResourceBindingSource> _threadResourceBindingSources;

        /// <summary>
        /// Creates or gets a resource binding source based on the provided the resource manager.
        /// This method must be called in a thread that has an associated Dispatcher.
        /// </summary>
        /// <param name="resourceManager">A resource manager to get a resource binding source.</param>
        /// <returns>A resource binding source.</returns>
        private static ResourceBindingSource CreateOrGetResourceBindingSource(ResourceManager resourceManager)
        {
            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException($"The {nameof(LocalStringExtension)} requires a Dispatcher in the current thread.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return null;

            var source = _threadResourceBindingSources?.FirstOrDefault(p => p.ResourceManager == resourceManager);
            if (source == null)
            {
                if (_threadResourceBindingSources == null)
                    _threadResourceBindingSources = new List<ResourceBindingSource>();

                source = new ResourceBindingSource(resourceManager, dispatcher);
                _threadResourceBindingSources.Add(source);
                source.Dispatcher.ShutdownFinished -= ResourceBindingSourceDispatcher_ShutdownFinished;
                source.Dispatcher.ShutdownFinished += ResourceBindingSourceDispatcher_ShutdownFinished;

                lock (_resourceBindingSourcesLocker)
                {
                    if (_resourceBindingSources == null)
                        _resourceBindingSources = new List<ResourceBindingSource>();

                    _resourceBindingSources.Add(source);
                }
            }

            return source;
        }

        private static void ResourceBindingSourceDispatcher_ShutdownFinished(object sender, EventArgs e)
        {
            if (_threadResourceBindingSources == null)
                return;

            lock (_resourceBindingSourcesLocker)
            {
                foreach (var source in _threadResourceBindingSources)
                    _resourceBindingSources.Remove(source);
            }

            _threadResourceBindingSources.Clear();
            _threadResourceBindingSources = null;
        }

        #endregion
    }
}
