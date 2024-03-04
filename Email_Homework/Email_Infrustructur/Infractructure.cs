using Email_Application.IServer;
using Email_Infrustructur.BaseRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Email_Infrustructur
{
    public static class Infractructure
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AddAplication>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IloginRepository, LoginRepository>();
            return services;

        }

    }

}
