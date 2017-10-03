/*
 * Author   JO Hyeong-Ryeol
 * Since    2017.10.02
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2017 JO Hyeong-Ryeol. All rights reserved.
 */

#if NICENIS_UWP
using DispatcherType = Windows.UI.Core.CoreDispatcher;
using MainDispatcherHolder = Windows.UI.Xaml.Window;
#else
using DispatcherType = System.Windows.Threading.Dispatcher;
using MainDispatcherHolder = System.Windows.Application;
#endif

namespace Nicenis.Windows.ViewModels
{
    /// <summary>
    /// Provides base implementation with a dispatcher for view models.
    /// </summary>
    public abstract class DispatcherViewModelBase : ViewModelBase
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
