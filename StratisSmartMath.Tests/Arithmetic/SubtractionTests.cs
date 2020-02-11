using Xunit;
using StratisSmartMath;

namespace StratisSmartMath.Tests.Arithmetic
{
    public class SubtractionTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", "0.00000000")]
        [InlineData("4.7654", "3.4732", "1.29220000")]
        [InlineData("1.2345", "0.0732430", "1.16125700")]
        public void CanSubtractTwoDecimalNumbers(string amountOne, string amountTwo, string expectedAmount)
        {
            var result = amountOne.Subtract(amountTwo).ToDecimal();

            Assert.Equal(expectedAmount, result);
        }
    }
}
