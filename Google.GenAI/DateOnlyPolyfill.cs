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
using System.Globalization;

namespace System
{
    internal readonly struct DateOnly : IComparable, IComparable<DateOnly>, IEquatable<DateOnly>, IFormattable
    {
        private readonly DateTime _dateTime;

        public DateOnly(int year, int month, int day)
        {
            _dateTime = new DateTime(year, month, day);
        }

        public DateOnly(DateTime dateTime)
        {
            _dateTime = dateTime.Date;
        }

        public int Year => _dateTime.Year;
        public int Month => _dateTime.Month;
        public int Day => _dateTime.Day;

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (obj is DateOnly other) return CompareTo(other);
            throw new ArgumentException("Object must be of type DateOnly");
        }

        public int CompareTo(DateOnly other) => _dateTime.CompareTo(other._dateTime);
        public bool Equals(DateOnly other) => _dateTime.Equals(other._dateTime);
        public override bool Equals(object? obj) => obj is DateOnly other && Equals(other);
        public override int GetHashCode() => _dateTime.GetHashCode();

        public override string ToString() => _dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        public string ToString(string? format, IFormatProvider? formatProvider) => _dateTime.ToString(format, formatProvider);

        public static bool operator ==(DateOnly left, DateOnly right) => left.Equals(right);
        public static bool operator !=(DateOnly left, DateOnly right) => !left.Equals(right);
    }
}

#endif
