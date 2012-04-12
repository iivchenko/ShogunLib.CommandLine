// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation.Parsing;

namespace CommandLineInterpreterFramework.Interpretation
{
    /// <summary>
    /// Standard mechanism of the command line interpreter cycle
    /// </summary>
    public class Interpreter : IInterpreter
    {
        private readonly IConsole _console;
        private readonly Action<IConsole, Exception> _exceptionHandling;
        private readonly IInputParser _inputParser;
        private readonly IDictionary<string, ICommand> _commands;
        private readonly ICommand _helpCommand;
        private readonly ICommand _exitCommand;
        private readonly string _prefix;

        /// <summary>
        /// Initializes a new instance of the Interpreter class
        /// </summary>
        /// <param name="console">IO device (console user interface). Can't be null</param>
        /// <param name="exceptionHandling">General exception handling policy for interpreter and its commands</param>
        /// <param name="inputParser">Parser for the command input. Can't be null</param>
        /// <param name="commands">Available console commands. Can't be null. Command names (Dictionary keys) should be in uppercase</param>
        /// <param name="helpCommand">General and command help. Can't be null</param>
        /// <param name="exitCommand">Interpreter cycle will be terminated after this command finished execution. Can't be null</param>
        /// <param name="prefix">Prefix that will be shown at the begining of the console string. Can't be null </param>
        public Interpreter(
            IConsole console,
            Action<IConsole, Exception> exceptionHandling,
            IInputParser inputParser,
            IDictionary<string, ICommand> commands,
            ICommand helpCommand, 
            ICommand exitCommand,
            string prefix)
        {
            var exceptions = new List<Exception>();

            if (console == null)
            {
                exceptions.Add(new ArgumentNullException("console"));
            }

            if (inputParser == null)
            {
                exceptions.Add(new ArgumentNullException("inputParser"));
            }

            if (commands == null)
            {
                exceptions.Add(new ArgumentNullException("commands"));
            }

            if (helpCommand == null)
            {
                exceptions.Add(new ArgumentNullException("helpCommand"));
            }

            if (exitCommand == null)
            {
                exceptions.Add(new ArgumentNullException("exitCommand"));
            }

            if (prefix == null)
            {
                exceptions.Add(new ArgumentNullException("prefix"));
            }

            if (exceptions.Count > 0)
            {
                throw new AggregateException("Parameter initialization fail", exceptions);
            }

            if (commands.ContainsKey(exitCommand.Name.ToUpperInvariant()))
            {
                throw new DuplicatedCommandException(string.Format(CultureInfo.InvariantCulture, "Commands parameter contains exit command {0}", exitCommand.Name));
            }

            if (commands.ContainsKey(helpCommand.Name.ToUpperInvariant()))
            {
                throw new DuplicatedCommandException(string.Format(CultureInfo.InvariantCulture, "Commands parameter contains help command {0}", helpCommand.Name));
            }

            if (exitCommand.Name == helpCommand.Name)
            {
                throw new DuplicatedCommandException(string.Format(CultureInfo.InvariantCulture, "Exit command name equals to help command name"));
            }

            _console = console;
            _exceptionHandling = exceptionHandling;
            _inputParser = inputParser;
            _commands = commands;
            _helpCommand = helpCommand;
            _exitCommand = exitCommand;
            _prefix = prefix;
        }

        /// <summary>
        /// Starts command line interpreter cycle
        /// </summary>
        public void Run()
        {
            while (true)
            {
                try
                {
                    _console.Write(_prefix);

                    var input = _console.ReadLine();
                    var parsedCommand = _inputParser.Parse(input);

                    if (parsedCommand == null)
                    {
                        continue;
                    }

                    if (_exitCommand.Name.ToUpperInvariant() == parsedCommand.Name.ToUpperInvariant())
                    {
                        _exitCommand.Execute(_console, parsedCommand.Args);
                        break;
                    }

                    if (_helpCommand.Name.ToUpperInvariant() == parsedCommand.Name.ToUpperInvariant())
                    {
                        _helpCommand.Execute(_console, parsedCommand.Args);
                        continue;
                    }

                    if (_commands.ContainsKey(parsedCommand.Name.ToUpperInvariant()))
                    {
                        _commands[parsedCommand.Name.ToUpperInvariant()].Execute(_console, parsedCommand.Args);
                        continue;
                    }

                    _console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Undefined command {0}", parsedCommand.Name));
                }
                catch (InputParserException e)
                {
                    _console.WriteLine(e.Message);
                }
                catch (ArgumentValidationException e)
                {
                    _console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    if (_exceptionHandling == null)
                    {
                        throw;
                    }

                    _exceptionHandling(_console, e);
                }
            }
        }
    }
}
