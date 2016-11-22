// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Linq;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Commands.Parameters;
using ShogunLib.LINQ;

namespace ShogunLib.CommandLine.Building
{
    /// <summary>
    /// Lazy command initialization.
    /// </summary>
    public class CommandBuilder : ICommandBuilder
    {
        private readonly string _name;
        private readonly IDictionary<string, IParameterBuilder> _parameters;

        private string _description;
        private Action<IDictionary<string, IEnumerable<string>>> _action;
        
        /// <summary>
        /// Initializes a new instance of the CommandBuilder class.
        /// </summary>
        /// <param name="name">Future command name.</param>
        public CommandBuilder(string name)
        {
            name.ValidateStringEmpty(nameof(name));

            _name = name;
            _description = string.Empty;
            _parameters = new Dictionary<string, IParameterBuilder>();
        }

        /// <summary>
        /// Gets lazy parameter by its name.
        /// </summary>
        public IParameterBuilder this[string name]
        {
            get { return _parameters[name]; }
        }

        /// <summary>
        /// Sets command description.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        public ICommandBuilder SetDescription(string description)
        {
            _description = description;

            return this;
        }

        /// <summary>
        /// Sets specific action for the command.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        public ICommandBuilder SetAction(Action<IDictionary<string, IEnumerable<string>>> action)
        {
            _action = action;

            return this;
        }

        /// <summary>
        /// Add new parameter with specified name.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        public ICommandBuilder Add(string name)
        {
            name.ValidateStringEmpty(nameof(name));

            _parameters.Add(name, new ParameterBuilder(name));

            return this;
        }

        /// <summary>
        /// Create command with specified data.
        /// </summary>
        public ICommand Create()
        {
            var parameterDictionary = new ParametersDictionary();

            _parameters
                .Select(x => x.Value.Create())
                .ForEach(x => parameterDictionary.Add(x));

            return new Command(_name, _description, parameterDictionary, _action);
        }
    }
}
