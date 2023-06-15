// <copyright file="CustomAuthenticationManager.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Authentication
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SwaggerPetstore.Standard.Http.Request;
    using APIMatic.Core.Authentication;
/// <summary>
/// CustomAuthenticationManager Class.
/// </summary>
internal class CustomAuthenticationManager : AuthManager, ICustomAuthenticationCredentials
     {
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomAuthenticationManager(string password)
        {
            Password = password;
            // TODO: Add your custom authentication here
            // Parameters(parameters => parameters
            //     .Header(headerParameter => headerParameter.Setup("Key 1", "Value 1"))
            //     .Header(headerParameter => headerParameter.Setup("Key 2", "Value 2"))
            //     .Header(headerParameter => headerParameter.Setup("...", "...")));
        }
        /// <summary>
        /// Gets string value for password.
        /// </summary>
        public string Password { get; }

        /// <summary>
        /// Check if credentials match.
        /// </summary>
        /// <param name="password"> The string value for credentials.</param>
        /// <returns> True if credentials matched.</returns>
        public bool Equals(string password)
        {
            return password.Equals(this.Password);
        }
    }
}