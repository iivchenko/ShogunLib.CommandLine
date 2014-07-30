// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CommandLineInterpreterFramework;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.LimitValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation;
using CommandLineInterpreterFramework.Interpretation;
using CommandLineInterpreterFramework.Interpretation.Parsing;

namespace DirectClassesUsage
{
    public static class Program
    {
        private const string HelloCommand = "Hello";
        private const string ByeCommand = "Bye";
        private const string ClearCommand = "Clear";
        private const string HelpCommand = "Help";
        private const string ExitCommand = "Exit";

        private const string NumberParameter = "-number:";
        private const string NameParameter = "-name:";

        private static bool isContinue = true;

        public static void Main()
        {
            var interpreter = CreateInterpreter();

            while (isContinue)
            {
                try
                {
                    Console.Write(":-) ");
                    interpreter.Execute(Console.ReadLine());
                }
                catch (CommandLineInterpreterFrameworkException e)
                {
                    Console.WriteLine(e.Message);
                }

                // TODO: Implement general catch Exception
            }

            Console.ReadKey();
        }

        private static IInterpreter CreateInterpreter()
        {
            var commands = CreateCommands();

            var interpreter = new Interpreter(new InputParser(),
                                              commands,
                                              HelpCommand);

            interpreter.Help += (sender, args) =>
                                    {
                                        if (args.Commands.Count == 1)
                                        {
                                            var command = args.Commands.First();

                                            Console.WriteLine("{0}\t\t\t-{1}", command.Name, command.Description);

                                            foreach (var parameter in command.Parameters)
                                            {
                                                Console.WriteLine("{0}\t\t\t-{1}", parameter.Name, parameter.Description);
                                            }
                                        }
                                        else
                                        {
                                            foreach (var command in args.Commands)
                                            {
                                                Console.WriteLine("{0}\t\t\t-{1}", command.Name, command.Description);
                                            }
                                        }
                                    };

            return interpreter;
        }

        private static CommandsDictionary CreateCommands()
        {
            return new CommandsDictionary
                       {
                           CreateHelloCommand(),
                           CreateByeCommand(),
                           CreateClearCommand(),
                           CreateExitCommand()
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

        private static ICommand CreateExitCommand()
        {
            return new Command(ExitCommand,
                               "Terminates app",
                               CreateExitCommandParameters(),
                               ExitCommandAction);
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

        private static ParametersDictionary CreateExitCommandParameters()
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

        private static void HelloCommandAction(IDictionary<string, IEnumerable<string>> arguments)
        {
            var times = arguments[NumberParameter].Any() ? int.Parse(arguments[NumberParameter].First(), CultureInfo.InvariantCulture)
                                                                            : 0;

            for (var i = 0; i < times; i++)
            {
                Console.WriteLine("Hello");
            }
        }
        
        private static void ByeCommandAction(IDictionary<string, IEnumerable<string>> arguments)
        {
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Bye-bye: {0}", arguments[NameParameter].Any() ? arguments[NameParameter].First() : string.Empty));
        }

        private static void ClearCommandAction(IDictionary<string, IEnumerable<string>> arguments)
        {
            Console.Clear();
        }

        private static void ExitCommandAction(IDictionary<string, IEnumerable<string>> arguments)
        {
            isContinue = false;
            Console.WriteLine("Press any key to exit...");
        }
    }
}
