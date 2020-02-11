using Xunit;

namespace StratisSmartMath.Tests.Comparison
{
    public class LessThanTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", false)]
        [InlineData("4.7654", "3.4732", false)]
        [InlineData("0.0732430", "1.2345", true)]
        public void AmountInDecimal_IsLessThan_AmountInDecimal(string first, string second, bool expected)
        {
            var result = first.IsLessThan(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, 100_000_001, false)]
        [InlineData(476_540_000, 347_320_000, false)]
        [InlineData(007_324_300, 123_450_000, true)]
        public void AmountInStratoshis_IsLessThan_AmountInStratoshis(ulong first, ulong second, bool expected)
        {
            var result = first.IsLessThan(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1.00000001", 100_000_001, false)]
        [InlineData("4.7654", 347_320_000, false)]
        [InlineData("0.0732430", 123_450_000, true)]
        public void AmountInDecimal_IsLessThan_AmountInStratoshis(string first, ulong second, bool expected)
        {
            var result = first.IsLessThan(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, "1.00000001", false)]
        [InlineData(476_540_000, "3.4732", false)]
        [InlineData(007_324_300, "1.2345", true)]
        public void AmountInStratoshis_IsLessThan_AmountInDecimal(ulong first, string second, bool expected)
        {
            var result = first.IsLessThan(second);

            Assert.Equal(expected, result);
        }
    }
}
