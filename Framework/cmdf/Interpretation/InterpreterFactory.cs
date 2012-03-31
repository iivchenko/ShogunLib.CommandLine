// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation.Parsing;

namespace CommandLineInterpreterFramework.Interpretation
{
    /// <summary>
    /// Provides functionality for lazy interpreter initialization
    /// </summary>
    public static class InterpreterFactory
    {
        /// <summary>
        /// Creates interpreter with standard console, framework input parser, framework help command, framework exit command and with empty console prefix
        /// </summary>
        /// <param name="commands">User defined commands</param>
        /// <param name="prefix">User defined console prefix </param>
        public static IInterpreter CreateInterpreter(CommandsDictionary commands, string prefix)
        {
            var console = new StandardConsole();
            var parser = new InputParser();
            var help = new HelpCommand(commands.Values);
            var exit = new ExitCommand();

            return new Interpreter(console, null, parser, commands, help, exit, prefix);
        }

        /// <summary>
        /// Creates interpreter with standard console, framework input parser, framework help command, framework exit command and with empty console prefix
        /// </summary>
        /// <param name="commands">User defined commands</param>
        /// <param name="exceptionHandling">User defined exception handling policy</param>
        /// <param name="prefix">User defined console prefix </param>
        public static IInterpreter CreateInterpreter(CommandsDictionary commands, Action<IConsole, Exception> exceptionHandling, string prefix)
        {
            var console = new StandardConsole();
            var parser = new InputParser();
            var help = new HelpCommand(commands.Values);
            var exit = new ExitCommand();

            return new Interpreter(console, exceptionHandling, parser, commands, help, exit, prefix);
        }
        
        /// <summary>
        /// Creates interpreter with framework input parser, framework help command, framework exit command and with empty console prefix
        /// </summary>
        /// <param name="commands">Used defined commands</param>
        /// <param name="console">User difined console </param>
        /// <param name="prefix">User defined console prefix </param>
        public static IInterpreter CreateInterpreter(CommandsDictionary commands, IConsole console, string prefix)
        {
            var parser = new InputParser();
            var help = new HelpCommand(commands.Values);
            var exit = new ExitCommand();

            return new Interpreter(console, null, parser, commands, help, exit, prefix);
        }

        /// <summary>
        /// Creates interpreter with framework input parser, framework help command, framework exit command and with empty console prefix
        /// </summary>
        /// <param name="commands">Used defined commands</param>
        /// <param name="console">User difined console </param>
        /// <param name="parser">User difined console input parser </param>
        /// <param name="help">User defined console help command </param>
        /// <param name="exit">Uesr defined console exit command </param>
        /// <param name="prefix">User defined console prefix </param>
        public static IInterpreter CreateInterpreter(CommandsDictionary commands, IConsole console, IInputParser parser, ICommand help, ICommand exit, string prefix)
        {
            return new Interpreter(console, null, parser, commands, help, exit, prefix);
        }
    }
}
