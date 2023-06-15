// <copyright file="PetController.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using APIMatic.Core;
    using APIMatic.Core.Types;
    using APIMatic.Core.Utilities;
    using APIMatic.Core.Utilities.Date.Xml;
    using Newtonsoft.Json.Converters;
    using SwaggerPetstore.Standard;
    using SwaggerPetstore.Standard.Authentication;
    using SwaggerPetstore.Standard.Exceptions;
    using SwaggerPetstore.Standard.Http.Client;
    using SwaggerPetstore.Standard.Utilities;
    using System.Net.Http;

    /// <summary>
    /// PetController.
    /// </summary>
    public class PetController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PetController"/> class.
        /// </summary>
        internal PetController(GlobalConfiguration globalConfiguration) : base(globalConfiguration) { }

        /// <summary>
        /// Add a new pet to the store.
        /// </summary>
        /// <param name="body">Required parameter: Pet object that needs to be added to the store.</param>
        public void Inpet(
                Models.Pet body)
            => CoreHelper.RunVoidTask(InpetAsync(body));

        /// <summary>
        /// Add a new pet to the store.
        /// </summary>
        /// <param name="body">Required parameter: Pet object that needs to be added to the store.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task InpetAsync(
                Models.Pet body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/pet")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("405", CreateErrorCase("Invalid input", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// uploads an image.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to update.</param>
        /// <param name="additionalMetadata">Optional parameter: Additional data to pass to server.</param>
        /// <param name="file">Optional parameter: file to upload.</param>
        /// <returns>Returns the Models.ApiResponse response from the API call.</returns>
        public Models.ApiResponse UploadFile(
                long petId,
                string additionalMetadata = null,
                FileStreamInfo file = null)
            => CoreHelper.RunTask(UploadFileAsync(petId, additionalMetadata, file));

        /// <summary>
        /// uploads an image.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to update.</param>
        /// <param name="additionalMetadata">Optional parameter: Additional data to pass to server.</param>
        /// <param name="file">Optional parameter: file to upload.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.ApiResponse response from the API call.</returns>
        public async Task<Models.ApiResponse> UploadFileAsync(
                long petId,
                string additionalMetadata = null,
                FileStreamInfo file = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.ApiResponse>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/pet/{petId}/uploadImage")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))
                      .Form(_form => _form.Setup("additionalMetadata", additionalMetadata))
                      .Form(_form => _form.Setup("file", file))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.ApiResponse>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Update an existing pet.
        /// </summary>
        /// <param name="body">Required parameter: Pet object that needs to be added to the store.</param>
        public void UpdateAnPet(
                Models.Pet body)
            => CoreHelper.RunVoidTask(UpdateAnPetAsync(body));

        /// <summary>
        /// Update an existing pet.
        /// </summary>
        /// <param name="body">Required parameter: Pet object that needs to be added to the store.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdateAnPetAsync(
                Models.Pet body,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Put, "/pet")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Body(_bodyParameter => _bodyParameter.Setup(body))
                      .Header(_header => _header.Setup("Content-Type", "application/json"))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Pet not found", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("405", CreateErrorCase("Validation exception", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <param name="status">Required parameter: Status values that need to be considered for filter.</param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public List<Models.Pet> FindPetInTheStatus(
                List<Models.Status2Enum> status)
            => CoreHelper.RunTask(FindPetInTheStatusAsync(status));

        /// <summary>
        /// Multiple status values can be provided with comma separated strings.
        /// </summary>
        /// <param name="status">Required parameter: Status values that need to be considered for filter.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        public async Task<List<Models.Pet>> FindPetInTheStatusAsync(
                List<Models.Status2Enum> status,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Models.Pet>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pet/findByStatus")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("status", status?.Select(a => ApiHelper.JsonSerialize(a).Trim('\"')).ToList()))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid status value", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<List<Models.Pet>>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
        /// </summary>
        /// <param name="tags">Required parameter: Tags to filter by.</param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        [Obsolete]
        public List<Models.Pet> FindPetsAnTags(
                List<string> tags)
            => CoreHelper.RunTask(FindPetsAnTagsAsync(tags));

        /// <summary>
        /// Multiple tags can be provided with comma separated strings. Use tag1, tag2, tag3 for testing.
        /// </summary>
        /// <param name="tags">Required parameter: Tags to filter by.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the List of Models.Pet response from the API call.</returns>
        [Obsolete]
        public async Task<List<Models.Pet>> FindPetsAnTagsAsync(
                List<string> tags,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<List<Models.Pet>>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pet/findByTags")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Query(_query => _query.Setup("tags", tags))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid tag value", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<List<Models.Pet>>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Returns a single pet.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to return.</param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public Models.Pet GetPetById(
                long petId)
            => CoreHelper.RunTask(GetPetByIdAsync(petId));

        /// <summary>
        /// Returns a single pet.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet to return.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the Models.Pet response from the API call.</returns>
        public async Task<Models.Pet> GetPetByIdAsync(
                long petId,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<Models.Pet>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Get, "/pet/{petId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Pet not found", (_reason, _context) => new ApiException(_reason, _context)))
                  .Deserializer(_response => ApiHelper.JsonDeserialize<Models.Pet>(_response)))
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Deletes a pet.
        /// </summary>
        /// <param name="petId">Required parameter: Pet id to delete.</param>
        /// <param name="apiKey">Optional parameter: Example: .</param>
        public void DeletePet(
                long petId,
                string apiKey = null)
            => CoreHelper.RunVoidTask(DeletePetAsync(petId, apiKey));

        /// <summary>
        /// Deletes a pet.
        /// </summary>
        /// <param name="petId">Required parameter: Pet id to delete.</param>
        /// <param name="apiKey">Optional parameter: Example: .</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task DeletePetAsync(
                long petId,
                string apiKey = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Delete, "/pet/{petId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))
                      .Header(_header => _header.Setup("api_key", apiKey))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("400", CreateErrorCase("Invalid ID supplied", (_reason, _context) => new ApiException(_reason, _context)))
                  .ErrorCase("404", CreateErrorCase("Pet not found", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);

        /// <summary>
        /// Updates a pet in the store with form data.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet that needs to be updated.</param>
        /// <param name="name">Optional parameter: Updated name of the pet.</param>
        /// <param name="status">Optional parameter: Updated status of the pet.</param>
        public void UpdatePetWithForm(
                long petId,
                string name = null,
                string status = null)
            => CoreHelper.RunVoidTask(UpdatePetWithFormAsync(petId, name, status));

        /// <summary>
        /// Updates a pet in the store with form data.
        /// </summary>
        /// <param name="petId">Required parameter: ID of pet that needs to be updated.</param>
        /// <param name="name">Optional parameter: Updated name of the pet.</param>
        /// <param name="status">Optional parameter: Updated status of the pet.</param>
        /// <param name="cancellationToken"> cancellationToken. </param>
        /// <returns>Returns the void response from the API call.</returns>
        public async Task UpdatePetWithFormAsync(
                long petId,
                string name = null,
                string status = null,
                CancellationToken cancellationToken = default)
            => await CreateApiCall<VoidType>()
              .RequestBuilder(_requestBuilder => _requestBuilder
                  .Setup(HttpMethod.Post, "/pet/{petId}")
                  .WithAuth("global")
                  .Parameters(_parameters => _parameters
                      .Template(_template => _template.Setup("petId", petId))
                      .Header(_header => _header.Setup("Content-Type", "application/x-www-form-urlencoded"))
                      .Form(_form => _form.Setup("name", name))
                      .Form(_form => _form.Setup("status", status))))
              .ResponseHandler(_responseHandler => _responseHandler
                  .ErrorCase("405", CreateErrorCase("Invalid input", (_reason, _context) => new ApiException(_reason, _context)))
)
              .ExecuteAsync(cancellationToken);
    }
}