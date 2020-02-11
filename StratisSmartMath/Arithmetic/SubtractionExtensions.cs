namespace StratisSmartMath
{
    public static class SubtractionExtensions
    {
        /// <summary>
        /// Subtracts a decimal string value from another decimal string value.
        /// </summary>
        /// <param name="first">The amount to be subtracted from.</param>
        /// <param name="second">The amount to subtract.</param>
        /// <returns>Ulong of second subtracted from first.</returns>
        public static ulong Subtract(this string first, string second)
            => first.ToStratoshis() - second.ToStratoshis();

        /// <summary>
        /// Subtracts a stratoshi value from a decimal string value.
        /// </summary>
        /// <param name="first">The amount to be subtracted from.</param>
        /// <param name="second">The amount to subtract.</param>
        /// <returns>Ulong of second subtracted from first.</returns>
        public static ulong Subtract(this string first, ulong second)
            => first.ToStratoshis() - second;

        /// <summary>
        /// Subtracts a stratoshi value from another stratoshi value.
        /// </summary>
        /// <param name="first">The amount to be subtracted from.</param>
        /// <param name="second">The amount to subtract.</param>
        /// <returns>Ulong of second subtracted from first.</returns>
        public static ulong Subtract(this ulong first, ulong second)
            => first - second;

        /// <summary>
        /// Subtracts a decimal string value from a stratoshi value.
        /// </summary>
        /// <param name="first">The amount to be subtracted from.</param>
        /// <param name="second">The amount to subtract.</param>
        /// <returns>Ulong of second subtracted from first.</returns>
        public static ulong Subtract(this ulong first, string second)
            => first - second.ToStratoshis();
    }
}
