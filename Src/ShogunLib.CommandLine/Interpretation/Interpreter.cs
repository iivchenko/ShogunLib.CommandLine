// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Interpretation.Parsing;
using ShogunLib.Events;

namespace ShogunLib.CommandLine.Interpretation
{
    /// <summary>
    /// Standard mechanism of the command line interpreter cycle.
    /// </summary>
    public class Interpreter : IInterpreter
    {
        private readonly IInputParser _inputParser;
        private readonly IDictionary<string, ICommand> _commands;
        private readonly string _help;

        /// <summary>
        /// Initializes a new instance of the Interpreter class.
        /// </summary>
        /// <param name="inputParser">Parser for the command input. Can't be null.</param>
        /// <param name="commands">Available console commands. Can't be null. Command names (Dictionary keys) should be in uppercase.</param>
        /// <param name="helpCommandName">Name for the help command that will be used in console.</param>
        public Interpreter(IInputParser inputParser, IDictionary<string, ICommand> commands, string helpCommandName)
        {
            inputParser.ValidateNull(nameof(inputParser));
            commands.ValidateNull(nameof(commands));
            helpCommandName.ValidateStringEmpty(nameof(helpCommandName));

            if (commands.ContainsKey(helpCommandName.ToUpperInvariant()))
            {
                throw new DuplicatedCommandException(string.Format(CultureInfo.InvariantCulture, "Commands parameter contains help command {0}", helpCommandName));
            }
            
            _inputParser = inputParser;
            _commands = commands;
            _help = helpCommandName;
        }

        /// <summary>
        /// Raised when Help command is executed.
        /// </summary>
        public event EventHandler<HelpCommandEventArgs> Help;

        /// <summary>
        /// Executes console command.
        /// </summary>
        /// <param name="input">Command to be executed.</param>
        public void Execute(string input)
        {
            var parsedCommand = _inputParser.Parse(input);

            if (parsedCommand == null)
            {
                return;
            }

            if (_help.ToUpperInvariant() == parsedCommand.Name.ToUpperInvariant())
            {
                ExecuteHelp(parsedCommand.Args);
                return;
            }

            if (_commands.ContainsKey(parsedCommand.Name.ToUpperInvariant()))
            {
                _commands[parsedCommand.Name.ToUpperInvariant()].Execute(parsedCommand.Args);
                return;
            }
            
            throw new UndefinedCommandException(string.Format(CultureInfo.InvariantCulture, "Undefined command '{0}'", parsedCommand.Name));
        }

        private void ExecuteHelp(IEnumerable<string> args)
        {
            List<CommandDescriptor> commands;
            if (!args.Any())
            {
                commands =
                    _commands.Values
                        .Select(command => new CommandDescriptor(command.Name, command.Description, command.Parameters))
                        .ToList();
            }
            else
            {
                commands =
                    _commands.Values
                        .Where(command => args.Select(arg => arg.ToUpperInvariant()).Contains(command.Name.ToUpperInvariant()))
                        .Select(command => new CommandDescriptor(command.Name, command.Description, command.Parameters))
                        .ToList();
            }

            Help.Raise<HelpCommandEventArgs>(this, new HelpCommandEventArgs(commands));
        }
    }
}
