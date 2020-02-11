namespace StratisSmartMath
{
    public static class AdditionExtensions
    {
        /// <summary>
        /// Add two decimal string values together.
        /// </summary>
        /// <param name="first">First decimal string to be added.</param>
        /// <param name="second">Second decimal string to be added to the first.</param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this string first, string second)
            => first.ToStratoshis() + second.ToStratoshis();

        /// <summary>
        /// Adds a decimal string value with another value in stratoshis.
        /// </summary>
        /// <param name="first">Decimal string value.</param>
        /// <param name="second">Amount in stratoshis to add to the decimal string.</param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this string first, ulong second)
            => first.ToStratoshis() + second;

        /// <summary>
        /// Adds to values in stratoshis together.
        /// </summary>
        /// <param name="first">The first value in stratoshis.</param>
        /// <param name="second">The second value in stratoshis.</param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this ulong first, ulong second)
            => first + second;

        /// <summary>
        /// Adds a value in stratoshies with a decimal string value.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Ulong of both values added together.</returns>
        public static ulong Add(this ulong first, string second)
            => first + second.ToStratoshis();
    }
}
