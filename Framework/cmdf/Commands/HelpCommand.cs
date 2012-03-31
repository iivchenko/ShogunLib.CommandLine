// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Console;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Lazy realization of the help command.
    /// Write to the console information about the available commands.
    /// Write to the console information on the specified command. 
    /// </summary>
    public class HelpCommand : ICommand
    {
        private readonly ICollection<ICommand> _commands;

        /// <summary>
        /// Initializes a new instance of the HelpCommand class
        /// </summary>
        /// <param name="commands">Available commands for which help should be performed</param>
        public HelpCommand(ICollection<ICommand> commands)
        {
            var exceptions = new List<Exception>();

            if (commands == null)
            {
                exceptions.Add(new ArgumentNullException("commands"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("Command initialization fail", exceptions);
            }

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
        public IEnumerable<IParameterInfo> Parameters
        {
            get
            {
                var parameterInfos = new Collection<IParameterInfo>
                                       {
                                           new ParameterInfo("No params", "list of available commands"),
                                           new ParameterInfo("Command name", "help for this command will be shown")
                                       };

                return parameterInfos;
            }
        }

        /// <summary> 
        /// Write to the console information about the available commands.
        /// Write to the console information on the specified command.
        /// </summary>
        /// <param name="console">IO device(console user interface)</param>
        /// <param name="args">Command input arguments</param> 
        public void Execute(IConsole console, IEnumerable<string> args)
        {
            if (console == null)
            {
               throw new ArgumentNullException("console");
            }

            // General help
            if (args == null || !args.Any())
            {
                foreach (var command in _commands)
                {
                    console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}\t\t- {1}", command.Name, command.Description));
                }

                return;
            }

            // Specified command help
            foreach (var command in _commands)
            {
                if (command.Name.ToUpperInvariant() == args.First().ToUpperInvariant())
                {
                    console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}\t\t- {1}", command.Name, command.Description));

                    foreach (var parameter in command.Parameters)
                    {
                        console.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}\t\t- {1}", parameter.Name, parameter.Description));
                    }

                    return;
                }
            }

            // Undifined command namd is used
            console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Undefined command {0}", args.First()));
        }
    }
}
