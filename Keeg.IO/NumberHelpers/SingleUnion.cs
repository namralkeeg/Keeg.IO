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
    internal struct SingleUnion
    {
        [FieldOffset(0)]
        private float F;

        [FieldOffset(0)]
        private uint U;

        public SingleUnion(float data)
        {
            U = default(uint);
            F = data;
        }

        public SingleUnion(uint data)
        {
            F = default(float);
            U = data;
        }

        public float AsSingle
        {
            get { return F; }
            set { F = value; }
        }

        public UInt32 AsUInt32
        {
            get { return U; }
            set { U = value; }
        }
    }
}
