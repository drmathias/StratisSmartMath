using Xunit;
using StratisSmartMath;

namespace StratisSmartMathTests.Arithmetic
{

    public class AdditionTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", "2.00000002")]
        [InlineData("4.7654", "3.4732", "8.23860000")]
        [InlineData("1.234500", "0.0732430", "1.30774300")]
        public void CanAddTwoDecimalNumbers(string amountOne, string amountTwo, string expectedAmount)
        {
            var result = amountOne.Add(amountTwo).ToDecimal();

            Assert.Equal(expectedAmount, result);
        }
    }
}
