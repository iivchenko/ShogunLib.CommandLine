// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace CommandLineInterpreterFramework.Common.Strings
{
    // TODO: Feature of the next version

    /// <summary>
    /// Represents wrapped System.String object
    /// </summary>
    public interface IString
    {
        /// <summary>
        /// Return string representation of the IString object. The same as ToString method
        /// </summary>
        string AsString();
    }
}
