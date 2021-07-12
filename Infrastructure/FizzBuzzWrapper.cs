namespace Infrastructure
{
    using Domain;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class FizzBuzzWrapper : IFizzBuzzWrapper
    {
        private readonly IHttpClientFactory httpClientFactory;
        public FizzBuzzWrapper(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        private const string Scheme = "Peer";
        public async Task<string> GetRandomValuesAsync()
        {
            using (var client = httpClientFactory.CreateClient(nameof(FizzBuzzSettings)))
            {
                var response = await client.GetAsync(new Uri(Scheme, UriKind.Relative));
                return (await response.Content.ReadAsStringAsync());
            }
        }
    }
}