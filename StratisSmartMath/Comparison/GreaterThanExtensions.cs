namespace StratisSmartMath
{
    public static class GreaterThanExtensions
    {
        public static bool IsGreaterThan(this string amountOne, string amountTwo)
            => amountOne.ToStratoshis() > amountTwo.ToStratoshis();

        public static bool IsGreaterThan(this string amountOne, ulong amountTwo)
            => amountOne.ToStratoshis() > amountTwo;

        public static bool IsGreaterThan(this ulong amountOne, string amountTwo)
            => amountOne > amountTwo.ToStratoshis();

        public static bool IsGreaterThan(this ulong amountOne, ulong amountTwo)
            => amountOne > amountTwo;
    }
}
