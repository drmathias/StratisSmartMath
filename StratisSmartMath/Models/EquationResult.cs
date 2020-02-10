namespace StratisSmartMath
{
    public class EquationResult
    {
        public EquationResult(string decimalValue = null, ulong stratoshiValue = 0)
        {
            this.DecimalValue = decimalValue;
            this.StratoshiValue = stratoshiValue;
        }

        public string DecimalValue { get; set; }

        public ulong StratoshiValue { get; set; }
    }
}
