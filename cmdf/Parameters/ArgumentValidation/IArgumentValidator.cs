// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System.Collections.Generic;

namespace CommandLineInterpreterFramework.Parameters.ArgumentValidation
{
    /// <summary>
    /// Provides functionality for console command argument validation
    /// </summary>
    public interface IArgumentValidator
    {
        /// <summary>
        /// Gets the error validation message if validation is failed
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Validate console command argument
        /// </summary>
        /// <param name="arg">Input argument</param>
        /// <returns>true - valid; false- invalid</returns>
        bool Validate(IEnumerable<string> arg);
    }
}
