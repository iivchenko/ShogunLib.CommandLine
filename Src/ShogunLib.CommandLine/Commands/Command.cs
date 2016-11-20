// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ShogunLib.CommandLine.Commands.Parameters;

namespace ShogunLib.CommandLine.Commands
{
    /// <summary>
    /// Lazy realization for the console command.
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action<IDictionary<string, IEnumerable<string>>> _action;
        private readonly IDictionary<string, IParameter> _parameters;

        /// <summary>
        /// Initializes a new instance of the Command class.
        /// </summary>
        /// <param name="name">Command name. Shouldn't have white spaces.</param>
        /// <param name="description">Command description. Shouldn't have white spaces.</param>
        /// <param name="parameters">Command parameters. Shouldn't be a null value. Parameters names (Dictionary keys) should be in uppercase.</param>
        /// <param name="action">Specific action  performed by command. Shouldn't be null.</param>
        public Command(string name,
                       string description,
                       IDictionary<string, IParameter> parameters,
                       Action<IDictionary<string, IEnumerable<string>>> action)
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
            
            if (parameters == null)
            {
                exceptions.Add(new ArgumentNullException("parameters"));
            }
            
            if (action == null)
            {
                exceptions.Add(new ArgumentNullException("action"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("Command initialization fail", exceptions);
            }

            Name = name;
            Description = description;

            _parameters = parameters;
            _action = action;
        }

        /// <summary>
        /// Gets the name of the command. Name shouldn't have white spaces.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets command description.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets description of the command parameters.
        /// </summary>
        public IEnumerable<IParameterInfo> Parameters
        {
            get
            {
                var parameterInfos = new Collection<IParameterInfo>();
                foreach (var parameter in _parameters)
                {
                    parameterInfos.Add(parameter.Value.Info);
                }

                return parameterInfos;
            } 
        }

        /// <summary>
        /// Performs validation and specific action. Firstly call Validate method.
        /// </summary>
        /// <param name="args">Command input arguments.</param>
        public virtual void Execute(IEnumerable<string> args)
        {
            _action(Validate(args));
        }

        /// <summary>
        /// Performs validation for the input arguments. Called by Execute method.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>Validated set of arguments.</returns>
        protected virtual IDictionary<string, IEnumerable<string>> Validate(IEnumerable<string> args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            return _parameters.Select(parameter => parameter.Value.Validate(args)).ToDictionary(argument => argument.Name, argument => argument.Values);
        }
    }
}
