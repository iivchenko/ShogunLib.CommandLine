// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;

namespace CommandLineInterpreterFramework.Interpretation.Parsing
{
    /// <summary>
    /// Represents parsed string as a command.
    /// </summary>
    public class ParsedCommand : IParsedCommand
    {
        /// <summary>
        /// Initializes a new instance of the ParsedCommand class.
        /// </summary>
        /// <param name="name">Command name.</param>
        /// <param name="args">Command arguments.</param>
        public ParsedCommand(string name, IEnumerable<string> args)
        {
            Name = name;
            Args = args;
        }

        /// <summary>
        /// Gets command name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets command parameters with arguments.
        /// </summary>
        public IEnumerable<string> Args { get; private set; }
    }
}
