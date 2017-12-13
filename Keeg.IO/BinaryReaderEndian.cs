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
    public class BinaryReaderEndian : BinaryReader
    {
        protected Endian    m_byteOrder;
        protected bool      m_doSwap;
        protected Encoding  m_encoding;
        protected Decoder   m_decoder;


        public Endian ByteOrder
        {
            get => m_byteOrder;
            set
            {
                m_byteOrder = value;
                m_doSwap = (m_byteOrder.Doswap()) ? true : false;
            }
        }

        #region Constructors
        public BinaryReaderEndian(Stream input) : this(input, new UTF8Encoding(false, true), false, Endian.Native)
        {
        }

        public BinaryReaderEndian(Stream input, Encoding encoding, Endian byteOrder)
            : this(input, encoding, false, byteOrder)
        {
        }

        public BinaryReaderEndian(Stream input, Encoding encoding, bool leaveOpen, Endian byteOrder)
            : base(input, encoding, leaveOpen)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            if (encoding == null)
                throw new ArgumentNullException("encoding");
            if (!input.CanRead)
                throw new ArgumentException("Stream Not Readable");
            Contract.EndContractBlock();

            ByteOrder = byteOrder;
            m_encoding = encoding;
            m_decoder = m_encoding.GetDecoder();
            m_doSwap = (byteOrder.Doswap()) ? true : false;
        }
        #endregion

        public override short ReadInt16()
        {
            var value = base.ReadInt16();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public override ushort ReadUInt16()
        {
            var value = base.ReadUInt16();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public override int ReadInt32()
        {
            var value = base.ReadInt32();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public override uint ReadUInt32()
        {
            var value = base.ReadUInt32();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public override long ReadInt64()
        {
            var value = base.ReadInt64();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public override ulong ReadUInt64()
        {
            var value = base.ReadUInt64();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public override float ReadSingle()
        {
            var value = base.ReadSingle();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public override double ReadDouble()
        {
            var value = base.ReadDouble();
            if (m_doSwap)
                value = value.Swap();

            return value;
        }

        public virtual string ReadBString()
        {
            return ReadPrefixString(Prefix.PByte, false);
        }

        public virtual string ReadBZString()
        {
            return ReadPrefixString(Prefix.PByte, true);
        }

        public virtual string ReadWString()
        {
            return ReadPrefixString(Prefix.PUInt16, false);
        }

        public virtual string ReadWZString()
        {
            return ReadPrefixString(Prefix.PUInt16, true);
        }

        public virtual string ReadZString()
        {
            return ReadTerminatedString('\0');
        }

        public virtual string ReadPrefixString(Prefix prefix)
        {
            return ReadPrefixString(prefix, false);
        }

        public virtual string ReadPrefixString(Prefix prefix, bool isNullTerminated)
        {
            ulong byteCount = 0;
            switch (prefix)
            {
                case Prefix.PByte: byteCount = ReadByte(); break;
                case Prefix.PUInt16: byteCount = ReadUInt16(); break;
                case Prefix.PUInt32: byteCount = ReadUInt32(); break;
                case Prefix.PUInt64: byteCount = ReadUInt64(); break;
                default: byteCount = 0; break;
            }

            var data = ReadBytes((int)byteCount);
            if (isNullTerminated)
            {
                StripTrailingNulls(ref data);
            }

            var preString = m_encoding.GetString(data);

            return preString;
        }

        public virtual string ReadFixedString(int length)
        {
            if (length < 1)
                throw new ArgumentOutOfRangeException("length");
            Contract.EndContractBlock();

            var data = ReadBytes(length);
            StripTrailingNulls(value: ref data);
            var value = m_encoding.GetString(data);

            return value;
        }

        public virtual string ReadTerminatedString(char end)
        {
            StringBuilder s = new StringBuilder();
            char c = ReadChar();

            while (c != end)
            {
                s.Append(c);
                c = ReadChar();
            }

            return s.ToString();
        }

        protected virtual void StripTrailingNulls(ref byte[] value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            Contract.EndContractBlock();

            int i = value.Length - 1;
            while (value[i] == 0)
            {
                --i;
            }

            Array.Resize(ref value, i + 1);
        }
    }
}
