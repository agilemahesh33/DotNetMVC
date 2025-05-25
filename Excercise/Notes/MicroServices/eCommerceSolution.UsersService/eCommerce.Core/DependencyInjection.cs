using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add core services to the dependency Injection Container.
    /// </summary>
    /// <param name="service"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection service)
    {
        // To Do : Add your core services to the IoC container
        // Core Services often include business logic, domain models, and application services.
        // Example: service.AddSingleton<IMyCoreService, MyCoreService>();
        return service;
    }
}
