namespace StratisSmartMath
{
    public class DecimalSet
    {
        public DecimalSet(string amount)
        {
            this.Decimal = amount;

            string[] amountSet = PrepareAmountSet(amount);

            this.Integer = ParseAmount(amountSet[0]);
            this.Fractional = ParseAmount(amountSet[1]);
        }

        public ulong Integer { get; set; }

        public ulong Fractional { get; set; }

        public string Decimal { get; set; }

        #region Helpers
        private string[] PrepareAmountSet(string amount)
        {
            string[] amountSet = amount.Split(Constants.Decimal);

            while (amountSet[1].Length < Constants.MaxDecimalLength)
            {
                amountSet[1] = $"{amountSet[1]}0";
            }

            return amountSet;
        }

        private ulong ParseAmount(string amount)
        {
            ulong.TryParse(amount, out ulong convertedAmount);

            return convertedAmount;
        }
        #endregion
    }
}
