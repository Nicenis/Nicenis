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

#if NICENIS_UWP
using TheWindow = Windows.UI.Xaml.Window;
using TheDispatcher = Windows.UI.Core.CoreDispatcher;
#endif

namespace Nicenis.ViewModels
{
    /// <summary>
    /// Provides base implementation for view models.
    /// </summary>
    public class ViewModelBase : PropertyObservable
    {
#if NICENIS_UWP
        /// <summary>
        /// Gets the related dispatcher.
        /// </summary>
        /// <remarks>
        /// If this property is not overridden, the Windows.UI.Xaml.Window.Current.Dispatcher is returned.
        /// </remarks>
        public virtual TheDispatcher Dispatcher
#else
        /// <summary>
        /// Gets the related dispatcher.
        /// </summary>
        /// <remarks>
        /// If this property is not overridden, the Application.Current.Dispatcher is returned.
        /// </remarks>
        public virtual System.Windows.Threading.Dispatcher Dispatcher
#endif
        {
            get
            {
#if NICENIS_UWP
                return TheWindow.Current.Dispatcher;
#else
                return Application.Current.Dispatcher;
#endif
            }
        }
    }
}
