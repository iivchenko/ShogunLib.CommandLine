// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Linq;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;

namespace OwnClassesImplementation
{
    public class OwnCommand : ICommand
    {
        private readonly IEnumerable<IParameter> _parameters;

        public OwnCommand(IEnumerable<IParameter> parameters)
        {
            _parameters = parameters;
        }

        public string Name
        {
            get { return "OwnCommand"; }
        }

        public string Description
        {
            get { return "this is very useful command"; }
        }

        public IEnumerable<IParameterInfo> Parameters
        {
            get { return _parameters.Select(parameter => parameter.Info); }
        }

        public void Execute(IEnumerable<string> args)
        {
            Console.WriteLine("Command execution started");

            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            Console.WriteLine("Command execution finished");
        }
    }
}
