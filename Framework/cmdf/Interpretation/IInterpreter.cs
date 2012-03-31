// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace CommandLineInterpreterFramework.Interpretation
{
    /// <summary>
    /// Represents a mechanism to start command line interpreter cycle
    /// </summary>
    public interface IInterpreter
    {
        /// <summary>
        ///  Starts command line interpreter cycle
        /// </summary>
        void Run();
    }
}
