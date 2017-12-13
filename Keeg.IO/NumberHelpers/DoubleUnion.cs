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
using System.Runtime.InteropServices;

namespace Keeg.IO.NumberHelpers
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct DoubleUnion
    {
        [FieldOffset(0)]
        private double D;

        [FieldOffset(0)]
        private ulong U;

        public DoubleUnion(double data)
        {
            U = default(ulong);
            D = data;
        }

        public DoubleUnion(ulong data)
        {
            D = default(double);
            U = data;
        }

        public double AsDouble
        {
            get { return D; }
            set { D = value; }
        }

        public ulong AsUInt64
        {
            get { return U; }
            set { U = value; }
        }
    }
}
