// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using ShogunLib.CommandLine.Commands;

namespace ShogunLib.CommandLine.Interpretation
{
    /// <summary>
    /// Represents a mechanism to start command line interpreter cycle.
    /// </summary>
    public interface IInterpreter
    {
        /// <summary>
        /// Raised when Help command is executed.
        /// </summary>
        event EventHandler<HelpCommandEventArgs> Help;

        /// <summary>
        /// Executes console command.
        /// </summary>
        /// <param name="input">Command to be executed.</param>
        void Execute(string input);
    }
}
