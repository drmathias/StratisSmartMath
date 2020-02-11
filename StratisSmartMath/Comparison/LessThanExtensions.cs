namespace StratisSmartMath
{
    public static class LessThanExtensions
    {
        public static bool IsLessThan(this string amountOne, string amountTwo)
            => amountOne.ToStratoshis() < amountTwo.ToStratoshis();

        public static bool IsLessThan(this string amountOne, ulong amountTwo)
            => amountOne.ToStratoshis() < amountTwo;

        public static bool IsLessThan(this ulong amountOne, string amountTwo)
            => amountOne < amountTwo.ToStratoshis();

        public static bool IsLessThan(this ulong amountOne, ulong amountTwo)
            => amountOne < amountTwo;
    }
}
