using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Neon.HttpClients.Abstract;
using Soenneker.Neon.OpenApiClientUtil.Abstract;
using Soenneker.Neon.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Neon.OpenApiClientUtil;

public sealed class NeonOpenApiClientUtil : INeonOpenApiClientUtil
{
    private readonly AsyncSingleton<NeonOpenApiClient> _client;

    public NeonOpenApiClientUtil(INeonOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<NeonOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new NeonOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<NeonOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
