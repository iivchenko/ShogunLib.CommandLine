// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Runtime.Serialization;

namespace ShogunLib.CommandLine
{
    /// <summary>
    /// This is base exception for all framework exceptions.
    /// </summary>
    [Serializable]
    public class CommandLineInterpreterFrameworkException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the CommandLineInterpreterFrameworkException class.
        /// </summary>
        public CommandLineInterpreterFrameworkException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommandLineInterpreterFrameworkException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public CommandLineInterpreterFrameworkException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommandLineInterpreterFrameworkException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public CommandLineInterpreterFrameworkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommandLineInterpreterFrameworkException class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected CommandLineInterpreterFrameworkException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
