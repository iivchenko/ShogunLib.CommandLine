// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
        public ICollection<ParameterInfo> Parameters
        {
            get { return new Collection<ParameterInfo>(); }
        }

        /// <summary>
        /// Performs specific action (Do nothing)
        /// </summary>
        /// <param name="args">Command input arguments</param> 
        public void Execute(IEnumerable<string> args)
        {
        }
    }
}
