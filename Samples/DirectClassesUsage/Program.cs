// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.LimitValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation;
using CommandLineInterpreterFramework.Interpretation.Parsing;

namespace DirectClassesUsage
{
    public static class Program
    {
        private const string HelloCommand = "Hello";
        private const string ByeCommand = "Bye";
        private const string ClearCommand = "Clear";

        private const string NumberParameter = "-number:";
        private const string NameParameter = "-name:";

        public static void Main()
        {
            CreateInterpreter().Run();
        }

        private static IInterpreter CreateInterpreter()
        {
            var commands = CreateCommands();

            return new Interpreter(new StandardConsole(),
                                   (console, e) => console.WriteLine(e.ToString()),
                                   new InputParser(), 
                                   commands,
                                   new HelpCommand(commands.Values), 
                                   new ExitCommand(),
                                   ":-) ");
        }

        private static CommandsDictionary CreateCommands()
        {
            return new CommandsDictionary
                       {
                           CreateHelloCommand(),
                           CreateByeCommand(),
                           CreateClearCommand()
                       };
        }

        private static ICommand CreateHelloCommand()
        {
            return new Command(HelloCommand, 
                               "Writes 'hello' to the console specified number of times", 
                               CreateHelloCommandParameters(), 
                               HelloCommandAction);
        }

        private static ICommand CreateByeCommand()
        {
            return new Command(ByeCommand, 
                               "Just says goodbye", 
                               CreateByeCommandParameters(), 
                               ByeCommandAction);
        }

        private static ICommand CreateClearCommand()
        {
            return new Command(ClearCommand,
                               "Clears console output",
                               CreateClearCommandParameters(),
                               ClearCommandAction);
        }

        private static ParametersDictionary CreateHelloCommandParameters()
        {
            return new ParametersDictionary
                       {
                           CrateNumberParameter()
                       };
        }

        private static ParametersDictionary CreateByeCommandParameters()
        {
            return new ParametersDictionary
                       {
                           CreateNameParameter()
                       };
        }

        private static ParametersDictionary CreateClearCommandParameters()
        {
            return new ParametersDictionary
                       {
                       };
        }

        private static IParameter CrateNumberParameter()
        {
            var info = new ParameterInfo(NumberParameter, "Number of times");

            var validators = new CompositeArgumentValidator();
            validators.Add(new OptionalParameterValidator());
            validators.Add(new IntTypeValidator());

            return new Parameter(info, validators);
        }

        private static IParameter CreateNameParameter()
        {
            var info = new ParameterInfo(NameParameter, "Name for whom bye-bye is said");

            return new Parameter(info, new OptionalParameterValidator());
        }

        private static void HelloCommandAction(IConsole console, IDictionary<string, IEnumerable<string>> arguments)
        {
            var times = arguments[NumberParameter].Any() ? int.Parse(arguments[NumberParameter].First(), CultureInfo.InvariantCulture)
                                                                            : 0;

            for (var i = 0; i < times; i++)
            {
                console.WriteLine("Hello");
            }
        }
        
        private static void ByeCommandAction(IConsole console, IDictionary<string, IEnumerable<string>> arguments)
        {
            console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Bye-bye: {0}", arguments[NameParameter].Any() ? arguments[NameParameter].First() : string.Empty));
        }

        private static void ClearCommandAction(IConsole console, IDictionary<string, IEnumerable<string>> arguments)
        {
            console.Clear();
        }
    }
}
