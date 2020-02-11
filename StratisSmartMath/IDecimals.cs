﻿namespace StratisSmartMath
{
    public interface IDecimals
    {
        ulong GetDelimiterFromDecimal(string amount);

        EquationResult Add(string amountOne, string amountTwo);

        EquationResult Subtract(string amountOne, string amountTwo);

        EquationResult Multiply(string amountOne, string amountTwo);

        //string DivideDecimals(string amountOne, string amountTwo);
    }
}
