// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace ShogunLib.CommandLine.Commands.Parameters
{
    /// <summary>
    /// Contains parameters data: Name and Description.
    /// </summary>
    public interface IParameterInfo
    {
        /// <summary>
        /// Gets parameters name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets parameters description.
        /// </summary>
        string Description { get; }
    }
}
