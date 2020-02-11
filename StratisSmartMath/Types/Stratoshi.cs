namespace StratisSmartMath
{
    /// <summary>
    /// Represents a one-hundred-millionth of a token
    /// </summary>
    public struct Stratoshi
    {
        readonly ulong _amount;

        internal Stratoshi(ulong amount)
        {
            _amount = amount;
        }

        public static Stratoshi operator +(Stratoshi s1, Stratoshi s2) => new Stratoshi(s1._amount + s2._amount);

        public static Stratoshi operator -(Stratoshi s1, Stratoshi s2) => new Stratoshi(s1._amount - s2._amount);

        public static Stratoshi operator +(Stratoshi s1, Strat s2) => new Stratoshi(s1._amount + s2.ToStratoshis()._amount);

        public static Stratoshi operator -(Stratoshi s1, Strat s2) => new Stratoshi(s1._amount - s2.ToStratoshis()._amount);

        public static Stratoshi operator *(Stratoshi s1, byte multiplier) => new Stratoshi(s1._amount * multiplier);

        public static Stratoshi operator *(Stratoshi s1, ushort multiplier) => new Stratoshi(s1._amount * multiplier);

        public static Stratoshi operator *(Stratoshi s1, uint multiplier) => new Stratoshi(s1._amount * multiplier);

        public static Stratoshi operator *(Stratoshi s1, ulong multiplier) => new Stratoshi(s1._amount * multiplier);

        public static explicit operator ulong(Stratoshi value) => value._amount;

        public static explicit operator Stratoshi(Strat value) => value.ToStratoshis();

        public static implicit operator Stratoshi(ulong value) => new Stratoshi(value);

        public static bool operator ==(Stratoshi s1, Stratoshi s2) => s1._amount == s2._amount;

        public static bool operator !=(Stratoshi s1, Stratoshi s2) => s1._amount != s2._amount;

        public static bool operator >(Stratoshi s1, Stratoshi s2) => s1._amount > s2._amount;

        public static bool operator <(Stratoshi s1, Stratoshi s2) => s1._amount < s2._amount;

        public static bool operator >=(Stratoshi s1, Stratoshi s2) => s1._amount >= s2._amount;

        public static bool operator <=(Stratoshi s1, Stratoshi s2) => s1._amount <= s2._amount;

        public static bool operator ==(Stratoshi s1, Strat s2) => s1._amount == s2.ToStratoshis();

        public static bool operator !=(Stratoshi s1, Strat s2) => s1._amount != s2.ToStratoshis();

        public static bool operator >(Stratoshi s1, Strat s2) => s1._amount > s2.ToStratoshis();

        public static bool operator <(Stratoshi s1, Strat s2) => s1._amount < s2.ToStratoshis();

        public static bool operator >=(Stratoshi s1, Strat s2) => s1._amount >= s2.ToStratoshis();

        public static bool operator <=(Stratoshi s1, Strat s2) => s1._amount <= s2.ToStratoshis();

        /// <summary>
        /// Convert to <see cref="Strat"/> units
        /// </summary>
        /// <returns><see cref="Strat"/> representation</returns>
        public Strat ToStrats() => new Strat(this);

        /// <inheritdoc/>
        public override string ToString()
        {
            return _amount.ToString();
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Stratoshi || obj is Strat)
            {
                return _amount == ((Stratoshi)obj)._amount;
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return 68920802 + _amount.GetHashCode();
        }
    }
}
