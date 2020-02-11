using Xunit;

namespace StratisSmartMath.Tests
{

    public class DecimalsTests
    {
        private readonly IDecimals _decimals;

        public DecimalsTests()
        {
            _decimals = new Decimals();
        }

        [Theory]
        [InlineData("1.0000", "1.00", 100_000_000)]
        [InlineData("1.2345", "0.0739", 9_122_955)]
        [InlineData("1.00", "0.01", 1_000_000)]
        [InlineData("109873.1239", "0.0887", 974_574_608_993)]
        [InlineData("200.01234567", "14.12345678", 282_486_571_953)]
        public void MultiplyDecimals(string amountOne, string amountTwo, ulong expectedCost)
        {
            var cost = _decimals.Multiply(amountOne, amountTwo);

            Assert.Equal(expectedCost, cost.StratoshiValue);
        }

        [Theory]
        [InlineData("4.8765", 487_650_000)]
        [InlineData("1.00000001", 100_000_001)]
        [InlineData("1.0000001", 100_000_010)]
        [InlineData("1.000001", 100_000_100)]
        [InlineData("1.00001", 100_001_000)]
        [InlineData("1.0001", 100_010_000)]
        [InlineData("1.001", 100_100_000)]
        [InlineData("1.01", 101_000_000)]
        [InlineData("1.1", 110_000_000)]
        public void Convert_ToStratoshis_FromDecimal(string amount, ulong expectedCost)
        {
            var cost = amount.ToStratoshis();

            Assert.Equal(expectedCost, cost);
        }

        [Theory]
        [InlineData(100_000_001, "1.00000001")]
        [InlineData(10_000_001, "0.10000001")]
        [InlineData(12345, "0.00012345")]
        [InlineData(987_654_321, "9.87654321")]
        public void Convert_ToDecimal_FromStratoshis(ulong amount, string expectedCost)
        {
            var cost = amount.ToDecimal();

            Assert.Equal(expectedCost, cost);
        }

        [Theory]
        [InlineData("1.00000001", 1)]
        [InlineData("1.0000001", 10)]
        [InlineData("1.000001", 100)]
        [InlineData("1.00001", 1_000)]
        [InlineData("1.0001", 10_000)]
        [InlineData("1.001", 100_000)]
        [InlineData("1.01", 1_000_000)]
        [InlineData("1.1", 10_000_000)]
        public void GetDelimiter_FromDecimal(string amount, ulong expectedDelimiter)
        {
            var formattedDelimiter = _decimals.GetDelimiterFromDecimal(amount);

            Assert.Equal(expectedDelimiter, formattedDelimiter);
        }

        [Theory]
        [InlineData("1.00000001", "1.00000001", "2.00000002")]
        [InlineData("4.7654", "3.4732", "8.23860000")]
        [InlineData("1.234500", "0.0732430", "1.30774300")]
        public void CanAddTwoDecimalNumbers(string amountOne, string amountTwo, string expectedAmount)
        {
            var result = _decimals.Add(amountOne, amountTwo);

            Assert.Equal(expectedAmount, result.DecimalValue);
        }

        [Theory]
        [InlineData("1.00000001", "1.00000001", "0.00000000")]
        [InlineData("4.7654", "3.4732", "1.29220000")]
        [InlineData("1.2345", "0.0732430", "1.16125700")]
        public void CanSubtractTwoDecimalNumbers(string amountOne, string amountTwo, string expectedAmount)
        {
            var result = _decimals.Subtract(amountOne, amountTwo);

            Assert.Equal(expectedAmount, result.DecimalValue);
        }
    }
}
