namespace StratisSmartMath
{
    public static class MultiplicationExtensions
    {
        /// <summary>
        /// Multiply two decimal strings and return the value.
        /// </summary>
        /// <param name="first">The first decimal to be multiplied.</param>
        /// <param name="second">The second decimal to be multiplied.</param>
        /// <returns>Ulong satoshi solution value.</returns>
        public static ulong Multiply(this string first, string second)
        {
            var firstDecimal = new DecimalModel(first);
            var secondDecimal = new DecimalModel(second);

            return MultiplyDecimalSets(firstDecimal, secondDecimal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static ulong Multiply(this string first, ulong second)
        {
            var firstDecimal = new DecimalModel(first);
            var secondDecimal = new DecimalModel(second.ToDecimal());

            return MultiplyDecimalSets(firstDecimal, secondDecimal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static ulong Multiply(this ulong first, string second)
        {
            var firstDecimal = new DecimalModel(first.ToDecimal());
            var secondDecimal = new DecimalModel(second);

            return MultiplyDecimalSets(firstDecimal, secondDecimal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static ulong Multiply(this ulong first, ulong second)
        {
            var firstDecimal = new DecimalModel(first.ToDecimal());
            var secondDecimal = new DecimalModel(second.ToDecimal());

            return MultiplyDecimalSets(firstDecimal, secondDecimal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private static ulong MultiplyDecimalSets(DecimalModel first, DecimalModel second)
        {
            ulong fullInt = first.Integer * second.Integer * Constants.OneFullCoinInStratoshis;
            ulong amountMath = first.Integer * second.Fractional;
            ulong amountTwoMath = second.Integer * first.Fractional;
            ulong fractionalAmount = first.Fractional * second.Fractional / Constants.OneFullCoinInStratoshis;

            return fullInt + amountMath + amountTwoMath + fractionalAmount;
        }
    }
}
