// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommandLineInterpreterFramework
{
    /// <summary>
    /// Lazy realization of the console command argument
    /// </summary>
    public class Argument : IArgument
    {
        /// <summary>
        /// Initializes a new instance of the Argument class
        /// </summary>
        /// <param name="name">Argument name</param>
        /// <param name="values">Argument values</param>
        public Argument(string name, IList<string> values)
        {
            Name = name;
            Values = new ReadOnlyCollection<string>(values);
        }

        /// <summary>
        /// Gets argument name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets argument values
        /// </summary>
        public ReadOnlyCollection<string> Values { get; private set; }
    }
}
