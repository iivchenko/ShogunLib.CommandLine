// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Runtime.Serialization;

namespace ShogunLib.CommandLine.Interpretation.Parsing
{
    /// <summary>
    /// The exception that is thrown when console input can't be parsed.
    /// </summary>
    [Serializable]
    public class InputParserException : CommandLineInterpreterFrameworkException
    {
        /// <summary>
        /// Initializes a new instance of the InputParserException class.
        /// </summary>
        public InputParserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the InputParserException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InputParserException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InputParserException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public InputParserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the InputParserException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected InputParserException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
