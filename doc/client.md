
# Client Class Documentation

The following parameters are configurable for the API Client:

| Parameter | Type | Description |
|  --- | --- | --- |
| `Environment` | Environment | The API environment. <br> **Default: `Environment.Production`** |
| `Timeout` | `TimeSpan` | Http client timeout.<br>*Default*: `TimeSpan.FromSeconds(100)` |
| `Password` | `string` |  |

The API client can be initialized as follows:

```csharp
SwaggerPetstore.Standard.SwaggerPetstoreClient client = new SwaggerPetstore.Standard.SwaggerPetstoreClient.Builder()
    .CustomAuthenticationCredentials("Password")
    .Environment(SwaggerPetstore.Standard.Environment.Production)
    .Build();
```

## Swagger PetstoreClient Class

The gateway for the SDK. This class acts as a factory for the Controllers and also holds the configuration of the SDK.

### Controllers

| Name | Description |
|  --- | --- |
| PetController | Gets PetController controller. |
| StoreController | Gets StoreController controller. |
| UserController | Gets UserController controller. |

### Properties

| Name | Description | Type |
|  --- | --- | --- |
| HttpClientConfiguration | Gets the configuration of the Http Client associated with this client. | [`IHttpClientConfiguration`](http-client-configuration.md) |
| Timeout | Http client timeout. | `TimeSpan` |
| Environment | Current API environment. | `Environment` |

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `GetBaseUri(Server alias = Server.Server1)` | Gets the URL for a particular alias in the current environment and appends it with template parameters. | `string` |
| `ToBuilder()` | Creates an object of the Swagger PetstoreClient using the values provided for the builder. | `Builder` |

## Swagger PetstoreClient Builder Class

Class to build instances of Swagger PetstoreClient.

### Methods

| Name | Description | Return Type |
|  --- | --- | --- |
| `HttpClientConfiguration(Action<`[`HttpClientConfiguration.Builder`](http-client-configuration-builder.md)`> action)` | Gets the configuration of the Http Client associated with this client. | `Builder` |
| `Timeout(TimeSpan timeout)` | Http client timeout. | `Builder` |
| `Environment(Environment environment)` | Current API environment. | `Builder` |

