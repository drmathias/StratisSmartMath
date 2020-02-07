namespace StratisSmartMath
{
    public interface IDecimals
    {
        ulong GetDelimiterFromDecimal(string amount);

        string ConvertToDecimalFromStratoshis(ulong amount);

        ulong ConvertToStratoshisFromDecimal(string amount);

        string AddDecimals(string amountOne, string amountTwo);

        string SubtractDecimals(string amountOne, string amountTwo);

        //string MultiplyDecimals(string amountOne, string amountTwo);

        //string DivideDecimals(string amountOne, string amountTwo);
    }
}
