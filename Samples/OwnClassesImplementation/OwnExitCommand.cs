// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Threading;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Console;

namespace OwnClassesImplementation
{
    public class OwnExitCommand : ICommand
    {
        public string Name
        {
            get { return "OwnExitCommand"; }
        }

        public string Description
        {
            get { return "This command do something useful"; }
        }

        public IEnumerable<IParameterInfo> Parameters
        {
            get { return new List<IParameterInfo>(); }
        }

        public void Execute(IConsole console, IEnumerable<string> args)
        {
            console.WriteLine("Exiting");
            Thread.Sleep(5000);
            console.WriteLine("Exited");
            Thread.Sleep(5000);
        }
    }
}
