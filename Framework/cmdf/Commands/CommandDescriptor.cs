// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands.Parameters;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Represent information about console command.
    /// </summary>
    public class CommandDescriptor
    {
        /// <summary>
        /// Initializes a new instance of the CommandDescriptor class.
        /// </summary>
        public CommandDescriptor(string name, 
                                 string description, 
                                 IEnumerable<IParameterInfo> parameters)
        {
            Name = name;
            Description = description;
            Parameters = parameters;
        }

        /// <summary>
        /// Gets the name of the command.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets command description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets commands parameters descriptions.
        /// </summary>
        public IEnumerable<IParameterInfo> Parameters { get; private set; }
    }
}
