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
    /// Lazy realization for the console command
    /// </summary>
    public class Command<TActionArgument> : ICommand where TActionArgument : class, IActionArgument, new()
    {
        private readonly Action<TActionArgument> _action;

        /// <summary>
        /// Initializes a new instance of the Command class
        /// </summary>
        /// <param name="name">Command name</param>
        /// <param name="description">Command description</param>
        /// <param name="parameters">Command parameters</param>
        /// <param name="action">Specific action  performed by command</param>
        protected Command(string name, string description, ICollection<IParameter> parameters, Action<TActionArgument> action)
        {
            Name = name;
            Description = description;
            Parameters = parameters;

            _action = action;
        }

        /// <summary>
        /// Gets the name of the command. Name shouldn't have white spaces.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets command description
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets description of the command parameters
        /// </summary>
        public ICollection<IParameter> Parameters { get; private set; }

        /// <summary>
        /// Performs validation and specific action. Firstly call Validate method
        /// </summary>
        /// <param name="args">Command input arguments</param>
        public virtual void Execute(IEnumerable<string> args)
        {
            _action(Validate(args));
        }

        /// <summary>
        /// Performs validation for the input argements. Called by Execute method
        /// </summary>
        /// <param name="args">Input arguments</param>
        /// <returns>Validated set of arguments</returns>
        protected virtual TActionArgument Validate(IEnumerable<string> args)
        {
            var actionArgument = new TActionArgument();
            foreach (var parameter in Parameters)
            {
                actionArgument.Add(parameter.Validate(args));
            }

            return actionArgument;
        }
    }
}
