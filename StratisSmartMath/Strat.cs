namespace StratisSmartMath
{
    public struct Strat
    {
        private const ulong StratoshisPerStrat = 100_000_000;
        private const int MAX_DP = 8;

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

        public Stratoshi ToStratoshis() => _value;

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

        public override string ToString()
        {
            var paddedValue = _value.ToString().PadLeft(MAX_DP + 1, '0');
            return paddedValue.Insert(paddedValue.Length - MAX_DP, ".");
        }

        private static Stratoshi ParseIntegerDigits(string value)
        {
            return ulong.Parse(value) * StratoshisPerStrat;
        }

        private static Stratoshi ParseFractionalDigits(string value)
        {
            return ulong.Parse(value.PadRight(MAX_DP, '0'));
        }

        public override bool Equals(object obj)
        {
            if (obj is ulong || obj is Stratoshi || obj is Strat)
            {
                return _value.Equals((Stratoshi)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return -1939223833 + _value.GetHashCode();
        }
    }
}
