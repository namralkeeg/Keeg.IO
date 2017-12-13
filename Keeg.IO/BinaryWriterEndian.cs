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
using System.Diagnostics.Contracts;
using System.IO;
using System.Text;
using Keeg.IO.NumberHelpers;

namespace Keeg.IO
{
    [Serializable]
    public class BinaryWriterEndian : BinaryWriter
    {
        protected Endian    m_byteOrder;
        protected bool      m_doSwap;
        protected Encoding  m_encoding;
        protected Encoder   m_encoder;

        public Endian ByteOrder
        {
            get => m_byteOrder;
            set
            {
                m_byteOrder = value;
                m_doSwap = (m_byteOrder.Doswap()) ? true : false;
            }
        }

        public BinaryWriterEndian(Stream output) : this(output, new UTF8Encoding(false, true), false, Endian.Native)
        {
        }

        public BinaryWriterEndian(Stream output, Encoding encoding, Endian byteOrder)
            : this(output, encoding, false, byteOrder)
        {
        }

        public BinaryWriterEndian(Stream output, Encoding encoding, bool leaveOpen, Endian byteOrder)
            : base(output, encoding, leaveOpen)
        {
            if (output == null)
                throw new ArgumentNullException("output");
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            if (!output.CanWrite)
                throw new ArgumentException("Stream Not Writable");
            Contract.EndContractBlock();

            m_byteOrder = byteOrder;
            m_encoding = encoding;
            m_encoder = m_encoding.GetEncoder();
            m_doSwap = (m_byteOrder.Doswap()) ? true : false;
        }

        protected BinaryWriterEndian()
        {
        }

        // Writes a double to this stream. The current position of the stream is
        // advanced by eight.
        public override void Write(double value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        // Writes a two-byte signed integer to this stream. The current position of
        // the stream is advanced by two.
        public override void Write(short value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        // Writes a two-byte unsigned integer to this stream. The current position
        // of the stream is advanced by two.
        public override void Write(ushort value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        // Writes a four-byte signed integer to this stream. The current position
        // of the stream is advanced by four.
        // 
        public override void Write(int value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        // Writes a four-byte unsigned integer to this stream. The current position
        // of the stream is advanced by four.
        public override void Write(uint value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        // Writes an eight-byte signed integer to this stream. The current position
        // of the stream is advanced by eight.
        public override void Write(long value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        // Writes an eight-byte unsigned integer to this stream. The current 
        // position of the stream is advanced by eight.
        public override void Write(ulong value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        // Writes a float to this stream. The current position of the stream is
        // advanced by four.
        public override void Write(float value)
        {
            if (m_doSwap)
                value = value.Swap();

            base.Write(value);
        }

        public virtual void Write(string value, Prefix prefix)
        {
            Write(value, prefix, false);
        }

        public virtual void Write(string value, Prefix prefix, bool isNullTerminated)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            Contract.EndContractBlock();

            if (isNullTerminated)
                value = value + '\0';

            ulong byteCount = (ulong)m_encoding.GetByteCount(value);
            switch (prefix)
            {
                case Prefix.PByte:
                    {
                        if ((byte)byteCount < byteCount)
                            throw new ArgumentException("String size is greater than " + byte.MaxValue);
                        Write((Byte)byteCount);
                        break;
                    }
                case Prefix.PUInt16:
                    {
                        if ((ushort)byteCount < byteCount)
                            throw new ArgumentException("String size is greater than " + ushort.MaxValue);
                        var size = (m_doSwap) ? ((ushort)byteCount).Swap() : (ushort)byteCount;
                        Write(size);
                        break;
                    }
                case Prefix.PUInt32:
                    {
                        if ((uint)byteCount < byteCount)
                            throw new ArgumentException("String size is greater than " + uint.MaxValue);
                        var size = (m_doSwap) ? ((uint)byteCount).Swap() : (uint)byteCount;
                        Write(size);
                        break;
                    }
                case Prefix.PUInt64:
                    {
                        var size = (m_doSwap) ? byteCount.Swap() : byteCount;
                        Write(size);
                        break;
                    }
                default: throw new Exception("Unknown prefix type");
            }

            // TODO: Optimize for larger sized strings.
            byte[] stringBytes = new byte[byteCount];
            int bytes = m_encoding.GetBytes(value, 0, (int)byteCount/m_encoding.GetMaxByteCount(1), stringBytes, 0);

            Write(stringBytes, 0, bytes);
        }

        public virtual void Write(string value, uint length)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            if (length < 1)
                throw new ArgumentOutOfRangeException("length");
            Contract.EndContractBlock();

            var bytes = m_encoding.GetBytes(value);
            Array.Resize(ref bytes, (int)length);
            Write(bytes);
        }

        public virtual void Write(string value, char c)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            Contract.EndContractBlock();

            var bytes = m_encoding.GetBytes(value.PadRight(value.Length + 1, c));
            Write(bytes);
        }

        public virtual void WriteBString(string value)
        {
            Write(value, Prefix.PByte, false);
        }

        public virtual void WriteBZString(string value)
        {
            Write(value, Prefix.PByte, true);
        }

        public virtual void WriteWString(string value)
        {
            Write(value, Prefix.PUInt16, false);
        }

        public virtual void WriteWZString(string value)
        {
            Write(value, Prefix.PUInt16, true);
        }

        public virtual void WriteZString(string value)
        {
            Write(value, '\0');
        }
    }
}
