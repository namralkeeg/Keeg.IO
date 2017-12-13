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
using System.Runtime.CompilerServices;

namespace Keeg.IO.NumberHelpers
{
    public enum Endian : Byte
    {
        Big,
        Little,
#if BIGENDIAN
        Native = Big,
#else
        Native = Little,
#endif
    }

    public static partial class NumberHelper
    {
        internal static bool Doswap(Endian endian)
        {
            if (endian == Endian.Native)
                return false;

            switch (endian)
            {
                case Endian.Little: return !BitConverter.IsLittleEndian;
                case Endian.Big: return BitConverter.IsLittleEndian;
                default: throw new ArgumentException("Endian type not supported.");
            }
        }

        public static ushort BigToNative(this ushort value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static short BigToNative(this short value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static uint BigToNative(this uint value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static int BigToNative(this int value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static ulong BigToNative(this ulong value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static long BigToNative(this long value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static float BigToNative(this float value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static double BigToNative(this double value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static ushort LittleToNative(this ushort value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static short LittleToNative(this short value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static uint LittleToNative(this uint value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static int LittleToNative(this int value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static ulong LittleToNative(this ulong value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static long LittleToNative(this long value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static float LittleToNative(this float value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static double LittleToNative(this double value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static ushort NativeToBig(this ushort value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static short NativeToBig(this short value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static uint NativeToBig(this uint value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static int NativeToBig(this int value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static ulong NativeToBig(this ulong value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static long NativeToBig(this long value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static float NativeToBig(this float value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static double NativeToBig(this double value)
        {
            if (Doswap(Endian.Big))
                return value.Swap();
            else
                return value;
        }

        public static ushort NativeToLittle(this ushort value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static short NativeToLittle(this short value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static uint NativeToLittle(this uint value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static int NativeToLittle(this int value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static ulong NativeToLittle(this ulong value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static long NativeToLittle(this long value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static float NativeToLittle(this float value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }

        public static double NativeToLittle(this double value)
        {
            if (Doswap(Endian.Little))
                return value.Swap();
            else
                return value;
        }
    }
}
