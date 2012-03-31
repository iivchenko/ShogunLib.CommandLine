// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Console;
using CommandLineInterpreterFramework.Interpretation;
using CommandLineInterpreterFramework.Interpretation.Parsing;
using CommandLineInterpreterFramework.Tests.Unit.Commands;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Interpretation
{
    [TestFixture]
    public class InterpreterTests
    {
        private const string ExitCommandName = "Exit";
        private const string HelpCommandName = "Help";
        private const string ParsedCommandName = "ParsedCommand";

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullConsole_Throws()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();

            new Interpreter(null, null, parser.Object, commands, help.Object, exit.Object);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullInputParser_Throws()
        {
            var console = new Mock<IConsole>();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();

            new Interpreter(console.Object, null, null, commands, help.Object, exit.Object);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullCommands_Throws()
        {
            var console = new Mock<IConsole>();
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            
            new Interpreter(console.Object, null, parser.Object, null, help.Object, exit.Object);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullHelpCommand_Throws()
        {
            var console = new Mock<IConsole>();
            var parser = CreateParser();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();

            new Interpreter(console.Object, null, parser.Object, commands, null, exit.Object);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullExitCommand_Throws()
        {
            var console = new Mock<IConsole>();
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var commands = new CommandsDictionary();
            
            new Interpreter(console.Object, null, parser.Object, commands, help.Object, null);
        }

        [Test]
        [ExpectedException(typeof(DuplicatedCommandException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_HelpCommandDuplicatedInCommandsList_Throws()
        {
            var console = new Mock<IConsole>();
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary
                               {
                                   help.Object
                               };

            new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);
        }

        [Test]
        [ExpectedException(typeof(DuplicatedCommandException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_ExitCommandDuplicatedInCommandsList_Throws()
        {
            var console = new Mock<IConsole>();
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary
                               {
                                   exit.Object
                               };

            new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);
        }

        [Test]
        [ExpectedException(typeof(DuplicatedCommandException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_ExitAndHelpCommandsHaveSameName_Throws()
        {
            var console = new Mock<IConsole>();
            var parser = CreateParser();
            var commandHelpExit = FakeCreator.CreateCommand("Duplication");
            var commands = new CommandsDictionary();

            new Interpreter(console.Object, null, parser.Object, commands, commandHelpExit, commandHelpExit);
        }

        // Parsing of the console input fails. Parsing error should be written to the console
        [Test]
        [Timeout(2000)]
        public void Run_ParsingFail_ConsoleWriteLine()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();
            var console = new Mock<IConsole>();

            parser.Setup(x => x.Parse(string.Empty)).Throws(new InputParserException());

            console.Setup(x => x.ReadLine()).Returns(string.Empty).Callback(() => console.Setup(x => x.ReadLine()).Returns(ExitCommandName));

            var interpreter = new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);

            interpreter.Run();

            console.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once());
        }

        [Test]
        [Timeout(2000)]
        public void Run_ExitCommand_CommandIsExecuted()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();
            var console = new Mock<IConsole>();

            console.Setup(x => x.ReadLine()).Returns(ExitCommandName);

            var interpreter = new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);

            interpreter.Run();

            exit.Verify(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        [Timeout(2000)]
        public void Run_HelpCommand_CommandIsExecuted()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();
            var console = new Mock<IConsole>();

            console.Setup(x => x.ReadLine()).Returns(HelpCommandName).Callback(() => console.Setup(x => x.ReadLine()).Returns(ExitCommandName));

            var interpreter = new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);
            
            interpreter.Run();
            
            help.Verify(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>()), Times.Once());
            exit.Verify(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        [Timeout(2000)]
        public void Run_SpecifiedCommand_CommandIsUndefined()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();
            var console = new Mock<IConsole>();
            
            console.Setup(x => x.ReadLine()).Returns(ParsedCommandName).Callback(() => console.Setup(x => x.ReadLine()).Returns(ExitCommandName));

            var interpreter = new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);

            interpreter.Run();
            
            console.Verify(x => x.WriteLine(It.IsRegex(ParsedCommandName + "$")), Times.Once());
            exit.Verify(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        [Timeout(2000)]
        public void Run_SpecifiedCommand_CommandIsExecuted()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();
            var console = new Mock<IConsole>();
            var command = new Mock<ICommand>();

            command.Setup(x => x.Name).Returns(ParsedCommandName);

            commands.Add(command.Object);

            console.Setup(x => x.ReadLine()).Returns(ParsedCommandName).Callback(() => console.Setup(x => x.ReadLine()).Returns(ExitCommandName));

            var interpreter = new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);
            
            interpreter.Run();

            command.Verify(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>()), Times.Once());
            exit.Verify(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        [Timeout(2000)]
        public void Run_SpecifiedCommandExecutionFailAndExceptionHandlingIsNull_ThrowsExceptionForward()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();
            var console = new Mock<IConsole>();
            var command = new Mock<ICommand>();

            command.Setup(x => x.Name).Returns(ParsedCommandName);
            command.Setup(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>())).Throws(new ArgumentException("Message"));

            commands.Add(command.Object);

            console.Setup(x => x.ReadLine()).Returns(ParsedCommandName).Callback(() => console.Setup(x => x.ReadLine()).Returns(ExitCommandName));

            var interpreter = new Interpreter(console.Object, null, parser.Object, commands, help.Object, exit.Object);
            
            Assert.Throws(typeof(ArgumentException), interpreter.Run);
        }

        [Test]
        [Timeout(2000)]
        public void Run_SpecifiedCommandExecutionFail_ExceptionHandlingUsed()
        {
            var parser = CreateParser();
            var help = CreateHelpCommand();
            var exit = CreateExitCommand();
            var commands = new CommandsDictionary();
            var console = new Mock<IConsole>();
            var command = new Mock<ICommand>();
            var isExceptionHandlingUsed = false;

            command.Setup(x => x.Name).Returns("Command");
            command.Setup(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>())).Throws(new ArgumentException("Message"));

            commands.Add(command.Object);

            console.Setup(x => x.ReadLine()).Returns("Command").Callback(() => console.Setup(x => x.ReadLine()).Returns(ExitCommandName));

            var interpreter = new Interpreter(console.Object, e => isExceptionHandlingUsed = true, parser.Object, commands, help.Object, exit.Object);
            
            interpreter.Run();

            Assert.IsTrue(isExceptionHandlingUsed);
            exit.Verify(x => x.Execute(It.IsAny<IConsole>(), It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        private static Mock<IInputParser> CreateParser()
        {
            var parser = new Mock<IInputParser>();
            var exit = new Mock<IParsedCommand>();
            var help = new Mock<IParsedCommand>();
            var command = new Mock<IParsedCommand>();

            exit.Setup(x => x.Name).Returns(ExitCommandName);
            exit.Setup(x => x.Args).Returns(new Collection<string>());

            help.Setup(x => x.Name).Returns(HelpCommandName);
            help.Setup(x => x.Args).Returns(new Collection<string>());

            command.Setup(x => x.Name).Returns(ParsedCommandName);
            command.Setup(x => x.Args).Returns(new Collection<string>());

            parser.Setup(x => x.Parse(ExitCommandName)).Returns(exit.Object);
            parser.Setup(x => x.Parse(HelpCommandName)).Returns(help.Object);
            parser.Setup(x => x.Parse(ParsedCommandName)).Returns(command.Object);

            return parser;
        }

        private static Mock<ICommand> CreateHelpCommand()
        {
            var command = new Mock<ICommand>();

            command.Setup(x => x.Name).Returns(HelpCommandName);

            return command;
        }

        private static Mock<ICommand> CreateExitCommand()
        {
            var command = new Mock<ICommand>();

            command.Setup(x => x.Name).Returns(ExitCommandName);

            return command;
        }
    }
}
