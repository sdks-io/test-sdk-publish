// <copyright file="SwaggerPetstoreClient.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using APIMatic.Core;
    using APIMatic.Core.Authentication;
    using APIMatic.Core.Types;
    using SwaggerPetstore.Standard.Authentication;
    using SwaggerPetstore.Standard.Controllers;
    using SwaggerPetstore.Standard.Http.Client;
    using SwaggerPetstore.Standard.Utilities;

    /// <summary>
    /// The gateway for the SDK. This class acts as a factory for Controller and
    /// holds the configuration of the SDK.
    /// </summary>
    public sealed class SwaggerPetstoreClient : IConfiguration
    {
        // A map of environments and their corresponding servers/baseurls
        private static readonly Dictionary<Environment, Dictionary<Enum, string>> EnvironmentsMap =
            new Dictionary<Environment, Dictionary<Enum, string>>
        {
            {
                Environment.Production, new Dictionary<Enum, string>
                {
                    { Server.Server1, "https://petstore.swagger.io/v2" },
                    { Server.Server2, "http://petstore.swagger.io/v2" },
                    { Server.AuthServer, "https://petstore.swagger.io/oauth" },
                }
            },
        };

        private readonly GlobalConfiguration globalConfiguration;
        private const string userAgent = "APIMATIC 3.0";
        private readonly CustomAuthenticationManager customAuthenticationManager;
        private readonly Lazy<PetController> pet;
        private readonly Lazy<StoreController> store;
        private readonly Lazy<UserController> user;

        private SwaggerPetstoreClient(
            Environment environment,
            string password,
            IHttpClientConfiguration httpClientConfiguration)
        {
            this.Environment = environment;
            this.HttpClientConfiguration = httpClientConfiguration;
            customAuthenticationManager = new CustomAuthenticationManager(password);
            globalConfiguration = new GlobalConfiguration.Builder()
                .AuthManagers(new Dictionary<string, AuthManager> {
                        {"global", customAuthenticationManager}
                })
                .HttpConfiguration(httpClientConfiguration)
                .ServerUrls(EnvironmentsMap[environment], Server.Server1)
                .UserAgent(userAgent)
                .Build();


            this.pet = new Lazy<PetController>(
                () => new PetController(globalConfiguration));
            this.store = new Lazy<StoreController>(
                () => new StoreController(globalConfiguration));
            this.user = new Lazy<UserController>(
                () => new UserController(globalConfiguration));
        }

        /// <summary>
        /// Gets PetController controller.
        /// </summary>
        public PetController PetController => this.pet.Value;

        /// <summary>
        /// Gets StoreController controller.
        /// </summary>
        public StoreController StoreController => this.store.Value;

        /// <summary>
        /// Gets UserController controller.
        /// </summary>
        public UserController UserController => this.user.Value;

        /// <summary>
        /// Gets the configuration of the Http Client associated with this client.
        /// </summary>
        public IHttpClientConfiguration HttpClientConfiguration { get; }

        /// <summary>
        /// Gets Environment.
        /// Current API environment.
        /// </summary>
        public Environment Environment { get; }


        /// <summary>
        /// Gets the credentials to use with CustomAuthentication.
        /// </summary>
        public ICustomAuthenticationCredentials CustomAuthenticationCredentials => this.customAuthenticationManager;

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends
        /// it with template parameters.
        /// </summary>
        /// <param name="alias">Default value:SERVER1.</param>
        /// <returns>Returns the baseurl.</returns>
        public string GetBaseUri(Server alias = Server.Server1)
        {
            return globalConfiguration.ServerUrl(alias);
        }

        /// <summary>
        /// Creates an object of the SwaggerPetstoreClient using the values provided for the builder.
        /// </summary>
        /// <returns>Builder.</returns>
        public Builder ToBuilder()
        {
            Builder builder = new Builder()
                .Environment(this.Environment)
                .CustomAuthenticationCredentials(customAuthenticationManager.Password)
                .HttpClientConfig(config => config.Build());

            return builder;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return
                $"Environment = {this.Environment}, " +
                $"HttpClientConfiguration = {this.HttpClientConfiguration}, ";
        }

        /// <summary>
        /// Creates the client using builder.
        /// </summary>
        /// <returns> SwaggerPetstoreClient.</returns>
        internal static SwaggerPetstoreClient CreateFromEnvironment()
        {
            var builder = new Builder();

            string environment = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_ENVIRONMENT");
            string password = System.Environment.GetEnvironmentVariable("SWAGGER_PETSTORE_STANDARD_PASSWORD");

            if (environment != null)
            {
                builder.Environment(ApiHelper.JsonDeserialize<Environment>($"\"{environment}\""));
            }

            if (password != null)
            {
                builder.CustomAuthenticationCredentials(password);
            }

            return builder.Build();
        }

        /// <summary>
        /// Builder class.
        /// </summary>
        public class Builder
        {
            private Environment environment = SwaggerPetstore.Standard.Environment.Production;
            private string password = "";
            private HttpClientConfiguration.Builder httpClientConfig = new HttpClientConfiguration.Builder();

            /// <summary>
            /// Sets credentials for CustomAuthentication.
            /// </summary>
            /// <param name="password">Password.</param>
            /// <returns>Builder.</returns>
            public Builder CustomAuthenticationCredentials(string password)
            {
                this.password = password ?? throw new ArgumentNullException(nameof(password));
                return this;
            }

            /// <summary>
            /// Sets Environment.
            /// </summary>
            /// <param name="environment"> Environment. </param>
            /// <returns> Builder. </returns>
            public Builder Environment(Environment environment)
            {
                this.environment = environment;
                return this;
            }

            /// <summary>
            /// Sets HttpClientConfig.
            /// </summary>
            /// <param name="action"> Action. </param>
            /// <returns>Builder.</returns>
            public Builder HttpClientConfig(Action<HttpClientConfiguration.Builder> action)
            {
                if (action is null)
                {
                    throw new ArgumentNullException(nameof(action));
                }

                action(this.httpClientConfig);
                return this;
            }

           

            /// <summary>
            /// Creates an object of the SwaggerPetstoreClient using the values provided for the builder.
            /// </summary>
            /// <returns>SwaggerPetstoreClient.</returns>
            public SwaggerPetstoreClient Build()
            {

                return new SwaggerPetstoreClient(
                    environment,
                    password,
                    httpClientConfig.Build());
            }
        }
    }
}
