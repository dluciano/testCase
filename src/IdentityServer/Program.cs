using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var seed = args.Contains("/seed");
            if (seed) args = args.Except(new[] {"/seed"}).ToArray();

            var host = CreateWebHostBuilder(args).Build();

            if (seed)
            {
                using (var scope = host.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<ISeed>().EnsureSeedDataAsync();
                }

                return;
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }
    }
}