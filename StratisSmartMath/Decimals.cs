namespace StratisSmartMath
{
    public class Decimals : IDecimals
    {
        /// <summary>
        /// Add two decimal strings together.
        /// </summary>
        /// <param name="amountOne">The first decimal string to add.</param>
        /// <param name="amountTwo">The second decimal string to add.</param>
        /// <returns>Decimal string of both amounts added together.</returns>
        public EquationResult Add(string amountOne, string amountTwo)
        {
            ulong amountOneStratoshis = amountOne.ToStratoshis();
            ulong amountTwoStratoshis = amountTwo.ToStratoshis();

            ulong finalAmountStratoshis = amountOneStratoshis + amountTwoStratoshis;
            string finalAmountDecimal = finalAmountStratoshis.ToDecimal();

            return new EquationResult(finalAmountDecimal, finalAmountStratoshis);

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

            string[] splitAmount = amount.Split(Constants.Decimal);
            int fractionalLength = splitAmount[1].Length;

            for (int i = fractionalLength; i < Constants.MaxDecimalLength; i++)
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
            ulong amountOneStratoshis = amountOne.ToStratoshis();
            ulong amountTwoStratoshis = amountTwo.ToStratoshis();

            ulong finalAmountStratoshis = amountOneStratoshis - amountTwoStratoshis;
            string finalAmountDecimal = finalAmountStratoshis.ToDecimal();

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

            ulong fullInt = amountSet.Integer * amountTwoSet.Integer * Constants.OneFullCoinInStratoshis;
            ulong amountMath = amountSet.Integer * amountTwoSet.Fractional;
            ulong amountTwoMath = amountTwoSet.Integer * amountSet.Fractional;
            ulong fractionalAmount = (amountSet.Fractional * amountTwoSet.Fractional) / Constants.OneFullCoinInStratoshis;

            var stratoshiValue = fullInt + amountMath + amountTwoMath + fractionalAmount;
            var decimalValue = stratoshiValue.ToDecimal();

            return new EquationResult(decimalValue, stratoshiValue);
        }
    }
}