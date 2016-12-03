// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using Moq;
using NUnit.Framework;
using ShogunLib.CommandLine.Commands;
using ShogunLib.CommandLine.Interpretation;
using ShogunLib.CommandLine.Interpretation.Parsing;
using ShogunLib.CommandLine.Tests.Commands;

namespace ShogunLib.CommandLine.Tests.Interpretation
{
    [TestFixture]
    public class InterpreterTests
    {
        private const string HelpCommandName = "Help";

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullInputParser_Throws()
        {
            var commands = new CommandsDictionary();

            Assert.Throws<ArgumentNullException>(() => new Interpreter(null, commands, HelpCommandName));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullCommands_Throws()
        {
            var parser = CreateParser();
            Assert.Throws<ArgumentNullException>(() => new Interpreter(parser.Object, null, HelpCommandName));
        }
       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_NullHelpCommandName_Throws()
        {
            var parser = CreateParser();
            var commands = new CommandsDictionary();

            Assert.Throws<ArgumentNullException>(() => new Interpreter(parser.Object, commands, null));
        }

        [TestCase("   ")]
        [TestCase("")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_EmptyHelpCommandName_Throws(string helpCommand)
        {
            var parser = CreateParser();
            var commands = new CommandsDictionary();

            Assert.Throws<ArgumentException>(() => new Interpreter(parser.Object, commands, helpCommand));
        }

        [Test]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "ShogunLib.CommandLine.Interpretation.Interpreter", Justification = "Unit test need it")]
        public void Constructor_HelpCommandDuplicatedInCommandsList_Throws()
        {
            var parser = CreateParser();
            var commands = new CommandsDictionary
                               {
                                  FakeCreator.CreateCommand(HelpCommandName)
                               };

            Assert.Throws<DuplicatedCommandException>(() => new Interpreter(parser.Object, commands, HelpCommandName));
        }

        [TestCase(null)]
        [TestCase("   ")]
        [TestCase("")]
        public void Execute_ParsedCommandIsEmpty_DoNothing(string commandName)
        {
            var isRaised = false;
            var parser = CreateParser();
            var mockCommand = FakeCreator.CreateCommandFake(FakeCreator.CommandName);
            var commands = new CommandsDictionary
                               {
                                   { FakeCreator.CommandName, mockCommand.Object }
                               };
            var interpreter = new Interpreter(parser.Object, commands, HelpCommandName);
            interpreter.Help += (sender, e) => isRaised = true;

            interpreter.Execute(commandName);
            
            mockCommand.Verify(command => command.Execute(It.IsAny<IEnumerable<string>>()), Times.Never());
            Assert.IsFalse(isRaised, "Help command should not raise in this test.");
        }

        [Test]
        public void Execute_ParsedCommandIsHelp_HelpIsExecuted()
        {
            var isRaised = false;
            var parser = CreateParser();
            var mockCommand = FakeCreator.CreateCommandFake(FakeCreator.CommandName);
            var commands = new CommandsDictionary
                               {
                                   { FakeCreator.CommandName, mockCommand.Object }
                               };
            var interpreter = new Interpreter(parser.Object, commands, HelpCommandName);
            interpreter.Help += (sender, e) => isRaised = true;

            interpreter.Execute(HelpCommandName);

            mockCommand.Verify(command => command.Execute(It.IsAny<IEnumerable<string>>()), Times.Never());
            Assert.IsTrue(isRaised, "Help command should raise in this test.");
        }

        [Test]
        public void Execute_ParsedCommandIsHelpAndNoInputParameters_HelpReturnsAllCommands()
        {
            const string Command1 = "command1";
            const string Command2 = "command2";
            
            var mockCommand1 = FakeCreator.CreateCommandFake(Command1);
            var mockCommand2 = FakeCreator.CreateCommandFake(Command2);
            
            var parser = CreateParser();
            var actualCommands = new List<CommandDescriptor>();
            var commands = new CommandsDictionary
                               {
                                   mockCommand1.Object,
                                   mockCommand2.Object
                               };
            var interpreter = new Interpreter(parser.Object, commands, HelpCommandName);

            interpreter.Help += (sender, e) => actualCommands = new List<CommandDescriptor>(e.Commands);
            interpreter.Execute(HelpCommandName);

            Assert.AreEqual(2, actualCommands.Count);
            Assert.IsTrue(actualCommands.Any(command => command.Name == mockCommand1.Object.Name));
            Assert.IsTrue(actualCommands.Any(command => command.Name == mockCommand2.Object.Name));
        }

        [Test]
        public void Execute_ParsedCommandIsHelpAndOneInputParameters_HelpReturnsCommand()
        {
            const string Command1 = "command1";
            const string Command2 = "command2";

            var mockCommand1 = FakeCreator.CreateCommandFake(Command1);
            var mockCommand2 = FakeCreator.CreateCommandFake(Command2);

            var parser = new Mock<IInputParser>();
            parser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new ParsedCommand(HelpCommandName, new[] { Command1 }));

            var actualCommands = new List<CommandDescriptor>();
            var commands = new CommandsDictionary
                               {
                                   mockCommand1.Object,
                                   mockCommand2.Object
                               };
            var input = string.Format(CultureInfo.InvariantCulture, "{0} {1}", HelpCommandName, Command1);
            var interpreter = new Interpreter(parser.Object, commands, HelpCommandName);
            
            interpreter.Help += (sender, e) => actualCommands = new List<CommandDescriptor>(e.Commands);
            interpreter.Execute(input);

            Assert.AreEqual(1, actualCommands.Count);
            Assert.IsTrue(actualCommands.Any(command => command.Name == mockCommand1.Object.Name));
            Assert.IsFalse(actualCommands.Any(command => command.Name == mockCommand2.Object.Name));
        }

        [Test]
        public void Execute_ParsedCommandIsNotEmpty_CommandIsExecuted()
        {
            var isRaised = false;
            var parser = CreateParser();
            var mockCommand = FakeCreator.CreateCommandFake(FakeCreator.CommandName);
            var commands = new CommandsDictionary
                               {
                                   mockCommand.Object
                               };

            var interpreter = new Interpreter(parser.Object, commands, HelpCommandName);
            interpreter.Help += (sender, e) => isRaised = true;

            interpreter.Execute(FakeCreator.CommandName);

            mockCommand.Verify(command => command.Execute(It.IsAny<IEnumerable<string>>()), Times.Once());
            Assert.IsFalse(isRaised, "Help command should not raise in this test.");
        }

        [Test]
        public void Execute_ParsedCommandIsUnknown_Throws()
        {
            var parser = CreateParser();
            var interpreter = new Interpreter(parser.Object, new CommandsDictionary(), HelpCommandName);

            Assert.Throws<UndefinedCommandException>(() => interpreter.Execute(FakeCreator.CommandName));
        }

        private static Mock<IInputParser> CreateParser()
        {
            var parser = new Mock<IInputParser>();
            var command = new Mock<IParsedCommand>();
            var help = new Mock<IParsedCommand>();

            command.Setup(x => x.Name).Returns(FakeCreator.CommandName);
            command.Setup(x => x.Args).Returns(new Collection<string>());

            help.Setup(x => x.Name).Returns(HelpCommandName);
            help.Setup(x => x.Args).Returns(new Collection<string>());

            parser.Setup(x => x.Parse(FakeCreator.CommandName)).Returns(command.Object);
            parser.Setup(x => x.Parse(HelpCommandName)).Returns(help.Object);

            return parser;
        }
    }
}
