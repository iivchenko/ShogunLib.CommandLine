// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;

namespace OwnClassesImplementation
{
    public static class Program
    {
        public static void Main()
        {
            var commands = new List<ICommand>
                               {
                                   new OwnCommand(new List<IParameter>
                                                      {
                                                          new OwnParameter(new OwnArgumentValidator())
                                                      })
                               };

            var interpreter = new OwnInterpreter(commands);

            interpreter.Run();
        }
    }
}
