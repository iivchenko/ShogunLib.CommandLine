// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;

namespace CommandLineInterpreterFramework.Commands.Parameters
{
    /// <summary>
    /// Represents specific argument for the console command.
    /// </summary>
    public interface IArgument
    {
        /// <summary>
        /// Gets argument name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets argument values.
        /// </summary>
        IEnumerable<string> Values { get; }
    }
}
