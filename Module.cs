using A3.Interfaces;
using A3.Services;
using Microsoft.Extensions.DependencyInjection;

namespace A3;

public static class Module
{
    public static IServiceCollection AddA3(this IServiceCollection services)
    {
        services.AddSingleton<IFormatManager, FormatManager>();
        services.AddSingleton<IRandomProvider, RandomProvider>();
        services.AddSingleton<IApp, App>();
        return services;
    }
}
