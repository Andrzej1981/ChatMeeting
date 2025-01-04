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
    }
}
