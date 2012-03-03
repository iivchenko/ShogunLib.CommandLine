// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

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
        /// <param name="value">Argument value</param>
        public Argument(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets argument name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets argument value
        /// </summary>
        public string Value { get; private set; }
    }
}
