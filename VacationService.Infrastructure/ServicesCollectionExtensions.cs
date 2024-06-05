using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VacationService.Application.Interfaces;
using VacationService.Infrastructure.Persistence;

namespace VacationService.Infrastructure;

public  static class ServicesCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IDataContext, DataContext>();
        return services;
    }
    public static IServiceCollection ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<DataContext>(options =>
        {
            if (connectionString != null)
                options.UseSqlServer(connectionString);
        });

        return services;
    }
    
}