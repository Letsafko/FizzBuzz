namespace Domain
{
    using Domain.Strategies;
    using System.Threading.Tasks;
    public class FizzBuzz : IFizzBuzz
    {
        private readonly IStrategyContext strategyContext;
        private readonly IFizzBuzzWrapper wrapper;
        public FizzBuzz(IFizzBuzzWrapper wrapper, IStrategyContext strategyContext)
        {
            this.strategyContext = strategyContext;
            this.wrapper = wrapper;
        }

        public async Task<string> CalculateResultAsync()
        {
            var values = (await wrapper.GetRandomValuesAsync()).Split(":");
            var strategy = strategyContext.GetStrategy(values);
            return strategy.Apply(values);
        }
    }
}