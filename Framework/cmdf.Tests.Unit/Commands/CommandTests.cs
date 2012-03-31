// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Console;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullName_Throws()
        {
            new Command(null, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_EmptyName_Throws()
        {
            new Command(string.Empty, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesName_Throws()
        {
            new Command("   ", FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullDescription_Throws()
        {
            new Command(FakeCreator.CommandName, null, new ParametersDictionary(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_EmptyDescription_Throws()
        {
            new Command(FakeCreator.CommandName, string.Empty, new ParametersDictionary(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesDescription_Throws()
        {
            new Command(FakeCreator.CommandName, "   ", new ParametersDictionary(), delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullParameters_Throws()
        {
            new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, null, delegate { });
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command", Justification = "Unit test needs it")]
        public void Constructor_NullAction_Throws()
        {
            new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), null);
        }

        [Test]
        public void Parameters_NoParameters_ReturnsEmptyString()
        {
            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });

            Assert.IsEmpty(command.Parameters);
        }

        [Test]
        public void Parameters_CorrectParametersAreUsed_ReturnsCorrectParamentersInfo()
        {
            var expectedParameters = new[]
                                         {
                                             FakeCreator.CreateParameterInfo("parameter1", "description1"),
                                             FakeCreator.CreateParameterInfo("parameter2", "description2")
                                         };

            var commandParameters = new ParametersDictionary
                                        {
                                            { "parameter1", FakeCreator.CreateParameter("parameter1", "description1") },
                                            { "parameter2", FakeCreator.CreateParameter("parameter2", "description2") }
                                        };

            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, commandParameters, delegate { });

            Assert.IsTrue(expectedParameters.SequenceEqual(command.Parameters, new ParameterInfoComparer()), "Actual parameters should be equal to expected parameters");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_NullConsole_Throws()
        {
            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });

            command.Execute(null, new Collection<string>());
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_NullArguments_Throws()
        {
            var stubConsole = new Mock<IConsole>();
            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), delegate { });

            command.Execute(stubConsole.Object, null);
        }

        [Test]
        public void Execute_Validation_ParameterValidationIsUsed()
        {
            var stubConsole = new Mock<IConsole>();
            var mockParameter = FakeCreator.CreateParameterFake(FakeCreator.ParameterName, FakeCreator.ParameterDescription);
            var parameters = new ParametersDictionary
                                 {
                                     mockParameter.Object
                                 };

            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, parameters, delegate { });

            command.Execute(stubConsole.Object, new Collection<string>());

            mockParameter.Verify(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        public void Execute_AllConditionsAreMet_ActionIsExecuted()
        {
            var stubConsole = new Mock<IConsole>();
            var isActionExecuted = false;
            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), (console, actionArgument) => isActionExecuted = true);

            command.Execute(stubConsole.Object, new Collection<string>());

            Assert.IsTrue(isActionExecuted, "Command should execute Action delegate");
        }

        [Test]
        public void Execute_AllConditionsAreMet_ConsoleIsUsed()
        {
            var mockConsole = new Mock<IConsole>();
            var command = new Command(FakeCreator.CommandName, FakeCreator.CommandDescription, new ParametersDictionary(), (console, actionArgument) => console.Clear());

            command.Execute(mockConsole.Object, new Collection<string>());

            mockConsole.Verify(console => console.Clear(), Times.Once());
        }

        private class ParameterInfoComparer : EqualityComparer<IParameterInfo>
        {
            public override bool Equals(IParameterInfo x, IParameterInfo y)
            {
                return x.Name == y.Name && x.Description == y.Description;
            }

            public override int GetHashCode(IParameterInfo obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
