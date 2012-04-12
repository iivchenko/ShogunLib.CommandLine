// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Linq;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation;
using CommandLineInterpreterFramework.Interpretation.Parsing;

namespace OwnClassesImplementation
{
    public class OwnInterpreter : IInterpreter
    {
        private readonly IInterpreter _interpreter;
        
        public OwnInterpreter(ICollection<ICommand> commands)
        {
            _interpreter = new Interpreter(new StandardConsole(), null, new InputParser(), commands.ToDictionary(command => command.Name.ToUpperInvariant()), new HelpCommand(commands), new OwnExitCommand(), ":-) ");
        }

        public void Run()
        {
            _interpreter.Run();
        }
    }
}
