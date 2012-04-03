// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation;
using CommandLineInterpreterFramework.Interpretation.Parsing;

namespace CommandLineInterpreterFramework.Builders
{
    /// <summary>
    /// Provides functionality for lazy interpreter initialization
    /// </summary>
    public interface IInterpreterBuilder
    {
        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <param name="name"></param>
        ICommandBuilder this[string name] { get; }

        /// <summary>
        /// Adds command
        /// </summary>
        /// <param name="name"></param>
        void Add(string name);

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <param name="name"></param>
        void SetPrefix(string name);

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <param name="console"></param>
        void SetConsole(IConsole console);

        /// <summary>
        /// TODO: Finish
        /// </summary>
        /// <returns></returns>
        IInterpreter Create();
    }
}
