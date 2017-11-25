/*
 * Author   JO Hyeong-Ryeol
 * Since    2017.10.02
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2017 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

#if NICENIS_UWP
using TheDispatcherOperation = Windows.Foundation.IAsyncAction;
using TheDispatcherPriority = Windows.UI.Core.CoreDispatcherPriority;
#else
using System.Windows.Threading;
using TheDispatcherOperation = System.Windows.Threading.DispatcherOperation;
using TheDispatcherPriority = System.Windows.Threading.DispatcherPriority;
#endif

namespace Nicenis.Windows.ViewModels
{
    /// <summary>
    /// Provides base framework implementation for view models.
    /// </summary>
    public abstract class FrameworkViewModelBase : DispatcherViewModelBase
    {
        #region Helpers

        /// <summary>
        /// The posted property names to notify changes.
        /// This field must be accessed on the thread that the Dispatcher is associated with.
        /// </summary>
        List<string> _postedPropertyNames;

        /// <summary>
        /// The action that raises changed events for the posted property names.
        /// This field must be accessed on the thread that the Dispatcher is associated with.
        /// </summary>
        TheDispatcherOperation _invokeAction;

        /// <summary>
        /// Raises changed events for the posted property names.
        /// This method must be called on the thread that the Dispatcher is associated with.
        /// </summary>
        private void RaiseEventsForPostedPropertyNames()
        {
            Debug.Assert(_invokeAction != null);

            _invokeAction = null;

            if (_postedPropertyNames == null)
                return;

            foreach (var propertyName in _postedPropertyNames)
                OnPropertyChanged(propertyName);

            _postedPropertyNames.Clear();
        }

        /// <summary>
        /// Posts an action that raises changed events for the posted property names if required.
        /// This method must be called on the thread that the Dispatcher is associated with.
        /// </summary>
        private void PostActionIfRequired()
        {
            if (_invokeAction != null)
                return;

#if NICENIS_UWP
            _invokeAction = Dispatcher.RunAsync
            (
                priority: PostDispatcherPriority,
                agileCallback: RaiseEventsForPostedPropertyNames
            );
#else
            _invokeAction = Dispatcher.InvokeAsync
            (
                callback: RaiseEventsForPostedPropertyNames,
                priority: PostDispatcherPriority
            );
#endif
        }

        #endregion


        #region PostPropertyChanged Related

        /// <summary>
        /// The dispatcher priority to use to post.
        /// </summary>
        protected virtual TheDispatcherPriority PostDispatcherPriority => TheDispatcherPriority.Normal;

        /// <summary>
        /// Posts a PropertyChanged event.
        /// This method must be called on the thread that the Dispatcher is associated with.
        /// </summary>
        /// <param name="propertyName">The property name that changed. An Empty value or null indicates that all of the properties have changed. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        protected virtual void PostPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (_postedPropertyNames == null)
            {
                _postedPropertyNames = new List<string>
                {
                    propertyName
                };
            }
            else
            {
                if (_postedPropertyNames.Contains(propertyName) == false)
                    _postedPropertyNames.Add(propertyName);
            }

            PostActionIfRequired();
        }

        /// <summary>
        /// Posts PropertyChanged events.
        /// This method must be called on the thread that the Dispatcher is associated with.
        /// </summary>
        /// <param name="propertyNames">The property names that changed.</param>
        protected void PostPropertyChanged(IEnumerable<string> propertyNames)
        {
            Debug.Assert(propertyNames != null);

            if (propertyNames.Any() == false)
                return;

            if (_postedPropertyNames == null)
                _postedPropertyNames = new List<string>();

            foreach (string propertyName in propertyNames)
            {
                if (_postedPropertyNames.Contains(propertyName) == false)
                    _postedPropertyNames.Add(propertyName);
            }

            PostActionIfRequired();
        }

        /// <summary>
        /// Posts PropertyChanged events.
        /// This method must be called on the thread that the Dispatcher is associated with.
        /// </summary>
        /// <param name="propertyNames">The property names that changed.</param>
        protected void PostPropertyChanged(params string[] propertyNames)
        {
            PostPropertyChanged((IEnumerable<string>)propertyNames);
        }

        /// <summary>
        /// Cancels posted PropertyChanged events if it is cancellable.
        /// This method must be called on the thread that the Dispatcher is associated with.
        /// </summary>
        protected virtual void CancelPostPropertyChanged()
        {
            if (_invokeAction == null)
                return;

#if NICENIS_UWP
            _invokeAction.Cancel();
#else
            _invokeAction.Abort();
#endif
            _invokeAction = null;
        }

        #endregion


        #region SetPropertyP Related

        /// <summary>
        /// Sets a value to the property specified by the property name.
        /// If it is changed and the isHidden parameter is false, PropertyChanged events are posted for the property name and the related property names.
        /// </summary>
        /// <remarks>
        /// This method stores the property value in the internal storage.
        /// </remarks>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        /// <param name="onChanging">The callback that is called when the property value is changing. Null is allowed.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="related">The related property names. Null is allowed.</param>
        /// <param name="isHidden">Whether to suppress raising the PropertyValueChanging, PropertyValueChanged event and posting PropertyChanged events.</param>
        /// <returns>True if the property is changed; otherwise false.</returns>
        protected virtual bool SetPropertyP<T>(T value, [CallerMemberName] string propertyName = null, Action<IPropertyValueChangingEventArgs<T>> onChanging = null, Action<IPropertyValueChangedEventArgs<T>> onChanged = null, IEnumerable<string> related = null, bool isHidden = false)
        {
            return SetProperty
            (
                value: value,
                propertyName: propertyName,
                onChanging: p =>
                {
                    Debug.Assert(p is IPropertyValueChangingEventArgs);

                    // Raises a PropertyValueChanging event.
                    if (isHidden == false)
                        OnPropertyValueChanging((IPropertyValueChangingEventArgs)p);

                    // Calls the changing callback.
                    onChanging?.Invoke(p);
                },
                onChanged: p =>
                {
                    // Calls the changed callback.
                    onChanged?.Invoke(p);

                    if (isHidden == false)
                    {
                        Debug.Assert(p is IPropertyValueChangedEventArgs);

                        // Raises a PropertyValueChanged event.
                        OnPropertyValueChanged((IPropertyValueChangedEventArgs)p);

                        // Posts PropertyChanged events.
                        PostPropertyChanged(p.PropertyName);
                        if (related != null)
                            PostPropertyChanged(related);
                    }
                },
                related: related,
                isHidden: true
            );
        }

        /// <summary>
        /// Sets a value to the specified storage.
        /// If it is changed and the isHidden parameter is false, PropertyChanged events are posted for the property name and the related property names.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="storage">The storage to store the property value.</param>
        /// <param name="value">The property value.</param>
        /// <param name="propertyName">The property name. If this parameter is not specified, the property name obtained by the CallerMemberName attribute is used.</param>
        /// <param name="onChanging">The callback that is called when the property value is changing. Null is allowed.</param>
        /// <param name="onChanged">The callback that is called when the property value is changed. Null is allowed.</param>
        /// <param name="related">The related property names.</param>
        /// <param name="isHidden">Whether to suppress raising the PropertyValueChanging, PropertyValueChanged event and posting PropertyChanged events.</param>
        /// <returns>True if the storage is changed; otherwise false.</returns>
        protected virtual bool SetPropertyP<T>(ref T storage, T value, [CallerMemberName] string propertyName = null, Action<IPropertyValueChangingEventArgs<T>> onChanging = null, Action<IPropertyValueChangedEventArgs<T>> onChanged = null, IEnumerable<string> related = null, bool isHidden = false)
        {
            return SetProperty
            (
                storage: ref storage,
                value: value,
                propertyName: propertyName,
                onChanging: p =>
                {
                    Debug.Assert(p is IPropertyValueChangingEventArgs);

                    // Raises a PropertyValueChanging event.
                    if (isHidden == false)
                        OnPropertyValueChanging((IPropertyValueChangingEventArgs)p);

                    // Calls the changing callback.
                    onChanging?.Invoke(p);
                },
                onChanged: p =>
                {
                    // Calls the changed callback.
                    onChanged?.Invoke(p);

                    if (isHidden == false)
                    {
                        Debug.Assert(p is IPropertyValueChangedEventArgs);

                        // Raises a PropertyValueChanged event.
                        OnPropertyValueChanged((IPropertyValueChangedEventArgs)p);

                        // Posts PropertyChanged events.
                        PostPropertyChanged(p.PropertyName);
                        if (related != null)
                            PostPropertyChanged(related);
                    }
                },
                related: related,
                isHidden: true
            );
        }

        #endregion
    }
}
