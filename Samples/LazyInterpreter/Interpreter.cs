// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.LimitValidation;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation;

namespace LazyInterpreter
{
    /// <summary>
    /// Creates sample interpreter
    /// </summary>
    public static class Interpreter
    {
        /// <summary>
        /// Creates lazy interpreter
        /// </summary>
        public static IInterpreter Create()
        {
            return InterpreterFactory.CreateInterpreter(CreateCommands(), ExceptionHandling, "prefix > ");
        }

        private static CommandsDictionary CreateCommands()
        {
            return new CommandsDictionary
                       {
                           CreateHelloCommand(),
                           CreateByCommand(),
                           CreateClearCommand()
                       };
        }

        private static void ExceptionHandling(IConsole console, Exception e)
        {
            console.WriteLine(e.Message);
        }

        #region Clear

        private static ICommand CreateClearCommand()
        {
            return new Command("Clear", "Clears console", new ParametersDictionary(), (console, arguments) => console.Clear());
        }

        #endregion 
        #region Hello

        private static ICommand CreateHelloCommand()
        {
            var parameteInfo = new ParameterInfo("-number:", "Number of times");
            var parameter = new Parameter(parameteInfo, new MultipleParameterValidator(), new IntTypeValidator());
            var parameters = new ParametersDictionary
                                 {
                                     parameter
                                 };

            return new Command("Hello", "Write \"Hello world\" specified number of times", parameters, HelloAction);
        }

        private static void HelloAction(IConsole console, IEnumerable<IArgument> arguments)
        {
            var times = 0;

            // TODO: Improve usage of the returned argumtes. It will be better to use dictionary in this case and to use indexer for this purpose
            foreach (var argument in arguments.Where(argument => argument.Name == "-number:"))
            {
                if (argument.Values.Any())
                {
                    times = int.Parse(argument.Values.First(), CultureInfo.InvariantCulture);
                }
            }

            for (var i = 0; i < times; i++)
            {
                console.WriteLine("Hello");
            }
        }

        #endregion
        #region By

        private static ICommand CreateByCommand()
        {
            return new Command("By", "Just say good by", new ParametersDictionary(), ByAction);
        }

        private static void ByAction(IConsole console, IEnumerable<IArgument> arguments)
        {
            console.WriteLine("This is the sample app for the cmdf\bBy");
        }

        #endregion
    }
}
