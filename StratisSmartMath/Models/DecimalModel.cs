namespace StratisSmartMath
{
    /// <summary>
    /// 
    /// </summary>
    public class DecimalModel
    {
        /// <summary>
        /// Constructor for DecimalModel to convert a decimal string into broken down ulong values for the integer and
        /// fractional parts. (e.g. "1.234" = { Integer: 1; Fractional: 23400000 })
        /// </summary>
        /// <param name="amount">The decimal string amount to break down into integer and fractional amounts.</param>
        public DecimalModel(string amount)
        {
            string[] set = GetDecimalSet(amount);

            this.Integer = ParseAmount(set[0]);
            this.Fractional = ParseAmount(set[1]);
        }

        public ulong Integer { get; set; }

        public ulong Fractional { get; set; }

        #region Helpers
        private string[] GetDecimalSet(string amount)
        {
            string[] set = amount.Split(Constants.Decimal);

            while (set[1].Length < Constants.MaxDecimalLength)
            {
                set[1] = $"{set[1]}0";
            }

            return set;
        }

        private ulong ParseAmount(string amount)
        {
            ulong.TryParse(amount, out ulong convertedAmount);

            return convertedAmount;
        }
        #endregion
    }
}
