using System;

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
        public string AddDecimals(string amountOne, string amountTwo)
        {
            // Convert each amount to it's value in stratoshis
            ulong amountOneStratoshis = ConvertToStratoshisFromDecimal(amountOne);
            ulong amountTwoStratoshis = ConvertToStratoshisFromDecimal(amountTwo);

            // Add the two stratoshi amounts together
            ulong finalAmountStratoshis = amountOneStratoshis + amountTwoStratoshis;

            // Return result converted back to a decimal string
            return ConvertToDecimalFromStratoshis(finalAmountStratoshis);
        }

        /// <summary>
        /// Convert to a decimal string based on stratoshi amount provided.
        /// </summary>
        /// <param name="amount">Amount in stratoshis to convert to a decimal string.</param>
        /// <returns>The a decimal string equal to the amount of stratoshis provided.</returns>
        public string ConvertToDecimalFromStratoshis(ulong amount)
        {
            string amountString = amount.ToString();
            // Set a reference to the amountStringLength so it does not get overwritten
            // (e.g. Without this reference setting amountString to a new value adjusts it's length
            // if amountString.Length were used.)
            int amountStringLength = amountString.Length;

            // Value is over 1 full number, just insert a decimal point where necessary.
            // Todo: Evaluate here if it would be better to compare amount to OneFullCoinInStratoshis
            if (amountStringLength > 8)
            {
                return amountString.Insert(amountStringLength - maxDecimalLength, ".");
            }

            // Loop through and prefix the amount string with zeros.
            // (e.g. If amount is 10_000_000 (7 length) would be 8 - 7, would loop once.
            // Setting the amountString value to "010000000".
            for (int i = 0; i < maxDecimalLength - amountStringLength; i++)
            {
                // Prefix the string with a zero every loop through
                amountString = $"0{amountString}";
            }

            // Add the leading zero and decimal point (e.g. 0.010000000)
            return $"0.{amountString}";
        }

        /// <summary>
        /// Convert a decimal string to the equivalent amount in stratoshis
        /// </summary>
        /// <param name="amount">Amount in string decimal format to convert to stratoshis.</param>
        /// <returns>Stratoshi amount equal to the provided decimal string.</returns>
        public ulong ConvertToStratoshisFromDecimal(string amount)
        {
            // Get the delimiter value based on the provided string decimal amount.
            ulong delimiter = GetDelimiterFromDecimal(amount);

            // Split amount on the ".".
            // Todo: Add validations and checks that there is a "." in the first place
            string[] splitAmount = amount.Split(dot);

            // Parse the amount integer and fractional to a ulong.
            ulong.TryParse(splitAmount[0], out ulong integer);
            ulong.TryParse(splitAmount[1], out ulong fractional);

            // Multiply the full integer amount by 100_000_000 stratoshis
            // (e.g. 2 * 100_000_000 = 200_000_000)
            ulong integerAmount = integer * OneFullCoinInStratoshis;

            // Multiple the fractional by the delimiter providing the accurate stratoshi amount
            // (e.g. .12304 = 12_304 x 100 = 12_304_000 stratoshis
            ulong fractionalAmount = fractional * delimiter;

            // Add the integer and fractional stratoshi amounts to get result
            return integerAmount + fractionalAmount;
        }

        /// <summary>
        /// Return a the delimiter based on the string decimal passed in.
        /// </summary>
        /// <param name="amount">String decimal amount value to get delimiter for.</param>
        /// <returns>Delimiter based on a string value passed in. (e.g. Passing in "1.123"
        /// will return a delimiter of 100_000. Where 123 * 100_000 would equal 12_300_000.</returns>
        public ulong GetDelimiterFromDecimal(string amount)
        {
            // The beginning of the delmiter string we'll be adjusting
            string delimiterString = "1";

            // Todo: Add validations and checks that there is a "." in the first place
            string[] splitAmount = amount.Split(dot);
            int fractionalLength = splitAmount[1].Length;

            // Loop through and append the necessary amount of 0's to the delimiter string.
            // Begin with the length of the fractional. (e.g. If fractional = 12345, length = 5
            // as long as 5 < 8 append necessary 0's to the delimiter string, results in = 1_000.
            // 12_345 * 1_000 = 12_345_000 the correct value in stratoshis)
            for (int i = fractionalLength; i < 8; i++)
            {
                delimiterString = $"{delimiterString}0";
            }

            // Parse the delimter string into a ulong
            ulong.TryParse(delimiterString, out ulong formattedDelimiter);

            return formattedDelimiter;
        }

        /// <summary>
        /// Subtract a decimal string from another.
        /// </summary>
        /// <param name="amountOne">The first decimal string amount to be subtracted against.</param>
        /// <param name="amountTwo">The second decimal string to be subtracted from amount one.</param>
        /// <returns>Decimal string result of amountOne - amountTwo</returns>
        public string SubtractDecimals(string amountOne, string amountTwo)
        {
            // Convert each amount to it's value in stratoshis
            ulong amountOneStratoshis = ConvertToStratoshisFromDecimal(amountOne);
            ulong amountTwoStratoshis = ConvertToStratoshisFromDecimal(amountTwo);

            // Subtract amount two from amount one
            ulong finalAmountStratoshis = amountOneStratoshis - amountTwoStratoshis;

            // Return result converted back to a decimal string
            return ConvertToDecimalFromStratoshis(finalAmountStratoshis);
        }

        public ulong MultiplyDecimalsReturnStratoshis(string amountOne, string amountTwo)
        {
            var amountOneIndex = amountOne.IndexOf(dot);
            var amountOneLengthMinusDecimal = amountOne.Length - 1;
            var amountOneDecimals = amountOneLengthMinusDecimal - amountOneIndex;

            amountOne = amountOne.Remove(amountOneIndex, 1);

            ulong.TryParse(amountOne, out ulong amountOneNumber);

            var amountTwoIndex = amountTwo.IndexOf(dot);
            var amountTwoLengthMinusDecimal = amountTwo.Length - 1;
            var amountTwoDecimals = amountTwoLengthMinusDecimal - amountTwoIndex;

            amountTwo = amountTwo.Remove(amountTwoIndex, 1);

            ulong.TryParse(amountTwo, out ulong amountTwoNumber);

            var resultString = (amountOneNumber * amountTwoNumber).ToString();
            //var startIndex = resultString.Length - (amountOneDecimals + amountTwoDecimals);
            //resultString = resultString.Insert(
            //    startIndex
            //, dot.ToString());

            //var result = ConvertToStratoshisFromDecimal(resultString);

            ulong.TryParse(resultString, out ulong result);

            return (ulong)result;
        }
    }
}