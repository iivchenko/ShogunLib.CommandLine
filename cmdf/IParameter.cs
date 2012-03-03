// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.ArgumentValidation;
using CommandLineInterpreterFramework.ParameterLimitation;

namespace CommandLineInterpreterFramework
{
    /// <summary>
    /// Represents specific parameter for the console command
    /// </summary>
    public interface IParameter
    {
        /// <summary>
        /// Gets parameter name. Shouldn't have white spaces.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets parameter description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Performs validation on the input arguments
        /// </summary>
        /// <param name="args">Input arguments</param>
        /// <exception cref="ParameterLimitException"/>
        /// <exception cref="ArgumentValidationException"/>
        /// <returns>Validated argument</returns>
        IArgument Validate(IEnumerable<string> args);
    }
}
