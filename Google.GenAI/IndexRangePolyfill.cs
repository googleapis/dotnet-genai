// Copyright 2026 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if NETSTANDARD2_0

using System;
using System.Runtime.CompilerServices;

namespace System
{
    internal readonly struct Index : IEquatable<Index>
    {
        private readonly int _value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Index(int value, bool fromEnd = false)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
            }

            _value = fromEnd ? ~value : value;
        }

        private Index(int value)
        {
            _value = value;
        }

        public static Index Start => new Index(0);
        public static Index End => new Index(~0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index FromStart(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
            }

            return new Index(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Index FromEnd(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "value must be non-negative");
            }

            return new Index(~value);
        }

        public int Value => _value < 0 ? ~_value : _value;
        public bool IsFromEnd => _value < 0;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetOffset(int length)
        {
            int offset = _value;
            if (IsFromEnd)
            {
                offset += length + 1;
            }
            return offset;
        }

        public override bool Equals(object? value) => value is Index index && _value == index._value;
        public bool Equals(Index other) => _value == other._value;
        public override int GetHashCode() => _value;
        public static implicit operator Index(int value) => FromStart(value);

        public override string ToString()
        {
            if (IsFromEnd)
            {
                return "^" + ((uint)Value).ToString();
            }

            return ((uint)Value).ToString();
        }
    }

    internal readonly struct Range : IEquatable<Range>
    {
        public Index Start { get; }
        public Index End { get; }

        public Range(Index start, Index end)
        {
            Start = start;
            End = end;
        }

        public override bool Equals(object? value) => value is Range range && Start.Equals(range.Start) && End.Equals(range.End);
        public bool Equals(Range other) => Start.Equals(other.Start) && End.Equals(other.End);
        public override int GetHashCode() => Start.GetHashCode() ^ End.GetHashCode();

        public override string ToString()
        {
            return Start.ToString() + ".." + End.ToString();
        }

        public static Range All => new Range(Index.Start, Index.End);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public (int Offset, int Length) GetOffsetAndLength(int length)
        {
            int start = Start.GetOffset(length);
            int end = End.GetOffset(length);

            if ((uint)start > (uint)length || (uint)end > (uint)length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            return (start, end - start);
        }
    }
}

#endif
