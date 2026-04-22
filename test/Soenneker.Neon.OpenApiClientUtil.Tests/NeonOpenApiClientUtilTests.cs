using Soenneker.Neon.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Neon.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class NeonOpenApiClientUtilTests : HostedUnitTest
{
    private readonly INeonOpenApiClientUtil _openapiclientutil;

    public NeonOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<INeonOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
