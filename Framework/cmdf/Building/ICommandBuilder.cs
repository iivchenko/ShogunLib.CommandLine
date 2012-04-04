// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Console;

namespace CommandLineInterpreterFramework.Building
{
    /// <summary>
    /// Provides functionality for lazy command initialization
    /// </summary>
    public interface ICommandBuilder
    {
        /// <summary>
        /// Gets lazy parameter by its name
        /// </summary>
        IParameterBuilder this[string name] { get; }

        /// <summary>
        /// Sets command description
        /// </summary>
        void SetDescription(string description);

        /// <summary>
        /// Sets specific action for the command
        /// </summary>
        void SetAction(Action<IConsole, IDictionary<string, IEnumerable<string>>> action);

        /// <summary>
        /// Add new parameter with specified name
        /// </summary>
        void Add(string name);

        /// <summary>
        /// Create command with specified data
        /// </summary>
        ICommand Create();
    }
}
