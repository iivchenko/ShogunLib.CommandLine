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
using ShogunLib.CommandLine.Commands.Parameters;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.LimitValidation;

namespace ExeAsCommand
{
    public static class Program
    {
        private const string CommandName = "HelloWorld";
        private const string CommandParameter = "-helloMan:";
        
        public static void Main(string[] args)
        {
            CreateCommand().Execute(args);
        }

        private static ICommand CreateCommand()
        {
            return new Command(CommandName, "Say hello to you", CreateParameters(), CommandAction);
        }

        private static ParametersDictionary CreateParameters()
        {
            var nameParameter = new Parameter(new ParameterInfo(CommandParameter, "For whom hello should be said"),
                                              new OptionalParameterValidator());

            return new ParametersDictionary
                       {
                           nameParameter
                       };
        }

        private static void CommandAction(IDictionary<string, IEnumerable<string>> arguments)
        {
            Console.WriteLine(string.Format(CultureInfo.InvariantCulture, "Hello {0} man.", arguments[CommandParameter].Any() ? arguments[CommandParameter].First() : string.Empty));
        }
    }
}
