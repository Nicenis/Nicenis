/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.07.12
 *
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicenis.Windows.Data.Converters;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Data;

namespace NicenisTests.Windows.Data.Converters
{
    [TestClass]
    public class FalsyToCollapsedConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new FalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Falsy()
        {
            // arrange
            bool value = false;
            IValueConverter converter = new FalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }
    }

    [TestClass]
    public class FalsyToFalseConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new FalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(value, typeof(bool), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Falsy()
        {
            // arrange
            bool value = false;
            IValueConverter converter = new FalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(value, typeof(bool), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class FalsyToHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new FalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Falsy()
        {
            // arrange
            bool value = false;
            IValueConverter converter = new FalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }
    }

    [TestClass]
    public class FalsyToTrueConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new FalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(value, typeof(bool), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Falsy()
        {
            // arrange
            bool value = false;
            IValueConverter converter = new FalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(value, typeof(bool), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class FalsyToVisibleConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new FalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Falsy()
        {
            // arrange
            bool value = false;
            IValueConverter converter = new FalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class FalsyToVisibleOtherwiseHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new FalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Falsy()
        {
            // arrange
            bool value = false;
            IValueConverter converter = new FalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class AllFalsyToCollapsedConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AllFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AllFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AllFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class AllFalsyToFalseConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AllFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AllFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AllFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class AllFalsyToHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AllFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AllFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AllFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class AllFalsyToTrueConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AllFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AllFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AllFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class AllFalsyToVisibleConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AllFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AllFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AllFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }
    }

    [TestClass]
    public class AllFalsyToVisibleOtherwiseHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AllFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AllFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AllFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }
    }

    [TestClass]
    public class AnyFalsyToCollapsedConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AnyFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AnyFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AnyFalsyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }
    }

    [TestClass]
    public class AnyFalsyToFalseConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AnyFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AnyFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AnyFalsyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class AnyFalsyToHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AnyFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AnyFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AnyFalsyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }
    }

    [TestClass]
    public class AnyFalsyToTrueConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AnyFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AnyFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AnyFalsyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class AnyFalsyToVisibleConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AnyFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AnyFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AnyFalsyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class AnyFalsyToVisibleOtherwiseHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Truthies()
        {
            // arrange
            bool[] values = new bool[] { true, true };
            IMultiValueConverter converter = new AnyFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Falsies()
        {
            // arrange
            bool[] values = new bool[] { false, false };
            IMultiValueConverter converter = new AnyFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }

        [TestMethod]
        public void Convert_Check_Booleany_Array_Mixed()
        {
            // arrange
            bool[] values = new bool[] { true, false };
            IMultiValueConverter converter = new AnyFalsyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }
}
