// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;

namespace CommandLineInterpreterFramework.Building
{
    /// <summary>
    /// Provides functionality for lazy parameter initialization
    /// </summary>
    public interface IParameterBuilder
    {
        /// <summary>
        ///  Sets parameter description
        /// </summary>
        /// <returns>Itself</returns>
        IParameterBuilder SetDescription(string description);

        /// <summary>
        /// Adds new validator to the end of validators list
        /// </summary>
        /// <returns>Itself</returns>
        IParameterBuilder AddValidator(IArgumentValidator validator);

        /// <summary>
        /// Create parameter with specified data
        /// </summary>
        IParameter Create();
    }
}
