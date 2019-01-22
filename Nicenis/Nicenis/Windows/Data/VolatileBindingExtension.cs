/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.10.24
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
using System.Threading;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Threading;

namespace Nicenis.Windows.Data
{
    /// <summary>
    /// 
    /// </summary>
    [MarkupExtensionReturnType(typeof(object))]
    public class VolatileBindingExtension : MarkupExtension
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public VolatileBindingExtension(BindingBase binding, string group)
        {
            Binding = binding;
            Group = group;
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        public VolatileBindingExtension(BindingBase binding)
        {
            Binding = binding;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets or sets a binding that provides a value.
        /// </summary>
        [ConstructorArgument("binding")]
        public BindingBase Binding { get; set; }

        /// <summary>
        /// Gets or sets a name that 
        /// </summary>
        [DefaultValue(null)]
        [ConstructorArgument("group")]
        public string Group { get; set; }

        #endregion


        #region Public Methods

        /// <summary>
        /// Reevaluates bindings in the current UI thread.
        /// </summary>
        /// <remarks>
        /// This method must be called in a UI thread that is associated with the LocalStringExtension.
        /// </remarks>
        public static void RefreshAsync(string group)
        {
            RefreshAsync(group, isAll: false);
        }

        /// <summary>
        /// Reevaluates bindings in the current UI thread.
        /// </summary>
        /// <remarks>
        /// This method must be called in a UI thread that is associated with the LocalStringExtension.
        /// </remarks>
        public static void RefreshAsync()
        {
            RefreshAsync(null, isAll: true);
        }

        /// <summary>
        /// Reevaluates bindings in all UI threads.
        /// This method is thread-safe.
        /// </summary>
        /// <remarks>
        /// If the application uses multiple UI threads, this method refreshes all related UI threads.
        /// </remarks>
        public static void RefreshAllAsync(string group)
        {
            RefreshAllAsync(group, isAll: false);
        }

        /// <summary>
        /// Reevaluates bindings in all UI threads.
        /// This method is thread-safe.
        /// </summary>
        /// <remarks>
        /// If the application uses multiple UI threads, this method refreshes all related UI threads.
        /// </remarks>
        public static void RefreshAllAsync()
        {
            RefreshAllAsync(null, isAll: true);
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

            if (Binding == null)
                return null;

            var multiBinding = new MultiBinding
            {
                Converter = FirstValueConverter.Instance
            };
            multiBinding.Bindings.Add(Binding);
            multiBinding.Bindings.Add
            (
                new Binding(nameof(NotificationBindingSource.Group))
                {
                    Source = CreateOrGetNotificationBindingSource(Group),
                    Mode = BindingMode.OneWay,
                }
            );

            return multiBinding.ProvideValue(serviceProvider);
        }

        #endregion


        #region Helpers

        private class FirstValueConverter : IMultiValueConverter
        {
            public static readonly FirstValueConverter Instance = new FirstValueConverter();

            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return values[0];
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                if (targetTypes == null || targetTypes.Length == 0)
                    return null;

                var objects = new object[targetTypes.Length];
                objects[0] = value;
                for (int i = 1; i < objects.Length; i++)
                    objects[i] = System.Windows.Data.Binding.DoNothing;

                return objects;
            }
        }

        private class NotificationBindingSource : INotifyPropertyChanged
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="dispatcher">A related dispacher.</param>
            public NotificationBindingSource(string group, Dispatcher dispatcher)
            {
                Debug.Assert(dispatcher != null);

                Group = group;
                Dispatcher = dispatcher;
            }

            #endregion


            #region Helpers

            public string Group { get; }

            /// <summary>
            /// The related dispacher.
            /// This property is always not null.
            /// </summary>
            public Dispatcher Dispatcher { get; }


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


        static readonly object _resourceBindingSourcesLocker = new object();
        static List<NotificationBindingSource> _resourceBindingSources;
        [ThreadStatic] static List<NotificationBindingSource> _threadResourceBindingSources;

        /// <summary>
        /// Creates or gets a resource binding source based on the provided the resource manager.
        /// This method must be called in a thread that has an associated Dispatcher.
        /// </summary>
        /// <param name="resourceManager">A resource manager to get a resource binding source.</param>
        /// <returns>A resource binding source.</returns>
        private static NotificationBindingSource CreateOrGetNotificationBindingSource(string group)
        {
            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException($"The {nameof(VolatileBindingExtension)} requires a Dispatcher in the current thread.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return null;

            var source = _threadResourceBindingSources?.FirstOrDefault(p => p.Group == group);
            if (source == null)
            {
                if (_threadResourceBindingSources == null)
                    _threadResourceBindingSources = new List<NotificationBindingSource>();

                source = new NotificationBindingSource(group, dispatcher);
                _threadResourceBindingSources.Add(source);
                source.Dispatcher.ShutdownFinished -= ResourceBindingSourceDispatcher_ShutdownFinished;
                source.Dispatcher.ShutdownFinished += ResourceBindingSourceDispatcher_ShutdownFinished;

                lock (_resourceBindingSourcesLocker)
                {
                    if (_resourceBindingSources == null)
                        _resourceBindingSources = new List<NotificationBindingSource>();

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

        /// <summary>
        /// Reevaluates bindings in the current UI thread.
        /// </summary>
        /// <remarks>
        /// This method must be called in a UI thread that is associated with the LocalStringExtension.
        /// </remarks>
        private static void RefreshAsync(string group, bool isAll)
        {
            if (_threadResourceBindingSources == null)
                return;

            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException($"The {nameof(RefreshAsync)} requires a Dispatcher in the current thread.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return;

            foreach (var source in _threadResourceBindingSources)
            {
                if (isAll || source.Group == group)
                    source.RaiseAllPropertyChanged();
            }
        }

        /// <summary>
        /// Reevaluates bindings in all UI threads.
        /// This method is thread-safe.
        /// </summary>
        /// <remarks>
        /// If the application uses multiple UI threads, this method refreshes all related UI threads.
        /// </remarks>
        private static void RefreshAllAsync(string group, bool isAll)
        {
            lock (_resourceBindingSourcesLocker)
            {
                if (_resourceBindingSources == null)
                    return;

                foreach (var source in _resourceBindingSources)
                {
                    if (source.Dispatcher.HasShutdownStarted || source.Dispatcher.HasShutdownFinished)
                        continue;

                    if (isAll || source.Group == group)
                        source.Dispatcher.BeginInvoke(new Action(() => source.RaiseAllPropertyChanged()));
                }
            }
        }

        #endregion
    }
}
