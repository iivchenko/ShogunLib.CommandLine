// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

namespace CommandLineInterpreterFramework
{
    /// <summary>
    /// Represents specific argument for the console command
    /// </summary>
    public interface IArgument
    {
        /// <summary>
        /// Gets argument name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets argment value
        /// </summary>
        string Value { get; }
    }
}
