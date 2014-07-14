/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.05.29
 * Version  $Id$
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

namespace Nicenis.ComponentModel
{
    /// <summary>
    /// Represents an object that can be frozen. If the object is frozen, it is immutable.
    /// </summary>
    internal interface IFreezable
    {
        /// <summary>
        /// Gets a value that indicates whether the object is currently modifiable.
        /// </summary>
        bool IsFrozen { get; }

        /// <summary>
        /// Makes the current object unmodifiable and sets its IsFrozen property to true.
        /// </summary>
        void Freeze();
    }
}
