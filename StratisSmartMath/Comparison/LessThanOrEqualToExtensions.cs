namespace StratisSmartMath
{
    public static class LessThanOrEqualToExtensions
    {
        public static bool IsLessThanOrEqualTo(this string amountOne, string amountTwo)
            => amountOne.ToStratoshis() <= amountTwo.ToStratoshis();

        public static bool IsLessThanOrEqualTo(this string amountOne, ulong amountTwo)
            => amountOne.ToStratoshis() <= amountTwo;

        public static bool IsLessThanOrEqualTo(this ulong amountOne, string amountTwo)
            => amountOne <= amountTwo.ToStratoshis();

        public static bool IsLessThanOrEqualTo(this ulong amountOne, ulong amountTwo)
            => amountOne <= amountTwo;
    }
}
