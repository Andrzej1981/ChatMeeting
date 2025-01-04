using Microsoft.EntityFrameworkCore;
using ChatMeeting.Core.Domain.Interfaces.Repositories;
using ChatMeeting.Infrastructure.Repositories;
using ChatMeeting.Core.Domain.Interfaces.Services;
using ChatMeeting.Core.Application.Services;

namespace ChatMeeting.API.Extensions
{
    public static class ServiceColletionExtension
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services,IConfiguration configuration) 
        {
            services.AddDbContext<ChatDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;    
        }

        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IAuthService, AuthService>();
            return services;
        }
    }
}
