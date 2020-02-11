using Xunit;
using StratisSmartMath;

namespace StratisSmartMath.Tests.Arithmetic
{

    public class AdditionTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", 200_000_002)]
        [InlineData("4.7654", "3.4732", 823_860_000)]
        [InlineData("1.234500", "0.0732430", 130_774_300)]
        public void CanAddTwoDecimalNumbers(string amountOne, string amountTwo, ulong expectedAmount)
        {
            var result = amountOne.Add(amountTwo);

            Assert.Equal(expectedAmount, result);
        }
    }
}
