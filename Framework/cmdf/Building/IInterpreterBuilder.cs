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
        void Add(string name);

        /// <summary>
        /// Sets console prefix
        /// </summary>
        void SetPrefix(string name);

        /// <summary>
        /// Sets specific console or StandardConsole will be used
        /// </summary>
        void SetConsole(IConsole console);

        /// <summary>
        /// Sets policy for general exception hanling
        /// </summary>
        void SetExceptionHandling(Action<IConsole, Exception> exceptionHandling);

        /// <summary>
        /// Create interpreter with specified data
        /// </summary>
        IInterpreter Create();
    }
}
