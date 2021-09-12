using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CodingChallenge.UnitTests
{
    public class TestContext : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }
        public CodingChallenge.Repositories.DBContexts.LocalDBContext DBContext { get; }
        public IServiceProvider ServiceProvider { get; }

        public TestContext()
        {
            var builder = new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<TestStartup>();

            _testServer = new TestServer(builder);
            Client = _testServer.CreateClient();
            DBContext = _testServer.Host.Services.GetService(typeof(CodingChallenge.Repositories.DBContexts.LocalDBContext)) as CodingChallenge.Repositories.DBContexts.LocalDBContext;
            ServiceProvider = _testServer.Host.Services;

            try
            {
                ///Set the seed initializer
                Repositories.DBContexts.LocalDBContext context = ServiceProvider.GetRequiredService<Repositories.DBContexts.LocalDBContext>();
                //Execute seed initializer
                Repositories.DBContexts.Seeds.SeedInitializer.Initialize(context).Wait();
            }
            catch (Exception ex)
            {
                ILogger<Program> logger = ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
        }

        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}
