namespace StratisSmartMath
{
    public static class LessThanExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThan(this string first, string second)
            => first.ToStratoshis() < second.ToStratoshis();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThan(this string first, ulong second)
            => first.ToStratoshis() < second;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThan(this ulong first, string second)
            => first < second.ToStratoshis();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool IsLessThan(this ulong first, ulong second)
            => first < second;
    }
}
