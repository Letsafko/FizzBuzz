namespace Domain.Strategies
{
    using System.Collections.Generic;
    public sealed class RandomDifferentOfTwoStrategy : IStrategy
    {
        private const string Fizz = "FIZZ";
        private const string Buzz = "BUZZ";
        public string Apply(IList<string> values)
        {
            var A = int.Parse(values[0]);
            var B = int.Parse(values[1]);
            var C = int.Parse(values[2]);

            return $"{(C % A == 0 ? Fizz : string.Empty)}{(C % B == 0 ? Buzz : string.Empty)}";
        }

        public bool CanApply(IList<string> values)
        {
            return values.Count != 2;
        }
    }
}
