namespace StratisSmartMath
{
    public static class ConversionExtensions
    {
        /// <summary>
        /// Convert a decimal string to the equivalent amount in stratoshis
        /// </summary>
        /// <param name="amount">Amount in string decimal format to convert to stratoshis.</param>
        /// <returns>Stratoshi amount equal to the provided decimal string.</returns>
        public static ulong ToStratoshis(this string amount)
        {
            var set = new DecimalSet(amount);

            ulong integerAmount = set.Integer * Constants.OneFullCoinInStratoshis;

            return integerAmount + set.Fractional;
        }

        /// <summary>
        /// Convert to a decimal string based on stratoshi amount provided.
        /// </summary>
        /// <param name="amount">Amount in stratoshis to convert to a decimal string.</param>
        /// <returns>The a decimal string equal to the amount of stratoshis provided.</returns>
        public static string ToDecimal(this ulong amount)
        {
            string amountString = amount.ToString();

            if (amountString.Length > Constants.MaxDecimalLength)
            {
                return amountString.Insert(amountString.Length - Constants.MaxDecimalLength, ".");
            }

            while (amountString.Length < Constants.MaxDecimalLength)
            {
                amountString = $"0{amountString}";
            }

            return $"0.{amountString}";
        }
    }
}
