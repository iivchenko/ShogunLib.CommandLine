// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.ArgumentValidation;
using CommandLineInterpreterFramework.ParameterLimitation;

namespace CommandLineInterpreterFramework
{
    /// <summary>
    /// Lazy realization of the the console command parameter
    /// </summary>
    public class Parameter : IParameter
    {
        private readonly IArgumentValidator _argumentValidator;

        /// <summary>
        /// Initializes a new instance of the Parameter class
        /// </summary>
        /// <param name="name">Parameter name</param>
        /// <param name="description">Parameter description</param>
        /// <param name="argumentValidator">Argument validator</param>
        protected Parameter(string name, string description, IArgumentValidator argumentValidator)
        {
            // TODO: Write some unit test for this
            var exceptions = new List<Exception>();

            if (string.IsNullOrWhiteSpace(name))
            {
                exceptions.Add(new ArgumentException("Should not be null, empty or whitespaces", "name"));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                exceptions.Add(new ArgumentException("Should not be null, empty or whitespaces", "description"));
            }

            if (argumentValidator == null)
            {
                exceptions.Add(new ArgumentNullException("argumentValidator"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("Parameter initialization fail", exceptions);
            }

            Name = name;
            Description = description;

            _argumentValidator = argumentValidator;
        }

        /// <summary>
        /// Gets parameter name. Shouldn't have white spaces.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets parameter description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Performs validation on the input arguments
        /// </summary>
        /// <param name="args">Input arguments</param>
        /// <exception cref="ParameterLimitException"/>
        /// <exception cref="ArgumentValidationException"/>
        /// <returns>Validated argument</returns>
        public virtual IArgument Validate(IEnumerable<string> args)
        {
            // TODO: Don't forget to implement... and unit tests to

            // - Get all items of current parameter type
            // - Validate limit
            //      - if wrong limit - throw ParameterLimitException
            // - Validate argument(s)
            //      - if validation fails - throw ArgumentValidationException
            // - Create and return Argument
            throw new NotImplementedException(_argumentValidator.ToString());
        }
    }
}
