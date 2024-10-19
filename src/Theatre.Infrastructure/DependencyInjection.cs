using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Theatre.Application.Common.Interfaces;
using Theatre.Infrastructure.Data;

namespace Theatre.Infrastructure;

public static class DependencyInjection
{
    private static readonly string ConfigFileName = "appsettings.json";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddDbContext();

        return services;
    }

    private static void AddDbContext(this IServiceCollection services)
    {
        var config = new Configuration();
        services.AddDbContext<TheatreDbContext>(options => options.UseNpgsql(config.ConnectionString));
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<TheatreDbContext>());
    }
}