using Soenneker.Neon.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Neon.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Neon management client backed by the configured HTTP provider.
/// </summary>
public interface INeonOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Neon client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Neon client.</returns>
    ValueTask<NeonOpenApiClient> Get(CancellationToken cancellationToken = default);
}
