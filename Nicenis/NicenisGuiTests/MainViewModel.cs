/*
 * Author   JO Hyeong-Ryeol
 * Since    2017.10.15
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2017 JO Hyeong-Ryeol. All rights reserved.
 */

using Nicenis.Windows.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Threading;

#if NICENIS_UWP
using Windows.UI.Core;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using System.Windows.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace NicenisGuiTests
{
    class MainViewModel : ViewModelBase
    {
        #region Assert

        public interface ILogWriter
        {
            /// <summary>
            /// Appends a log message asynchronously.
            /// This method must be thread-safe.
            /// </summary>
            /// <param name="log">A log message to append.</param>
            void AppendLogAsync(string log);
        }

        public static class Assert
        {
            static ILogWriter _logWriter;

            public static void SetLogWriter(ILogWriter logWriter)
            {
                _logWriter = logWriter;
            }

            public static void AppendLog(string log)
            {
                _logWriter.AppendLogAsync(log);
            }

            public static void Sleep(int millisecondsTimeout)
            {
#if NICENIS_UWP
                for (int i = 0; i < millisecondsTimeout * 100000; i++) ;
#else
                Thread.Sleep(millisecondsTimeout);
#endif
            }

            public static void IsTrue(bool value, [CallerMemberName] string name = null)
            {
                if (value == false)
                    AppendLog($"{name}: fail");
            }

            public static void IsFalse(bool value, [CallerMemberName] string name = null)
            {
                if (value)
                    AppendLog($"{name}: fail");
            }

            public static void AreEqual<T>(T expected, T actual, [CallerMemberName] string name = null)
            {
                if (Equals(expected, actual) == false)
                    AppendLog($"{name}: fail");
            }
        }

#endregion


#region FrameworkViewModelTestViewModel

        [TestClass]
        class FrameworkViewModelTestViewModel : FrameworkViewModelBase
        {
#region Consturctors

            public FrameworkViewModelTestViewModel() { }

#endregion


#region PostPropertyChanged Tests

            [TestMethod]
            public void PostPropertyChanged_Must_Not_Raise_PropertyChanged_Event_Immediately()
            {
                // arrange
                int raisedCount = 0;
                PropertyChanged += (_, p) =>
                {
                    raisedCount++;
                };

                // act
                PostPropertyChanged(nameof(raisedCount));

                // assert
                Assert.IsTrue(raisedCount == 0);
            }

            [TestMethod]
            public async Task PostPropertyChanged_Raise_PropertyChanged_Event_Asynchronously()
            {
                // arrange
                string raisedPropertyName = null;
                int raisedCount = 0;
                PropertyChanged += (_, p) =>
                {
                    raisedPropertyName = p.PropertyName;
                    raisedCount++;
                };

                // act
                PostPropertyChanged(nameof(raisedCount));
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(raisedPropertyName == nameof(raisedCount));
                Assert.IsTrue(raisedCount == 1);
            }

            [TestMethod]
            public async Task PostPropertyChanged_Must_Not_Raise_Duplicated_PropertyChanged_Event()
            {
                // arrange
                string raisedPropertyName = null;
                int raisedCount = 0;
                PropertyChanged += (_, p) =>
                {
                    raisedPropertyName = p.PropertyName;
                    raisedCount++;
                };

                // act
                PostPropertyChanged(nameof(raisedCount));
                PostPropertyChanged(nameof(raisedCount));
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(raisedPropertyName == nameof(raisedCount));
                Assert.IsTrue(raisedCount == 1);
            }

            [TestMethod]
            public async Task PostPropertyChanged_Must_Cancel_PropertyChanged_Event_If_Requested()
            {
                // arrange
                int raisedCount = 0;
                PropertyChanged += (_, p) =>
                {
                    raisedCount++;
                };

                // act
                PostPropertyChanged(nameof(raisedCount));
                CancelPostPropertyChanged();
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(raisedCount == 0);
            }

#endregion


#region SetPropertyP Test Related

            [TestMethod]
            public void SetPropertyP_Support_Set_A_Value()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";

                // act
                SetPropertyP(testValue, testPropertyName);
                int value = GetProperty<int>(testPropertyName);

                // assert
                Assert.AreEqual(value, testValue);
            }

            [TestMethod]
            public void SetPropertyP_Calls_OnChanging_Callback_If_A_Value_Is_Changed()
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
                SetPropertyP(testValue, testPropertyName, onChanging: p =>
                {
                    propertyNameInChanging = p.PropertyName;
                    oldValue = p.OldValue;
                    newValue = p.NewValue;
                    onChangingCount++;
                });
                SetPropertyP(testValue2, testPropertyName, onChanging: p =>
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
            public void SetPropertyP_OnChanging_Callback_Can_Override_NewValue()
            {
                // arrange
                const int testValue = 100;
                const int overridenTestValue = 200;
                const string testPropertyName = "propertyName";

                // act
                SetPropertyP(testValue, testPropertyName, onChanging: p => p.NewValue = overridenTestValue);
                int value = GetProperty<int>(testPropertyName);

                // assert
                Assert.IsTrue(value == overridenTestValue);
            }

            [TestMethod]
            public void SetPropertyP_Does_Not_Call_OnChanging_Callback_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int onChangingCount = 0;

                // act
                SetPropertyP(testValue, testPropertyName, onChanging: p => onChangingCount++);
                SetPropertyP(testValue, testPropertyName, onChanging: p => onChangingCount++);

                // assert
                Assert.IsTrue(onChangingCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Calls_OnChanged_Callback_If_A_Value_Is_Changed()
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
                SetPropertyP(testValue, testPropertyName, onChanged: p =>
                {
                    propertyNameInChanging = p.PropertyName;
                    oldValue = p.OldValue;
                    newValue = p.NewValue;
                    onChangedCount++;
                });
                SetPropertyP(testValue2, testPropertyName, onChanged: p =>
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
            public void SetPropertyP_Does_Not_Call_OnChanged_Callback_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int onChangedCount = 0;

                // act
                SetPropertyP(testValue, testPropertyName, onChanged: p => onChangedCount++);
                SetPropertyP(testValue, testPropertyName, onChanged: p => onChangedCount++);

                // assert
                Assert.IsTrue(onChangedCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Calls_OnChanged_Callback_After_OnChanging_Callback()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                double? changingTicks = null;
                double? changedTicks = null;

                // act
                SetPropertyP(testValue, testPropertyName, onChanging: p =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changingTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                },
                onChanged: p =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changedTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                });

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(changedTicks != null);
                Assert.IsTrue(changingTicks < changedTicks);
            }


            [TestMethod]
            public void SetPropertyP_Calls_PropertyValueChanging_EventHandler_If_A_Value_Is_Changed()
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

                SetPropertyP(testValue, testPropertyName);
                SetPropertyP(testValue2, testPropertyName);

                // assert
                Assert.IsTrue(changingCount == 2);
                Assert.IsTrue(propertyNameInChanging == testPropertyName);
                Assert.IsTrue(oldValue == testValue);
                Assert.IsTrue(newValue == testValue2);
            }

            [TestMethod]
            public void SetPropertyP_PropertyValueChanging_EventHandler_Can_Override_NewValue()
            {
                // arrange
                const int testValue = 100;
                const int overridenTestValue = 200;
                const string testPropertyName = "propertyName";

                // act
                PropertyValueChanging += (_, p) => p.NewValue = overridenTestValue;
                SetPropertyP(testValue, testPropertyName);
                int value = GetProperty<int>(testPropertyName);

                // assert
                Assert.IsTrue(value == overridenTestValue);
            }

            [TestMethod]
            public void SetPropertyP_Does_Not_Call_PropertyValueChanging_EventHandler_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int changingCount = 0;

                // act
                PropertyValueChanging += (_, p) => changingCount++;
                SetPropertyP(testValue, testPropertyName);
                SetPropertyP(testValue, testPropertyName);

                // assert
                Assert.IsTrue(changingCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Calls_PropertyValueChanged_EventHandler_If_A_Value_Is_Changed()
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

                SetPropertyP(testValue, testPropertyName);
                SetPropertyP(testValue2, testPropertyName);

                // assert
                Assert.IsTrue(changedCount == 2);
                Assert.IsTrue(propertyNameInChanged == testPropertyName);
                Assert.IsTrue(oldValue == testValue);
                Assert.IsTrue(newValue == testValue2);
            }

            [TestMethod]
            public void SetPropertyP_Does_Not_Call_PropertyValueChanged_EventHandler_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int changedCount = 0;

                // act
                PropertyValueChanged += (_, p) => changedCount++;
                SetPropertyP(testValue, testPropertyName);
                SetPropertyP(testValue, testPropertyName);

                // assert
                Assert.IsTrue(changedCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Calls_PropertyValueChanged_EventHandler_After_PropertyValueChanging_EventHandler()
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
                        Assert.Sleep(10);
                    }
                };
                PropertyValueChanged += (_, p) =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changedTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                };
                SetPropertyP(testValue, testPropertyName);

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(changedTicks != null);
                Assert.IsTrue(changingTicks < changedTicks);
            }


            [TestMethod]
            public void SetPropertyP_Must_Not_Call_PropertyChanged_EventHandler_Immediately_If_A_Value_Is_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int changedCount = 0;
                string propertyNameInChanged = null;

                // act
                PropertyChanged += (_, p) =>
                {
                    propertyNameInChanged = p.PropertyName;
                    changedCount++;
                };

                SetPropertyP(testValue, testPropertyName);

                // assert
                Assert.IsTrue(changedCount == 0);
                Assert.IsTrue(propertyNameInChanged == null);
            }

            [TestMethod]
            public async Task SetPropertyP_Calls_PropertyChanged_EventHandler_Asynchronously_If_A_Value_Is_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int changedCount = 0;
                string propertyNameInChanged = null;

                // act
                PropertyChanged += (_, p) =>
                {
                    propertyNameInChanged = p.PropertyName;
                    changedCount++;
                };

                SetPropertyP(testValue, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changedCount == 1);
                Assert.IsTrue(propertyNameInChanged == testPropertyName);
            }

            [TestMethod]
            public async Task SetPropertyP_Calls_PropertyChanged_EventHandler_Asynchronously_Without_Duplication_If_A_Value_Is_Changed()
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

                SetPropertyP(testValue, testPropertyName);
                SetPropertyP(testValue2, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changedCount == 1);
                Assert.IsTrue(propertyNameInChanged == testPropertyName);
            }

            [TestMethod]
            public async Task SetPropertyP_Does_Not_Call_PropertyChanged_EventHandler_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int changedCount = 0;

                // act
                PropertyChanged += (_, p) => changedCount++;
                SetPropertyP(testValue, testPropertyName);
                await Task.Delay(1000);
                SetPropertyP(testValue, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changedCount == 1);
            }

            [TestMethod]
            public async Task SetPropertyP_Calls_PropertyChanged_EventHandler_After_PropertyValueChanging_EventHandler()
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
                        Assert.Sleep(10);
                    }
                };
                PropertyChanged += (_, p) =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changedTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                };
                SetPropertyP(testValue, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(changedTicks != null);
                Assert.IsTrue(changingTicks < changedTicks);
            }


            [TestMethod]
            public async Task SetPropertyP_Calls_PropertyChanged_EventHandler_For_Related_Property_Names()
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
                SetPropertyP(testValue, testPropertyName, related: testRelated);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(Enumerable.SequenceEqual(testRelated, related));
            }


            [TestMethod]
            public void SetPropertyP_Calls_OnChanging_OnChanged_Callback_Even_If_IsHidden_Is_True()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int onChangingCount = 0;
                int onChangedCount = 0;

                // act
                SetPropertyP(testValue, testPropertyName, onChanging: p => onChangingCount++, onChanged: p => onChangedCount++, isHidden: true);

                // assert
                Assert.IsTrue(onChangingCount == 1);
                Assert.IsTrue(onChangedCount == 1);
            }


            [TestMethod]
            public async Task SetPropertyP_Does_Not_Call_PropertyValueChanging_PropertyValueChanged_PropertyChanged_EventHandler_If_IsHidden_Is_True()
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
                SetPropertyP(testValue, testPropertyName, related: testRelated, isHidden: true);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(propertyNameInChanging == null);
                Assert.IsTrue(propertyNameInChanged == null);
                Assert.IsFalse(related.Any());
            }


            [TestMethod]
            public void SetPropertyP_Calls_OnChanging_Callback_After_PropertyValueChanging_EventHandler()
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
                        Assert.Sleep(10);
                    }
                };
                SetPropertyP(testValue, testPropertyName, onChanging: p =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        onChangingTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                });

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(onChangingTicks != null);
                Assert.IsTrue(changingTicks < onChangingTicks);
            }


            [TestMethod]
            public async Task SetPropertyP_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "SetPropertyP_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed";
                string propertyNameInChanged = null;

                // act
                PropertyChanged += (_, p) => propertyNameInChanged = p.PropertyName;
                SetPropertyP(testValue);
                await Task.Delay(1000);

                // assert
                Assert.AreEqual(testPropertyName, propertyNameInChanged);
            }

#endregion


#region SetPropertyP with Local Field Test Related

            [TestMethod]
            public void SetPropertyP_Local_Support_Set_A_Value()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int value = 0;

                // act
                SetPropertyP(ref value, testValue, testPropertyName);

                // assert
                Assert.AreEqual(value, testValue);
            }

            [TestMethod]
            public void SetPropertyP_Local_Calls_OnChanging_Callback_If_A_Value_Is_Changed()
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
                SetPropertyP(ref value, testValue, testPropertyName, onChanging: p =>
                {
                    propertyNameInChanging = p.PropertyName;
                    oldValue = p.OldValue;
                    newValue = p.NewValue;
                    onChangingCount++;
                });
                SetPropertyP(ref value, testValue2, testPropertyName, onChanging: p =>
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
            public void SetPropertyP_Local_OnChanging_Callback_Can_Override_NewValue()
            {
                // arrange
                const int testValue = 100;
                const int overridenTestValue = 200;
                const string testPropertyName = "propertyName";
                int value = 0;

                // act
                SetPropertyP(ref value, testValue, testPropertyName, onChanging: p => p.NewValue = overridenTestValue);

                // assert
                Assert.IsTrue(value == overridenTestValue);
            }

            [TestMethod]
            public void SetPropertyP_Local_Does_Not_Call_OnChanging_Callback_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int value = 0;
                int onChangingCount = 0;

                // act
                SetPropertyP(ref value, testValue, testPropertyName, onChanging: p => onChangingCount++);
                SetPropertyP(ref value, testValue, testPropertyName, onChanging: p => onChangingCount++);

                // assert
                Assert.IsTrue(onChangingCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Local_Calls_OnChanged_Callback_If_A_Value_Is_Changed()
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
                SetPropertyP(ref value, testValue, testPropertyName, onChanged: p =>
                {
                    propertyNameInChanging = p.PropertyName;
                    oldValue = p.OldValue;
                    newValue = p.NewValue;
                    onChangedCount++;
                });
                SetPropertyP(ref value, testValue2, testPropertyName, onChanged: p =>
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
            public void SetPropertyP_Local_Does_Not_Call_OnChanged_Callback_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int value = 0;
                int onChangedCount = 0;

                // act
                SetPropertyP(ref value, testValue, testPropertyName, onChanged: p => onChangedCount++);
                SetPropertyP(ref value, testValue, testPropertyName, onChanged: p => onChangedCount++);

                // assert
                Assert.IsTrue(onChangedCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Local_Calls_OnChanged_Callback_After_OnChanging_Callback()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                double? changingTicks = null;
                double? changedTicks = null;
                int value = 0;

                // act
                SetPropertyP(ref value, testValue, testPropertyName, onChanging: p =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changingTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                },
                onChanged: p =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changedTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                });

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(changedTicks != null);
                Assert.IsTrue(changingTicks < changedTicks);
            }


            [TestMethod]
            public void SetPropertyP_Local_Calls_PropertyValueChanging_EventHandler_If_A_Value_Is_Changed()
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

                SetPropertyP(ref value, testValue, testPropertyName);
                SetPropertyP(ref value, testValue2, testPropertyName);

                // assert
                Assert.IsTrue(changingCount == 2);
                Assert.IsTrue(propertyNameInChanging == testPropertyName);
                Assert.IsTrue(oldValue == testValue);
                Assert.IsTrue(newValue == testValue2);
            }

            [TestMethod]
            public void SetPropertyP_Local_PropertyValueChanging_EventHandler_Can_Override_NewValue()
            {
                // arrange
                const int testValue = 100;
                const int overridenTestValue = 200;
                const string testPropertyName = "propertyName";
                int value = 0;

                // act
                PropertyValueChanging += (_, p) => p.NewValue = overridenTestValue;
                SetPropertyP(ref value, testValue, testPropertyName);

                // assert
                Assert.IsTrue(value == overridenTestValue);
            }

            [TestMethod]
            public void SetPropertyP_Local_Does_Not_Call_PropertyValueChanging_EventHandler_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int value = 0;
                int changingCount = 0;

                // act
                PropertyValueChanging += (_, p) => changingCount++;
                SetPropertyP(ref value, testValue, testPropertyName);
                SetPropertyP(ref value, testValue, testPropertyName);

                // assert
                Assert.IsTrue(changingCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Local_Calls_PropertyValueChanged_EventHandler_If_A_Value_Is_Changed()
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

                SetPropertyP(ref value, testValue, testPropertyName);
                SetPropertyP(ref value, testValue2, testPropertyName);

                // assert
                Assert.IsTrue(changedCount == 2);
                Assert.IsTrue(propertyNameInChanged == testPropertyName);
                Assert.IsTrue(oldValue == testValue);
                Assert.IsTrue(newValue == testValue2);
            }

            [TestMethod]
            public void SetPropertyP_Local_Does_Not_Call_PropertyValueChanged_EventHandler_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int value = 0;
                int changedCount = 0;

                // act
                PropertyValueChanged += (_, p) => changedCount++;
                SetPropertyP(ref value, testValue, testPropertyName);
                SetPropertyP(ref value, testValue, testPropertyName);

                // assert
                Assert.IsTrue(changedCount == 1);
            }

            [TestMethod]
            public void SetPropertyP_Local_Calls_PropertyValueChanged_EventHandler_After_PropertyValueChanging_EventHandler()
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
                        Assert.Sleep(10);
                    }
                };
                PropertyValueChanged += (_, p) =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changedTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                };
                SetPropertyP(ref value, testValue, testPropertyName);

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(changedTicks != null);
                Assert.IsTrue(changingTicks < changedTicks);
            }


            [TestMethod]
            public void SetPropertyP_Local_Must_Not_Call_PropertyChanged_EventHandler_Immediately_If_A_Value_Is_Changed()
            {
                // arrange
                const int testValue = 100;
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

                SetPropertyP(ref value, testValue, testPropertyName);

                // assert
                Assert.IsTrue(changedCount == 0);
                Assert.IsTrue(propertyNameInChanged == null);
            }

            [TestMethod]
            public async Task SetPropertyP_Local_Calls_PropertyChanged_EventHandler_Asynchronously_If_A_Value_Is_Changed()
            {
                // arrange
                const int testValue = 100;
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

                SetPropertyP(ref value, testValue, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changedCount == 1);
                Assert.IsTrue(propertyNameInChanged == testPropertyName);
            }

            [TestMethod]
            public async Task SetPropertyP_Local_Calls_PropertyChanged_EventHandler_Asynchronously_Without_Duplication_If_A_Value_Is_Changed()
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

                SetPropertyP(ref value, testValue, testPropertyName);
                SetPropertyP(ref value, testValue2, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changedCount == 1);
                Assert.IsTrue(propertyNameInChanged == testPropertyName);
            }

            [TestMethod]
            public async Task SetPropertyP_Local_Does_Not_Call_PropertyChanged_EventHandler_If_A_Value_Is_Not_Changed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int value = 0;
                int changedCount = 0;

                // act
                PropertyChanged += (_, p) => changedCount++;
                SetPropertyP(ref value, testValue, testPropertyName);
                await Task.Delay(1000);
                SetPropertyP(ref value, testValue, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changedCount == 1);
            }

            [TestMethod]
            public async Task SetPropertyP_Local_Calls_PropertyChanged_EventHandler_After_PropertyValueChanging_EventHandler()
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
                        Assert.Sleep(10);
                    }
                };
                PropertyChanged += (_, p) =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        changedTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                };
                SetPropertyP(ref value, testValue, testPropertyName);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(changedTicks != null);
                Assert.IsTrue(changingTicks < changedTicks);
            }


            [TestMethod]
            public async Task SetPropertyP_Local_Calls_PropertyChanged_EventHandler_For_Related_Property_Names()
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
                SetPropertyP(ref value, testValue, testPropertyName, related: testRelated);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(Enumerable.SequenceEqual(testRelated, related));
            }


            [TestMethod]
            public void SetPropertyP_Local_Calls_OnChanging_OnChanged_Callback_Even_If_IsHidden_Is_True()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "propertyName";
                int value = 0;
                int onChangingCount = 0;
                int onChangedCount = 0;

                // act
                SetPropertyP(ref value, testValue, testPropertyName, onChanging: p => onChangingCount++, onChanged: p => onChangedCount++, isHidden: true);

                // assert
                Assert.IsTrue(onChangingCount == 1);
                Assert.IsTrue(onChangedCount == 1);
            }


            [TestMethod]
            public async Task SetPropertyP_Local_Does_Not_Call_PropertyValueChanging_PropertyValueChanged_PropertyChanged_EventHandler_If_IsHidden_Is_True()
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
                SetPropertyP(ref value, testValue, testPropertyName, related: testRelated, isHidden: true);
                await Task.Delay(1000);

                // assert
                Assert.IsTrue(propertyNameInChanging == null);
                Assert.IsTrue(propertyNameInChanged == null);
                Assert.IsFalse(related.Any());
            }


            [TestMethod]
            public void SetPropertyP_Local_Calls_OnChanging_Callback_After_PropertyValueChanging_EventHandler()
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
                        Assert.Sleep(10);
                    }
                };
                SetPropertyP(ref value, testValue, testPropertyName, onChanging: p =>
                {
                    if (p.PropertyName == testPropertyName)
                    {
                        onChangingTicks = DateTime.Now.Ticks;
                        Assert.Sleep(10);
                    }
                });

                // assert
                Assert.IsTrue(changingTicks != null);
                Assert.IsTrue(onChangingTicks != null);
                Assert.IsTrue(changingTicks < onChangingTicks);
            }


            [TestMethod]
            public async Task SetPropertyP_Local_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed()
            {
                // arrange
                const int testValue = 100;
                const string testPropertyName = "SetPropertyP_Local_Uses_CallerMemberName_If_PropertyName_Is_Not_Passed";
                string propertyNameInChanged = null;
                int value = 0;

                // act
                PropertyChanged += (_, p) => propertyNameInChanged = p.PropertyName;
                SetPropertyP(ref value, testValue);
                await Task.Delay(1000);

                // assert
                Assert.AreEqual(testPropertyName, propertyNameInChanged);
            }

#endregion
        }

#endregion


#region Constructors

        public MainViewModel() { }

#endregion


        public async Task RunAsync()
        {
            var testClasseTypes = GetType().GetNestedTypes(BindingFlags.NonPublic)
                                       .Where(p => p.GetTypeInfo().GetCustomAttributes(typeof(TestClassAttribute), inherit: true).Any())
                                       .ToArray();

            foreach (var testClass in testClasseTypes)
            {
                var testMethods = testClass.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                           .Where(p => p.CustomAttributes.Any(p2 => p2.AttributeType == typeof(TestMethodAttribute)))
                                           .ToArray();

                foreach (var testMethod in testMethods)
                {
                    await Task.Delay(0);
                    if (testMethod.Invoke(Activator.CreateInstance(testClass), null) is Task task)
                        await task;
                }
            }

            Assert.AppendLog($"The end of {nameof(RunAsync)}");
        }
    }
}
