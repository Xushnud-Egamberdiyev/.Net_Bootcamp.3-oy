using FileApi.Aplication.Services.CarServeces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileApi.Aplication
{
    public static class AdAplication
    {
        public static IServiceCollection AdService(this IServiceCollection services)
        {
            services.AddScoped<Services.CarServeces.ICarServece, CarServece>();
            return services;
        }
    }
}
 