// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System.Collections.Generic;

namespace CommandLineInterpreterFramework.Parsing
{
    /// <summary>
    /// Represents parsed string as a command
    /// </summary>
    public interface IParsedCommand
    {
        /// <summary>
        /// Gets command name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets command parameters with arguments
        /// </summary>
        ICollection<string> Args { get; }
    }
}
