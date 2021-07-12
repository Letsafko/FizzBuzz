namespace Domain
{
    using System.Threading.Tasks;

    public interface IFizzBuzzWrapper
    {
        Task<string> GetRandomValuesAsync();
    }
}