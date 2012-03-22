// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Lazy realization that enables to convert console arguments into specific function arguments
    /// </summary>
    [Serializable]
    public class ActionArgumentDictionary : Dictionary<string, ICollection<string>>, IActionArgument
    {
        /// <summary>
        /// Initializes a new instance of the ActionArgumentDictionary class
        /// </summary>
        public ActionArgumentDictionary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ActionArgumentDictionary class with serialized data
        /// </summary>
        /// <param name="info">A System.Runtime.Serialization.SerializationInfo object containing the information required to serialize the dictionary</param>
        /// <param name="context">A System.Runtime.Serialization.StreamingContext structure containing the source and destination of the serialized stream associated with the Dictionary</param>
        protected ActionArgumentDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Add and convert console argument
        /// </summary>
        /// <param name="argument">Validated console command argument</param>
        public void Add(IArgument argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException("argument");
            }

            if (string.IsNullOrWhiteSpace(argument.Name))
            {
                throw new ArgumentException("Argument name should not be a null, empty or whitespaces value", "argument");
            }

            Add(argument.Name, argument.Values);
        }
    }
}
