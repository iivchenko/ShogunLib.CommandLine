// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using CommandLineInterpreterFramework.Commands;

namespace CommandLineInterpreterFramework.Builders
{
    /// <summary>
    /// Provides functionality for lazy command initialization
    /// </summary>
    public interface ICommandBuilder
    {
        /// <summary>
        /// Gets or sets name of the command TODO: Finish
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <param name="name"></param>
        IParameterBuilder this[string name] { get; }

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <param name="description"></param>
        void SetDescription(string description);

        /// <summary>
        /// Adds parameter
        /// </summary>
        /// <param name="name"></param>
        void Add(string name);

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <returns></returns>
        ICommand Create();
    }
}
