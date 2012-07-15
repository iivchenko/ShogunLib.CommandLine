// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Interpretation;
using CommandLineInterpreterFramework.Interpretation.Parsing;

namespace CommandLineInterpreterFramework.Building
{
    /// <summary>
    /// Lazy interpreter initialization
    /// </summary>
    public class InterpreterBuilder : IInterpreterBuilder
    {
        private readonly IDictionary<string, ICommandBuilder> _commands;
        private string _help;
        private EventHandler<HelpCommandEventArgs> _helpAction;

        /// <summary>
        /// Initializes a new instance of the InterpreterBuilder class
        /// </summary>
        public InterpreterBuilder()
        {
            _commands = new Dictionary<string, ICommandBuilder>();
            _help = "Help";
        }
        
        /// <summary>
        /// Gets lazy command by its name
        /// </summary>
        public ICommandBuilder this[string name]
        {
            get { return _commands[name]; }
        }

        /// <summary>
        /// Add new command with specified name
        /// </summary>
        /// <returns>Itself</returns>
        public IInterpreterBuilder Add(string name)
        {
            _commands.Add(name, new CommandBuilder(name));

            return this;
        }

        /// <summary>
        /// Set help command name and action.
        /// </summary>
        /// <returns>Itself</returns>
        public IInterpreterBuilder SetHelp(string name, EventHandler<HelpCommandEventArgs> helpAction)
        {
            _help = name;
            _helpAction = helpAction;

            return this;
        }

        /// <summary>
        /// Create interpreter with specified data
        /// </summary>
        public IInterpreter Create()
        {
            var commandsDictionary = new CommandsDictionary();

            foreach (var commandBuilder in _commands)
            {
                var command = commandBuilder.Value.Create();

                commandsDictionary.Add(command);
            }

            var interpreter = new Interpreter(new InputParser(),
                                              commandsDictionary,
                                              _help);

            interpreter.Help += _helpAction;

            return interpreter;
        }
    }
}
