﻿/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.03.21
 *
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

#if NICENIS_UWP
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using Nicenis.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml.Serialization;

namespace NicenisTests.ComponentModel
{
    #region Related Types

    public class PropertyObservableSample
    {
        public static string PublicStaticProperty { get; set; }
        public string PublicProperty { get; set; }
    }

    public class PropertyObservableTestsBase : PropertyObservable
    {
        public virtual string PublicOverridenProperty { get; set; }
    }

    #endregion


    [TestClass]
    public class PropertyObservableTests : PropertyObservableTestsBase
    {
        #region GetProperty Test Related

        [TestMethod]
        public void GetProperty_Returns_Default_Value_If_It_Is_Not_Set()
        {
            // arrange
            const string testPropertyName = "propertyName";

            // act
            int property = GetProperty<int>(testPropertyName);

            // assert
            Assert.AreEqual(default(int), property);
        }

        [TestMethod]
        public void GetProperty_Returns_Default_Reference_If_It_Is_Not_Set()
        {
            // arrange
            const string testPropertyName = "propertyName";

            // act
            string property = GetProperty<string>(testPropertyName);

            // assert
            Assert.AreEqual(default(string), property);
        }

        [TestMethod]
        public void GetProperty_Returns_Initialized_Value_If_It_Is_Not_Set()
        {
            // arrange
            const int initializedValue = 10;
            const string testPropertyName = "propertyName";

            // act
            int property = GetProperty(testPropertyName, () => initializedValue);

            // assert
            Assert.AreEqual(initializedValue, property);
        }

        [TestMethod]
        public void GetProperty_Does_Not_Call_Initializer_Twice()
        {
            // arrange
            const int initializedValue = 10;
            const int expectedInitializerCallCount = 1;
            const string testPropertyName = "propertyName";
            int initializerCallCount = 0;
            Func<int> initializer = () =>
            {
                initializerCallCount++;
                return initializedValue;
            };

            // act
            GetProperty(testPropertyName, initializer);
            GetProperty(testPropertyName, initializer);

            // assert
            Assert.AreEqual(initializerCallCount, expectedInitializerCallCount);
        }

        [TestMethod]
        public void GetProperty_Does_Not_Call_Initializer_If_It_Is_Set()
        {
            // arrange
            const int testValue = 100;
            const int initializedValue = 10;
            const int expectedInitializerCallCount = 0;
            const string testPropertyName = "propertyName";
            int initializerCallCount = 0;

            // act
            SetProperty(testValue, testPropertyName);
            GetProperty(testPropertyName, () =>
            {
                initializerCallCount++;
                return initializedValue;
            });

            // assert
            Assert.AreEqual(initializerCallCount, expectedInitializerCallCount);
        }

        [TestMethod]
        public void GetProperty_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "GetProperty_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed";

            // act
            SetProperty(testValue, testPropertyName);
            int value = GetProperty<int>();

            // assert
            Assert.AreEqual(testValue, value);
        }

        #endregion


        #region SetProperty Test Related

        [TestMethod]
        public void SetProperty_Support_Set_A_Value()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";

            // act
            SetProperty(testValue, testPropertyName);
            int value = GetProperty<int>(testPropertyName);

            // assert
            Assert.AreEqual(value, testValue);
        }

        [TestMethod]
        public void SetProperty_Calls_OnChanging_Callback_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int onChangingCount = 0;
            string propertyNameInChanging = null;
            string propertyNameInChanging2 = null;
            int oldValue = -1, newValue = -1;
            int oldValue2 = -1, newValue2 = -1;

            // act
            SetProperty(testValue, testPropertyName, onChanging: p =>
            {
                propertyNameInChanging = p.PropertyName;
                oldValue = p.OldValue;
                newValue = p.NewValue;
                onChangingCount++;
            });
            SetProperty(testValue2, testPropertyName, onChanging: p =>
            {
                propertyNameInChanging2 = p.PropertyName;
                oldValue2 = p.OldValue;
                newValue2 = p.NewValue;
                onChangingCount++;
            });

            // assert
            Assert.IsTrue(onChangingCount == 2);
            Assert.IsTrue(propertyNameInChanging == testPropertyName);
            Assert.IsTrue(propertyNameInChanging2 == testPropertyName);
            Assert.IsTrue(oldValue == 0);
            Assert.IsTrue(newValue == testValue);
            Assert.IsTrue(oldValue2 == testValue);
            Assert.IsTrue(newValue2 == testValue2);
        }

        [TestMethod]
        public void SetProperty_OnChanging_Callback_Can_Override_NewValue()
        {
            // arrange
            const int testValue = 100;
            const int overridenTestValue = 200;
            const string testPropertyName = "propertyName";

            // act
            SetProperty(testValue, testPropertyName, onChanging: p => p.NewValue = overridenTestValue);
            int value = GetProperty<int>(testPropertyName);

            // assert
            Assert.IsTrue(value == overridenTestValue);
        }

        [TestMethod]
        public void SetProperty_Does_Not_Call_OnChanging_Callback_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int onChangingCount = 0;

            // act
            SetProperty(testValue, testPropertyName, onChanging: p => onChangingCount++);
            SetProperty(testValue, testPropertyName, onChanging: p => onChangingCount++);

            // assert
            Assert.IsTrue(onChangingCount == 1);
        }

        [TestMethod]
        public void SetProperty_Calls_OnChanged_Callback_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int onChangedCount = 0;
            string propertyNameInChanging = null;
            string propertyNameInChanging2 = null;
            int oldValue = -1, newValue = -1;
            int oldValue2 = -1, newValue2 = -1;

            // act
            SetProperty(testValue, testPropertyName, onChanged: p =>
            {
                propertyNameInChanging = p.PropertyName;
                oldValue = p.OldValue;
                newValue = p.NewValue;
                onChangedCount++;
            });
            SetProperty(testValue2, testPropertyName, onChanged: p =>
            {
                propertyNameInChanging2 = p.PropertyName;
                oldValue2 = p.OldValue;
                newValue2 = p.NewValue;
                onChangedCount++;
            });

            // assert
            Assert.IsTrue(onChangedCount == 2);
            Assert.IsTrue(propertyNameInChanging == testPropertyName);
            Assert.IsTrue(propertyNameInChanging2 == testPropertyName);
            Assert.IsTrue(oldValue == 0);
            Assert.IsTrue(newValue == testValue);
            Assert.IsTrue(oldValue2 == testValue);
            Assert.IsTrue(newValue2 == testValue2);
        }

        [TestMethod]
        public void SetProperty_Does_Not_Call_OnChanged_Callback_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int onChangedCount = 0;

            // act
            SetProperty(testValue, testPropertyName, onChanged: p => onChangedCount++);
            SetProperty(testValue, testPropertyName, onChanged: p => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Calls_OnChanged_Callback_After_OnChanging_Callback()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            double? changingTicks = null;
            double? changedTicks = null;

            // act
            SetProperty(testValue, testPropertyName, onChanging: p =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            },
            onChanged: p =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changedTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            });

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(changedTicks != null);
            Assert.IsTrue(changingTicks < changedTicks);
        }


        [TestMethod]
        public void SetProperty_Calls_PropertyValueChanging_EventHandler_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int changingCount = 0;
            string propertyNameInChanging = null;
            int oldValue = -1, newValue = -1;

            // act
            PropertyValueChanging += (_, p) =>
            {
                propertyNameInChanging = p.PropertyName;
                oldValue = (int)p.OldValue;
                newValue = (int)p.NewValue;
                changingCount++;
            };

            SetProperty(testValue, testPropertyName);
            SetProperty(testValue2, testPropertyName);

            // assert
            Assert.IsTrue(changingCount == 2);
            Assert.IsTrue(propertyNameInChanging == testPropertyName);
            Assert.IsTrue(oldValue == testValue);
            Assert.IsTrue(newValue == testValue2);
        }

        [TestMethod]
        public void SetProperty_PropertyValueChanging_EventHandler_Can_Override_NewValue()
        {
            // arrange
            const int testValue = 100;
            const int overridenTestValue = 200;
            const string testPropertyName = "propertyName";

            // act
            PropertyValueChanging += (_, p) => p.NewValue = overridenTestValue;
            SetProperty(testValue, testPropertyName);
            int value = GetProperty<int>(testPropertyName);

            // assert
            Assert.IsTrue(value == overridenTestValue);
        }

        [TestMethod]
        public void SetProperty_Does_Not_Call_PropertyValueChanging_EventHandler_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int changingCount = 0;

            // act
            PropertyValueChanging += (_, p) => changingCount++;
            SetProperty(testValue, testPropertyName);
            SetProperty(testValue, testPropertyName);

            // assert
            Assert.IsTrue(changingCount == 1);
        }

        [TestMethod]
        public void SetProperty_Calls_PropertyValueChanged_EventHandler_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int changedCount = 0;
            string propertyNameInChanged = null;
            int oldValue = -1, newValue = -1;

            // act
            PropertyValueChanged += (_, p) =>
            {
                propertyNameInChanged = p.PropertyName;
                oldValue = (int)p.OldValue;
                newValue = (int)p.NewValue;
                changedCount++;
            };

            SetProperty(testValue, testPropertyName);
            SetProperty(testValue2, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 2);
            Assert.IsTrue(propertyNameInChanged == testPropertyName);
            Assert.IsTrue(oldValue == testValue);
            Assert.IsTrue(newValue == testValue2);
        }

        [TestMethod]
        public void SetProperty_Does_Not_Call_PropertyValueChanged_EventHandler_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int changedCount = 0;

            // act
            PropertyValueChanged += (_, p) => changedCount++;
            SetProperty(testValue, testPropertyName);
            SetProperty(testValue, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Calls_PropertyValueChanged_EventHandler_After_PropertyValueChanging_EventHandler()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            double? changingTicks = null;
            double? changedTicks = null;

            // act
            PropertyValueChanging += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            PropertyValueChanged += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changedTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            SetProperty(testValue, testPropertyName);

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(changedTicks != null);
            Assert.IsTrue(changingTicks < changedTicks);
        }


        [TestMethod]
        public void SetProperty_Calls_PropertyChanged_EventHandler_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int changedCount = 0;
            string propertyNameInChanged = null;

            // act
            PropertyChanged += (_, p) =>
            {
                propertyNameInChanged = p.PropertyName;
                changedCount++;
            };

            SetProperty(testValue, testPropertyName);
            SetProperty(testValue2, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 2);
            Assert.IsTrue(propertyNameInChanged == testPropertyName);
        }

        [TestMethod]
        public void SetProperty_Does_Not_Call_PropertyChanged_EventHandler_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int changedCount = 0;

            // act
            PropertyChanged += (_, p) => changedCount++;
            SetProperty(testValue, testPropertyName);
            SetProperty(testValue, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Calls_PropertyChanged_EventHandler_After_PropertyValueChanging_EventHandler()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            double? changingTicks = null;
            double? changedTicks = null;

            // act
            PropertyValueChanging += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            PropertyChanged += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changedTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            SetProperty(testValue, testPropertyName);

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(changedTicks != null);
            Assert.IsTrue(changingTicks < changedTicks);
        }


        [TestMethod]
        public void SetProperty_Calls_PropertyChanged_EventHandler_For_Related_Property_Names()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            string[] testRelated = new string[]
            {
                "RelatedProperty1",
                "RelatedProperty2",
                "RelatedProperty3",
            };
            List<string> related = new List<string>();

            // act
            PropertyChanged += (_, p) =>
            {
                if (p.PropertyName != testPropertyName)
                    related.Add(p.PropertyName);
            };
            SetProperty(testValue, testPropertyName, related: testRelated);

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(testRelated, related));
        }


        [TestMethod]
        public void SetProperty_Calls_OnChanging_OnChanged_Callback_Even_If_IsHidden_Is_True()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int onChangingCount = 0;
            int onChangedCount = 0;

            // act
            SetProperty(testValue, testPropertyName, onChanging: p => onChangingCount++, onChanged: p => onChangedCount++, isHidden: true);

            // assert
            Assert.IsTrue(onChangingCount == 1);
            Assert.IsTrue(onChangedCount == 1);
        }


        [TestMethod]
        public void SetProperty_Does_Not_Call_PropertyValueChanging_PropertyValueChanged_PropertyChanged_EventHandler_If_IsHidden_Is_True()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            string[] testRelated = new string[]
            {
                "RelatedProperty1",
                "RelatedProperty2",
                "RelatedProperty3",
            };
            List<string> related = new List<string>();
            string propertyNameInChanging = null;
            string propertyNameInChanged = null;

            // act
            PropertyValueChanging += (_, p) => propertyNameInChanging = p.PropertyName;
            PropertyValueChanged += (_, p) => propertyNameInChanged = p.PropertyName;
            PropertyChanged += (_, p) =>
            {
                if (p.PropertyName != testPropertyName)
                    related.Add(p.PropertyName);
            };
            SetProperty(testValue, testPropertyName, related: testRelated, isHidden: true);

            // assert
            Assert.IsTrue(propertyNameInChanging == null);
            Assert.IsTrue(propertyNameInChanged == null);
            Assert.IsFalse(related.Any());
        }


        [TestMethod]
        public void SetProperty_Calls_OnChanging_Callback_After_PropertyValueChanging_EventHandler()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            double? changingTicks = null;
            double? onChangingTicks = null;

            // act
            PropertyValueChanging += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            SetProperty(testValue, testPropertyName, onChanging: p =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    onChangingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            });

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(onChangingTicks != null);
            Assert.IsTrue(changingTicks < onChangingTicks);
        }


        [TestMethod]
        public void SetProperty_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "SetProperty_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed";
            string propertyNameInChanged = null;

            // act
            PropertyChanged += (_, p) => propertyNameInChanged = p.PropertyName;
            SetProperty(testValue);

            // assert
            Assert.AreEqual(testPropertyName, propertyNameInChanged);
        }

        #endregion


        #region SetProperty with Local Field Test Related

        [TestMethod]
        public void SetProperty_Local_Support_Set_A_Value()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;

            // act
            SetProperty(ref value, testValue, testPropertyName);

            // assert
            Assert.AreEqual(value, testValue);
        }

        [TestMethod]
        public void SetProperty_Local_Calls_OnChanging_Callback_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int value = 0;
            int onChangingCount = 0;
            string propertyNameInChanging = null;
            string propertyNameInChanging2 = null;
            int oldValue = -1, newValue = -1;
            int oldValue2 = -1, newValue2 = -1;

            // act
            SetProperty(ref value, testValue, testPropertyName, onChanging: p =>
            {
                propertyNameInChanging = p.PropertyName;
                oldValue = p.OldValue;
                newValue = p.NewValue;
                onChangingCount++;
            });
            SetProperty(ref value, testValue2, testPropertyName, onChanging: p =>
            {
                propertyNameInChanging2 = p.PropertyName;
                oldValue2 = p.OldValue;
                newValue2 = p.NewValue;
                onChangingCount++;
            });

            // assert
            Assert.IsTrue(onChangingCount == 2);
            Assert.IsTrue(propertyNameInChanging == testPropertyName);
            Assert.IsTrue(propertyNameInChanging2 == testPropertyName);
            Assert.IsTrue(oldValue == 0);
            Assert.IsTrue(newValue == testValue);
            Assert.IsTrue(oldValue2 == testValue);
            Assert.IsTrue(newValue2 == testValue2);
        }

        [TestMethod]
        public void SetProperty_Local_OnChanging_Callback_Can_Override_NewValue()
        {
            // arrange
            const int testValue = 100;
            const int overridenTestValue = 200;
            const string testPropertyName = "propertyName";
            int value = 0;

            // act
            SetProperty(ref value, testValue, testPropertyName, onChanging: p => p.NewValue = overridenTestValue);

            // assert
            Assert.IsTrue(value == overridenTestValue);
        }

        [TestMethod]
        public void SetProperty_Local_Does_Not_Call_OnChanging_Callback_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            int onChangingCount = 0;

            // act
            SetProperty(ref value, testValue, testPropertyName, onChanging: p => onChangingCount++);
            SetProperty(ref value, testValue, testPropertyName, onChanging: p => onChangingCount++);

            // assert
            Assert.IsTrue(onChangingCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_Calls_OnChanged_Callback_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int value = 0;
            int onChangedCount = 0;
            string propertyNameInChanging = null;
            string propertyNameInChanging2 = null;
            int oldValue = -1, newValue = -1;
            int oldValue2 = -1, newValue2 = -1;

            // act
            SetProperty(ref value, testValue, testPropertyName, onChanged: p =>
            {
                propertyNameInChanging = p.PropertyName;
                oldValue = p.OldValue;
                newValue = p.NewValue;
                onChangedCount++;
            });
            SetProperty(ref value, testValue2, testPropertyName, onChanged: p =>
            {
                propertyNameInChanging2 = p.PropertyName;
                oldValue2 = p.OldValue;
                newValue2 = p.NewValue;
                onChangedCount++;
            });

            // assert
            Assert.IsTrue(onChangedCount == 2);
            Assert.IsTrue(propertyNameInChanging == testPropertyName);
            Assert.IsTrue(propertyNameInChanging2 == testPropertyName);
            Assert.IsTrue(oldValue == 0);
            Assert.IsTrue(newValue == testValue);
            Assert.IsTrue(oldValue2 == testValue);
            Assert.IsTrue(newValue2 == testValue2);
        }

        [TestMethod]
        public void SetProperty_Local_Does_Not_Call_OnChanged_Callback_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            int onChangedCount = 0;

            // act
            SetProperty(ref value, testValue, testPropertyName, onChanged: p => onChangedCount++);
            SetProperty(ref value, testValue, testPropertyName, onChanged: p => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_Calls_OnChanged_Callback_After_OnChanging_Callback()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            double? changingTicks = null;
            double? changedTicks = null;
            int value = 0;

            // act
            SetProperty(ref value, testValue, testPropertyName, onChanging: p =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            },
            onChanged: p =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changedTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            });

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(changedTicks != null);
            Assert.IsTrue(changingTicks < changedTicks);
        }


        [TestMethod]
        public void SetProperty_Local_Calls_PropertyValueChanging_EventHandler_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int value = 0;
            int changingCount = 0;
            string propertyNameInChanging = null;
            int oldValue = -1, newValue = -1;

            // act
            PropertyValueChanging += (_, p) =>
            {
                propertyNameInChanging = p.PropertyName;
                oldValue = (int)p.OldValue;
                newValue = (int)p.NewValue;
                changingCount++;
            };

            SetProperty(ref value, testValue, testPropertyName);
            SetProperty(ref value, testValue2, testPropertyName);

            // assert
            Assert.IsTrue(changingCount == 2);
            Assert.IsTrue(propertyNameInChanging == testPropertyName);
            Assert.IsTrue(oldValue == testValue);
            Assert.IsTrue(newValue == testValue2);
        }

        [TestMethod]
        public void SetProperty_Local_PropertyValueChanging_EventHandler_Can_Override_NewValue()
        {
            // arrange
            const int testValue = 100;
            const int overridenTestValue = 200;
            const string testPropertyName = "propertyName";
            int value = 0;

            // act
            PropertyValueChanging += (_, p) => p.NewValue = overridenTestValue;
            SetProperty(ref value, testValue, testPropertyName);

            // assert
            Assert.IsTrue(value == overridenTestValue);
        }

        [TestMethod]
        public void SetProperty_Local_Does_Not_Call_PropertyValueChanging_EventHandler_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            int changingCount = 0;

            // act
            PropertyValueChanging += (_, p) => changingCount++;
            SetProperty(ref value, testValue, testPropertyName);
            SetProperty(ref value, testValue, testPropertyName);

            // assert
            Assert.IsTrue(changingCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_Calls_PropertyValueChanged_EventHandler_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int value = 0;
            int changedCount = 0;
            string propertyNameInChanged = null;
            int oldValue = -1, newValue = -1;

            // act
            PropertyValueChanged += (_, p) =>
            {
                propertyNameInChanged = p.PropertyName;
                oldValue = (int)p.OldValue;
                newValue = (int)p.NewValue;
                changedCount++;
            };

            SetProperty(ref value, testValue, testPropertyName);
            SetProperty(ref value, testValue2, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 2);
            Assert.IsTrue(propertyNameInChanged == testPropertyName);
            Assert.IsTrue(oldValue == testValue);
            Assert.IsTrue(newValue == testValue2);
        }

        [TestMethod]
        public void SetProperty_Local_Does_Not_Call_PropertyValueChanged_EventHandler_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            int changedCount = 0;

            // act
            PropertyValueChanged += (_, p) => changedCount++;
            SetProperty(ref value, testValue, testPropertyName);
            SetProperty(ref value, testValue, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_Calls_PropertyValueChanged_EventHandler_After_PropertyValueChanging_EventHandler()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            double? changingTicks = null;
            double? changedTicks = null;

            // act
            PropertyValueChanging += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            PropertyValueChanged += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changedTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            SetProperty(ref value, testValue, testPropertyName);

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(changedTicks != null);
            Assert.IsTrue(changingTicks < changedTicks);
        }


        [TestMethod]
        public void SetProperty_Local_Calls_PropertyChanged_EventHandler_If_A_Value_Is_Changed()
        {
            // arrange
            const int testValue = 100;
            const int testValue2 = 200;
            const string testPropertyName = "propertyName";
            int value = 0;
            int changedCount = 0;
            string propertyNameInChanged = null;

            // act
            PropertyChanged += (_, p) =>
            {
                propertyNameInChanged = p.PropertyName;
                changedCount++;
            };

            SetProperty(ref value, testValue, testPropertyName);
            SetProperty(ref value, testValue2, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 2);
            Assert.IsTrue(propertyNameInChanged == testPropertyName);
        }

        [TestMethod]
        public void SetProperty_Local_Does_Not_Call_PropertyChanged_EventHandler_If_A_Value_Is_Not_Changed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            int changedCount = 0;

            // act
            PropertyChanged += (_, p) => changedCount++;
            SetProperty(ref value, testValue, testPropertyName);
            SetProperty(ref value, testValue, testPropertyName);

            // assert
            Assert.IsTrue(changedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_Calls_PropertyChanged_EventHandler_After_PropertyValueChanging_EventHandler()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            double? changingTicks = null;
            double? changedTicks = null;

            // act
            PropertyValueChanging += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            PropertyChanged += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changedTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            SetProperty(ref value, testValue, testPropertyName);

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(changedTicks != null);
            Assert.IsTrue(changingTicks < changedTicks);
        }


        [TestMethod]
        public void SetProperty_Local_Calls_PropertyChanged_EventHandler_For_Related_Property_Names()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            string[] testRelated = new string[]
            {
                "RelatedProperty1",
                "RelatedProperty2",
                "RelatedProperty3",
            };
            List<string> related = new List<string>();

            // act
            PropertyChanged += (_, p) =>
            {
                if (p.PropertyName != testPropertyName)
                    related.Add(p.PropertyName);
            };
            SetProperty(ref value, testValue, testPropertyName, related: testRelated);

            // assert
            Assert.IsTrue(Enumerable.SequenceEqual(testRelated, related));
        }


        [TestMethod]
        public void SetProperty_Local_Calls_OnChanging_OnChanged_Callback_Even_If_IsHidden_Is_True()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            int onChangingCount = 0;
            int onChangedCount = 0;

            // act
            SetProperty(ref value, testValue, testPropertyName, onChanging: p => onChangingCount++, onChanged: p => onChangedCount++, isHidden: true);

            // assert
            Assert.IsTrue(onChangingCount == 1);
            Assert.IsTrue(onChangedCount == 1);
        }


        [TestMethod]
        public void SetProperty_Local_Does_Not_Call_PropertyValueChanging_PropertyValueChanged_PropertyChanged_EventHandler_If_IsHidden_Is_True()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            int value = 0;
            string[] testRelated = new string[]
            {
                "RelatedProperty1",
                "RelatedProperty2",
                "RelatedProperty3",
            };
            List<string> related = new List<string>();
            string propertyNameInChanging = null;
            string propertyNameInChanged = null;

            // act
            PropertyValueChanging += (_, p) => propertyNameInChanging = p.PropertyName;
            PropertyValueChanged += (_, p) => propertyNameInChanged = p.PropertyName;
            PropertyChanged += (_, p) =>
            {
                if (p.PropertyName != testPropertyName)
                    related.Add(p.PropertyName);
            };
            SetProperty(ref value, testValue, testPropertyName, related: testRelated, isHidden: true);

            // assert
            Assert.IsTrue(propertyNameInChanging == null);
            Assert.IsTrue(propertyNameInChanged == null);
            Assert.IsFalse(related.Any());
        }


        [TestMethod]
        public void SetProperty_Local_Calls_OnChanging_Callback_After_PropertyValueChanging_EventHandler()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "propertyName";
            double? changingTicks = null;
            double? onChangingTicks = null;
            int value = 0;

            // act
            PropertyValueChanging += (_, p) =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    changingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            };
            SetProperty(ref value, testValue, testPropertyName, onChanging: p =>
            {
                if (p.PropertyName == testPropertyName)
                {
                    onChangingTicks = DateTime.Now.Ticks;
                    Thread.Sleep(10);
                }
            });

            // assert
            Assert.IsTrue(changingTicks != null);
            Assert.IsTrue(onChangingTicks != null);
            Assert.IsTrue(changingTicks < onChangingTicks);
        }


        [TestMethod]
        public void SetProperty_Local_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed()
        {
            // arrange
            const int testValue = 100;
            const string testPropertyName = "SetProperty_Local_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed";
            string propertyNameInChanged = null;
            int value = 0;

            // act
            PropertyChanged += (_, p) => propertyNameInChanged = p.PropertyName;
            SetProperty(ref value, testValue);

            // assert
            Assert.AreEqual(testPropertyName, propertyNameInChanged);
        }

        #endregion


        #region Serialization Test Related

        [DataContract]
        public class SerializationSample : PropertyObservable
        {
            [DataMember]
            public int TestValue
            {
                get { return GetProperty<int>(nameof(TestValue)); }
                set { SetProperty(value, nameof(TestValue)); }
            }

            [DataMember]
            public string TestString
            {
                get { return GetProperty(nameof(TestString), getDefault: () => "Test String"); }
                set { SetProperty(value, nameof(TestString)); }
            }
        }

        [TestMethod]
        public void DataContractSerializer_Must_Be_Supported()
        {
            // arrange
            const int testValue = 20;
            const string testString = "haha";
            SerializationSample sample = new SerializationSample();

            // act
            sample.TestValue = testValue;
            sample.TestString = testString;

            MemoryStream memoryStream = new MemoryStream();
            DataContractSerializer serializer = new DataContractSerializer(typeof(SerializationSample));
            serializer.WriteObject(memoryStream, sample);

            memoryStream.Position = 0;
            SerializationSample deserialized = (SerializationSample)serializer.ReadObject(memoryStream);

            // assert
            Assert.AreEqual(sample.TestValue, deserialized.TestValue);
            Assert.AreEqual(sample.TestString, deserialized.TestString);
        }

        [TestMethod]
        public void XmlSerializer_Must_Be_Supported()
        {
            // arrange
            const int testValue = 20;
            const string testString = "haha";
            SerializationSample sample = new SerializationSample();

            // act
            sample.TestValue = testValue;
            sample.TestString = testString;

            MemoryStream memoryStream = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(typeof(SerializationSample));
            serializer.Serialize(memoryStream, sample);

            memoryStream.Position = 0;
            SerializationSample deserialized = (SerializationSample)serializer.Deserialize(memoryStream);

            // assert
            Assert.AreEqual(sample.TestValue, deserialized.TestValue);
            Assert.AreEqual(sample.TestString, deserialized.TestString);
        }

        #endregion
    }
}
