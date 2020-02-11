namespace StratisSmartMath
{
    public static class HelperExtensions
    {
        /// <summary>
        /// Return a the delimiter based on the string decimal passed in.
        /// </summary>
        /// <param name="amount">String decimal amount value to get delimiter for.</param>
        /// <returns>Delimiter based on a string value passed in. (e.g. Passing in "1.123"
        /// will return a delimiter of 100_000. Where 123 * 100_000 would equal 12_300_000.</returns>
        public static ulong Delimiter(this string amount)
        {
            string delimiterString = "1";

            string[] splitAmount = amount.Split(Constants.Decimal);
            int fractionalLength = splitAmount[1].Length;

            for (int i = fractionalLength; i < Constants.MaxDecimalLength; i++)
            {
                delimiterString = $"{delimiterString}0";
            }

            ulong.TryParse(delimiterString, out ulong delimiter);

            return delimiter;
        }
    }
}
