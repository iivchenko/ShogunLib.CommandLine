// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Interpretation;

namespace ShogunLib.CommandLine.Building
{
    /// <summary>
    /// Provides functionality for lazy interpreter initialization.
    /// </summary>
    public interface IInterpreterBuilder
    {
        /// <summary>
        /// Gets lazy command by its name.
        /// </summary>
        ICommandBuilder this[string name] { get; }

        /// <summary>
        /// Add new command with specified name.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        IInterpreterBuilder Add(string name);

        /// <summary>
        /// Set help command name and action.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        IInterpreterBuilder SetHelp(string name, EventHandler<HelpCommandEventArgs> helpAction);
        
        /// <summary>
        /// Create interpreter with specified data.
        /// </summary>
        IInterpreter Create();
    }
}
