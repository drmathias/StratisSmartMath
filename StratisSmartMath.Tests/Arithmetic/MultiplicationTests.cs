using Xunit;
using StratisSmartMath;

namespace StratisSmartMath.Tests.Arithmetic
{
    public class MultiplicationTests
    {
        [Theory]
        [InlineData("1.0000", "1.00", 100_000_000)]
        [InlineData("1.2345", "0.0739", 9_122_955)]
        [InlineData("1.00", "0.01", 1_000_000)]
        [InlineData("109873.1239", "0.0887", 974_574_608_993)]
        [InlineData("200.01234567", "14.12345678", 282_486_571_953)]
        public void MultiplyDecimals(string amountOne, string amountTwo, ulong expectedCost)
        {
            var cost = amountOne.Multiply(amountTwo);

            Assert.Equal(expectedCost, cost);
        }
    }
}
