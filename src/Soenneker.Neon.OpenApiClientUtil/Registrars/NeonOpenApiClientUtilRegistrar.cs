using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Neon.HttpClients.Registrars;
using Soenneker.Neon.OpenApiClientUtil.Abstract;

namespace Soenneker.Neon.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class NeonOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="NeonOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddNeonOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddNeonOpenApiHttpClientAsSingleton()
                .TryAddSingleton<INeonOpenApiClientUtil, NeonOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="NeonOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddNeonOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddNeonOpenApiHttpClientAsSingleton()
                .TryAddScoped<INeonOpenApiClientUtil, NeonOpenApiClientUtil>();

        return services;
    }
}
