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

            ulong fullInt = amountSet.Integer * amountTwoSet.Integer * Constants.OneFullCoinInStratoshis;
            ulong amountMath = amountSet.Integer * amountTwoSet.Fractional;
            ulong amountTwoMath = amountTwoSet.Integer * amountSet.Fractional;
            ulong fractionalAmount = (amountSet.Fractional * amountTwoSet.Fractional) / Constants.OneFullCoinInStratoshis;

            return fullInt + amountMath + amountTwoMath + fractionalAmount;
        }
    }
}
