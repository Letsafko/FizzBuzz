namespace Domain.Strategies
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class StrategyContext : IStrategyContext
    {
        private readonly IEnumerable<IStrategy> strategies;
        public StrategyContext(IEnumerable<IStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public IStrategy GetStrategy(IList<string> values)
        {
            return strategies.FirstOrDefault(x => x.CanApply(values));
        }
    }
}
