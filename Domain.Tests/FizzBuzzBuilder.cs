namespace FissBuzz.Tests
{
    using Domain;
    using Domain.Strategies;
    using NSubstitute;
    using System.Collections.Generic;

    internal sealed class FizzBuzzBuilder
    {
        private readonly IStrategyContext strategyContext;
        private readonly IFizzBuzzWrapper wrapper;
        private FizzBuzzBuilder()
        {
            wrapper = Substitute.For<IFizzBuzzWrapper>();
            strategyContext = new StrategyContext(new List<IStrategy>()
            {
                new RandomDifferentOfTwoStrategy(),
                new RandomEqualsToTwoStrategy()
            });
        }

        public static FizzBuzzBuilder Instance => new FizzBuzzBuilder();
        public FizzBuzz Build()
        {
            return new FizzBuzz(wrapper, strategyContext);
        }

        public FizzBuzzBuilder WithGetRandomValues(string value)
        {
            wrapper.GetRandomValuesAsync().Returns(value);
            return this;
        }
    }
}
