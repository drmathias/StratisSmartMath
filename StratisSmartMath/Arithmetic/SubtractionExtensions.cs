namespace StratisSmartMath
{
    public static class SubtractionExtensions
    {
        /// <summary>
        /// Subtracts a decimal string value from another decimal string value.
        /// </summary>
        /// <param name="amountOne">The amount to be subtracted from.</param>
        /// <param name="amountTwo">The amount to subtract.</param>
        /// <returns>Ulong of amountTwo subtracted from amountOne.</returns>
        public static ulong Subtract(this string amountOne, string amountTwo)
            => amountOne.ToStratoshis() - amountTwo.ToStratoshis();

        /// <summary>
        /// Subtracts a stratoshi value from a decimal string value.
        /// </summary>
        /// <param name="amountOne">The amount to be subtracted from.</param>
        /// <param name="amountTwo">The amount to subtract.</param>
        /// <returns>Ulong of amountTwo subtracted from amountOne.</returns>
        public static ulong Subtract(this string amountOne, ulong amountTwo)
            => amountOne.ToStratoshis() - amountTwo;

        /// <summary>
        /// Subtracts a stratoshi value from another stratoshi value.
        /// </summary>
        /// <param name="amountOne">The amount to be subtracted from.</param>
        /// <param name="amountTwo">The amount to subtract.</param>
        /// <returns>Ulong of amountTwo subtracted from amountOne.</returns>
        public static ulong Subtract(this ulong amountOne, ulong amountTwo)
            => amountOne - amountTwo;

        /// <summary>
        /// Subtracts a decimal string value from a stratoshi value.
        /// </summary>
        /// <param name="amountOne">The amount to be subtracted from.</param>
        /// <param name="amountTwo">The amount to subtract.</param>
        /// <returns>Ulong of amountTwo subtracted from amountOne.</returns>
        public static ulong Subtract(this ulong amountOne, string amountTwo)
            => amountOne - amountTwo.ToStratoshis();
    }
}
