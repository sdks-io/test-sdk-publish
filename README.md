
# Getting Started with Swagger Petstore

## Introduction

This is a sample server Petstore server.  You can find out more about Swagger at [http://swagger.io](http://swagger.io) or on [irc.freenode.net, #swagger](http://swagger.io/irc/).  For this sample, you can use the api key `special-key` to test the authorization filters.

Find out more about Swagger: [http://swagger.io](http://swagger.io)

## Install the Package

If you are building with .NET CLI tools then you can also use the following command:

```bash
dotnet add package RepoTestSDK --version 1.1.1
```

You can also view the package at:
https://www.nuget.org/packages/RepoTestSDK/1.1.1

## Initialize the API Client

**_Note:_** Documentation for the client can be found [here.](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/client.md)

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

## Authorization

This API uses `Custom Authentication`.

## List of APIs

* [Pet](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/controllers/pet.md)
* [Store](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/controllers/store.md)
* [User](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/controllers/user.md)

## Classes Documentation

* [Utility Classes](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/utility-classes.md)
* [HttpRequest](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/http-request.md)
* [HttpResponse](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/http-response.md)
* [HttpStringResponse](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/http-string-response.md)
* [HttpContext](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/http-context.md)
* [HttpClientConfiguration](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/http-client-configuration.md)
* [HttpClientConfiguration Builder](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/http-client-configuration-builder.md)
* [IAuthManager](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/i-auth-manager.md)
* [ApiException](https://www.github.com/sdks-io/test-sdk-publish/tree/1.1.1/doc/api-exception.md)

