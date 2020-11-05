using Api.Model;
using Api.Services;
using Api.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Middleware
{
    public static class Registrar
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            var atuhOptions = configuration.GetSection("AuthenticationSettings");
            services.Configure<AuthOptions>(atuhOptions);
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
