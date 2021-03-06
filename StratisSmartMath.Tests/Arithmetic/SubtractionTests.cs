﻿using Xunit;

namespace StratisSmartMath.Tests.Arithmetic
{
    public class SubtractionTests
    {
        [Theory]
        [InlineData("1.00000001", "1.00000001", 0)]
        [InlineData("4.7654", "3.4732", 129_220_000)]
        [InlineData("1.2345", "0.0732430", 116_125_700)]
        public void CanSubtract_TwoDecimalNumbers(string first, string second, ulong expected)
        {
            var result = first.Subtract(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, 100_000_001, 0)]
        [InlineData(476_540_000, 347_320_000, 129_220_000)]
        [InlineData(123_450_000, 007_324_300, 116_125_700)]
        public void CanSubtract_TwoStratoshiValues(ulong first, ulong second, ulong expected)
        {
            var result = first.Subtract(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1.00000001", 100_000_001, 0)]
        [InlineData("4.7654", 347_320_000, 129_220_000)]
        [InlineData("1.2345", 007_324_300, 116_125_700)]
        public void CanSubtract_StratoshiValue_From_DecimalString(string first, ulong second, ulong expected)
        {
            var result = first.Subtract(second);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100_000_001, "1.00000001", 0)]
        [InlineData(476_540_000, "3.4732", 129_220_000)]
        [InlineData(123_450_000, "0.0732430", 116_125_700)]
        public void CanSubtract_DecimalString_From_StratoshiValue(ulong first, string second, ulong expected)
        {
            var result = first.Subtract(second);

            Assert.Equal(expected, result);
        }
    }
}
