using Xunit;
using StratisSmartMath;

namespace StratisSmartMath.Tests.Common
{
    public class ConversionsTests
    {
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
    }
}
