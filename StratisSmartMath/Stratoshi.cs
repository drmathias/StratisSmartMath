namespace StratisSmartMath
{
    /// <summary>
    /// CONCEPT
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

        public static Stratoshi operator *(Stratoshi s1, string multipler)
        {
            ulong integerPart = 0;
            ulong fractionalPart = 0;
            ulong divisor = 1;
            if (!multipler.Contains("."))
            {
                integerPart = ulong.Parse(multipler);
            }
            else if (multipler.StartsWith("."))
            {
                var fractionalPartString = multipler.Substring(1).TrimEnd('0');
                var delimiter = fractionalPartString.Length;
                for (var x = 0; x < delimiter; x++)
                {
                    divisor *= 10;
                }

                fractionalPart = ulong.Parse(fractionalPartString);
            }
            else
            {
                var parts = multipler.Split('.');
                integerPart = ulong.Parse(parts[0]);
                var fractionalPartString = parts[1].TrimEnd('0');
                var delimiter = fractionalPartString.Length;
                for (var x = 0; x < delimiter; x++)
                {
                    divisor *= 10;
                }

                fractionalPart = ulong.Parse(fractionalPartString);
            }

            // TODO: division results in a decimal
            return s1 * integerPart + new Stratoshi(s1._amount * fractionalPart / divisor);
        }

        public static explicit operator ulong(Stratoshi value) => value._amount;

        public static explicit operator Stratoshi(Strat value) => value.ToStratoshis();

        public static implicit operator Stratoshi(ulong value) => new Stratoshi(value);

        public Strat ToStrats() => new Strat(this);

        public override string ToString()
        {
            return _amount.ToString();
        }
    }
}
