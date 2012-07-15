// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;

namespace CommandLineInterpreterFramework.Building
{
    /// <summary>
    /// Lazy command initialization
    /// </summary>
    public class CommandBuilder : ICommandBuilder
    {
        private readonly string _name;
        private readonly IDictionary<string, IParameterBuilder> _parameters;

        private string _description;
        private Action<IDictionary<string, IEnumerable<string>>> _action;
        
        /// <summary>
        /// Initializes a new instance of the CommandBuilder class
        /// </summary>
        /// <param name="name">Future command name</param>
        public CommandBuilder(string name)
        {
            _name = name;
            _description = string.Empty;
            _parameters = new Dictionary<string, IParameterBuilder>();
        }

        /// <summary>
        /// Gets lazy parameter by its name
        /// </summary>
        public IParameterBuilder this[string name]
        {
            get { return _parameters[name]; }
        }

        /// <summary>
        /// Sets command description
        /// </summary>
        /// <returns>Itself</returns>
        public ICommandBuilder SetDescription(string description)
        {
            _description = description;

            return this;
        }

        /// <summary>
        /// Sets specific action for the command
        /// </summary>
        /// <returns>Itself</returns>
        public ICommandBuilder SetAction(Action<IDictionary<string, IEnumerable<string>>> action)
        {
            _action = action;

            return this;
        }

        /// <summary>
        /// Add new parameter with specified name
        /// </summary>
        /// <returns>Itself</returns>
        public ICommandBuilder Add(string name)
        {
            _parameters.Add(name, new ParameterBuilder(name));

            return this;
        }

        /// <summary>
        /// Create command with specified data
        /// </summary>
        public ICommand Create()
        {
            var parameterDictionary = new ParametersDictionary();

            foreach (var parameterBuilder in _parameters)
            {
                var parameter = parameterBuilder.Value.Create();

                parameterDictionary.Add(parameter);
            }
            
            return new Command(_name, _description, parameterDictionary, _action);
        }
    }
}
