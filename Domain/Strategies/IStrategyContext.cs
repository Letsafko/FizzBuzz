namespace Domain.Strategies
{
    using System.Collections.Generic;
    public interface IStrategyContext
    {
        IStrategy GetStrategy(IList<string> values);
    }
}