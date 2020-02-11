namespace StratisSmartMath
{
    public static class AdditionExtensions
    {
        /// <summary>
        /// Add two decimal strings together.
        /// </summary>
        /// <param name="amountOne">The first decimal string to add.</param>
        /// <param name="amountTwo">The second decimal string to add.</param>
        /// <returns>Decimal string of both amounts added together.</returns>
        public static ulong Add(this string amountOne, string amountTwo)
        {
            ulong amountOneStratoshis = amountOne.ToStratoshis();
            ulong amountTwoStratoshis = amountTwo.ToStratoshis();

            return amountOneStratoshis + amountTwoStratoshis;
        }

        public static ulong Add(this string amountOne, ulong amountTwo)
        {
            ulong amountOneStratoshis = amountOne.ToStratoshis();

            return amountOneStratoshis + amountTwo;
        }

        public static ulong Add(this ulong amountOne, ulong amountTwo)
        {
            return amountOne + amountTwo;
        }

        public static ulong Add(this ulong amountOne, string amountTwo)
        {
            ulong amountTwoStratoshis = amountTwo.ToStratoshis();

            return amountOne + amountTwoStratoshis;
        }
    }
}
