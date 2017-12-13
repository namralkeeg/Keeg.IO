#region Copyright
/*
 * Copyright (C) 2017 Larry Lopez
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to
 * deal in the Software without restriction, including without limitation the
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
 * sell copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
 * IN THE SOFTWARE.
 */
 #endregion
using System;

namespace Keeg.IO.NumberHelpers
{
    public static partial class NumberHelpers
    {
        public static byte RotateLeft(this byte value, int count)
        {
            return (byte)((value << count) | (value >> (8 - count)));
        }

        public static sbyte RotateLeft(this sbyte value, int count)
        {
            return (sbyte)(((byte)value).RotateLeft(count));
        }

        public static ushort RotateLeft(this ushort value, int count)
        {
            return (ushort)((value << count) | (value >> (16 - count)));
        }

        public static short RotateLeft(this short value, int count)
        {
            return (short)(((ushort)value).RotateLeft(count));
        }

        public static uint RotateLeft(this uint value, int count)
        {
            return (value << count) | (value >> (32 - count));
        }

        public static int RotateLeft(this int value, int count)
        {
            return (int)(((uint)value).RotateLeft(count));
        }

        public static ulong RotateLeft(this ulong value, int count)
        {
            return (value << count) | (value >> (64 - count));
        }

        public static long RotateLeft(this long value, int count)
        {
            return (long)(((ulong)value).RotateLeft(count));
        }

        public static byte RotateRight(this byte value, int count)
        {
            return (byte)((value >> count) | (value << (8 - count)));
        }

        public static sbyte RotateRight(this sbyte value, int count)
        {
            return (sbyte)(((byte)value).RotateRight(count));
        }

        public static ushort RotateRight(this ushort value, int count)
        {
            return (ushort)((value >> count) | (value << (16 - count)));
        }

        public static short RotateRight(this short value, int count)
        {
            return (short)(((ushort)value).RotateRight(count));
        }

        public static uint RotateRight(this uint value, int count)
        {
            return (value >> count) | (value << (32 - count));
        }

        public static int RotateRight(this int value, int count)
        {
            return (int)(((uint)value).RotateRight(count));
        }

        public static ulong RotateRight(this ulong value, int count)
        {
            return (value >> count) | (value << (64 - count));
        }

        public static long RotateRight(this long value, int count)
        {
            return (long)(((ulong)value).RotateRight(count));
        }
    }
}
