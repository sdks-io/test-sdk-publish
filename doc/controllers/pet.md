# Pet

Everything about your Pets

Find out more: [http://swagger.io](http://swagger.io)

```csharp
PetController petController = client.PetController;
```

## Class Name

`PetController`

## Methods

* [Inpet](../../doc/controllers/pet.md#inpet)
* [Upload File](../../doc/controllers/pet.md#upload-file)
* [Update an Pet](../../doc/controllers/pet.md#update-an-pet)
* [Find Pet in the Status](../../doc/controllers/pet.md#find-pet-in-the-status)
* [Find Pets an Tags](../../doc/controllers/pet.md#find-pets-an-tags)
* [Get Pet by Id](../../doc/controllers/pet.md#get-pet-by-id)
* [Delete Pet](../../doc/controllers/pet.md#delete-pet)
* [Update Pet With Form](../../doc/controllers/pet.md#update-pet-with-form)


# Inpet

Add a new pet to the store

```csharp
InpetAsync(
    Models.Pet body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Pet`](../../doc/models/pet.md) | Body, Required | Pet object that needs to be added to the store |

## Response Type

`Task`

## Example Usage

```csharp
Pet body = new Pet
{
    Name = "name6",
    PhotoUrls = new List<string>
    {
        "photoUrls1",
    },
};

try
{
    await petController.InpetAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 405 | Invalid input | `ApiException` |


# Upload File

uploads an image

```csharp
UploadFileAsync(
    long petId,
    string additionalMetadata = null,
    FileStreamInfo file = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to update |
| `additionalMetadata` | `string` | Form, Optional | Additional data to pass to server |
| `file` | `FileStreamInfo` | Form, Optional | file to upload |

## Response Type

[`Task<Models.ApiResponse>`](../../doc/models/api-response.md)

## Example Usage

```csharp
long petId = 152L;
try
{
    ApiResponse result = await petController.UploadFileAsync(petId, null, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```


# Update an Pet

Update an existing pet

```csharp
UpdateAnPetAsync(
    Models.Pet body)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `body` | [`Models.Pet`](../../doc/models/pet.md) | Body, Required | Pet object that needs to be added to the store |

## Response Type

`Task`

## Example Usage

```csharp
Pet body = new Pet
{
    Name = "name6",
    PhotoUrls = new List<string>
    {
        "photoUrls1",
    },
};

try
{
    await petController.UpdateAnPetAsync(body);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |
| 405 | Validation exception | `ApiException` |


# Find Pet in the Status

Multiple status values can be provided with comma separated strings

```csharp
FindPetInTheStatusAsync(
    List<Models.Status2Enum> status)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `status` | [`List<Models.Status2Enum>`](../../doc/models/status-2-enum.md) | Query, Required | Status values that need to be considered for filter |

## Response Type

[`Task<List<Models.Pet>>`](../../doc/models/pet.md)

## Example Usage

```csharp
List<Models.Status2Enum> status = new List<Models.Status2Enum>
{
    Status2Enum.Pending,
    Status2Enum.Sold,
    Status2Enum.Available,
};

try
{
    List<Pet> result = await petController.FindPetInTheStatusAsync(status);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid status value | `ApiException` |


# Find Pets an Tags

**This endpoint is deprecated.**

Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.

```csharp
FindPetsAnTagsAsync(
    List<string> tags)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `tags` | `List<string>` | Query, Required | Tags to filter by |

## Response Type

[`Task<List<Models.Pet>>`](../../doc/models/pet.md)

## Example Usage

```csharp
List<string> tags = new List<string>
{
    "tags5",
    "tags6",
};

try
{
    List<Pet> result = await petController.FindPetsAnTagsAsync(tags);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid tag value | `ApiException` |


# Get Pet by Id

Returns a single pet

```csharp
GetPetByIdAsync(
    long petId)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet to return |

## Response Type

[`Task<Models.Pet>`](../../doc/models/pet.md)

## Example Usage

```csharp
long petId = 152L;
try
{
    Pet result = await petController.GetPetByIdAsync(petId);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |


# Delete Pet

Deletes a pet

```csharp
DeletePetAsync(
    long petId,
    string apiKey = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | Pet id to delete |
| `apiKey` | `string` | Header, Optional | - |

## Response Type

`Task`

## Example Usage

```csharp
long petId = 152L;
try
{
    await petController.DeletePetAsync(petId, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 400 | Invalid ID supplied | `ApiException` |
| 404 | Pet not found | `ApiException` |


# Update Pet With Form

Updates a pet in the store with form data

```csharp
UpdatePetWithFormAsync(
    long petId,
    string name = null,
    string status = null)
```

## Parameters

| Parameter | Type | Tags | Description |
|  --- | --- | --- | --- |
| `petId` | `long` | Template, Required | ID of pet that needs to be updated |
| `name` | `string` | Form, Optional | Updated name of the pet |
| `status` | `string` | Form, Optional | Updated status of the pet |

## Response Type

`Task`

## Example Usage

```csharp
long petId = 152L;
try
{
    await petController.UpdatePetWithFormAsync(petId, null, null);
}
catch (ApiException e)
{
    // TODO: Handle exception here
    Console.WriteLine(e.Message);
}
```

## Errors

| HTTP Status Code | Error Description | Exception Class |
|  --- | --- | --- |
| 405 | Invalid input | `ApiException` |

