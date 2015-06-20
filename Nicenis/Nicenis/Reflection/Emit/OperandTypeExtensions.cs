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
using System.Reflection.Emit;

namespace Nicenis.Reflection.Emit
{
    /// <summary>
    /// Provides extension methods for the System.Reflection.Emit.OperandType.
    /// </summary>
    internal static class OperandTypeExtensions
    {
        /// <summary>
        /// Gets the operand size in bytes.
        /// </summary>
        /// <param name="operandType">The operand type.</param>
        /// <returns>The operand size in bytes.</returns>
        public static int GetSize(this OperandType operandType)
        {
            switch (operandType)
            {
                case System.Reflection.Emit.OperandType.InlineNone:
#pragma warning disable 0618
                case System.Reflection.Emit.OperandType.InlinePhi:
#pragma warning restore 0618
                    return 0;

                case System.Reflection.Emit.OperandType.ShortInlineBrTarget:
                case System.Reflection.Emit.OperandType.ShortInlineI:
                case System.Reflection.Emit.OperandType.ShortInlineVar:
                    return 1;

                case System.Reflection.Emit.OperandType.InlineVar:
                    return 2;

                case System.Reflection.Emit.OperandType.InlineBrTarget:
                case System.Reflection.Emit.OperandType.InlineField:
                case System.Reflection.Emit.OperandType.InlineI:
                case System.Reflection.Emit.OperandType.InlineMethod:
                case System.Reflection.Emit.OperandType.InlineSig:
                case System.Reflection.Emit.OperandType.InlineString:
                case System.Reflection.Emit.OperandType.InlineSwitch:
                case System.Reflection.Emit.OperandType.InlineTok:
                case System.Reflection.Emit.OperandType.InlineType:
                case System.Reflection.Emit.OperandType.ShortInlineR:
                    return 4;

                case System.Reflection.Emit.OperandType.InlineI8:
                case System.Reflection.Emit.OperandType.InlineR:
                    return 8;

                default:
                    throw new InvalidOperationException(string.Format("Unknown OperandType: {0}", operandType));
            }
        }
    }
}