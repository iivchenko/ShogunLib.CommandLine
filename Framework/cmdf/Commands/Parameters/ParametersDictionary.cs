// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CommandLineInterpreterFramework.Commands.Parameters
{
    /// <summary>
    /// Parameters container for the specific command
    /// </summary>
    [Serializable]
    public class ParametersDictionary : Dictionary<string, IParameter>
    {
        /// <summary>
        /// Initializes a new instance of the ParametersDictionary class
        /// </summary>
        public ParametersDictionary()
        {
        }

        /// <summary>
        /// Initializes a new instance of the ParametersDictionary class with serialized data
        /// </summary>
        /// <param name="info">A System.Runtime.Serialization.SerializationInfo object containing the information required to serialize the dictionary</param>
        /// <param name="context">A System.Runtime.Serialization.StreamingContext structure containing the source and destination of the serialized stream associated with the Dictionary</param>
        protected ParametersDictionary(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Add and convert console parameter
        /// </summary>
        /// <param name="parameter">Validated console command parameter</param>
        public void Add(IParameter parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException("parameter");
            }

            if (string.IsNullOrWhiteSpace(parameter.Info.Name))
            {
                throw new ArgumentException("Parameter name should not be a null, empty or whitespaces value", "parameter");
            }

            Add(parameter.Info.Name, parameter);
        }
    }
}