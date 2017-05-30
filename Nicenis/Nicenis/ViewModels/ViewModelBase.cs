/*
 * Author   JO Hyeong-Ryeol
 * Since    2015.08.26
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2015 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.ComponentModel;

#if NICENIS_UWP
using DispatcherType = Windows.UI.Core.CoreDispatcher;
using MainDispatcherHolder = Windows.UI.Xaml.Window;
#else
using DispatcherType = System.Windows.Threading.Dispatcher;
using MainDispatcherHolder = System.Windows.Application;
#endif

namespace Nicenis.ViewModels
{
    /// <summary>
    /// Provides base implementation for view models.
    /// </summary>
    public class ViewModelBase : PropertyObservable
    {
        /// <summary>
        /// Gets the related dispatcher.
        /// </summary>
        /// <remarks>
        /// If this property is not overridden, the main UI thread's dispatcher is returned.
        /// </remarks>
        public virtual DispatcherType Dispatcher => MainDispatcherHolder.Current.Dispatcher;
    }
}
