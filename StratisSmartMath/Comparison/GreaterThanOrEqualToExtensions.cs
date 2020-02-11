namespace StratisSmartMath
{
    public static class GreaterThanOrEqualToExtensions
    {
        public static bool IsGreaterThanOrEqualTo(this string amountOne, string amountTwo)
            => amountOne.ToStratoshis() >= amountTwo.ToStratoshis();

        public static bool IsGreaterThanOrEqualTo(this string amountOne, ulong amountTwo)
            => amountOne.ToStratoshis() >= amountTwo;

        public static bool IsGreaterThanOrEqualTo(this ulong amountOne, string amountTwo)
            => amountOne >= amountTwo.ToStratoshis();

        public static bool IsGreaterThanOrEqualTo(this ulong amountOne, ulong amountTwo)
            => amountOne >= amountTwo;
    }
}
