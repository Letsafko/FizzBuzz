namespace Domain.Strategies
{
    using System.Collections.Generic;
    public sealed class RandomEqualsToTwoStrategy : IStrategy
    {
        public string Apply(IList<string> values)
        {
            return $"{int.Parse(values[0]) * int.Parse(values[1])}";
        }

        public bool CanApply(IList<string> values)
        {
            return values.Count == 2;
        }
    }
}