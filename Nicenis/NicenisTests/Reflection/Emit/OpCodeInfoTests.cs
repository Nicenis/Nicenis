/*
 * Author   JO Hyeong-Ryeol
 * Since    2015.06.21
 *
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2015 JO Hyeong-Ryeol. All rights reserved.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nicenis.Reflection.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicenisTests.Reflection.Emit
{
    [TestClass]
    public class OpCodeInfoTests
    {
        [TestMethod]
        public void GetTotalSize_Supports_ldarg()
        {
            // arrange
            byte[] opCode = new byte[] { 0xFE, 0x09 };

            // act
            int totalSize = OpCodeInfo.GetTotalSize(opCode, 0);

            // assert
            Assert.IsTrue(totalSize == 4);
        }

        [TestMethod]
        public void GetTotalSize_Supports_call()
        {
            // arrange
            byte[] opCode = new byte[] { 0x28 };

            // act
            int totalSize = OpCodeInfo.GetTotalSize(opCode, 0);

            // assert
            Assert.IsTrue(totalSize == 5);
        }
    }
}
