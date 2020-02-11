namespace StratisSmartMath
{
    public static class EqualToExtensions
    {
        public static bool IsEqualTo(this string amountOne, string amountTwo)
            => amountOne.ToStratoshis() == amountTwo.ToStratoshis();

        public static bool IsEqualTo(this string amountOne, ulong amountTwo)
            => amountOne.ToStratoshis() == amountTwo;

        public static bool IsEqualTo(this ulong amountOne, string amountTwo)
            => amountOne == amountTwo.ToStratoshis();

        public static bool IsEqualTo(this ulong amountOne, ulong amountTwo)
            => amountOne == amountTwo;
    }
}
