/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.07.12
 * Version  $Id$
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
    public class TruthyToCollapsedConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new TruthyToCollapsedConverter();

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
            IValueConverter converter = new TruthyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class TruthyToFalseConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new TruthyToFalseConverter();

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
            IValueConverter converter = new TruthyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(value, typeof(bool), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class TruthyToHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new TruthyToHiddenConverter();

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
            IValueConverter converter = new TruthyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class TruthyToTrueConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new TruthyToTrueConverter();

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
            IValueConverter converter = new TruthyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(value, typeof(bool), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class TruthyToVisibleConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new TruthyToVisibleConverter();

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
            IValueConverter converter = new TruthyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }
    }

    [TestClass]
    public class TruthyToVisibleOtherwiseHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Truthy()
        {
            // arrange
            bool value = true;
            IValueConverter converter = new TruthyToVisibleOtherwiseHiddenConverter();

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
            IValueConverter converter = new TruthyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(value, typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }
    }

    [TestClass]
    public class AllTruthyToCollapsedConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllTruthyToCollapsedConverter();

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
            IMultiValueConverter converter = new AllTruthyToCollapsedConverter();

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
            IMultiValueConverter converter = new AllTruthyToCollapsedConverter();

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
            IMultiValueConverter converter = new AllTruthyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class AllTruthyToFalseConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllTruthyToFalseConverter();

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
            IMultiValueConverter converter = new AllTruthyToFalseConverter();

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
            IMultiValueConverter converter = new AllTruthyToFalseConverter();

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
            IMultiValueConverter converter = new AllTruthyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class AllTruthyToHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllTruthyToHiddenConverter();

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
            IMultiValueConverter converter = new AllTruthyToHiddenConverter();

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
            IMultiValueConverter converter = new AllTruthyToHiddenConverter();

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
            IMultiValueConverter converter = new AllTruthyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class AllTruthyToTrueConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllTruthyToTrueConverter();

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
            IMultiValueConverter converter = new AllTruthyToTrueConverter();

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
            IMultiValueConverter converter = new AllTruthyToTrueConverter();

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
            IMultiValueConverter converter = new AllTruthyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class AllTruthyToVisibleConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllTruthyToVisibleConverter();

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
            IMultiValueConverter converter = new AllTruthyToVisibleConverter();

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
            IMultiValueConverter converter = new AllTruthyToVisibleConverter();

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
            IMultiValueConverter converter = new AllTruthyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }
    }

    [TestClass]
    public class AllTruthyToVisibleOtherwiseHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AllTruthyToVisibleOtherwiseHiddenConverter();

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
            IMultiValueConverter converter = new AllTruthyToVisibleOtherwiseHiddenConverter();

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
            IMultiValueConverter converter = new AllTruthyToVisibleOtherwiseHiddenConverter();

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
            IMultiValueConverter converter = new AllTruthyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }
    }

    [TestClass]
    public class AnyTruthyToCollapsedConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyTruthyToCollapsedConverter();

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
            IMultiValueConverter converter = new AnyTruthyToCollapsedConverter();

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
            IMultiValueConverter converter = new AnyTruthyToCollapsedConverter();

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
            IMultiValueConverter converter = new AnyTruthyToCollapsedConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Collapsed);
        }
    }

    [TestClass]
    public class AnyTruthyToFalseConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyTruthyToFalseConverter();

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
            IMultiValueConverter converter = new AnyTruthyToFalseConverter();

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
            IMultiValueConverter converter = new AnyTruthyToFalseConverter();

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
            IMultiValueConverter converter = new AnyTruthyToFalseConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class AnyTruthyToHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyTruthyToHiddenConverter();

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
            IMultiValueConverter converter = new AnyTruthyToHiddenConverter();

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
            IMultiValueConverter converter = new AnyTruthyToHiddenConverter();

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
            IMultiValueConverter converter = new AnyTruthyToHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Hidden);
        }
    }

    [TestClass]
    public class AnyTruthyToTrueConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyTruthyToTrueConverter();

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
            IMultiValueConverter converter = new AnyTruthyToTrueConverter();

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
            IMultiValueConverter converter = new AnyTruthyToTrueConverter();

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
            IMultiValueConverter converter = new AnyTruthyToTrueConverter();

            // act
            bool result = (bool)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result);
        }
    }

    [TestClass]
    public class AnyTruthyToVisibleConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyTruthyToVisibleConverter();

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
            IMultiValueConverter converter = new AnyTruthyToVisibleConverter();

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
            IMultiValueConverter converter = new AnyTruthyToVisibleConverter();

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
            IMultiValueConverter converter = new AnyTruthyToVisibleConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }

    [TestClass]
    public class AnyTruthyToVisibleOtherwiseHiddenConverterTests
    {
        [TestMethod]
        public void Convert_Check_Booleany_Array_Empty()
        {
            // arrange
            bool[] values = new bool[0];
            IMultiValueConverter converter = new AnyTruthyToVisibleOtherwiseHiddenConverter();

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
            IMultiValueConverter converter = new AnyTruthyToVisibleOtherwiseHiddenConverter();

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
            IMultiValueConverter converter = new AnyTruthyToVisibleOtherwiseHiddenConverter();

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
            IMultiValueConverter converter = new AnyTruthyToVisibleOtherwiseHiddenConverter();

            // act
            Visibility result = (Visibility)converter.Convert(values.Cast<object>().ToArray(), typeof(Visibility), null, Thread.CurrentThread.CurrentUICulture);

            // assert
            Assert.IsTrue(result == Visibility.Visible);
        }
    }
}
