namespace StratisSmartMath
{
    public static class SubtractionExtensions
    {
        /// <summary>
        /// Subtract a decimal string from another.
        /// </summary>
        /// <param name="amountOne">The first decimal string amount to be subtracted against.</param>
        /// <param name="amountTwo">The second decimal string to be subtracted from amount one.</param>
        /// <returns>Decimal string result of amountOne - amountTwo</returns>
        public static ulong Subtract(this string amountOne, string amountTwo)
        {
            ulong amountOneStratoshis = amountOne.ToStratoshis();
            ulong amountTwoStratoshis = amountTwo.ToStratoshis();

            return amountOneStratoshis - amountTwoStratoshis;
        }

        public static ulong Subtract(this string amountOne, ulong amountTwo)
        {
            ulong amountOneStratoshis = amountOne.ToStratoshis();

            return amountOneStratoshis - amountTwo;
        }

        public static ulong Subtract(this ulong amountOne, ulong amountTwo)
        {
            return amountOne - amountTwo;
        }

        public static ulong Subtract(this ulong amountOne, string amountTwo)
        {
            ulong amountTwoStratoshis = amountTwo.ToStratoshis();

            return amountOne - amountTwoStratoshis;
        }
    }
}
