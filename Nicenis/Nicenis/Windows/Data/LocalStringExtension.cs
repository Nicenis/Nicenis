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
using System.Linq;
using System.Resources;
using System.Threading;
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
        /// <param name="name">A string that specifies the localized resource string.</param>
        /// <param name="resource">A ResourceManager that provides resource strings.</param>
        public LocalStringExtension(string name, ResourceManager resource)
        {
            Name = name;
            Resource = resource;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets a string that specifies the localized resource string.
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
        public string StringFormat { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// TODO: Writes comments.
        /// This method must be called in a UI thread that is associated with LocalStringExtension.
        /// </summary>
        public static void RefreshAsync()
        {
            if (_threadResourceBindingSources == null)
                return;

            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException("A Dispatcher is required for RefreshAsync.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return;

            foreach (var bindingSource in _threadResourceBindingSources)
                bindingSource.RaiseAllPropertyChanged();
        }

        /// <summary>
        /// TODO: Writes comments.
        /// If the application uses multiple UI threads, this method refreshes all related UI threads.
        /// This method is thread-safe.
        /// </summary>
        public static void RefreshAllAsync()
        {
            if (_resourceBindingSources == null)
                return;

            lock (_resourceBindingSourcesLocker)
            {
                if (_resourceBindingSources == null)
                    return;

                foreach (var bindingSource in _resourceBindingSources)
                {
                    if (bindingSource.Dispatcher.HasShutdownStarted || bindingSource.Dispatcher.HasShutdownFinished)
                        continue;

                    bindingSource.Dispatcher.BeginInvoke(new Action(() => bindingSource.RaiseAllPropertyChanged()));
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

            var bindingSource = CreateOrGetResourceBindingSource(Resource);
            if (bindingSource == null)
                return null;

            var binding = new Binding("[" + Name + "]")
            {
                StringFormat = StringFormat,
                Source = bindingSource,
                Mode = BindingMode.OneWay,
            };
            return binding.ProvideValue(serviceProvider);
        }

        #endregion


        #region Helpers

        static readonly object _resourceBindingSourcesLocker = new object();
        static List<ResourceBindingSource> _resourceBindingSources;
        [ThreadStatic] static List<ResourceBindingSource> _threadResourceBindingSources;

        /// <summary>
        /// This method must be called in a thread that has an associated Dispatcher.
        /// </summary>
        /// <param name="resourceManager"></param>
        /// <returns></returns>
        private static ResourceBindingSource CreateOrGetResourceBindingSource(ResourceManager resourceManager)
        {
            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException("A Dispatcher is required for LocalStringExtension.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return null;

            var bindingSource = _threadResourceBindingSources?.FirstOrDefault(p => p.ResourceManager == resourceManager);
            if (bindingSource == null)
            {
                if (_threadResourceBindingSources == null)
                    _threadResourceBindingSources = new List<ResourceBindingSource>();

                bindingSource = new ResourceBindingSource(resourceManager, dispatcher);
                _threadResourceBindingSources.Add(bindingSource);
                bindingSource.Dispatcher.ShutdownFinished += ResourceBindingSourceDispatcher_ShutdownFinished;

                lock (_resourceBindingSourcesLocker)
                {
                    if (_resourceBindingSources == null)
                        _resourceBindingSources = new List<ResourceBindingSource>();

                    _resourceBindingSources.Add(bindingSource);
                }
            }

            return bindingSource;
        }

        private static void ResourceBindingSourceDispatcher_ShutdownFinished(object sender, EventArgs e)
        {
            if (_threadResourceBindingSources == null)
                return;

            lock (_resourceBindingSourcesLocker)
            {
                foreach (var bindingSource in _threadResourceBindingSources)
                    _resourceBindingSources.Remove(bindingSource);
            }

            _threadResourceBindingSources.Clear();
            _threadResourceBindingSources = null;
        }

        #endregion
    }
}
