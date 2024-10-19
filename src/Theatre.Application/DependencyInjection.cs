﻿using System.Reflection;
using System.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;

namespace Theatre.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        return services;
    }
}