// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace CommandLineInterpreterFramework.Common.Strings
{
    // TODO: Feature of the next version

    /// <summary>
    /// Simple string factory representation.
    /// </summary>
    public class StringFactory : IStringFactory
    {
        /// <summary>
        /// Creates new StringWrapper object.
        /// </summary>
        /// <param name="value">String value that will be wrapped by StringWrapper object.</param>
        /// <returns>New StringWrapper object.</returns>
        public IString Create(string value)
        {
            return new StringWrapper(value);
        }
    }
}
