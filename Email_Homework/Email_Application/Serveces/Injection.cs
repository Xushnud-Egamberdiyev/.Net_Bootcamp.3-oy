using Email_Application.Serveces.EmailServeces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Application.Serveces
{
    public static class Injection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IEmailServece, EmailServece>();
            return services;
        }
    }
}
