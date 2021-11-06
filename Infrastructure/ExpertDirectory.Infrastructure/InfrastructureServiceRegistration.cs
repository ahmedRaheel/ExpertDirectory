using ExpertDirectory.Application.Contracts;
using ExpertDirectory.Infrastructure.Persistence;
using ExpertDirectory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpertDirectory.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ExpertDirectoryContext>(options => 
                                    options.UseSqlServer(configuration.GetConnectionString("DirectoryConnectionString")));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserConnectionRepository, UserConnectionRepository>();
            services.AddScoped<IUserHeadingRepository, UserHeadingRepository>();
            return services; 
        }
    }
}
