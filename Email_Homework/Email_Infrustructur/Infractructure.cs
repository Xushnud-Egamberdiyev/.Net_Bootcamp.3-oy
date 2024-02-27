using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Infrustructur
{
    public static class Infractructure
    {
        public static IServiceCollection AddInfrustructure(this  IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AddAplication>(option =>
            option.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
        
    }

}
