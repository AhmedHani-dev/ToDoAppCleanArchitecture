using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ToDo.Application.Extensions;
public static class AddDependenciesExtensionMethods
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
