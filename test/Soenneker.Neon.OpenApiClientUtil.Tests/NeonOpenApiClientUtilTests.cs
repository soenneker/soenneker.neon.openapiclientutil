using Soenneker.Neon.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Neon.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class NeonOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly INeonOpenApiClientUtil _openapiclientutil;

    public NeonOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<INeonOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
