namespace StratisSmartMath
{
    public interface IDecimals
    {
        ulong GetDelimiterFromDecimal(string amount);

        string ConvertToDecimal(ulong amount);

        ulong ConvertToStratoshis(string amount);

        EquationResult AddDecimals(string amountOne, string amountTwo);

        EquationResult SubtractDecimals(string amountOne, string amountTwo);

        EquationResult MultiplyDecimals(string amountOne, string amountTwo);


        //string DivideDecimals(string amountOne, string amountTwo);
    }
}
