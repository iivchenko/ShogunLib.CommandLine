// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation;

namespace CommandLineInterpreterFramework.Building
{
    /// <summary>
    /// Provides functionality for lazy interpreter initialization
    /// </summary>
    public interface IInterpreterBuilder
    {
        /// <summary>
        /// Gets lazy command by its name
        /// </summary>
        ICommandBuilder this[string name] { get; }

        /// <summary>
        /// Add new command with specified name
        /// </summary>
        /// <returns>Itself</returns>
        IInterpreterBuilder Add(string name);

        /// <summary>
        /// Sets console prefix
        /// </summary>
        /// <returns>Itself</returns>
        IInterpreterBuilder SetPrefix(string name);

        /// <summary>
        /// Sets specific console or StandardConsole will be used
        /// </summary>
        /// <returns>Itself</returns>
        IInterpreterBuilder SetConsole(IConsole console);

        /// <summary>
        /// Sets policy for general exception hanling
        /// </summary>
        /// <returns>Itself</returns>
        IInterpreterBuilder SetExceptionHandling(Action<IConsole, Exception> exceptionHandling);

        /// <summary>
        /// Create interpreter with specified data
        /// </summary>
        IInterpreter Create();
    }
}
