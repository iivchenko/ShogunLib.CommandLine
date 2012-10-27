// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands;

namespace CommandLineInterpreterFramework.Building
{
    /// <summary>
    /// Provides functionality for lazy command initialization.
    /// </summary>
    public interface ICommandBuilder
    {
        /// <summary>
        /// Gets lazy parameter by its name.
        /// </summary>
        IParameterBuilder this[string name] { get; }

        /// <summary>
        /// Sets command description.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        ICommandBuilder SetDescription(string description);

        /// <summary>
        /// Sets specific action for the command.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        ICommandBuilder SetAction(Action<IDictionary<string, IEnumerable<string>>> action);

        /// <summary>
        /// Add new parameter with specified name.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        ICommandBuilder Add(string name);

        /// <summary>
        /// Create command with specified data.
        /// </summary>
        ICommand Create();
    }
}
