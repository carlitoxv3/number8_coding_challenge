using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CodingChallenge.Repositories.DBContexts.Extensions
{
    /// <summary>
    /// Extensions of IServiceCollection to implement a DBContext in Memory
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryDbContext<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
            => services.AddDbContext<TDbContext>(opt
                => opt.UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .ConfigureWarnings(w =>
                    {
                        w.Ignore(InMemoryEventId.TransactionIgnoredWarning);
                    }
                    ), ServiceLifetime.Singleton);
    }
}
