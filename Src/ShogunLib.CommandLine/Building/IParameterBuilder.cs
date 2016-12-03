// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using ShogunLib.CommandLine.Commands.Parameters;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation;

namespace ShogunLib.CommandLine.Building
{
    /// <summary>
    /// Provides functionality for lazy parameter initialization.
    /// </summary>
    public interface IParameterBuilder
    {
        /// <summary>
        ///  Sets parameter description.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        IParameterBuilder SetDescription(string description);

        /// <summary>
        /// Adds new validator to the end of validators list.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        IParameterBuilder AddValidator(IArgumentValidator validator);

        /// <summary>
        /// Create parameter with specified data.
        /// </summary>
        IParameter Create();
    }
}
