using Xunit;
using StratisSmartMath;

namespace StratisSmartMath.Tests.Arithmetic
{
    public class SubtractionTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", 0)]
        [InlineData("4.7654", "3.4732", 129_220_000)]
        [InlineData("1.2345", "0.0732430", 116_125_700)]
        public void CanSubtractTwoDecimalNumbers(string amountOne, string amountTwo, ulong expectedAmount)
        {
            var result = amountOne.Subtract(amountTwo);

            Assert.Equal(expectedAmount, result);
        }
    }
}
