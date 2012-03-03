// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

namespace CommandLineInterpreterFramework
{
    /// <summary>
    /// Represents functionality that allows to convert console arguments into specific function arguments
    /// </summary>
    public interface IActionArgument
    {
        /// <summary>
        /// Add and convert console argument
        /// </summary>
        /// <param name="argument">Validated console command argument</param>
        void Add(IArgument argument);
    }
}
