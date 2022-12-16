using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TFE.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionString");

        services.AddDbContext<ApplicationDbContext>(option =>
        {
            option.UseNpgsql(connectionString);
        });
        
        return services;
    }
}