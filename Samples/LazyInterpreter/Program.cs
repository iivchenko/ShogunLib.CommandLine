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
    /// <summary>
    /// Entry point
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main()
        {
            var interpreter = CreateInterpreter();

            interpreter.Run();
        }

        private static IInterpreter CreateInterpreter()
        {
            var builder = InterpreterBuilderFactory.Create();

            builder.SetPrefix(":-) ");
            builder.SetExceptionHandling((console, e) => console.WriteLine(e.ToString()));

            // Add Commands
            builder.Add("Hello");
            builder.Add("By");
            builder.Add("Clear");

            // Commands Descriptions
            builder["Hello"].SetDescription("Writes hello to the console specified number of times");
            builder["By"].SetDescription("Just say good by");
            builder["Clear"].SetDescription("Clears console output");

            // Add parameters
            builder["Hello"].Add("-number:");
            builder["By"].Add("-name:");

            // Setup parameters
            builder["Hello"]["-number:"].SetDescription("Number of times");
            builder["Hello"]["-number:"].AddValidator(new OptionalParameterValidator());
            builder["Hello"]["-number:"].AddValidator(new IntTypeValidator());
            
            builder["By"]["-name:"].SetDescription("Name for whom by-by is said");
            builder["By"]["-name:"].AddValidator(new OptionalParameterValidator());

            // Setup actions
            builder["Hello"].SetAction((console, arguments) =>
                                           {
                                               var times = arguments["-number:"].Any() ? int.Parse(arguments["-number:"].First(), CultureInfo.InvariantCulture) : 0;

                                               for (var i = 0; i < times; i++)
                                               {
                                                   console.WriteLine("Hello");
                                               }
                                           });
            builder["By"].SetAction((console, arguments) => console.WriteLine(string.Format(CultureInfo.InvariantCulture, "By-by: {0}", arguments["-name:"].Any() ? arguments["-name:"].First() : string.Empty)));
            builder["Clear"].SetAction((console, arguments) => console.Clear());

            return builder.Create();
        }
    }
}
