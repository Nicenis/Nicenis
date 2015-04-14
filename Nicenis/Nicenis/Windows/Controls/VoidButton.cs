/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.06.21
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System.Windows;
using System.Windows.Controls;

namespace Nicenis.Windows.Controls
{
    /// <summary>
    /// Represents a button without any visual element.
    /// </summary>
    public class VoidButton : Button
    {
        #region Constructors

        /// <summary>
        /// The static constructor.
        /// </summary>
        static VoidButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VoidButton), new FrameworkPropertyMetadata(typeof(VoidButton)));
        }

        /// <summary>
        /// Initializes a new instance of the VoidButton class.
        /// </summary>
        public VoidButton() { }

        #endregion
    }
}
