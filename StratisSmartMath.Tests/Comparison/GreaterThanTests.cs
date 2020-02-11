using Xunit;

namespace StratisSmartMath.Tests.Comparison
{
    public class GreaterThanTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", false)]
        [InlineData("4.7654", "3.4732", true)]
        [InlineData("0.0732430", "1.2345", false)]
        public void AmountInDecimal_IsGreaterThan_AmountInDecimal(string first, string second, bool expected)
        {
            var result = first.IsGreaterThan(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, 100_000_001, false)]
        [InlineData(476_540_000, 347_320_000, true)]
        [InlineData(007_324_300, 123_450_000, false)]
        public void AmountInStratoshis_IsGreaterThan_AmountInStratoshis(ulong first, ulong second, bool expected)
        {
            var result = first.IsGreaterThan(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1.00000001", 100_000_001, false)]
        [InlineData("4.7654", 347_320_000, true)]
        [InlineData("0.0732430", 123_450_000, false)]
        public void AmountInDecimal_IsGreaterThan_AmountInStratoshis(string first, ulong second, bool expected)
        {
            var result = first.IsGreaterThan(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, "1.00000001", false)]
        [InlineData(476_540_000, "3.4732", true)]
        [InlineData(007_324_300, "1.2345", false)]
        public void AmountInStratoshis_IsGreaterThan_AmountInDecimal(ulong first, string second, bool expected)
        {
            var result = first.IsGreaterThan(second);

            Assert.Equal(expected, result);
        }
    }
}
