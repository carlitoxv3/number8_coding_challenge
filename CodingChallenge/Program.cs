using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = CreateHostBuilder(args);

            var webhost = hostBuilder.Build();

            using (IServiceScope scope = webhost.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;
                try
                {
                    // Set the seed initializer
                    Repositories.DBContexts.LocalDBContext context = services.GetRequiredService<Repositories.DBContexts.LocalDBContext>();
                    //Execute seed initializer
                    Repositories.DBContexts.Seeds.SeedInitializer.Initialize(context).Wait();
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            webhost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
