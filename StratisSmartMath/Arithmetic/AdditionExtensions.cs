namespace StratisSmartMath
{
    public static class AdditionExtensions
    {
        /// <summary>
        /// Add two decimal string values together.
        /// </summary>
        /// <param name="amountOne">First decimal string to be added.</param>
        /// <param name="amountTwo">Second decimal string to be added to the first.</param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this string amountOne, string amountTwo)
            => amountOne.ToStratoshis() + amountTwo.ToStratoshis();

        /// <summary>
        /// Adds a decimal string value with another value in stratoshis.
        /// </summary>
        /// <param name="amountOne">Decimal string value.</param>
        /// <param name="amountTwo">Amount in stratoshis to add to the decimal string.</param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this string amountOne, ulong amountTwo)
            => amountOne.ToStratoshis() + amountTwo;

        /// <summary>
        /// Adds to values in stratoshis together.
        /// </summary>
        /// <param name="amountOne">The first value in stratoshis.</param>
        /// <param name="amountTwo">The second value in stratoshis.</param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this ulong amountOne, ulong amountTwo)
            => amountOne + amountTwo;

        /// <summary>
        /// Adds a value in stratoshies with a decimal string value.
        /// </summary>
        /// <param name="amountOne"></param>
        /// <param name="amountTwo"></param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this ulong amountOne, string amountTwo)
            => amountOne + amountTwo.ToStratoshis();
    }
}
