using Soenneker.Neon.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Neon.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface INeonOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<NeonOpenApiClient> Get(CancellationToken cancellationToken = default);
}
