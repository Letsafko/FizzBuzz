using Domain;
using Domain.Strategies;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Peer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private const string FizzBuzzScheme = "Api:FizzBuzz";
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<FizzBuzzSettings>(Configuration.GetSection(FizzBuzzScheme))
                    .AddTransient<IFizzBuzzWrapper, FizzBuzzWrapper>()
                    .AddHttpClient(nameof(FizzBuzzSettings),
                    (provider, client) =>
                    {
                        var options = provider.GetRequiredService<IOptions<FizzBuzzSettings>>();
                        client.BaseAddress = options.Value.BaseAddress;
                    });

            services.AddScoped<IStrategyContext, StrategyContext>();
            services.AddScoped<IStrategy, RandomDifferentOfTwoStrategy>();
            services.AddScoped<IStrategy, RandomEqualsToTwoStrategy>();
            services.AddScoped<IFizzBuzz, FizzBuzz>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
