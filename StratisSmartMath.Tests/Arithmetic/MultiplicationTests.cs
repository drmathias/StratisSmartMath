using Xunit;

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
        public void CanMultiply_TwoDecimalNumbers(string amountOne, string amountTwo, ulong expectedCost)
        {
            var cost = amountOne.Multiply(amountTwo);

            Assert.Equal(expectedCost, cost);
        }

        [Theory]
        [InlineData(100_000_000, "1.00", 100_000_000)]
        [InlineData(123_450_000, "0.0739", 9_122_955)]
        [InlineData(100_000_000, "0.01", 1_000_000)]
        [InlineData(10_987_312_390_000, "0.0887", 974_574_608_993)]
        [InlineData(20_001_234_567, "14.12345678", 282_486_571_953)]
        public void CanMultiplyA_StratoshiValue_AndA_Decimal(ulong amountOne, string amountTwo, ulong expectedCost)
        {
            var cost = amountOne.Multiply(amountTwo);

            Assert.Equal(expectedCost, cost);
        }

        [Theory]
        [InlineData("1.0000", 100_000_000, 100_000_000)]
        [InlineData("1.2345", 7_390_000, 9_122_955)]
        [InlineData("1.00", 1_000_000, 1_000_000)]
        [InlineData("109873.1239", 8_870_000, 974_574_608_993)]
        [InlineData("200.01234567", 1_412_345_678, 282_486_571_953)]
        public void CanMultiply_ADecimalAmount_And_StratoshiAmount(string amountOne, ulong amountTwo, ulong expectedCost)
        {
            var cost = amountOne.Multiply(amountTwo);

            Assert.Equal(expectedCost, cost);
        }

        [Theory]
        [InlineData(100_000_000, 100_000_000, 100_000_000)]
        [InlineData(123_450_000, 7_390_000, 9_122_955)]
        [InlineData(100_000_000, 1_000_000, 1_000_000)]
        [InlineData(10_987_312_390_000, 8_870_000, 974_574_608_993)]
        [InlineData(20_001_234_567, 1_412_345_678, 282_486_571_953)]
        public void CanMultiply_TwoStratoshiAmounts(ulong amountOne, ulong amountTwo, ulong expectedCost)
        {
            var cost = amountOne.Multiply(amountTwo);

            Assert.Equal(expectedCost, cost);
        }
    }
}
