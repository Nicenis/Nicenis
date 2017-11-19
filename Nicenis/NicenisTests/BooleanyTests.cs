/*
 * Author   JO Hyeong-Ryeol
 * Since    2013.07.11
 * 
 * This file is a part of the Nicenis project.
 * https://github.com/nicenis/nicenis
 * 
 * Copyright (C) 2013 JO Hyeong-Ryeol. All rights reserved.
 */

#if NICENIS_UWP
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif
using Nicenis;
using System;
using System.Collections;

namespace NicenisTests
{
    [TestClass]
    public class BooleanyTests
    {
        [TestMethod]
        public void IsTruthy_Check_Object_Null()
        {
            // arrange
            object value = null;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Object_NotNull()
        {
            // arrange
            object value = new object();

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_String_Empty()
        {
            // arrange
            string value = string.Empty;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_String_NonEmpty()
        {
            // arrange
            string value = " ";

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Boolean_True()
        {
            // arrange
            bool value = true;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Boolean_False()
        {
            // arrange
            bool value = false;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Int_Zero()
        {
            // arrange
            int value = 0;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Int_NonZero()
        {
            // arrange
            int value = 10;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Double_Zero()
        {
            // arrange
            double value = 0d;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Double_NonZero()
        {
            // arrange
            double value = 10d;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Double_NaN()
        {
            // arrange
            double value = double.NaN;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Double_PositiveInfinity()
        {
            // arrange
            double value = double.PositiveInfinity;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Double_NegativeInfinity()
        {
            // arrange
            double value = double.NegativeInfinity;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Long_Zero()
        {
            // arrange
            long value = 0L;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Long_NonZero()
        {
            // arrange
            long value = 10L;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_ICollection_Empty()
        {
            // arrange
            ICollection value = new int[0];

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_ICollection_NonEmpty()
        {
            // arrange
            ICollection value = new int[] { 1, 2, 3 };

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        public static IEnumerable GetEmptyEnumerable()
        {
            yield break;
        }

        [TestMethod]
        public void IsTruthy_Check_IEnumerable_Empty()
        {
            // arrange
            IEnumerable value = GetEmptyEnumerable();

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        public static IEnumerable GetNonEmptyEnumerable()
        {
            for (int i = 0; i < 10; i++)
                yield return i;
        }

        [TestMethod]
        public void IsTruthy_Check_IEnumerable_NonEmpty()
        {
            // arrange
            IEnumerable value = GetNonEmptyEnumerable();

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_DBNull()
        {
            // arrange
            DBNull value = DBNull.Value;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_SByte_Zero()
        {
            // arrange
            sbyte value = 0;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_SByte_NonZero()
        {
            // arrange
            sbyte value = 10;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Byte_Zero()
        {
            // arrange
            byte value = 0;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Byte_NonZero()
        {
            // arrange
            byte value = 10;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Short_Zero()
        {
            // arrange
            short value = 0;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Short_NonZero()
        {
            // arrange
            short value = 10;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_UShort_Zero()
        {
            // arrange
            ushort value = 0;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_UShort_NonZero()
        {
            // arrange
            ushort value = 10;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_UInt_Zero()
        {
            // arrange
            uint value = 0;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_UInt_NonZero()
        {
            // arrange
            uint value = 10;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Float_Zero()
        {
            // arrange
            float value = 0f;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Float_NonZero()
        {
            // arrange
            float value = 10f;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Decimal_Zero()
        {
            // arrange
            decimal value = 0m;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsTruthy_Check_Decimal_NonZero()
        {
            // arrange
            decimal value = 10m;

            // act
            bool result = Booleany.IsTruthy(value);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsFalsy_Check_Boolean_True()
        {
            // arrange
            bool value = true;

            // act
            bool result = Booleany.IsFalsy(value);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsFalsy_Check_Boolean_False()
        {
            // arrange
            bool value = false;

            // act
            bool result = Booleany.IsFalsy(value);

            // assert
            Assert.IsTrue(result);
        }
    }
}
