using FileApiLesson.Aplication.Services.UserProfileServices;
using Microsoft.Extensions.DependencyInjection;

namespace FileApiLesson.Aplication
{
    public static class AplicationDependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileServeces, UserProfileService>();
            return services;
        }
    }
}
