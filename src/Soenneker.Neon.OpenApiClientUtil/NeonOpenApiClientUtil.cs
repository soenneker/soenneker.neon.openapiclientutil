using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Neon.HttpClients.Abstract;
using Soenneker.Neon.OpenApiClientUtil.Abstract;
using Soenneker.Neon.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Neon.OpenApiClientUtil;

///<inheritdoc cref="INeonOpenApiClientUtil"/>
public sealed class NeonOpenApiClientUtil : INeonOpenApiClientUtil
{
    private readonly AsyncSingleton<NeonOpenApiClient> _client;

    public NeonOpenApiClientUtil(INeonOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<NeonOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Neon:ApiKey");
            string authHeaderValueTemplate = configuration["Neon:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
