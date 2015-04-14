/*
 * Author   JO Hyeong-Ryeol
 * Since    2014.03.21
 *
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2014 JO Hyeong-Ryeol. All rights reserved.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Xml.Serialization;

namespace NicenisTests.ComponentModel
{
    [TestClass]
    public class PropertyObservableTests : PropertyObservable
    {
        #region Samples

        class Sample : PropertyObservable
        {
            #region Converted Methods From Protected To Public

            #region GetProperty Related

            public new T GetProperty<T>(string propertyName, Func<T> initializer)
            {
                return base.GetProperty(propertyName, initializer);
            }

            public new T GetProperty<T>(string propertyName)
            {
                return base.GetProperty<T>(propertyName);
            }

            #endregion

            #region SetProperty Related

            public new bool SetPropertyOnly<T>(string propertyName, T value)
            {
                return base.SetPropertyOnly(propertyName, value);
            }

            public new bool SetProperty<T>(string propertyName, T value, IEnumerable<string> affectedPropertyNames)
            {
                return base.SetProperty(propertyName, value, affectedPropertyNames);
            }

            public new bool SetProperty<T>(string propertyName, T value, params string[] affectedPropertyNames)
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

            #endregion

#if !NICENIS_4C

            #region GetCallerProperty/SetCallerProperty Related

            public new T GetCallerProperty<T>(Func<T> initializer, [CallerMemberName] string propertyName = "")
            {
                return base.GetCallerProperty(initializer, propertyName);
            }

            public new T GetCallerProperty<T>([CallerMemberName] string propertyName = "")
            {
                return base.GetCallerProperty<T>(propertyName);
            }

            public new bool SetCallerPropertyOnly<T>(T value, [CallerMemberName] string propertyName = "")
            {
                return base.SetCallerPropertyOnly(value, propertyName);
            }

            public new bool SetCallerProperty<T>(T value, IEnumerable<string> affectedPropertyNames, [CallerMemberName] string propertyName = "")
            {
                return base.SetCallerProperty(value, affectedPropertyNames, propertyName);
            }

            public new bool SetCallerProperty<T>(T value, [CallerMemberName] string propertyName = "")
            {
                return base.SetCallerProperty(value, propertyName);
            }

            #endregion

#endif

            #region SetProperty with Local Storage Related

            public new bool SetPropertyOnly<T>(ref T storage, T value)
            {
                return base.SetPropertyOnly(ref storage, value);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value, IEnumerable<string> affectedPropertyNames)
            {
                return base.SetProperty(propertyName, ref storage, value, affectedPropertyNames);
            }

            public new bool SetProperty<T>(string propertyName, ref T storage, T value, params string[] affectedPropertyNames)
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

#if !NICENIS_4C

            #region SetCallerProperty with Local Storage Related

            public new bool SetCallerProperty<T>(ref T storage, T value, IEnumerable<string> affectedPropertyNames, [CallerMemberName] string propertyName = "")
            {
                return base.SetCallerProperty(ref storage, value, affectedPropertyNames, propertyName);
            }

            public new bool SetCallerProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
            {
                return base.SetCallerProperty(ref storage, value, propertyName);
            }

            #endregion

#endif

            #region OnPropertyChanged Related

            public new void OnPropertyChanged(string propertyName)
            {
                base.OnPropertyChanged(propertyName);
            }

            public new void OnPropertyChanged(IEnumerable<string> propertyNames)
            {
                base.OnPropertyChanged(propertyNames);
            }

            #endregion

            #endregion

            #region ValueProperty & ReferenceProperty Related

            public int ValueProperty
            {
                get { return GetProperty(() => ValueProperty); }
                set { SetProperty(() => ValueProperty, value); }
            }

            public string GetValuePropertyName()
            {
                return ToPropertyName(() => ValueProperty);
            }

            public string ReferenceProperty
            {
                get { return GetProperty(() => ReferenceProperty); }
                set { SetProperty(() => ReferenceProperty, value); }
            }

            public string GetReferencePropertyName()
            {
                return ToPropertyName(() => ReferenceProperty);
            }

            private int PrivateValueProperty
            {
                get { return GetProperty(() => PrivateValueProperty); }
                set { SetProperty(() => PrivateValueProperty, value); }
            }

            public int IndirectPrivateValueProperty
            {
                get { return PrivateValueProperty; }
                set { PrivateValueProperty = value; }
            }

            public string GetPrivateValuePropertyName()
            {
                return ToPropertyName(() => PrivateValueProperty);
            }

#if !NICENIS_4C

            public string CallerMemberNameProperty
            {
                get { return GetCallerProperty<string>(); }
                set { SetCallerProperty(value); }
            }

            public string CallerMemberNamePropertyWithoutPropertyChangedEvent
            {
                get { return GetCallerProperty<string>(); }
                set { SetCallerPropertyOnly(value); }
            }

            string _callerMemberNamePropertyWithLocalStorage;

            public string CallerMemberNamePropertyWithLocalStorage
            {
                get { return _callerMemberNamePropertyWithLocalStorage; }
                set { SetCallerProperty(ref _callerMemberNamePropertyWithLocalStorage, value); }
            }

#endif

            #endregion

            #region TestProperty1 ~ TestProperty2

            public class TestPropertyType1 { }
            public class TestPropertyType2 { }

            public TestPropertyType1 TestProperty1
            {
                get { return GetProperty(() => TestProperty1); }
                set { SetProperty(() => TestProperty1, value); }
            }

            public string GetTestProperty1Name()
            {
                return ToPropertyName(() => TestProperty1);
            }

            public TestPropertyType2 TestProperty2
            {
                get { return GetProperty(() => TestProperty2); }
                set { SetProperty(() => TestProperty2, value); }
            }

            public string GetTestProperty2Name()
            {
                return ToPropertyName(() => TestProperty2);
            }

            #endregion

            #region VirtualValueProperty

            public virtual int VirtualValueProperty
            {
                get { return GetProperty(() => VirtualValueProperty); }
                set { SetProperty(() => VirtualValueProperty, value); }
            }

            public string GetVirtualValuePropertyName()
            {
                return ToPropertyName(() => VirtualValueProperty);
            }

            #endregion
        }

        class InheritedSample : Sample
        {
            public override int VirtualValueProperty
            {
                get { return GetProperty(() => VirtualValueProperty); }
                set { SetProperty(() => VirtualValueProperty, value); }
            }
        }

        [DataContract]
        public class SerializationSample : PropertyObservable
        {
            [DataMember]
            public int TestValue
            {
                get { return GetProperty(() => TestValue); }
                set { SetProperty(() => TestValue, value); }
            }

            [DataMember]
            public string TestString
            {
                get { return GetProperty(() => TestString, () => "Test String"); }
                set { SetProperty(() => TestString, value); }
            }
        }

        public string TestProperty { get; set; }

        #endregion


        #region Helpers

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

        private void ChangeTestProperty(Sample sample, int count)
        {
            for (int i = 0; i < count; i++)
            {
                int no = i + 1;

                SetPropertyByReflection
                (
                    sample: sample,
                    propertyName: "TestProperty" + no,
                    value: Activator.CreateInstance
                    (
                        assemblyName: null,
                        typeName: "NicenisTests.ComponentModel.WatchableObjectTests+Sample+TestPropertyType" + no
                    ).Unwrap()
                );
            }
        }

        private static int ExtractFirstNumberInPropertyName(string propertyName)
        {
            string numberString = "";
            foreach (char chr in propertyName)
            {
                if (!char.IsDigit(chr))
                {
                    if (numberString == "")
                        continue;

                    break;
                }

                numberString += chr;
            };

            return int.Parse(numberString);
        }

        #endregion


        #region ToPropertyName Test Related

        [TestMethod]
        public void ToPropertyName_must_return_public_property_name()
        {
            // arrange
            const string expectedPropertyName = "ValueProperty";
            Sample sample = new Sample();

            // act
            string propertyName = sample.GetValuePropertyName();

            // assert
            Assert.AreEqual(expectedPropertyName, propertyName);
        }

        [TestMethod]
        public void ToPropertyName_must_return_private_property_name()
        {
            // arrange
            const string expectedPropertyName = "PrivateValueProperty";
            Sample sample = new Sample();

            // act
            string propertyName = sample.GetPrivateValuePropertyName();

            // assert
            Assert.AreEqual(expectedPropertyName, propertyName);
        }

        [TestMethod]
        public void ToPropertyName_must_return_virtual_property_name()
        {
            // arrange
            const string expectedPropertyName = "VirtualValueProperty";
            Sample sample = new Sample();

            // act
            string propertyName = sample.GetVirtualValuePropertyName();

            // assert
            Assert.AreEqual(expectedPropertyName, propertyName);
        }

        [TestMethod]
        public void ToPropertyName_must_return_overridden_property_name()
        {
            // arrange
            const string expectedPropertyName = "VirtualValueProperty";
            InheritedSample inheritedSample = new InheritedSample();

            // act
            string propertyName = inheritedSample.GetVirtualValuePropertyName();

            // assert
            Assert.AreEqual(expectedPropertyName, propertyName);
        }

        [TestMethod]
        public void ToPropertyName_must_support_multiple_property_names()
        {
            // arrange
            string[] expectedPropertyNames =
            {
                "ValueProperty",
                "PrivateValueProperty",
                "VirtualValueProperty",
            };
            Sample sample = new Sample();

            for (int i = 0; i < 3; i++)
            {
                // act
                string[] propertyNames = 
                {
                    sample.GetValuePropertyName(),
                    sample.GetPrivateValuePropertyName(),
                    sample.GetVirtualValuePropertyName(),
                };

                // assert
                for (int j = 0; j < expectedPropertyNames.Length; j++)
                    Assert.AreEqual(expectedPropertyNames[j], propertyNames[j]);
            }
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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


        #region GetProperty Test Related

        [TestMethod]
        public void GetProperty_must_return_default_value_if_it_is_not_set()
        {
            // arrange
            Sample sample = new Sample();

            // act
            int property = sample.GetProperty<int>(sample.GetValuePropertyName());

            // assert
            Assert.AreEqual(default(int), property);
        }

        [TestMethod]
        public void GetProperty_must_return_default_reference_if_it_is_not_set()
        {
            // arrange
            Sample sample = new Sample();

            // act
            string property = sample.ReferenceProperty;

            // assert
            Assert.AreEqual(default(string), property);
        }

        [TestMethod]
        public void GetProperty_must_return_initialized_value_if_it_is_not_set()
        {
            // arrange
            const int initializedValue = 10;
            Sample sample = new Sample();

            // act
            int property = sample.GetProperty(sample.GetValuePropertyName(), () => initializedValue);

            // assert
            Assert.AreEqual(initializedValue, property);
        }

        [TestMethod]
        public void GetProperty_must_not_call_initializer_twice()
        {
            // arrange
            const int initializedValue = 10;
            const int expectedInitializerCallCount = 1;
            Sample sample = new Sample();
            int initializerCallCount = 0;
            Func<int> initializer = () =>
            {
                initializerCallCount++;
                return initializedValue;
            };

            // act
            sample.GetProperty(sample.GetValuePropertyName(), initializer);
            sample.GetProperty(sample.GetValuePropertyName(), initializer);

            // assert
            Assert.AreEqual(initializerCallCount, expectedInitializerCallCount);
        }

        [TestMethod]
        public void GetProperty_must_not_call_initializer_if_it_is_set()
        {
            // arrange
            const int setValue = 100;
            const int initializedValue = 10;
            const int expectedInitializerCallCount = 0;
            Sample sample = new Sample();
            int initializerCallCount = 0;

            // act
            sample.SetProperty(sample.GetValuePropertyName(), setValue);
            sample.GetProperty(sample.GetValuePropertyName(), () =>
            {
                initializerCallCount++;
                return initializedValue;
            });

            // assert
            Assert.AreEqual(initializerCallCount, expectedInitializerCallCount);
        }

        #endregion


        #region SetPropertyOnly Parameter Check Related

        [TestMethod]
        public void SetPropertyOnly_must_throw_exception_if_null_property_name_is_passed()
        {
            // arrange
            string propertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyOnly(propertyName, "test");
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "propertyName");
        }

        [TestMethod]
        public void SetPropertyOnly_must_throw_exception_if_empty_property_name_is_passed()
        {
            // arrange
            string propertyName = "";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyOnly(propertyName, "test");
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
        public void SetPropertyOnly_must_throw_exception_if_whitespace_property_name_is_passed()
        {
            // arrange
            string propertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetPropertyOnly(propertyName, "test");
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_is_null()
        {
            // arrange
            IEnumerable<string> affectedPropertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "affectedPropertyNames");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_not_throw_exception_if_affected_property_names_is_empty()
        {
            // arrange
            IEnumerable<string> affectedPropertyNames = new string[0];
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_null()
        {
            // arrange
            IEnumerable<string> affectedPropertyNames = new string[] { "test", null };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyNames");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_empty_string()
        {
            // arrange
            IEnumerable<string> affectedPropertyNames = new string[] { "test", "" };
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_whitespace_string()
        {
            // arrange
            IEnumerable<string> affectedPropertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyNames");
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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
        public void SetProperty_with_affected_property_name_must_throw_exception_if_affected_property_name_is_null()
        {
            // arrange
            string affectedPropertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyName");
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_empty()
        {
            // arrange
            string affectedPropertyName = "";
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_affected_property_name_must_throw_exception_if_affected_property_name_is_whitespace()
        {
            // arrange
            string affectedPropertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyName");
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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

        #endregion


        #region SetProperty Test Related

        [TestMethod]
        public void SetPropertyOnly_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();

            // act
            sample.SetPropertyOnly(sample.GetValuePropertyName(), testValue);
            int propertyValue = sample.GetProperty<int>(sample.GetValuePropertyName());

            // assert
            Assert.AreEqual(propertyValue, testValue);
        }

        [TestMethod]
        public void SetPropertyOnly_must_not_raise_PropertyChanged()
        {
            // arrange
            const int testValue = 100;

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            sample.PropertyChanged += (_, __) => propertyChangedCount++;

            // act
            sample.SetPropertyOnly(sample.GetValuePropertyName(), testValue);
            sample.SetPropertyOnly(sample.GetValuePropertyName(), testValue);

            // assert
            Assert.AreEqual(0, propertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetValuePropertyName(), testValue);
            int propertyValue = sample.GetProperty<int>(sample.GetValuePropertyName());

            // assert
            Assert.AreEqual(propertyValue, testValue);
        }

        [TestMethod]
        public void SetProperty_must_set_reference_properly()
        {
            // arrange
            const string testReference = "Test";
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetReferencePropertyName(), testReference);
            string propertyReference = sample.GetProperty<string>(sample.GetReferencePropertyName());

            // assert
            Assert.AreEqual(propertyReference, testReference);
        }

        [TestMethod]
        public void SetProperty_must_support_multiple_properties_with_insertion_in_ascending_order()
        {
            for (int count = 1; count <= 100; count++)
            {
                // arrange
                Sample sample = new Sample();

                // act
                for (int i = 0; i <= count; i++)
                    sample.SetProperty("Test" + i, i);

                // assert
                for (int i = 0; i <= count; i++)
                {
                    int value = sample.GetProperty<int>("Test" + i);
                    Assert.AreEqual(value, i);

                    value = sample.GetProperty<int>("Nonexistence" + i);
                    Assert.AreEqual(value, default(int));
                }
            }
        }

        [TestMethod]
        public void SetProperty_must_support_multiple_properties_with_insertion_in_decending_order()
        {
            for (int count = 1; count <= 100; count++)
            {
                // arrange
                Sample sample = new Sample();

                // act
                for (int i = count; i >= 0; i--)
                    sample.SetProperty("Test" + i, i);

                // assert
                for (int i = count; i >= 0; i--)
                {
                    int value = sample.GetProperty<int>("Test" + i);
                    Assert.AreEqual(value, i);

                    value = sample.GetProperty<int>("Nonexistence" + i);
                    Assert.AreEqual(value, default(int));
                }
            }
        }

        [TestMethod]
        public void SetProperty_must_support_multiple_properties_with_insertion_in_random_order()
        {
            int[] numbers = Enumerable.Range(0, 101).ToArray();
            Random random = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                int swapIndex = random.Next(0, numbers.Length);

                int temp = numbers[i];
                numbers[i] = numbers[swapIndex];
                numbers[swapIndex] = temp;
            }

            // arrange
            for (int count = 1; count <= 100; count++)
            {
                // arrange
                Sample sample = new Sample();

                // act
                for (int i = count; i >= 0; i--)
                    sample.SetProperty("Test" + numbers[i], numbers[i]);

                // assert
                for (int i = count; i >= 0; i--)
                {
                    int value = sample.GetProperty<int>("Test" + numbers[i]);
                    Assert.AreEqual(value, numbers[i]);

                    value = sample.GetProperty<int>("Nonexistence" + numbers[i]);
                    Assert.AreEqual(value, default(int));
                }
            }
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();

            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == propertyName)
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(propertyName, testValue);

            // assert
            Assert.AreEqual(1, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_not_raise_PropertyChanged_if_it_is_not_changed()
        {
            // arrange
            const int testValue = default(int);

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();

            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == propertyName)
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(propertyName, testValue);

            // assert
            Assert.AreEqual(0, propertyChangedCount);
            Assert.AreEqual(0, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_2_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 3;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();
            string affectedPropertyName1 = sample.GetTestProperty1Name();
            string affectedPropertyName2 = sample.GetTestProperty2Name();

            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != propertyName)
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty
            (
                propertyName, testValue, affectedPropertyName1, affectedPropertyName2
            );

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_raise_PropertyChanged_for_1_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 2;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();
            string affectedPropertyName = sample.GetTestProperty1Name();

            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != propertyName)
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(propertyName, testValue, affectedPropertyName);

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_must_support_private_property()
        {
            // arrange
            Sample sample = new Sample();

            // act
            sample.IndirectPrivateValueProperty = 10;

            // assert
            Assert.IsTrue(true);
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentNullException);
            StringAssert.Contains(exception.Message, "affectedPropertyNames");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_not_throw_exception_if_affected_property_names_is_empty()
        {
            // arrange
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[0];
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_null()
        {
            // arrange
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", null };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyNames");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_not_throw_exception_if_affected_property_names_contain_empty_string()
        {
            // arrange
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", "" };
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyNames);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_names_must_throw_exception_if_affected_property_names_contain_whitespace_string()
        {
            // arrange
            int storage = 0;
            IEnumerable<string> affectedPropertyNames = new string[] { "test", " " };
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyNames);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyNames");
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_affected_property_name_is_null()
        {
            // arrange
            int storage = 0;
            string affectedPropertyName = null;
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyName");
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_not_throw_exception_if_affected_property_name_is_empty()
        {
            // arrange
            int storage = 0;
            string affectedPropertyName = "";
            Sample sample = new Sample();

            // act
            sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyName);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_with_affected_property_name_must_throw_exception_if_affected_property_name_is_whitespace()
        {
            // arrange
            int storage = 0;
            string affectedPropertyName = " ";
            Exception exception = null;
            Sample sample = new Sample();

            // act
            try
            {
                sample.SetProperty(sample.GetValuePropertyName(), ref storage, 10, affectedPropertyName);
            }
            catch (Exception e)
            {
                exception = e;
            }

            // assert
            Assert.IsTrue(exception is ArgumentException);
            StringAssert.Contains(exception.Message, "affectedPropertyName");
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
            Assert.IsTrue(exception is ArgumentException || exception is ArgumentNullException);
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


        #region SetProperty with local storage Test Related

        [TestMethod]
        public void SetPropertyOnly_with_local_storage_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();
            int valueStorage = 0;

            // act
            sample.SetPropertyOnly(ref valueStorage, testValue);

            // assert
            Assert.AreEqual(valueStorage, testValue);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_set_value_properly()
        {
            // arrange
            const int testValue = 100;
            Sample sample = new Sample();
            int valueStorage = 0;

            // act
            sample.SetProperty(sample.GetValuePropertyName(), ref valueStorage, testValue);

            // assert
            Assert.AreEqual(valueStorage, testValue);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_set_reference_properly()
        {
            // arrange
            const string testReference = "Test";
            Sample sample = new Sample();
            string referenceStorage = null;

            // act
            sample.SetProperty(sample.GetReferencePropertyName(), ref referenceStorage, testReference);

            // assert
            Assert.AreEqual(referenceStorage, testReference);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_support_multiple_properties()
        {
            // arrange
            const int testValue = 10;
            const string testReference = "Test";

            Sample sample = new Sample();
            int valueStorage = 0;
            string referenceStorage = null;

            // act
            sample.SetProperty(sample.GetValuePropertyName(), ref valueStorage, testValue);
            sample.SetProperty(sample.GetReferencePropertyName(), ref referenceStorage, testReference);

            // assert
            Assert.AreEqual(testValue, valueStorage);
            Assert.AreEqual(testReference, referenceStorage);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();

            int valueStorage = 0;
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == propertyName)
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(propertyName, ref valueStorage, testValue);

            // assert
            Assert.AreEqual(1, propertyChangedCount);
            Assert.AreEqual(1, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_not_raise_PropertyChanged_if_it_is_not_changed()
        {
            // arrange
            const int testValue = default(int);

            int propertyChangedCount = 0;
            int valuePropertyChangedCount = 0;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();

            int valueStorage = 0;
            sample.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == propertyName)
                    valuePropertyChangedCount++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(propertyName, ref valueStorage, testValue);

            // assert
            Assert.AreEqual(0, propertyChangedCount);
            Assert.AreEqual(0, valuePropertyChangedCount);
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_2_affected_properties_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 3;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();
            string affectedPropertyName1 = sample.GetTestProperty1Name();
            string affectedPropertyName2 = sample.GetTestProperty2Name();

            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != propertyName)
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(propertyName, ref valueStorage, testValue, affectedPropertyName1, affectedPropertyName2);

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        [TestMethod]
        public void SetProperty_with_local_storage_must_raise_PropertyChanged_for_1_affected_property_if_it_is_changed()
        {
            // arrange
            const int testValue = 1000;
            const int changedPropertyCount = 2;
            const int affectedPropertyCount = changedPropertyCount - 1;

            Sample sample = new Sample();
            string propertyName = sample.GetValuePropertyName();
            string affectedPropertyName = sample.GetTestProperty1Name();

            int valueStorage = 0;
            int propertyChangedCount = 0;
            int[] affectedPropertyChangedCounts = new int[affectedPropertyCount];
            sample.PropertyChanged += (_, e) =>
            {
                // If it is not an affected property
                if (e.PropertyName != propertyName)
                    affectedPropertyChangedCounts[ExtractFirstNumberInPropertyName(e.PropertyName) - 1]++;

                propertyChangedCount++;
            };

            // act
            sample.SetProperty(propertyName, ref valueStorage, testValue, affectedPropertyName);

            // assert
            Assert.AreEqual(propertyChangedCount, changedPropertyCount);
            Assert.IsTrue(affectedPropertyChangedCounts.All(p => p == 1));
        }

        #endregion


#if !NICENIS_4C

        #region GetCallerProperty/SetCallerProperty Test Related

        [TestMethod]
        public void SetCallerProperty_must_set_value_properly()
        {
            // arrange
            const string testValue = "test value";
            Sample sample = new Sample();

            // act
            sample.CallerMemberNameProperty = testValue;
            string propertyValue = sample.CallerMemberNameProperty;

            // assert
            Assert.AreEqual(propertyValue, testValue);
        }

        [TestMethod]
        public void SetCallerProperty_must_raise_property_changed_event()
        {
            // arrange
            const int expectedPropertyChangedCount = 1;
            const string expectedChangedPropertyName = "CallerMemberNameProperty";

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            string changedPropertyName = null;

            sample.PropertyChanged += (_, e) =>
            {
                propertyChangedCount++;
                changedPropertyName = e.PropertyName;
            };

            // act
            sample.CallerMemberNameProperty = "test value";

            // assert
            Assert.AreEqual(propertyChangedCount, expectedPropertyChangedCount);
            Assert.AreEqual(changedPropertyName, expectedChangedPropertyName);
        }

        [TestMethod]
        public void SetCallerPropertyOnly_must_not_raise_property_changed_event()
        {
            // arrange
            const int expectedPropertyChangedCount = 0;

            Sample sample = new Sample();
            int propertyChangedCount = 0;

            sample.PropertyChanged += (_, __) => propertyChangedCount++;

            // act
            sample.CallerMemberNamePropertyWithoutPropertyChangedEvent = "Test Value";

            // assert
            Assert.AreEqual(propertyChangedCount, expectedPropertyChangedCount);
        }

        #endregion


        #region SetCallerProperty with local storage Test Related

        [TestMethod]
        public void SetCallerPropertyWithLocalStorage_must_set_value_properly()
        {
            // arrange
            const string testValue = "test value";
            Sample sample = new Sample();

            // act
            sample.CallerMemberNamePropertyWithLocalStorage = testValue;
            string propertyValue = sample.CallerMemberNamePropertyWithLocalStorage;

            // assert
            Assert.AreEqual(propertyValue, testValue);
        }

        [TestMethod]
        public void SetCallerPropertyWithLocalStorage_must_raise_property_changed_event()
        {
            // arrange
            const int expectedPropertyChangedCount = 1;
            const string expectedChangedPropertyName = "CallerMemberNamePropertyWithLocalStorage";

            Sample sample = new Sample();
            int propertyChangedCount = 0;
            string changedPropertyName = null;

            sample.PropertyChanged += (_, e) =>
            {
                propertyChangedCount++;
                changedPropertyName = e.PropertyName;
            };

            // act
            sample.CallerMemberNamePropertyWithLocalStorage = "test value";

            // assert
            Assert.AreEqual(propertyChangedCount, expectedPropertyChangedCount);
            Assert.AreEqual(changedPropertyName, expectedChangedPropertyName);
        }

        #endregion

#endif


        #region Serialization Test Related

        [TestMethod]
        public void DataContractSerializer_must_be_supported()
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
        public void XmlSerializer_must_be_supported()
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


        #region onChanged Parameter Test Related

        [TestMethod]
        public void SetPropertyOnly_Calls_Allows_Null_OnChanged_Parameter()
        {
            // act
            SetPropertyOnly("Property Name", "Property Value", null);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetPropertyOnly_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetPropertyOnly("Property Name", "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetPropertyOnly_By_Lambda_Property_Name_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetPropertyOnly(() => TestProperty, "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_With_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", "Property Value", () => onChangedCount++, new string[] { "1", "2" });

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_With_Param_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", "Property Value", () => onChangedCount++, "1", "2");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_With_Affect_Property_Name_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", "Property Value", () => onChangedCount++, "1");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetPropert_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_By_Lambda_Property_Name_With_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, "Property Value", () => onChangedCount++, new string[] { "1", "2" });

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_By_Lambda_Property_Name_With_Param_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, "Property Value", () => onChangedCount++, "1", "2");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_By_Lambda_Property_Name_With_Affect_Property_Name_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, "Property Value", () => onChangedCount++, "1");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetPropert_By_Lambda_Property_Name_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }


#if !NICENIS_4C

        [TestMethod]
        public void SetCallerPropertyOnly_Calls_Allows_Null_OnChanged_Parameter()
        {
            // act
            SetCallerPropertyOnly("Property Value", onChanged: null);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetCallerPropertyOnly_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetCallerPropertyOnly("Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetCallerProperty_With_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetCallerProperty("Property Value", () => onChangedCount++, new string[] { "1", "2" });

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetCallerProperty_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            int onChangedCount = 0;

            // act
            SetCallerProperty("Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

#endif

        [TestMethod]
        public void SetPropertyOnly_Local_Calls_Allows_Null_OnChanged_Parameter()
        {
            // arrange
            string property = null;

            // act
            SetPropertyOnly(ref property, "Property Value", null);

            // assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SetPropertyOnly_Local_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetPropertyOnly(ref property, "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_With_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", ref property, "Property Value", () => onChangedCount++, new string[] { "1", "2" });

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_With_Param_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", ref property, "Property Value", () => onChangedCount++, "1", "2");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_With_Affect_Property_Name_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", ref property, "Property Value", () => onChangedCount++, "1");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetPropert_Local_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty("Property Name", ref property, "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_By_Lambda_Property_Name_With_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, ref property, "Property Value", () => onChangedCount++, new string[] { "1", "2" });

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_By_Lambda_Property_Name_With_Param_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, ref property, "Property Value", () => onChangedCount++, "1", "2");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetProperty_Local_By_Lambda_Property_Name_With_Affect_Property_Name_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, ref property, "Property Value", () => onChangedCount++, "1");

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetPropert_Local_By_Lambda_Property_Name_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetProperty(() => TestProperty, ref property, "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }


#if !NICENIS_4C

        [TestMethod]
        public void SetCallerProperty_Local_With_Affect_Property_Names_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetCallerProperty(ref property, "Property Value", () => onChangedCount++, new string[] { "1", "2" });

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

        [TestMethod]
        public void SetCallerProperty_Local_Calls_OnChanged_Parameter_When_Property_Value_Is_Changed()
        {
            // arrange
            string property = null;
            int onChangedCount = 0;

            // act
            SetCallerProperty(ref property, "Property Value", () => onChangedCount++);

            // assert
            Assert.IsTrue(onChangedCount == 1);
        }

#endif

        #endregion
    }
}
