// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;

namespace CommandLineInterpreterFramework.Parameters
{
    /// <summary>
    /// Contains parameters data: Name and Description
    /// </summary>
    public class ParameterInfo : IParameterInfo
    {
        /// <summary>
        /// Initializes a new instance of the ParameterInfo class
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="description">Parameter description</param>
        public ParameterInfo(string name, string description)
        {
            var exceptions = new List<Exception>();

            if (string.IsNullOrWhiteSpace(name))
            {
                exceptions.Add(new ArgumentException("Should not be null, empty or whitespaces", "name"));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                exceptions.Add(new ArgumentException("Should not be null, empty or whitespaces", "description"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("Parameter initialization fail", exceptions);
            }

            Name = name;
            Description = description;
        }

        /// <summary>
        /// Gets parameters name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets parameters description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Creates copy for ParameterInfo
        /// </summary>
        /// <returns>ParameterInfo copy</returns>
        public object Clone()
        {
            return new ParameterInfo(Name, Description);
        }
    }
}
