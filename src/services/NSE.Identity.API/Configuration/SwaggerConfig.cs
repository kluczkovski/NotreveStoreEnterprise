using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace NSE.Identity.API.Configuration
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services) 
        {
            services.AddSwaggerGen(sg =>
            {
                sg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Notreve Store Enterprise Identity API",
                    Description = "This API is part of Notreve Store Enterprise",
                    Contact = new OpenApiContact() { Name = "Everton Kluczkovski", Email = "kluczkovski@hotmail.com" },
                    License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org./licenses/MIT") }
                });
            });

            return services;
        }
    }
}
