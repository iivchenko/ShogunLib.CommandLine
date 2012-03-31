// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Console;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Lazy realization for the exit command.
    /// It doesn't do anything.
    /// When exit command is performed interpreter terminates its work.
    /// </summary>
    public class ExitCommand : ICommand
    {
        /// <summary>
        /// Gets the name of the Exit command
        /// </summary>
        public string Name
        {
            get { return "Exit"; }
        }

        /// <summary>
        /// Gets Exut command description
        /// </summary>
        public string Description
        {
            get { return "Doesn't do anything"; }
        }

        /// <summary>
        /// Gets description of the command parameters (Exit command doesn't have parameters)
        /// </summary>
        public IEnumerable<IParameterInfo> Parameters
        {
            get { return new Collection<IParameterInfo>(); }
        }

        /// <summary>
        /// Performs specific action (Do nothing)
        /// </summary>
        /// <param name="console">IO device(console user interface)</param>
        /// <param name="args">Command input arguments</param> 
        public void Execute(IConsole console, IEnumerable<string> args)
        {
        }
    }
}
