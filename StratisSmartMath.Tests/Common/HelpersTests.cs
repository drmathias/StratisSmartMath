using Xunit;

namespace StratisSmartMath.Tests.Common
{
    public class HelpersTests
    {
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
            var formattedDelimiter = amount.Delimiter();

            Assert.Equal(expectedDelimiter, formattedDelimiter);
        }
    }
}
