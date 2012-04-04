// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Console;
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

        private string _prefix;
        private IConsole _console;
        private Action<IConsole, Exception> _exceptionHandling;

        /// <summary>
        /// Initializes a new instance of the InterpreterBuilder class
        /// </summary>
        public InterpreterBuilder()
        {
            _commands = new Dictionary<string, ICommandBuilder>();
            _prefix = string.Empty;
            _console = new StandardConsole();
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
        public void Add(string name)
        {
            _commands.Add(name, new CommandBuilder(name));
        }

        /// <summary>
        /// Sets console prefix
        /// </summary>
        public void SetPrefix(string name)
        {
            _prefix = name;
        }

        /// <summary>
        /// Sets specific console or StandardConsole will be used
        /// </summary>
        public void SetConsole(IConsole console)
        {
            _console = console;
        }

        /// <summary>
        /// Sets policy for general exception hanling
        /// </summary>
        public void SetExceptionHandling(Action<IConsole, Exception> exceptionHandling)
        {
            _exceptionHandling = exceptionHandling;
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

            return new Interpreter(_console, 
                                   _exceptionHandling, 
                                   new InputParser(), 
                                   commandsDictionary,
                                   new HelpCommand(commandsDictionary.Values), 
                                   new ExitCommand(), 
                                   _prefix);
        }
    }
}
