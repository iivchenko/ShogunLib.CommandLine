// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace CommandLineInterpreterFramework.Common.Strings
{
    // TODO: Feature of the next version

    /// <summary>
    /// Provides support for creating string objects.
    /// </summary>
    public interface IStringFactory
    {
        /// <summary>
        /// Creates new IString object.
        /// </summary>
        /// <param name="value">String value that will be wrapped by IString object.</param>
        /// <returns>New IString object.</returns>
        IString Create(string value);
    }
}
