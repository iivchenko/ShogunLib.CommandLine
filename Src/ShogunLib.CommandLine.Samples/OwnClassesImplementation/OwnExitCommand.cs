// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Threading;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Commands.Parameters;

namespace OwnClassesImplementation
{
    public class OwnExitCommand : ICommand
    {
        private readonly ExitMonitor _exitMonitor;

        public OwnExitCommand(ExitMonitor exitMonitor)
        {
            _exitMonitor = exitMonitor;
        }

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

        public void Execute(IEnumerable<string> args)
        {
            Console.WriteLine("Exiting");
            Thread.Sleep(5000);
            Console.WriteLine("Exited");
            Thread.Sleep(5000);

            _exitMonitor.IsContinue = false;
        }
    }
}
