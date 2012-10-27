// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace CommandLineInterpreterFramework.Building
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
