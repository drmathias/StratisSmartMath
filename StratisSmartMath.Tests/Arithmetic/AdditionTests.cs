using Xunit;

namespace StratisSmartMath.Tests.Arithmetic
{

    public class AdditionTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", 200_000_002)]
        [InlineData("4.7654", "3.4732", 823_860_000)]
        [InlineData("1.234500", "0.0732430", 130_774_300)]
        public void CanAdd_TwoDecimalNumbers(string first, string second, ulong expected)
        {
            var result = first.Add(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1.00000001", 100_000_001, 200_000_002)]
        [InlineData("4.7654", 347_320_000, 823_860_000)]
        [InlineData("1.234500", 7_324_300, 130_774_300)]
        public void CanAdd_DecimalString_With_StratoshiValue(string first, ulong second, ulong expected)
        {
            var result = first.Add(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, "1.00000001", 200_000_002)]
        [InlineData(476_540_000, "3.4732", 823_860_000)]
        [InlineData(123_450_000, "0.0732430", 130_774_300)]
        public void CanAdd_StratoshiValue_With_DecimalString(ulong first, string second, ulong expected)
        {
            var result = first.Add(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, 100_000_001, 200_000_002)]
        [InlineData(476_540_000, 347_320_000, 823_860_000)]
        [InlineData(123_450_000, 7_324_300, 130_774_300)]
        public void CanAdd_TwoStratoshiValues(ulong first, ulong second, ulong expected)
        {
            var result = first.Add(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1.00000001", "1.00000001", 200_000_002, 400_000_004)]
        [InlineData("4.7654", "3.4732", 823_860_000, 1_647_720_000)]
        [InlineData("1.234500", "0.0732430", 130_774_300, 261_548_600)]
        public void CanChainMultiple_AddsTogether(string first, string second, ulong third, ulong expected)
        {
            var result = first.Add(second).Add(third);

            Assert.Equal(expected, result);
        }
    }
}
