using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Theatre.Application.Common.Interfaces;
using Theatre.Infrastructure.Data;
using Theatre.Infrastructure.Repositories;

namespace Theatre.Infrastructure;

public static class DependencyInjection
{
    private const string TheatreConnectionStringName = "TheatreConnectionString";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfigurationManager configurationManager)
    {
        var connectionString = configurationManager[TheatreConnectionStringName] ??
                               throw new NullReferenceException("Connection String was not found");

        services
            .AddDbContext(connectionString)
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<TheatreDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<TheatreDbContext>());
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEventsRepository, EventsRepository>();
        services.AddScoped<IHallsRepository, HallsRepository>();
        services.AddScoped<ISeatsRepository, SeatsRepository>();
        services.AddScoped<ISectorsRepository, SectorsRepository>();
        services.AddScoped<ITicketsRepository, TicketsRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        return services;
    }
}