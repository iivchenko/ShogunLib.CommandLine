// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Globalization;
using System.Linq;
using ShogunLib.CommandLine;
using ShogunLib.CommandLine.Building;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.LimitValidation;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.TypeValidation;
using ShogunLib.CommandLine.Interpretation;

namespace LazyInterpreter
{
    /// <summary>
    /// Sample demonstrates how to create console app using ShogunLib.CommandLine fluent API
    /// </summary>
    public static class Program
    {
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
            }

            Console.ReadKey();
        }

        private static IInterpreter CreateInterpreter()
        {
            const string HelloCommand = "Hello";
            const string ByeCommand = "Bye";
            const string ClearCommand = "Clear";
            const string ExitCommand = "Exit";

            const string NumberParameter = "-number:";
            const string NameParameter = "-name:";

            var builder = InterpreterBuilderFactory.Create();

            // Setup builder
            builder
                .SetHelp("Help",
                         (sender, args) =>
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
                             });

            // Add Commands
            builder
                .Add(HelloCommand)
                .Add(ByeCommand)
                .Add(ClearCommand)
                .Add(ExitCommand);

            // Setup commands
            builder[HelloCommand]
                .SetDescription("Writes 'hello' to the console specified number of times")
                .SetAction(arguments =>
                               {
                                   var times = arguments[NumberParameter].Any()
                                                   ? int.Parse(arguments[NumberParameter].First(),
                                                               CultureInfo.InvariantCulture)
                                                   : 0;

                                   for (var i = 0; i < times; i++)
                                   {
                                       Console.WriteLine("Hello");
                                   }
                               });

            builder[ByeCommand]
                .SetDescription("Just says goodbye")
                .SetAction(arguments => Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Bye-bye: {0}", arguments[NameParameter].Any() ? arguments[NameParameter].First() : string.Empty)));

            builder[ClearCommand]
                .SetDescription("Clears console output")
                .SetAction(arguments => Console.Clear());

            builder[ExitCommand]
                .SetDescription("Terminate app")
                .SetAction(arguments =>
                               {
                                   isContinue = false;
                                   Console.WriteLine("Press any key to exit...");
                               });

            // Add parameters
            builder[HelloCommand].Add(NumberParameter);
            builder[ByeCommand].Add(NameParameter);

            // Setup parameters
            builder[HelloCommand][NumberParameter]
                .SetDescription("Number of times")
                .AddValidator(new OptionalParameterValidator())
                .AddValidator(new IntTypeValidator());

            builder[ByeCommand][NameParameter]
                .SetDescription("Name for whom bye-bye is said")
                .AddValidator(new OptionalParameterValidator());
            
            // Building interpreter
            return builder.Create();
        }
    }
}
