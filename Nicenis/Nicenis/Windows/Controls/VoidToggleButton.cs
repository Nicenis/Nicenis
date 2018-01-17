/*
 * Author   JO Hyeong-Ryeol
 * Since    2018.01.18
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2018 JO Hyeong-Ryeol. All rights reserved.
 */

using System.Windows;
using System.Windows.Controls.Primitives;

namespace Nicenis.Windows.Controls
{
    /// <summary>
    /// Represents a toggle button without any visual element.
    /// </summary>
    public class VoidToggleButton : ToggleButton
    {
        #region Constructors

        /// <summary>
        /// The static constructor.
        /// </summary>
        static VoidToggleButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VoidToggleButton), new FrameworkPropertyMetadata(typeof(VoidToggleButton)));
        }

        /// <summary>
        /// Initializes a new instance of the VoidToggleButton class.
        /// </summary>
        public VoidToggleButton() { }

        #endregion
    }
}
