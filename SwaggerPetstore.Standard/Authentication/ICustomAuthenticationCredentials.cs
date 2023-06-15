// <copyright file="ICustomAuthenticationCredentials.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace SwaggerPetstore.Standard.Authentication
{
    using System;

    public interface ICustomAuthenticationCredentials
    {
        /// <summary>
        /// Gets string value for password.
        /// </summary>
        string Password { get; }

        /// <summary>
        ///  Returns true if credentials matched.
        /// </summary>
        /// <param name="password"> The string value for credentials.</param>
        /// <returns>True if credentials matched.</returns>
        bool Equals(string password);
    }
}