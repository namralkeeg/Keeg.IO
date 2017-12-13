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
using System.IO;
using System.Threading;

namespace Keeg.IO
{
    public static class SmallBufferedReader
    {
        public const int BufferSize = 8;

        private static readonly ThreadLocal<byte[]> smallBufer =
            new ThreadLocal<byte[]>(() => new byte[BufferSize]);

        public static byte[] SmallBuffer
        {
            get => smallBufer.Value;
            set => Array.Copy(value, smallBufer.Value, BufferSize);
        }

        public static byte[] ReadBytes(Stream stream, int count)
        {
            if (count < 0 || count > BufferSize)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            int n = 0;
            int bytesRead = 0;
            var buffer = smallBufer.Value;

            do
            {
                n = stream.Read(buffer, bytesRead, count - bytesRead);
                if (n == 0)
                {
                    throw new EndOfStreamException();
                }

                bytesRead += n;
            } while (bytesRead < count);

            return buffer;
        }
    }
}
