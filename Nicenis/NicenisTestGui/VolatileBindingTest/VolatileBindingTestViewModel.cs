/*
 * Author   JO Hyeong-Ryeol
 * Since    2019.01.23
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2019 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.ComponentModel;

namespace NicenisTestGui.VolatileBindingTest
{
    public class VolatileBindingTestViewModel : PropertyObservable
    {
        VolatileBindingTestEnum _enum = VolatileBindingTestEnum.Welcome;

        public VolatileBindingTestEnum Enum
        {
            get { return _enum; }
            set { SetProperty(ref _enum, value); }
        }
    }
}
