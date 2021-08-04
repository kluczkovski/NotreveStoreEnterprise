using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NSE.Web.MVC.Extensions;
using NSE.Web.MVC.Services;

namespace NSE.Web.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            services.AddHttpClient<IAuthService, AuthService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
