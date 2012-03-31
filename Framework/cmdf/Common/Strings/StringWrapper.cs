// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace CommandLineInterpreterFramework.Common.Strings
{
    // TODO: Feature of the next version

    /// <summary>
    /// Simple wrapper for the System.String type. Do nothing with input string just wrapes it
    /// </summary>
    public class StringWrapper : IString
    {
        private readonly string _string;

        /// <summary>
        /// Initializes a new instance of the StringWrapper class
        /// </summary>
        /// <param name="value">Wrapped string</param>
        public StringWrapper(string value)
        {
            _string = value;
        }

        /// <summary>
        /// Return string representation of the StringWrapper object. The same as ToString method
        /// </summary>
        public string AsString()
        {
            return _string;
        }

        /// <summary>
        /// Return string representation of the StringWrapper object
        /// </summary>
        public override string ToString()
        {
            return _string;
        }
    }
}
