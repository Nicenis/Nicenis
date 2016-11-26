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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

#if NICENIS_RT
using RtWindow = Windows.UI.Xaml.Window;
using RtDispatcher = Windows.UI.Core.CoreDispatcher;
#endif

namespace Nicenis.ViewModels
{
    /// <summary>
    /// Provides base implementation for view models.
    /// </summary>
    public class ViewModelBase : PropertyObservable
    {
#if NICENIS_RT
        /// <summary>
        /// Gets the related dispatcher.
        /// </summary>
        /// <remarks>
        /// If this property is not overriden, the CoreApplication.MainView.CoreWindow.Dispatcher is returned.
        /// </remarks>
        public virtual RtDispatcher Dispatcher
#elif NICENIS_UWP
        /// <summary>
        /// Gets the related dispatcher.
        /// </summary>
        /// <remarks>
        /// If this property is not overriden, the CoreApplication.MainView.CoreWindow.Dispatcher is returned.
        /// </remarks>
        public virtual Windows.UI.Core.CoreDispatcher Dispatcher
#else
        /// <summary>
        /// Gets the related dispatcher.
        /// </summary>
        /// <remarks>
        /// If this property is not overriden, the Application.Current.Dispatcher is returned.
        /// </remarks>
        public virtual System.Windows.Threading.Dispatcher Dispatcher
#endif
        {
            get
            {
#if NICENIS_RT
                return RtWindow.Current.Dispatcher;
#elif NICENIS_UWP
                return Windows.UI.Core.CoreWindow.GetForCurrentThread().Dispatcher;
#else
                return Application.Current.Dispatcher;
#endif
            }
        }
    }
}
