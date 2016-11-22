// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;

namespace ShogunLib.CommandLine.Interpretation.Parsing
{
    /// <summary>
    /// Represents parsed string as a command.
    /// </summary>
    public interface IParsedCommand
    {
        /// <summary>
        /// Gets command name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets command parameters with arguments.
        /// </summary>
        IEnumerable<string> Args { get; }
    }
}
