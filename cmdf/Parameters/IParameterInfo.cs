// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;

namespace CommandLineInterpreterFramework.Parameters
{
    /// <summary>
    /// Contains parameters data: Name and Description
    /// </summary>
    public interface IParameterInfo : ICloneable
    {
        /// <summary>
        /// Gets parameters name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets parameters description
        /// </summary>
        string Description { get; }
    }
}
