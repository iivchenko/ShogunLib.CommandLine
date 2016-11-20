// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Linq;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Interpretation;
using ShogunLib.CommandLine.Interpretation.Parsing;

namespace OwnClassesImplementation
{
    public class OwnInterpreter : IInterpreter
    {
        private const string HelpCommandName = "Help";
        private readonly IInterpreter _interpreter;
        
        public OwnInterpreter(IEnumerable<ICommand> commands)
        {
            _interpreter = new Interpreter(new InputParser(), commands.ToDictionary(command => command.Name.ToUpperInvariant()), HelpCommandName);
        }

        public event EventHandler<HelpCommandEventArgs> Help
        {
            add { _interpreter.Help += value; }
            remove { _interpreter.Help -= value; }
        }
        
        public void Execute(string input)
        {
            _interpreter.Execute(input);
        }
    }
}
