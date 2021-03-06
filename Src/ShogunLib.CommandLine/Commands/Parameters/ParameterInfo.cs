// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;

namespace ShogunLib.CommandLine.Commands.Parameters
{
    /// <summary>
    /// Contains parameters data: Name and Description.
    /// </summary>
    public class ParameterInfo : IParameterInfo
    {
        /// <summary>
        /// Initializes a new instance of the ParameterInfo class.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="description">Parameter description.</param>
        public ParameterInfo(string name, string description)
        {
            name.ValidateStringEmpty(nameof(name));
            description.ValidateStringEmpty(nameof(description));

            Name = name;
            Description = description;
        }

        /// <summary>
        /// Gets parameters name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets parameters description.
        /// </summary>
        public string Description { get; private set; }
    }
}
