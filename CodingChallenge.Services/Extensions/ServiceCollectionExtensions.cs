using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Services.Extensions
{
    /// <summary>
    /// Extensions of IServiceCollection to implement a dependency injection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServicesInjection(this IServiceCollection services)
        {
            services.AddScoped<Interfaces.IDepartmentService, DepartmentService>();
            services.AddScoped<Interfaces.ITaxService, TaxService>();
            services.AddScoped<Interfaces.IOrderService, OrderService>();
            return services;
        }
    }
}
