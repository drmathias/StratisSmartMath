namespace StratisSmartMath
{
    public class DecimalSet
    {
        private const int _maxDecimalLength = 8;

        public DecimalSet(string amount)
        {
            this.Decimal = amount;

            var amountSet = amount.Split('.');
            while (amountSet[1].Length < _maxDecimalLength)
            {
                amountSet[1] = $"{amountSet[1]}0";
            }

            ulong.TryParse(amountSet[0], out ulong amountInt);
            ulong.TryParse(amountSet[1], out ulong amountFractional);

            this.Integer = amountInt;
            this.Fractional = amountFractional;
        }

        public ulong Integer { get; set; }

        public ulong Fractional { get; set; }

        public string Decimal { get; set; }
    }
}
