/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.09.02
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2018 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Nicenis.Windows.Data
{
    public static class Localization
    {
        #region Public Members

        public static ResourceManager AppResource { get; set; }
        public static ResourceManager FallbackResource { get; set; }

        public static readonly DependencyProperty ResourceProperty = DependencyProperty.RegisterAttached
        (
            name: "Resource",
            propertyType: typeof(ResourceManager),
            ownerType: typeof(Localization),
            defaultMetadata: new FrameworkPropertyMetadata(null)
        );

        public static ResourceManager GetResource(DependencyObject obj)
        {
            return (ResourceManager)obj.GetValue(ResourceProperty);
        }

        public static void SetResource(DependencyObject obj, ResourceManager value)
        {
            obj.SetValue(ResourceProperty, value);
        }

        public static void RefreshAsync()
        {
            lock (_resourceBindingSourcesLocker)
            {
                if (_resourceBindingSources == null)
                    return;

                foreach (var bindable in _resourceBindingSources)
                {
                    if (bindable.Dispatcher.HasShutdownStarted || bindable.Dispatcher.HasShutdownFinished)
                        continue;

                    bindable.Dispatcher.BeginInvoke(new Action(() => bindable.RaiseAllPropertyChanged()));
                }
            }
        }

        #endregion


        #region Helpers

        static readonly object _resourceBindingSourcesLocker = new object();
        internal static List<ResourceBindingSource> _resourceBindingSources;
        [ThreadStatic] static List<ResourceBindingSource> _threadResourceBindingSources;

        /// <summary>
        /// This method must be called in a thread that has an associated Dispatcher.
        /// </summary>
        /// <param name="resourceManager"></param>
        /// <returns></returns>
        internal static ResourceBindingSource CreateOrGetResourceBindingSource(ResourceManager resourceManager)
        {
            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException("A Dispatcher is required for localization.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return null;

            var bindingSource = _threadResourceBindingSources?.FirstOrDefault(p => p.ResourceManager == resourceManager);
            if (bindingSource == null)
            {
                if (_threadResourceBindingSources == null)
                    _threadResourceBindingSources = new List<ResourceBindingSource>();

                bindingSource = new ResourceBindingSource(resourceManager, dispatcher);
                _threadResourceBindingSources.Add(bindingSource);

                lock (_resourceBindingSourcesLocker)
                {
                    if (_resourceBindingSources == null)
                        _resourceBindingSources = new List<ResourceBindingSource>();

                    _resourceBindingSources.Add(bindingSource);
                }
            }

            return bindingSource;
        }

        private static void BindableResourceManagerDispatcher_ShutdownFinished(object sender, EventArgs e)
        {
            if (_threadResourceBindingSources == null)
                return;

            lock (_resourceBindingSourcesLocker)
            {
                foreach (var bindingSource in _threadResourceBindingSources)
                    _resourceBindingSources.Remove(bindingSource);
            }

            _threadResourceBindingSources.Clear();
        }

        #endregion
    }
}
