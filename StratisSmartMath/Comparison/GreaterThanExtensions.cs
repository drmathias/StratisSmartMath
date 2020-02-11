namespace StratisSmartMath
{
    public static class GreaterThanExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsGreaterThan(this string first, string second)
            => first.ToStratoshis() > second.ToStratoshis();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsGreaterThan(this string first, ulong second)
            => first.ToStratoshis() > second;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsGreaterThan(this ulong first, string second)
            => first > second.ToStratoshis();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsGreaterThan(this ulong first, ulong second)
            => first > second;
    }
}
