// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Console;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Provides functionality to work with the command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the name of the command
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets command description
        /// </summary>
        string Description { get; }
        
        /// <summary>
        /// Gets parameters names and descriptions
        /// </summary>
        IEnumerable<IParameterInfo> Parameters { get; }

        /// <summary>
        /// Performs specific action
        /// </summary>
        /// <param name="console">IO device(console user interface)</param>
        /// <param name="args">Command input arguments</param> 
        void Execute(IConsole console, IEnumerable<string> args);
    }
}
