namespace FissBuzz.Tests
{
    using System.Threading.Tasks;
    using Xunit;
    public sealed class FizzBuzzTest
    {
        private const string Fizz = "FIZZ";
        private const string Buzz = "BUZZ";
        private const string FizzBuzz = "FIZZBUZZ";

        [Theory]
        [InlineData("2:1:4", FizzBuzz)]
        [InlineData("3:2:4", Buzz)]
        [InlineData("2:3:4", Fizz)]
        [InlineData("6:7", "42")]
        [InlineData("7:3", "21")]
        [InlineData("1:2", "2")]
        public async Task Test1(string value, string expected)
        {
            //arrange
            var service = FizzBuzzBuilder
                .Instance
                .WithGetRandomValues(value)
                .Build();

            //act
            var actual = await service.CalculateResultAsync();

            //assert
            Assert.Equal(actual, expected);
        }
    }
}
