namespace StratisSmartMath
{
    /// <summary>
    /// Represents a single token
    /// </summary>
    public struct Strat
    {
        private const ulong _stratoshisPerStrat = 100_000_000;
        private const int _maxDecimials = 8;

        readonly Stratoshi _value;

        internal Strat(Stratoshi value)
        {
            _value = value;
        }

        public static Strat operator +(Strat s1, Strat s2) => new Strat(s1._value + s2._value);

        public static Strat operator -(Strat s1, Strat s2) => new Strat(s1._value - s2._value);

        public static Strat operator +(Strat s1, Stratoshi s2) => new Strat(s1._value + s2);

        public static Strat operator -(Strat s1, Stratoshi s2) => new Strat(s1._value - s2);

        public static Strat operator *(Strat s1, byte multiplier) => new Strat(s1._value * multiplier);

        public static Strat operator *(Strat s1, ushort multiplier) => new Strat(s1._value * multiplier);

        public static Strat operator *(Strat s1, uint multiplier) => new Strat(s1._value * multiplier);

        public static Strat operator *(Strat s1, ulong multiplier) => new Strat(s1._value * multiplier);

        public static explicit operator Strat(Stratoshi value) => value.ToStrats();

        public static bool operator ==(Strat s1, Strat s2) => s1._value == s2._value;

        public static bool operator !=(Strat s1, Strat s2) => s1._value != s2._value;

        public static bool operator >(Strat s1, Strat s2) => s1._value > s2._value;

        public static bool operator <(Strat s1, Strat s2) => s1._value < s2._value;

        public static bool operator >=(Strat s1, Strat s2) => s1._value >= s2._value;

        public static bool operator <=(Strat s1, Strat s2) => s1._value <= s2._value;

        public static bool operator ==(Strat s1, Stratoshi s2) => s1._value == s2;

        public static bool operator !=(Strat s1, Stratoshi s2) => s1._value != s2;

        public static bool operator >(Strat s1, Stratoshi s2) => s1._value > s2;

        public static bool operator <(Strat s1, Stratoshi s2) => s1._value < s2;

        public static bool operator >=(Strat s1, Stratoshi s2) => s1._value >= s2;

        public static bool operator <=(Strat s1, Stratoshi s2) => s1._value <= s2;

        /// <summary>
        /// Parses a token amount string
        /// </summary>
        /// <param name="value">String representation of the value</param>
        /// <returns>The Strat value</returns>
        public static Strat Parse(string value)
        {
            Stratoshi integerAmount = 0;
            Stratoshi fractionalAmount = 0;
            if (!value.Contains("."))
            {
                integerAmount = ParseIntegerDigits(value);
            }
            else if (value.StartsWith("."))
            {
                fractionalAmount = ParseFractionalDigits(value.Substring(1));
            }
            else
            {
                var parts = value.Split('.');
                integerAmount = ParseIntegerDigits(parts[0]);
                fractionalAmount = ParseFractionalDigits(parts[1]);
            }

            return new Strat(integerAmount + fractionalAmount);
        }

        private static Stratoshi ParseIntegerDigits(string value)
        {
            return ulong.Parse(value) * _stratoshisPerStrat;
        }

        private static Stratoshi ParseFractionalDigits(string value)
        {
            return ulong.Parse(value.PadRight(_maxDecimials, '0'));
        }

        /// <summary>
        /// Convert to <see cref="Stratoshi"/> units
        /// </summary>
        /// <returns><see cref="Stratoshi"/> representation</returns>
        public Stratoshi ToStratoshis() => _value;

        /// <summary>
        /// Returns the token value as a string, in the format x.xxxxxxxx
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            var paddedValue = _value.ToString().PadLeft(_maxDecimials + 1, '0');
            return paddedValue.Insert(paddedValue.Length - _maxDecimials, ".");
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Stratoshi || obj is Strat)
            {
                return _value.Equals((Stratoshi)obj);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return -1939223833 + _value.GetHashCode();
        }
    }
}
