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



            if (!(Binding.ProvideValue(serviceProvider) is BindingExpressionBase expression))
                throw new InvalidOperationException("TODO");

            AddToExpressionStorage(Group, expression);
            return expression;
        }

        #endregion


        #region Helpers

        private class ExpressionStorage
        {
            #region Constructors

            public ExpressionStorage(string group, Dispatcher dispatcher)
            {
                Debug.Assert(dispatcher != null);

                Group = group;
                Dispatcher = dispatcher;
                ExpressionReferences = new List<WeakReference<BindingExpression>>();
            }

            #endregion


            public string Group { get; }

            /// <summary>
            /// The related dispacher.
            /// This property is always not null.
            /// </summary>
            public Dispatcher Dispatcher { get; }

            /// <summary>
            /// This property is always not null.
            /// </summary>
            public List<WeakReference<BindingExpression>> ExpressionReferences { get; }
        }


        static readonly object _dispatchersLocker = new object();
        static List<Dispatcher> _dispatchers;
        [ThreadStatic] static List<ExpressionStorage> _threadExpressionStorages;

        /// <summary>
        /// This method must be called in a thread that has an associated Dispatcher.
        /// </summary>
        private static void AddToExpressionStorage(string group, BindingExpressionBase bindingExpression)
        {
            Debug.Assert(bindingExpression != null);

            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException($"The {nameof(VolatileBindingExtension)} requires a Dispatcher in the current thread.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return;

            if (_threadExpressionStorages == null)
            {
                _threadExpressionStorages = new List<ExpressionStorage>();

                lock (_dispatchersLocker)
                {
                    if (_dispatchers == null)
                        _dispatchers = new List<Dispatcher>();

                    _dispatchers.Add(dispatcher);
                    dispatcher.ShutdownFinished -= Dispatcher_ShutdownFinished;
                    dispatcher.ShutdownFinished += Dispatcher_ShutdownFinished;
                }
            }

            var storage = _threadExpressionStorages.FirstOrDefault(p => p.Group == group);
            if (storage == null)
            {
                storage = new ExpressionStorage(group, dispatcher);
                _threadExpressionStorages.Add(storage);
            }

            //storage.ExpressionReferences.Add(new WeakReference<BindingExpression>(bindingExpression));
        }

        private static void Dispatcher_ShutdownFinished(object sender, EventArgs e)
        {
            if (_threadExpressionStorages == null)
                return;

            var dispatcher = _threadExpressionStorages.FirstOrDefault()?.Dispatcher;
            if (dispatcher != null)
            {
                lock (_dispatchersLocker)
                    _dispatchers.Remove(dispatcher);
            }

            _threadExpressionStorages.Clear();
            _threadExpressionStorages = null;
        }

        /// <summary>
        /// Reevaluates bindings in the current UI thread.
        /// </summary>
        /// <remarks>
        /// This method must be called in a UI thread that is associated with the VolatileBindingExtension.
        /// </remarks>
        private static void RefreshAsync(string group, bool isAll)
        {
            if (_threadVolatileBindingSources == null)
                return;

            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException($"The {nameof(RefreshAsync)} requires a Dispatcher in the current thread.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return;

            foreach (var storage in _threadExpressionStorages)
            {
                if (isAll || storage.Group == group)
                {
                    foreach (var expressionReference in storage.ExpressionReferences)
                    {
                        if (expressionReference.TryGetTarget(out BindingExpression expression))
                        {
                            expression.UpdateTarget();
                        }
                        else
                        {
                            // TODO:
                        }
                    }
                }
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
            lock (_volatileBindingSourcesLocker)
            {
                if (_volatileBindingSources == null)
                    return;

                foreach (var source in _volatileBindingSources)
                {
                    if (source.Dispatcher.HasShutdownStarted || source.Dispatcher.HasShutdownFinished)
                        continue;

                    if (isAll || source.Group == group)
                        source.Dispatcher.BeginInvoke(new Action(() => source.RaiseAllPropertyChanged()));
                }
            }
        }










        #region VolatileBindingSource

        private class VolatileBindingSource : INotifyPropertyChanged
        {
            #region Constructors

            /// <summary>
            /// Initializes a new instance.
            /// </summary>
            /// <param name="dispatcher">A related dispacher.</param>
            public VolatileBindingSource(string group, Dispatcher dispatcher)
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

        #endregion


        static readonly object _volatileBindingSourcesLocker = new object();
        static List<VolatileBindingSource> _volatileBindingSources;
        [ThreadStatic] static List<VolatileBindingSource> _threadVolatileBindingSources;

        /// <summary>
        /// Creates or gets a volatile binding source based on the provided the group.
        /// This method must be called in a thread that has an associated Dispatcher.
        /// </summary>
        /// <param name="group">A group to get a volatile binding source.</param>
        /// <returns>A volatile binding source.</returns>
        private static VolatileBindingSource CreateOrGetVolatileBindingSource(string group)
        {
            var dispatcher = Dispatcher.FromThread(Thread.CurrentThread);
            if (dispatcher == null)
                throw new InvalidOperationException($"The {nameof(VolatileBindingExtension)} requires a Dispatcher in the current thread.");

            if (dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                return null;

            var source = _threadVolatileBindingSources?.FirstOrDefault(p => p.Group == group);
            if (source == null)
            {
                if (_threadVolatileBindingSources == null)
                    _threadVolatileBindingSources = new List<VolatileBindingSource>();

                source = new VolatileBindingSource(group, dispatcher);
                _threadVolatileBindingSources.Add(source);
                source.Dispatcher.ShutdownFinished -= VolatileBindingSourceDispatcher_ShutdownFinished;
                source.Dispatcher.ShutdownFinished += VolatileBindingSourceDispatcher_ShutdownFinished;

                lock (_volatileBindingSourcesLocker)
                {
                    if (_volatileBindingSources == null)
                        _volatileBindingSources = new List<VolatileBindingSource>();

                    _volatileBindingSources.Add(source);
                }
            }

            return source;
        }

        private static void VolatileBindingSourceDispatcher_ShutdownFinished(object sender, EventArgs e)
        {
            if (_threadVolatileBindingSources == null)
                return;

            lock (_volatileBindingSourcesLocker)
            {
                foreach (var source in _threadVolatileBindingSources)
                    _volatileBindingSources.Remove(source);
            }

            _threadVolatileBindingSources.Clear();
            _threadVolatileBindingSources = null;
        }


        #endregion
    }
}
