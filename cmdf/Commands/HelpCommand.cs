// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Parameters;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Lazy realization of the help command.
    /// Write to the console information about the available commands.
    /// Write to the console information on the specified command. 
    /// </summary>
    public class HelpCommand : ICommand
    {
        private readonly IConsole _console;
        private readonly ICollection<ICommand> _commands;

        /// <summary>
        /// Initializes a new instance of the HelpCommand class
        /// </summary>
        /// <param name="console">Specified console input and output</param>
        /// <param name="commands">Available commands for which help should be performed</param>
        public HelpCommand(IConsole console, ICollection<ICommand> commands)
        {
            var exceptions = new List<Exception>();

            if (console == null)
            {
                exceptions.Add(new ArgumentNullException("console"));
            }

            if (commands == null)
            {
                exceptions.Add(new ArgumentNullException("commands"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("Command initialization fail", exceptions);
            }

            _console = console;
            _commands = commands;
        }

        /// <summary>
        /// Gets the name of the Help command
        /// </summary>
        public string Name
        {
            get { return "Help"; }
        }

        /// <summary>
        /// Gets Help command description
        /// </summary>
        public string Description
        {
            get { return "Provides help on available commands"; }
        }

        /// <summary>
        /// Gets description of the Help command parameters
        /// </summary>
        public ICollection<IParameterInfo> Parameters
        {
            get
            {
                var descriptions = new Collection<IParameterInfo>
                                       {
                                           new ParameterInfo("No params", "list of available commands"),
                                           new ParameterInfo("Command name", "help for this command will be shown")
                                       };

                return descriptions;
            }
        }

        /// <summary> 
        /// Write to the console information about the available commands.
        /// Write to the console information on the specified command.
        /// </summary>
        /// <param name="args">Command input arguments</param> 
        public void Execute(IEnumerable<string> args)
        {
            // General help
            if (args == null || args.Count() == 0)
            {
                foreach (var command in _commands)
                {
                    _console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}\t\t- {1}", command.Name, command.Description));
                }

                return;
            }

            // Specified command help
            foreach (var command in _commands)
            {
                if (command.Name == args.First())
                {
                    _console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}\t\t- {1}", command.Name, command.Description));

                    foreach (var parameter in command.Parameters)
                    {
                        _console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}\t\t- {1}", parameter.Name, parameter.Description));
                    }

                    return;
                }
            }

            // Undifined command namd is used
            _console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Undefined command {0}", args.First()));
        }
    }
}
