// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;

namespace CommandLineInterpreterFramework.Builders
{
    /// <summary>
    /// Provides functionality for lazy parameter initialization
    /// </summary>
    public interface IParameterBuilder
    {
        /// <summary>
        /// Gets or sets name of the parameter TODO: Finish
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <param name="description"></param>
        void SetDescription(string description);

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <param name="validator"></param>
        void AddValidator(IArgumentValidator validator);

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <returns></returns>
        IParameter Create();
    }
}
