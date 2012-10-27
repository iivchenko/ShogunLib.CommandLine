// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;

namespace CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation
{
    /// <summary>
    /// Provides functionality for console command arguments validation.
    /// </summary>
    public interface IArgumentValidator
    {
        /// <summary>
        /// Gets the error validation message if validation is failed.
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Validate console command arguments.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>true - validation succeeded; false - fail.</returns>
        bool Validate(IEnumerable<string> args);
    }
}
