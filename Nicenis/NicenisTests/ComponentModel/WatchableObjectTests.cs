/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.03.21
 * Version  $Id$
 *
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicenis.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NicenisTests.ComponentModel
{
    [TestClass]
    public class WatchableObjectTests
    {
        #region Sample class

        class Sample : WatchableObject
        {
            #region Raw Methods

            public new static bool IsEqualPropertyValue<T>(T left, T right)
            {
                return WatchableObject.IsEqualPropertyValue(left, right);
            }

            public new T GetProperty<T>(string propertyName, T defaultValue = default(T))
            {
                return base.GetProperty(propertyName, defaultValue);
            }

            public new T GetProperty<T>(string propertyName, Func<T> initializer)
            {
                return base.GetProperty(propertyName, initializer);
            }

            public new bool SetPropertyWithoutNotification<T>(string propertyName, T value)
            {
                return base.SetPropertyWithoutNotification(propertyName, value);
            }

            public new bool SetProperty<T>(string propertyName, T value, IEnumerable<string> affectedPropertyNames)
            {
                return base.SetProperty(propertyName, value, affectedPropertyNames);
            }

            public new bool SetProperty<T>(string propertyName, T value, string affectedPropertyName)
            {
                return base.SetProperty(propertyName, value, affectedPropertyName);
            }

            public new bool SetProperty<T>(string propertyName, T value)
            {
                return base.SetProperty(propertyName, value);
            }

            public new bool SetPropertyWithoutNotification<T>(ref T storage, T value)
            {
                return base.SetPropertyWithoutNotification(ref storage, value);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
            {
                return base.SetProperty(propertyName, ref storage, value, affectedPropertyNames);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value, string affectedPropertyName)
            {
                return base.SetProperty(propertyName, ref storage, value, affectedPropertyName);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value)
            {
                return base.SetProperty(propertyName, ref storage, value);
            }

            #endregion


            public int ValueProperty
            {
                get { return GetProperty(() => ValueProperty); }
                set { SetProperty(() => ValueProperty, value); }
            }

            public const int DefaultOfValuePropertyWithDefault = 10;

            public int ValuePropertyWithDefault
            {
                get { return GetProperty(() => ValuePropertyWithDefault, DefaultOfValuePropertyWithDefault); }
                set { SetProperty(() => ValuePropertyWithDefault, value); }
            }

            public int ValuePropertyWithoutNotification
            {
                get { return GetProperty(() => ValueProperty); }
                set { SetPropertyWithoutNotification(() => ValueProperty, value); }
            }

            int _valuePropertyWithLocalStorage;

            public int ValuePropertyWithLocalStorage
            {
                get { return _valuePropertyWithLocalStorage; }
                set { SetProperty(() => ValuePropertyWithLocalStorage, ref _valuePropertyWithLocalStorage, value); }
            }

            int _valuePropertyWithLocalStorageWithDefault = DefaultOfValuePropertyWithDefault;

            public int ValuePropertyWithLocalStorageWithDefault
            {
                get { return _valuePropertyWithLocalStorageWithDefault; }
                set { SetProperty(() => ValuePropertyWithLocalStorageWithDefault, ref _valuePropertyWithLocalStorageWithDefault, value); }
            }

            public string ReferenceProperty
            {
                get { return GetProperty(() => ReferenceProperty); }
                set { SetProperty(() => ReferenceProperty, value); }
            }

            public List<int> ReferencePropertyWithInitializer
            {
                get { return GetProperty(() => ReferencePropertyWithInitializer, () => new List<int>()); }
                set { SetProperty(() => ReferencePropertyWithInitializer, value); }
            }

            string _referencePropertyWithLocalStorage;

            public string ReferencePropertyWithLocalStorage
            {
                get { return _referencePropertyWithLocalStorage; }
                set { SetProperty(() => ReferencePropertyWithLocalStorage, ref _referencePropertyWithLocalStorage, value); }
            }

            public const int MaxAffectedPropertyCount = 20;

            #region TestProperty1 ~ TestProperty20

            public class TestPropertyType1 { }
            public class TestPropertyType2 { }
            public class TestPropertyType3 { }
            public class TestPropertyType4 { }
            public class TestPropertyType5 { }
            public class TestPropertyType6 { }
            public class TestPropertyType7 { }
            public class TestPropertyType8 { }
            public class TestPropertyType9 { }
            public class TestPropertyType10 { }
            public class TestPropertyType11 { }
            public class TestPropertyType12 { }
            public class TestPropertyType13 { }
            public class TestPropertyType14 { }
            public class TestPropertyType15 { }
            public class TestPropertyType16 { }
            public class TestPropertyType17 { }
            public class TestPropertyType18 { }
            public class TestPropertyType19 { }
            public class TestPropertyType20 { }

            public TestPropertyType1 TestProperty1
            {
                get { return GetProperty(() => TestProperty1); }
                set { SetProperty(() => TestProperty1, value); }
            }

            public TestPropertyType2 TestProperty2
            {
                get { return GetProperty(() => TestProperty2); }
                set { SetProperty(() => TestProperty2, value); }
            }

            public TestPropertyType3 TestProperty3
            {
                get { return GetProperty(() => TestProperty3); }
                set { SetProperty(() => TestProperty3, value); }
            }

            public TestPropertyType4 TestProperty4
            {
                get { return GetProperty(() => TestProperty4); }
                set { SetProperty(() => TestProperty4, value); }
            }

            public TestPropertyType5 TestProperty5
            {
                get { return GetProperty(() => TestProperty5); }
                set { SetProperty(() => TestProperty5, value); }
            }

            public TestPropertyType6 TestProperty6
            {
                get { return GetProperty(() => TestProperty6); }
                set { SetProperty(() => TestProperty6, value); }
            }

            public TestPropertyType7 TestProperty7
            {
                get { return GetProperty(() => TestProperty7); }
                set { SetProperty(() => TestProperty7, value); }
            }

            public TestPropertyType8 TestProperty8
            {
                get { return GetProperty(() => TestProperty8); }
                set { SetProperty(() => TestProperty8, value); }
            }

            public TestPropertyType9 TestProperty9
            {
                get { return GetProperty(() => TestProperty9); }
                set { SetProperty(() => TestProperty9, value); }
            }

            public TestPropertyType10 TestProperty10
            {
                get { return GetProperty(() => TestProperty10); }
                set { SetProperty(() => TestProperty10, value); }
            }

            public TestPropertyType11 TestProperty11
            {
                get { return GetProperty(() => TestProperty11); }
                set { SetProperty(() => TestProperty11, value); }
            }

            public TestPropertyType12 TestProperty12
            {
                get { return GetProperty(() => TestProperty12); }
                set { SetProperty(() => TestProperty12, value); }
            }

            public TestPropertyType13 TestProperty13
            {
                get { return GetProperty(() => TestProperty13); }
                set { SetProperty(() => TestProperty13, value); }
            }

            public TestPropertyType14 TestProperty14
            {
                get { return GetProperty(() => TestProperty14); }
                set { SetProperty(() => TestProperty14, value); }
            }

            public TestPropertyType15 TestProperty15
            {
                get { return GetProperty(() => TestProperty15); }
                set { SetProperty(() => TestProperty15, value); }
            }

            public TestPropertyType16 TestProperty16
            {
                get { return GetProperty(() => TestProperty16); }
                set { SetProperty(() => TestProperty16, value); }
            }

            public TestPropertyType17 TestProperty17
            {
                get { return GetProperty(() => TestProperty17); }
                set { SetProperty(() => TestProperty17, value); }
            }

            public TestPropertyType18 TestProperty18
            {
                get { return GetProperty(() => TestProperty18); }
                set { SetProperty(() => TestProperty18, value); }
            }

            public TestPropertyType19 TestProperty19
            {
                get { return GetProperty(() => TestProperty19); }
                set { SetProperty(() => TestProperty19, value); }
            }

            public TestPropertyType20 TestProperty20
            {
                get { return GetProperty(() => TestProperty20); }
                set { SetProperty(() => TestProperty20, value); }
            }

            #endregion

            #region AffectedPropertyTest Series

            public int AffectedPropertyTest20
            {
                get { return GetProperty(() => AffectedPropertyTest20); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest20,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19, () => TestProperty20
                    );
                }
            }

            public int AffectedPropertyTest19
            {
                get { return GetProperty(() => AffectedPropertyTest19); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest19,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19
                    );
                }
            }

            public int AffectedPropertyTest18
            {
                get { return GetProperty(() => AffectedPropertyTest18); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest18,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18
                    );
                }
            }

            public int AffectedPropertyTest17
            {
                get { return GetProperty(() => AffectedPropertyTest17); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest17,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17
                    );
                }
            }

            public int AffectedPropertyTest16
            {
                get { return GetProperty(() => AffectedPropertyTest16); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest16,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16
                    );
                }
            }

            public int AffectedPropertyTest15
            {
                get { return GetProperty(() => AffectedPropertyTest15); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest15,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15
                    );
                }
            }

            public int AffectedPropertyTest14
            {
                get { return GetProperty(() => AffectedPropertyTest14); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest14,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14
                    );
                }
            }

            public int AffectedPropertyTest13
            {
                get { return GetProperty(() => AffectedPropertyTest13); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest13,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13
                    );
                }
            }

            public int AffectedPropertyTest12
            {
                get { return GetProperty(() => AffectedPropertyTest12); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest12,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12
                    );
                }
            }

            public int AffectedPropertyTest11
            {
                get { return GetProperty(() => AffectedPropertyTest11); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest11,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11
                    );
                }
            }

            public int AffectedPropertyTest10
            {
                get { return GetProperty(() => AffectedPropertyTest10); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest10,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10
                    );
                }
            }

            public int AffectedPropertyTest9
            {
                get { return GetProperty(() => AffectedPropertyTest9); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest9,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9
                    );
                }
            }

            public int AffectedPropertyTest8
            {
                get { return GetProperty(() => AffectedPropertyTest8); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest8,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8
                    );
                }
            }

            public int AffectedPropertyTest7
            {
                get { return GetProperty(() => AffectedPropertyTest7); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest7,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7
                    );
                }
            }

            public int AffectedPropertyTest6
            {
                get { return GetProperty(() => AffectedPropertyTest6); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest6,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6
                    );
                }
            }

            public int AffectedPropertyTest5
            {
                get { return GetProperty(() => AffectedPropertyTest5); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest5,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5
                    );
                }
            }

            public int AffectedPropertyTest4
            {
                get { return GetProperty(() => AffectedPropertyTest4); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest4,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4
                    );
                }
            }

            public int AffectedPropertyTest3
            {
                get { return GetProperty(() => AffectedPropertyTest3); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest3,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3
                    );
                }
            }

            public int AffectedPropertyTest2
            {
                get { return GetProperty(() => AffectedPropertyTest2); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest2,
                        value,
                        () => TestProperty1, () => TestProperty2
                    );
                }
            }

            public int AffectedPropertyTest1
            {
                get { return GetProperty(() => AffectedPropertyTest1); }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTest1,
                        value,
                        () => TestProperty1
                    );
                }
            }

            #endregion

            #region OnPropertyChangedTest Series

            public int OnPropertyChangedTest20
            {
                get { return GetProperty(() => OnPropertyChangedTest20); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest20, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17, () => TestProperty18, () => TestProperty19, () => TestProperty20
                        );
                    }
                }
            }

            public int OnPropertyChangedTest19
            {
                get { return GetProperty(() => OnPropertyChangedTest19); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest19, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17, () => TestProperty18, () => TestProperty19
                        );
                    }
                }
            }

            public int OnPropertyChangedTest18
            {
                get { return GetProperty(() => OnPropertyChangedTest18); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest18, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17, () => TestProperty18
                        );
                    }
                }
            }

            public int OnPropertyChangedTest17
            {
                get { return GetProperty(() => OnPropertyChangedTest17); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest17, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                            () => TestProperty17
                        );
                    }
                }
            }

            public int OnPropertyChangedTest16
            {
                get { return GetProperty(() => OnPropertyChangedTest16); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest16, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16
                        );
                    }
                }
            }

            public int OnPropertyChangedTest15
            {
                get { return GetProperty(() => OnPropertyChangedTest15); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest15, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14, () => TestProperty15
                        );
                    }
                }
            }

            public int OnPropertyChangedTest14
            {
                get { return GetProperty(() => OnPropertyChangedTest14); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest14, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13, () => TestProperty14
                        );
                    }
                }
            }

            public int OnPropertyChangedTest13
            {
                get { return GetProperty(() => OnPropertyChangedTest13); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest13, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                            () => TestProperty13
                        );
                    }
                }
            }

            public int OnPropertyChangedTest12
            {
                get { return GetProperty(() => OnPropertyChangedTest12); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest12, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12
                        );
                    }
                }
            }

            public int OnPropertyChangedTest11
            {
                get { return GetProperty(() => OnPropertyChangedTest11); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest11, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10, () => TestProperty11
                        );
                    }
                }
            }

            public int OnPropertyChangedTest10
            {
                get { return GetProperty(() => OnPropertyChangedTest10); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest10, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9, () => TestProperty10
                        );
                    }
                }
            }

            public int OnPropertyChangedTest9
            {
                get { return GetProperty(() => OnPropertyChangedTest9); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest9, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                            () => TestProperty9
                        );
                    }
                }
            }

            public int OnPropertyChangedTest8
            {
                get { return GetProperty(() => OnPropertyChangedTest8); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest8, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8
                        );
                    }
                }
            }

            public int OnPropertyChangedTest7
            {
                get { return GetProperty(() => OnPropertyChangedTest7); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest7, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6, () => TestProperty7
                        );
                    }
                }
            }

            public int OnPropertyChangedTest6
            {
                get { return GetProperty(() => OnPropertyChangedTest6); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest6, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5, () => TestProperty6
                        );
                    }
                }
            }

            public int OnPropertyChangedTest5
            {
                get { return GetProperty(() => OnPropertyChangedTest5); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest5, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                            () => TestProperty5
                        );
                    }
                }
            }

            public int OnPropertyChangedTest4
            {
                get { return GetProperty(() => OnPropertyChangedTest4); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest4, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4
                        );
                    }
                }
            }

            public int OnPropertyChangedTest3
            {
                get { return GetProperty(() => OnPropertyChangedTest3); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest3, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2, () => TestProperty3
                        );
                    }
                }
            }

            public int OnPropertyChangedTest2
            {
                get { return GetProperty(() => OnPropertyChangedTest2); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest2, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1, () => TestProperty2
                        );
                    }
                }
            }

            public int OnPropertyChangedTest1
            {
                get { return GetProperty(() => OnPropertyChangedTest1); }
                set
                {
                    if (SetProperty(() => OnPropertyChangedTest1, value))
                    {
                        OnPropertyChanged
                        (
                            () => TestProperty1
                        );
                    }
                }
            }

            #endregion

            #region AffectedPropertyTestInSetPropertyWithLocalStorage Series

            int _affectedPropertyTestInSetPropertyWithLocalStorage20;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage20
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage20; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage20,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage20,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19, () => TestProperty20
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage19;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage19
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage19; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage19,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage19,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18, () => TestProperty19
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage18;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage18
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage18; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage18,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage18,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17, () => TestProperty18
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage17;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage17
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage17; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage17,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage17,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16,
                        () => TestProperty17
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage16;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage16
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage16; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage16,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage16,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15, () => TestProperty16
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage15;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage15
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage15; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage15,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage15,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14, () => TestProperty15
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage14;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage14
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage14; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage14,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage14,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13, () => TestProperty14
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage13;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage13
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage13; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage13,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage13,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12,
                        () => TestProperty13
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage12;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage12
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage12; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage12,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage12,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11, () => TestProperty12
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage11;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage11
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage11; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage11,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage11,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10, () => TestProperty11
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage10;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage10
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage10; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage10,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage10,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9, () => TestProperty10
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage9;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage9
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage9; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage9,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage9,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8,
                        () => TestProperty9
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage8;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage8
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage8; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage8,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage8,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7, () => TestProperty8
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage7;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage7
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage7; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage7,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage7,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6, () => TestProperty7
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage6;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage6
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage6; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage6,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage6,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5, () => TestProperty6
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage5;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage5
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage5; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage5,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage5,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4,
                        () => TestProperty5
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage4;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage4
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage4; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage4,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage4,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3, () => TestProperty4
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage3;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage3
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage3; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage3,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage3,
                        value,
                        () => TestProperty1, () => TestProperty2, () => TestProperty3
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage2;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage2
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage2; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage2,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage2,
                        value,
                        () => TestProperty1, () => TestProperty2
                    );
                }
            }

            int _affectedPropertyTestInSetPropertyWithLocalStorage1;

            public int AffectedPropertyTestInSetPropertyWithLocalStorage1
            {
                get { return _affectedPropertyTestInSetPropertyWithLocalStorage1; }
                set
                {
                    SetProperty
                    (
                        () => AffectedPropertyTestInSetPropertyWithLocalStorage1,
                        ref _affectedPropertyTestInSetPropertyWithLocalStorage1,
                        value,
                        () => TestProperty1
                    );
                }
            }

            #endregion
        }

        #endregion


        #region SetPropertyByReflection

        private void SetPropertyByReflection(Sample sample, string propertyName, object value)
        {
            Assert.IsNotNull(sample);
            Assert.IsFalse(string.IsNullOrWhiteSpace(propertyName));

            sample.GetType().InvokeMember
            (
                name: propertyName,
                invokeAttr: BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty,
                binder: null,
                target: sample,
                args: new object[] { value }
            );
        }

        #endregion


        #region IsEqualPropertyValue Related

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_same_values()
        {
            // arrange
            const int left = 10;
            const int right = 10;
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_false_for_different_values()
        {
            // arrange
            const int left = 10;
            const int right = 20;
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_same_references()
        {
            // arrange
            Sample left = new Sample();
            Sample right = left;
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_false_for_different_references()
        {
            // arrange
            Sample left = new Sample();
            Sample right = new Sample();
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_same_strings()
        {
            // arrange
            string left = "Test";
            string right = "Test";
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_different_strings()
        {
            // arrange
            string left = "Test";
            string right = "Haha";
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_false_for_null_and_non_null()
        {
            // arrange
            Sample left = null;
            Sample right = new Sample();
            const bool expectedEquality = false;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        [TestMethod]
        public void IsEqualPropertyValue_must_return_true_for_null_values()
        {
            // arrange
            Sample left = null;
            Sample right = null;
            const bool expectedEquality = true;

            // act
            bool result = Sample.IsEqualPropertyValue(left, right);

            // assert
            Assert.AreEqual(expectedEquality, result);
        }

        #endregion


        #region GetProperty Parameter Check Related

        [TestMethod]
        public void GetProperty_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty(propertyName, () => "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName, () => "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName, () => "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void GetProperty_with_initializer_must_throw_exception_if_null_initializer_is_passed()
        {
            // arrange
            string propertyName = "propertyName";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.GetProperty<string>(propertyName, initializer: null);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "initializer");
        }

        #endregion


        #region SetPropertyWithoutNotification Parameter Check Related

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyWithoutNotification(propertyName, "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        #endregion


        #region SetProperty Parameter Check Related

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "Test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[0];
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[] { "test", null };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_empty_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[] { "test", "" };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_whitespace_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            IEnumerable<string> affectedPropertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "Test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            string affectedPropertyName = null;
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            string affectedPropertyName = "";
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_affected_property_name_is_whitespace()
        {
            // arrange
            string propertyName = "ValueProperty";
            string affectedPropertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }


        [TestMethod]
        public void SetProperty_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_must_throw_exception_if_property_does_not_exist()
        {
            // arrange
            string propertyName = "NotExistedPropertyName";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, "Test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsNotNull(exception);
            StringAssert.Contains(exception.Message, propertyName);
        }

        #endregion


        #region SetProperty with local storage Parameter Check Related

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string storage = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string storage = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string storage = null;
            IEnumerable<string> affectedPropertyNames = new string[] { "affected" };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[0];
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyNames");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", null };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_empty_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", "" };
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_whitespace_string()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string storage = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string storage = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string storage = null;
            string affectedPropertyName = "affected";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test", affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_null()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            string affectedPropertyName = null;
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_empty()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            string affectedPropertyName = "";
            Sample sample = new Sample();

            // act
            sample.SetProperty(propertyName, ref storage, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_affected_property_name_is_whitespace()
        {
            // arrange
            string propertyName = "ValueProperty";
            int storage = 0;
            string affectedPropertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }


        [TestMethod]
        public void SetProperty_with_local_storage_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            string storage = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            string storage = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            string storage = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(propertyName, ref storage, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        #endregion


        [TestMethod]
        public void Uninitialized_value_property_must_return_zero()
        {
            // arrange
            Sample sample = new Sample();

            // act
            int property = sample.ValueProperty;

            // assert
            Assert.AreEqual(0, property);
        }

        [TestMethod]
        public void Uninitialized_value_property_with_default_must_return_default()
        {
            // arrange
            Sample sample = new Sample();

            // act
            int property = sample.ValuePropertyWithDefault;

            // assert
            Assert.AreEqual(Sample.DefaultOfValuePropertyWithDefault, property);
        }

        [TestMethod]
        public void Set_value_property_and_get_it()
        {
            // arrange
            const int expected = 10;
            Sample sample = new Sample();

            // act
            sample.ValueProperty = expected;
            int property = sample.ValueProperty;

            // assert
            Assert.AreEqual(expected, property);
        }

        [TestMethod]
        public void Set_value_property_with_local_storage_and_get_it()
        {
            // arrange
            const int expected = 10;
            Sample sample = new Sample();

            // act
            sample.ValuePropertyWithLocalStorage = expected;
            int property = sample.ValuePropertyWithLocalStorage;

            // assert
            Assert.AreEqual(expected, property);
        }

        [TestMethod]
        public void SetPropertyWithoutNotification_must_not_raise_PropertyChanged()
        {
            // arrange
            const int testInt = 100;
            int propertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, __) => propertyChangedCount++;

            // act
            sample.ValuePropertyWithoutNotification = testInt;
            sample.ValuePropertyWithoutNotification = testInt;

            // assert
            Assert.AreEqual(0, propertyChangedCount);
        }

        [TestMethod]
        public void Uninitialized_reference_property_must_return_null()
        {
            // arrange
            Sample sample = new Sample();

            // act
            string property = sample.ReferenceProperty;

            // assert
            Assert.AreEqual(null, property);
        }

        [TestMethod]
        public void Set_reference_property_and_get_it()
        {
            // arrange
            const string expected = "Test";
            Sample sample = new Sample();

            // act
            sample.ReferenceProperty = expected;
            string property = sample.ReferenceProperty;

            // assert
            Assert.AreEqual(expected, property);
        }

        [TestMethod]
        public void Uninitialized_reference_property_with_initializer_must_return_initialized_value()
        {
            // arrange
            Sample sample = new Sample();

            // act
            List<int> property = sample.ReferencePropertyWithInitializer;

            // assert
            Assert.IsNotNull(property);
        }

        [TestMethod]
        public void SetProperty_initializer_must_not_be_called_twice()
        {
            // arrange
            Sample sample = new Sample();

            // act
            List<int> property = sample.ReferencePropertyWithInitializer;
            List<int> property2 = sample.ReferencePropertyWithInitializer;

            // assert
            Assert.AreEqual(property, property2);
        }

        [TestMethod]
        public void SetProperty_initializer_must_not_be_called_if_property_is_initialized()
        {
            // arrange
            Sample sample = new Sample();

            // act
            sample.ReferencePropertyWithInitializer = null;
            List<int> property = sample.ReferencePropertyWithInitializer;

            // assert
            Assert.IsNull(property);
        }

        [TestMethod]
        public void SetProperty_must_not_interfere_other_property()
        {
            // arrange
            const int testInt = 1;
            const int testInt2 = 2;

            Sample sample = new Sample();

            // act
            sample.ValueProperty = testInt;
            sample.ValuePropertyWithDefault = testInt2;

            int propertyValue = sample.ValueProperty;
            int propertyValue2 = sample.ValuePropertyWithDefault;

            // assert
            Assert.AreEqual(testInt, propertyValue);
            Assert.AreEqual(testInt2, propertyValue2);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_not_interfere_other_property()
        {
            // arrange
            const int testInt = 1;
            const int testInt2 = 2;

            Sample sample = new Sample();

            // act
            sample.ValuePropertyWithLocalStorage = testInt;
            sample.ValuePropertyWithLocalStorageWithDefault = testInt2;

            int propertyValue = sample.ValuePropertyWithLocalStorage;
            int propertyValue2 = sample.ValuePropertyWithLocalStorageWithDefault;

            // assert
            Assert.AreEqual(testInt, propertyValue);
            Assert.AreEqual(testInt2, propertyValue2);
        }

        [TestMethod]
        public void PropertyChanged_must_be_raised_per_changed_property()
        {
            // arrange
            const int testInt = 1000;
            const string testString = "test";

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;
            int referencePropertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == "ValueProperty")
                    valuePropertyChangedCount++;

                if (e.PropertyName == "ReferenceProperty")
                    referencePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.ValueProperty = testInt;
            sample.ReferenceProperty = testString;

            // assert
            Assert.AreEqual(2, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
            Assert.AreEqual(1, referencePropertyChangedCount);
        }

        [TestMethod]
        public void PropertyChanged_must_not_be_raised_if_property_is_not_changed()
        {
            // arrange
            const int testInt = 1000;

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == "ValueProperty")
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.ValueProperty = testInt;
            sample.ValueProperty = testInt;

            // assert
            Assert.AreEqual(1, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_affected_properties_specified()
        {
            // arrange
            const int testInt = 1000;

            List<string> changedPropertyNames = new List<string>();

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) => changedPropertyNames.Add(e.PropertyName);

            for (int i = 0; i < Sample.MaxAffectedPropertyCount; i++)
            {
                changedPropertyNames.Clear();
                int affectedPropertyCount = i + 1;
                string targetPropertyName = "AffectedPropertyTest" + affectedPropertyCount;

                // act
                SetPropertyByReflection(sample, targetPropertyName, testInt);
                SetPropertyByReflection(sample, targetPropertyName, testInt);

                // assert
                Assert.AreEqual(affectedPropertyCount + 1, changedPropertyNames.Count());
                Assert.IsTrue(changedPropertyNames.Count() == changedPropertyNames.Distinct().Count());
                Assert.IsTrue(changedPropertyNames.Contains(targetPropertyName));

                for (int j = 0; j < affectedPropertyCount; j++)
                    Assert.IsTrue(changedPropertyNames.Contains("TestProperty" + (j + 1)));
            }
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_affected_properties_specified()
        {
            // arrange
            const int testInt = 1000;

            List<string> changedPropertyNames = new List<string>();

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) => changedPropertyNames.Add(e.PropertyName);

            for (int i = 0; i < Sample.MaxAffectedPropertyCount; i++)
            {
                changedPropertyNames.Clear();
                int affectedPropertyCount = i + 1;
                string targetPropertyName = "AffectedPropertyTestInSetPropertyWithLocalStorage" + affectedPropertyCount;

                // act
                SetPropertyByReflection(sample, targetPropertyName, testInt);
                SetPropertyByReflection(sample, targetPropertyName, testInt);

                // assert
                Assert.AreEqual(affectedPropertyCount + 1, changedPropertyNames.Count());
                Assert.IsTrue(changedPropertyNames.Count() == changedPropertyNames.Distinct().Count());
                Assert.IsTrue(changedPropertyNames.Contains(targetPropertyName));

                for (int j = 0; j < affectedPropertyCount; j++)
                    Assert.IsTrue(changedPropertyNames.Contains("TestProperty" + (j + 1)));
            }
        }

        [TestMethod]
        public void OnPropertyChanged_must_raise_PropertyChanged_for_specified_properties()
        {
            // arrange
            const int maxPropertyCount = 20;
            const int testInt = 1000;

            List<string> changedPropertyNames = new List<string>();

            Sample sample = new Sample();
            sample.PropertyChanged += (_, e) => changedPropertyNames.Add(e.PropertyName);

            for (int i = 0; i < maxPropertyCount; i++)
            {
                changedPropertyNames.Clear();
                int propertyCount = i + 1;
                string targetPropertyName = "OnPropertyChangedTest" + propertyCount;

                // act
                SetPropertyByReflection(sample, targetPropertyName, testInt);
                SetPropertyByReflection(sample, targetPropertyName, testInt);

                // assert
                Assert.AreEqual(propertyCount + 1, changedPropertyNames.Count());
                Assert.IsTrue(changedPropertyNames.Count() == changedPropertyNames.Distinct().Count());
                Assert.IsTrue(changedPropertyNames.Contains(targetPropertyName));

                for (int j = 0; j < propertyCount; j++)
                    Assert.IsTrue(changedPropertyNames.Contains("TestProperty" + (j + 1)));
            }
        }
    }
}
