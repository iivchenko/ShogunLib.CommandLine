// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections.Generic;
using CommandLineInterpreterFramework.Parsing;

namespace CommandLineInterpreterFramework
{
    // TODO: Implement

    /// <summary>
    /// Standard mechanism of the command line interpreter cycle
    /// </summary>
    public class Interpreter : IInterpreter
    {
        private readonly IInputParser<IParsedCommand> _inputParser;
        private readonly ICollection<ICommand> _commands;
        private readonly ICommand _helpCommand;
        private readonly ICommand _exitCommand;

        /// <summary>
        /// Initializes a new instance of the Interpreter class
        /// </summary>
        /// <param name="inputParser">Parser for the command input</param>
        /// <param name="commands">Available console commands</param>
        /// <param name="helpCommand">General and command help</param>
        /// <param name="exitCommand">Terminate interpreter cycle</param>
        public Interpreter(IInputParser<IParsedCommand> inputParser, ICollection<ICommand> commands, ICommand helpCommand, ICommand exitCommand)
        {
            _inputParser = inputParser;
            _commands = commands;
            _helpCommand = helpCommand;
            _exitCommand = exitCommand;
        }

        /// <summary>
        /// Starts command line interpreter cycle
        /// </summary>
        public void Run()
        {
            _commands.ToString();
            _exitCommand.ToString();
            _helpCommand.ToString();
            _inputParser.ToString();
            throw new NotImplementedException();
        }
    }
}
