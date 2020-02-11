using Xunit;

namespace StratisSmartMath.Tests.Comparison
{
    public class EqualToTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", true)]
        [InlineData("4.7654", "3.4732", false)]
        [InlineData("0.0732430", "1.2345", false)]
        public void AmountInDecimal_IsEqualTo_AmountInDecimal(string amountOne, string amountTwo, bool expectedResult)
        {
            var result = amountOne.IsEqualTo(amountTwo);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(100_000_001, 100_000_001, true)]
        [InlineData(476_540_000, 347_320_000, false)]
        [InlineData(007_324_300, 123_450_000, false)]
        public void AmountInStratoshis_IsEqualTo_AmountInStratoshis(ulong amountOne, ulong amountTwo, bool expectedResult)
        {
            var result = amountOne.IsEqualTo(amountTwo);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1.00000001", 100_000_001, true)]
        [InlineData("4.7654", 347_320_000, false)]
        [InlineData("0.0732430", 123_450_000, false)]
        public void AmountInDecimal_IsEqualTo_AmountInStratoshis(string amountOne, ulong amountTwo, bool expectedResult)
        {
            var result = amountOne.IsEqualTo(amountTwo);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(100_000_001, "1.00000001", true)]
        [InlineData(476_540_000, "3.4732", false)]
        [InlineData(007_324_300, "1.2345", false)]
        public void AmountInStratoshis_IsEqualTo_AmountInDecimal(ulong amountOne, string amountTwo, bool expectedResult)
        {
            var result = amountOne.IsEqualTo(amountTwo);

            Assert.Equal(expectedResult, result);
        }
    }
}
