// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Globalization;
using System.Linq;
using CommandLineInterpreterFramework.Building;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.LimitValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation;
using CommandLineInterpreterFramework.Interpretation;

namespace LazyInterpreter
{
    public static class Program
    {
        public static void Main()
        {
            var interpreter = CreateInterpreter();

            interpreter.Run();
        }

        private static IInterpreter CreateInterpreter()
        {
            const string HelloCommand = "Hello";
            const string ByeCommand = "Bye";
            const string ClearCommand = "Clear";

            const string NumberParameter = "-number:";
            const string NameParameter = "-name:";

            var builder = InterpreterBuilderFactory.Create();

            // Setup builder
            builder.SetPrefix(":-) ")
                   .SetExceptionHandling((console, e) => console.WriteLine(e.ToString()));

            // Add Commands
            builder.Add(HelloCommand)
                   .Add(ByeCommand)
                   .Add(ClearCommand);

            // Setup commands
            builder[HelloCommand].SetDescription("Writes 'hello' to the console specified number of times")
                                 .SetAction((console, arguments) =>
                                                {
                                                    var times = arguments[NumberParameter].Any() ? int.Parse(arguments[NumberParameter].First(), CultureInfo.InvariantCulture)
                                                                                            : 0;

                                                    for (var i = 0; i < times; i++)
                                                    {
                                                        console.WriteLine("Hello");
                                                    }
                                                });

            builder[ByeCommand].SetDescription("Just says goodbye")
                               .SetAction((console, arguments) => console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Bye-bye: {0}", arguments[NameParameter].Any() ? arguments[NameParameter].First() : string.Empty)));

            builder[ClearCommand].SetDescription("Clears console output")
                                 .SetAction((console, arguments) => console.Clear());

            // Add parameters
            builder[HelloCommand].Add(NumberParameter);
            builder[ByeCommand].Add(NameParameter);

            // Setup parameters
            builder[HelloCommand][NumberParameter].SetDescription("Number of times")
                                                  .AddValidator(new OptionalParameterValidator())
                                                  .AddValidator(new IntTypeValidator());

            builder[ByeCommand][NameParameter].SetDescription("Name for whom bye-bye is said")
                                              .AddValidator(new OptionalParameterValidator());
            
            // Building interpreter
            return builder.Create();
        }
    }
}
