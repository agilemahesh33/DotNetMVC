using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency Injection Container.
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        // To Do : Add your infrastructure services to the IoC container
        // Infrastructure Services offen include data access, caching, logging, and low-level components etc.
        // Example: service.AddSingleton<IMyService, MyService>();
        return service;
    }
}
