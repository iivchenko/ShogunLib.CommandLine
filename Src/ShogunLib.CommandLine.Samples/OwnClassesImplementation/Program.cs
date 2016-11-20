// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Linq;
using ShogunLib.CommandLine;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Commands.Parameters;

namespace OwnClassesImplementation
{
    public static class Program
    {
        public static void Main()
        {
            var exitMonitor = new ExitMonitor
                                  {
                                      IsContinue = true
                                  };

            var commands = new List<ICommand>
                               {
                                   new OwnCommand(new List<IParameter>
                                                      {
                                                          new OwnParameter(new OwnArgumentValidator())
                                                      }),
                                   new OwnExitCommand(exitMonitor)
                               };

            var interpreter = new OwnInterpreter(commands);
            interpreter.Help += Help;
            
            while (exitMonitor.IsContinue)
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

        private static void Help(object sender, HelpCommandEventArgs e)
        {
            if (e.Commands.Count == 1)
            {
                var command = e.Commands.First();

                Console.WriteLine("{0}\t\t\t-{1}", command.Name, command.Description);

                foreach (var parameter in command.Parameters)
                {
                    Console.WriteLine("{0}\t\t\t-{1}", parameter.Name, parameter.Description);
                }
            }
            else
            {
                foreach (var command in e.Commands)
                {
                    Console.WriteLine("{0}\t\t\t-{1}", command.Name, command.Description);
                }
            }
        }
    }
}
