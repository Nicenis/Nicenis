/*
 * Author   JO Hyeong-Ryeol
 * Since    2015.06.21
 * 
 * This file is a part of the Nicenis project.
 * https://nicenis.codeplex.com
 * 
 * Copyright (C) 2015 JO Hyeong-Ryeol. All rights reserved.
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Nicenis.Reflection.Emit
{
    /// <summary>
    /// Represents OpCode information that is used to calculate the total byte size of an OpCode.
    /// </summary>
    internal class OpCodeInfo
    {
        static readonly OpCodeInfo[] All;


        #region Constructors

        static OpCodeInfo()
        {
            // Initializes all op code information.
            All =
            (
                from fieldInfo in typeof(OpCodes).GetFields(BindingFlags.Public | BindingFlags.Static)
                where fieldInfo.FieldType == typeof(OpCode)
                select fieldInfo.GetValue(null)
            )
            .Select
            (
                fieldValue =>
                {
                    OpCode opCode = (OpCode)fieldValue;
                    return new OpCodeInfo(opCode.Value, opCode.Size + opCode.OperandType.GetSize());
                }
            )
            .ToArray();
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="opCode">The OpCode.</param>
        /// <param name="totalSize">The OpCode size including all related data in bytes.</param>
        private OpCodeInfo(short opCode, int totalSize)
        {
            OpCode = opCode;
            TotalSize = totalSize;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// The OpCode.
        /// </summary>
        public short OpCode { get; private set; }

        /// <summary>
        /// The OpCode size including all related data in bytes.
        /// </summary>
        public int TotalSize { get; private set; }

        #endregion


        #region Public Static Methods

        /// <summary>
        /// Gets the OpCode size in bytes including all related data.
        /// </summary>
        /// <param name="ilBytes">The IL byte array.</param>
        /// <param name="startIndex">The OpCode start index.</param>
        /// <returns>The OpCode size in bytes including all related data.</returns>
        public static int GetTotalSize(byte[] ilBytes, int startIndex)
        {
            Debug.Assert(ilBytes != null);
            Debug.Assert(startIndex >= 0 && startIndex < ilBytes.Length);

            // Gets the OpCode value from the IL byte array.
            short opCode = ilBytes[startIndex];
            if (opCode == 0xFE)
            {
                if (ilBytes.Length <= startIndex + 1)
                    throw new ArgumentException(string.Format("Insufficient OpCode at {0}", startIndex));

                opCode = (short)((opCode << 8) + ilBytes[startIndex + 1]);
            }

            // Gets the OpCode information.
            OpCodeInfo opCodeInfo = All.FirstOrDefault(o => o.OpCode == opCode);
            if (opCodeInfo == null)
                throw new ArgumentException(string.Format("Unknown OpCode: 0x{0}", opCode.ToString("X4")));

            // Returns the OpCode total size.
            return opCodeInfo.TotalSize;
        }

        #endregion


        #region ToString

        public override string ToString()
        {
            return OpCode.ToString("X4");
        }

        #endregion
    }
}
