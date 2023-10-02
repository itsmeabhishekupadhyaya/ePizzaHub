using ePizzaHub.Core;
using ePizzaHub.Core.Entities;
using ePizzaHub.Repositories.Implementations;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Implementations;
using ePizzaHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ePizzaHub.Services
{
    public static class ConfigureDependencies
    {
        public static void RegisterService(IServiceCollection services,IConfiguration configuration)
        {
            //database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });
            //repository
            services.AddScoped<IRepository<User>, Respository<User>>();
            services.AddScoped<IUserRespository, UserRepository>();
            services.AddScoped<IService<User>,Service<User>>();
            services.AddScoped<IAuthService,AuthService>();

            
        }
    }
}
