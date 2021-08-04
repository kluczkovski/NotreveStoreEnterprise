using System;
using Microsoft.Extensions.DependencyInjection;

namespace NSE.Identity.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection  AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();


            return services;
        }
    }
}
