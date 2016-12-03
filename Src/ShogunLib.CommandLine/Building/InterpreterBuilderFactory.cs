// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace ShogunLib.CommandLine.Building
{
    /// <summary>
    /// Provides functionality for lazy interpreter initialization.
    /// </summary>
    public static class InterpreterBuilderFactory
    {
        /// <summary>
        /// Creates Interpreter builder.
        /// </summary>
        public static IInterpreterBuilder Create()
        {
            return new InterpreterBuilder();
        }
    }
}
