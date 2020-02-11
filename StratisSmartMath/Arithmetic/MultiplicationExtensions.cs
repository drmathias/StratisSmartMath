namespace StratisSmartMath
{
    public static class MultiplicationExtensions
    {
        /// <summary>
        /// Multiply two decimal strings and return the value.
        /// </summary>
        /// <param name="amount">The first decimal to be multiplied.</param>
        /// <param name="amountTwo">The second decimal to be multiplied.</param>
        /// <returns>Ulong satoshi solution value.</returns>
        public static ulong Multiply(this string amount, string amountTwo)
        {
            var amountSet = new DecimalSet(amount);
            var amountTwoSet = new DecimalSet(amountTwo);

            return MultiplateDecimalSets(amountSet, amountTwoSet);
        }

        public static ulong Multiply(this string amount, ulong amountTwo)
        {
            var amountSet = new DecimalSet(amount);
            var amountTwoSet = new DecimalSet(amountTwo.ToDecimal());

            return MultiplateDecimalSets(amountSet, amountTwoSet);
        }

        public static ulong Multiply(this ulong amount, string amountTwo)
        {
            var amountSet = new DecimalSet(amount.ToDecimal());
            var amountTwoSet = new DecimalSet(amountTwo);

            return MultiplateDecimalSets(amountSet, amountTwoSet);
        }

        public static ulong Multiply(this ulong amount, ulong amountTwo)
        {
            var amountSet = new DecimalSet(amount.ToDecimal());
            var amountTwoSet = new DecimalSet(amountTwo.ToDecimal());

            return MultiplateDecimalSets(amountSet, amountTwoSet);
        }

        private static ulong MultiplateDecimalSets(DecimalSet amountSet, DecimalSet amountTwoSet)
        {
            ulong fullInt = amountSet.Integer * amountTwoSet.Integer * Constants.OneFullCoinInStratoshis;
            ulong amountMath = amountSet.Integer * amountTwoSet.Fractional;
            ulong amountTwoMath = amountTwoSet.Integer * amountSet.Fractional;
            ulong fractionalAmount = (amountSet.Fractional * amountTwoSet.Fractional) / Constants.OneFullCoinInStratoshis;

            return fullInt + amountMath + amountTwoMath + fractionalAmount;
        }
    }
}
