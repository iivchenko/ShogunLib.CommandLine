// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Commands container for the specific interpreter
    /// </summary>
    [Serializable]
    public class CommandsDictionary : Dictionary<string, ICommand>
    {
         /// <summary>
        /// Initializes a new instance of the CommandsDictionary class
        /// </summary>
        public CommandsDictionary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CommandsDictionary class with serialized data
        /// </summary>
        /// <param name="info">A System.Runtime.Serialization.SerializationInfo object containing the information required to serialize the dictionary</param>
        /// <param name="context">A System.Runtime.Serialization.StreamingContext structure containing the source and destination of the serialized stream associated with the Dictionary</param>
        protected CommandsDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Add and convert console command
        /// </summary>
        /// <param name="command">Validated console command command</param>
        public void Add(ICommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            if (string.IsNullOrWhiteSpace(command.Name))
            {
                throw new ArgumentException("Command name should not be a null, empty or whitespaces value", "command");
            }

            Add(command.Name, command);
        }
    }
}
