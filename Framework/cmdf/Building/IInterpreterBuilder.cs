// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using CommandLineInterpreterFramework.Commands;
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
        /// Set help command name and action.
        /// </summary>
        /// <returns>Itself</returns>
        IInterpreterBuilder SetHelp(string name, EventHandler<HelpCommandEventArgs> helpAction);
        
        /// <summary>
        /// Create interpreter with specified data
        /// </summary>
        IInterpreter Create();
    }
}
