namespace StratisSmartMath
{
    public static class LessThanOrEqualToExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThanOrEqualTo(this string first, string second)
            => first.ToStratoshis() <= second.ToStratoshis();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThanOrEqualTo(this string first, ulong second)
            => first.ToStratoshis() <= second;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThanOrEqualTo(this ulong first, string second)
            => first <= second.ToStratoshis();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThanOrEqualTo(this ulong first, ulong second)
            => first <= second;
    }
}
