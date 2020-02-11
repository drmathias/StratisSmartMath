using Xunit;

namespace StratisSmartMath.Tests.Models
{
    public class DecimalModelTests
    {
        [Theory]
        [InlineData("1.1234", 1, 12340000)]
        [InlineData("0.12345678", 0, 12345678)]
        [InlineData("148873.847472", 148873, 84747200)]
        [InlineData("0.00001", 0, 00001000)]
        public void CreatesNewDecimalSet(string amount, ulong expectedInteger, ulong expectedFractional)
        {
            var decimalModel = new DecimalModel(amount);

            Assert.Equal(expectedInteger, decimalModel.Integer);
            Assert.Equal(expectedFractional, decimalModel.Fractional);
        }
    }
}
