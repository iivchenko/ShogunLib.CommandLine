// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;

namespace CommandLineInterpreterFramework
{
    // TODO: Implement

    /// <summary>
    /// Simple mechanism that allows to convert console arguments into specific function arguments
    /// </summary>
    public class LazyActionArgument : IActionArgument
    {
        private readonly Dictionary<string, string> _arguments;

        /// <summary>
        /// Initializes a new instance of the LazyActionArgument class
        /// </summary>
        public LazyActionArgument()
        {
            _arguments = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets converted argument
        /// </summary>
        /// <param name="argument">Name for the converted argment</param>
        public string this[string argument]
        {
            // TODO: Implement
            get { return argument + _arguments.ToString(); }
        }

        /// <summary>
        /// Add and convert console argument
        /// </summary>
        /// <param name="argument">Validated console command argument</param>
        public void Add(IArgument argument)
        {
            throw new NotImplementedException(_arguments.ToString());
        }
    }
}
