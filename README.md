[![](https://img.shields.io/nuget/v/soenneker.neon.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.neon.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.neon.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.neon.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.neon.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.neon.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.neon.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.neon.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Neon.OpenApiClientUtil

Provides a configured Neon management client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Neon.OpenApiClientUtil
```

## Configuration

```json
{
  "Neon": {
    "ApiKey": "your-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.Neon.OpenApiClientUtil.Abstract;
using Soenneker.Neon.OpenApiClientUtil.Registrars;

services.AddNeonOpenApiClientUtilAsSingleton();

INeonOpenApiClientUtil neon = serviceProvider
    .GetRequiredService<INeonOpenApiClientUtil>();

var client = await neon.Get(cancellationToken);
var regions = await client.Regions.GetAsync(cancellationToken: cancellationToken);
```

Use `AddNeonOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying HTTP provider remains shared and is disposed by the service container at shutdown.
