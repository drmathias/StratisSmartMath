namespace StratisSmartMath
{
    public class Decimals : IDecimals
    {
        private const char dot = '.';
        private const int maxDecimalLength = 8;
        private const ulong OneFullCoinInStratoshis = 100_000_000;

        /// <summary>
        /// Add two decimal strings together.
        /// </summary>
        /// <param name="amountOne">The first decimal string to add.</param>
        /// <param name="amountTwo">The second decimal string to add.</param>
        /// <returns>Decimal string of both amounts added together.</returns>
        public EquationResult Add(string amountOne, string amountTwo)
        {
            ulong amountOneStratoshis = Convert(amountOne);
            ulong amountTwoStratoshis = Convert(amountTwo);

            ulong finalAmountStratoshis = amountOneStratoshis + amountTwoStratoshis;
            string finalAmountDecimal = Convert(finalAmountStratoshis);

            return new EquationResult(finalAmountDecimal, finalAmountStratoshis);

        }

        /// <summary>
        /// Convert to a decimal string based on stratoshi amount provided.
        /// </summary>
        /// <param name="amount">Amount in stratoshis to convert to a decimal string.</param>
        /// <returns>The a decimal string equal to the amount of stratoshis provided.</returns>
        public string Convert(ulong amount)
        {
            string amountString = amount.ToString();

            if (amountString.Length > maxDecimalLength)
            {
                return amountString.Insert(amountString.Length - maxDecimalLength, ".");
            }

            while (amountString.Length < maxDecimalLength)
            {
                amountString = $"0{amountString}";
            }

            return $"0.{amountString}";
        }

        /// <summary>
        /// Convert a decimal string to the equivalent amount in stratoshis
        /// </summary>
        /// <param name="amount">Amount in string decimal format to convert to stratoshis.</param>
        /// <returns>Stratoshi amount equal to the provided decimal string.</returns>
        public ulong Convert(string amount)
        {
            var set = new DecimalSet(amount);

            ulong integerAmount = set.Integer * OneFullCoinInStratoshis;

            return integerAmount + set.Fractional;
        }

        /// <summary>
        /// Return a the delimiter based on the string decimal passed in.
        /// </summary>
        /// <param name="amount">String decimal amount value to get delimiter for.</param>
        /// <returns>Delimiter based on a string value passed in. (e.g. Passing in "1.123"
        /// will return a delimiter of 100_000. Where 123 * 100_000 would equal 12_300_000.</returns>
        public ulong GetDelimiterFromDecimal(string amount)
        {
            string delimiterString = "1";

            string[] splitAmount = amount.Split(dot);
            int fractionalLength = splitAmount[1].Length;

            for (int i = fractionalLength; i < maxDecimalLength; i++)
            {
                delimiterString = $"{delimiterString}0";
            }

            ulong.TryParse(delimiterString, out ulong formattedDelimiter);

            return formattedDelimiter;
        }

        /// <summary>
        /// Subtract a decimal string from another.
        /// </summary>
        /// <param name="amountOne">The first decimal string amount to be subtracted against.</param>
        /// <param name="amountTwo">The second decimal string to be subtracted from amount one.</param>
        /// <returns>Decimal string result of amountOne - amountTwo</returns>
        public EquationResult Subtract(string amountOne, string amountTwo)
        {
            ulong amountOneStratoshis = Convert(amountOne);
            ulong amountTwoStratoshis = Convert(amountTwo);

            ulong finalAmountStratoshis = amountOneStratoshis - amountTwoStratoshis;
            string finalAmountDecimal = Convert(finalAmountStratoshis);

            return new EquationResult(finalAmountDecimal, finalAmountStratoshis);
        }

        /// <summary>
        /// Multiply two decimal strings and return the value.
        /// </summary>
        /// <param name="amount">The first decimal to be multiplied.</param>
        /// <param name="amountTwo">The second decimal to be multiplied.</param>
        /// <returns>EquationResult model with decimal and satoshi solution values.</returns>
        public EquationResult Multiply(string amount, string amountTwo)
        {
            var amountSet = new DecimalSet(amount);
            var amountTwoSet = new DecimalSet(amountTwo);

            ulong fullInt = amountSet.Integer * amountTwoSet.Integer * OneFullCoinInStratoshis;
            ulong amountMath = amountSet.Integer * amountTwoSet.Fractional;
            ulong amountTwoMath = amountTwoSet.Integer * amountSet.Fractional;
            ulong fractionalAmount = (amountSet.Fractional * amountTwoSet.Fractional) / OneFullCoinInStratoshis;

            var stratoshiValue = fullInt + amountMath + amountTwoMath + fractionalAmount;
            var decimalValue = Convert(stratoshiValue);

            return new EquationResult(decimalValue, stratoshiValue);
        }
    }
}