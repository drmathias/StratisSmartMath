using Xunit;

namespace StratisSmartMath.Tests
{
    public class MoneyTests
    {
        [Theory]
        [InlineData(0, "0.00000000")]
        [InlineData(1, "0.00000001")]
        [InlineData(50, "0.00000050")]
        [InlineData(500_000_000, "5.00000000")]
        [InlineData(5_000_000_000, "50.00000000")]
        public void Strat_ToString(ulong amount, string expected)
        {
            var strats = ((Stratoshi)amount).ToStrats();
            Assert.Equal(expected, strats.ToString());
        }

        [Theory]
        [InlineData("0.00000000", 0)]
        [InlineData("2.9", 290_000_000)]
        [InlineData(".09", 9_000_000)]
        [InlineData("6.0079", 600_790_000)]
        [InlineData("24", 2_400_000_000)]
        public void Strat_Parse(string value, ulong expectedStratoshis)
        {
            var strats = Strat.Parse(value);
            Assert.Equal(expectedStratoshis, ulong.Parse(strats.ToStratoshis().ToString()));
        }

        [Theory]
        [InlineData(0, 10, 10)]
        [InlineData(10, 10, 20)]
        public void Stratoshi_Add(ulong a, ulong b, ulong expected)
        {
            Stratoshi s1 = a;
            Stratoshi s2 = b;
            Assert.Equal(expected, s1 + s2);
        }

        [Theory]
        [InlineData(10, 0, 10)]
        [InlineData(10, 10, 0)]
        public void Stratoshi_Subtract(ulong a, ulong b, ulong expected)
        {
            Stratoshi s1 = a;
            Stratoshi s2 = b;
            Assert.Equal(expected, s1 - s2);
        }

        [Theory]
        [InlineData(10, 0, 0)]
        [InlineData(10, 10, 100)]
        public void Stratoshi_Multiply(ulong a, ulong b, ulong expected)
        {
            Stratoshi s1 = a;
            Assert.Equal(expected, s1 * b);
        }
    }
}
