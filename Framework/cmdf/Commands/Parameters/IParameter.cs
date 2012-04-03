// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;

namespace CommandLineInterpreterFramework.Commands.Parameters
{
    /// <summary>
    /// Represents specific parameter for the console command
    /// </summary>
    public interface IParameter
    {
        /// <summary>
        /// Gets parameter information
        /// </summary>
        IParameterInfo Info { get; }

        /// <summary>
        /// Performs validation on the input arguments
        /// </summary>
        /// <param name="args">Input arguments</param>
        /// <exception cref="ArgumentValidationException"/>
        /// <returns>Validated argument</returns>
        IArgument Validate(IEnumerable<string> args);
    }
}
