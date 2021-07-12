namespace Domain.Strategies
{
    using System.Collections.Generic;
    public interface IStrategy
    {
        bool CanApply(IList<string> values);
        string Apply(IList<string> values);
    }
}