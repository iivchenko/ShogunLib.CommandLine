// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommandLineInterpreterFramework.Commands;
using Moq;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    [TestFixture]
    public class CommandTests
    {
        private const string Name = "Command";
        private const string Description = "Command description";

        //protected Command(string name, string description, ICollection<IParameter> parameters, Action<TActionArgument> action)
        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_NullName_Throws()
        {
            new Command<ActionArgumentDictionary>(null, Description, new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_EmptyName_Throws()
        {
            new Command<ActionArgumentDictionary>(string.Empty, Description, new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesName_Throws()
        {
            new Command<ActionArgumentDictionary>("   ", Description, new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_NullDescription_Throws()
        {
            new Command<ActionArgumentDictionary>(Name, null, new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_EmptyDescription_Throws()
        {
            new Command<ActionArgumentDictionary>(Name, string.Empty, new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_WhiteSpacesDescription_Throws()
        {
            new Command<ActionArgumentDictionary>(Name, "   ", new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_NullParameters_Throws()
        {
            new Command<ActionArgumentDictionary>(Name, Description, null, ActionTest<IActionArgument>.Hello);
        }

        [Test]
        [ExpectedException(typeof(AggregateException))]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "CommandLineInterpreterFramework.Commands.Command`1<CommandLineInterpreterFramework.ActionArgumentDictionary>", Justification = "Unit test needs it")]
        public void Constructor_NullAction_Throws()
        {
            new Command<ActionArgumentDictionary>(Name, Description, new Collection<IParameter>(), null);
        }

        [Test]
        public void Parameters_NoParameters_ReturnsEmptyString()
        {
            var command = new Command<ActionArgumentDictionary>(Name, Description, new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);

            Assert.IsEmpty(command.Parameters);
        }

        // TODO: Fix this unit test
        [Test]
        public void Parameters_CorrectParametersAreUsed_ReturnsCorrectParamentersInfo()
        {
            var expectedParameters = new[]
                                         {
                                             new ParameterInfo("parameter1", "description1"),
                                             new ParameterInfo("parameter2", "description2")
                                         };

            var commandParameters = new[]
                                 {
                                     CreateParameter("parameter1", "description1"),
                                     CreateParameter("parameter2", "description2")
                                 };
            
            var command = new Command<ActionArgumentDictionary>(Name, Description, commandParameters, ActionTest<IActionArgument>.Hello);

            Assert.IsTrue(expectedParameters.SequenceEqual(command.Parameters), "Actual parameters should be equal to expected parameters");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Execute_NullArguments_Throws()
        {
            var command = new Command<ActionArgumentDictionary>(Name, Description, new Collection<IParameter>(), ActionTest<IActionArgument>.Hello);

            command.Execute(null);
        }

        [Test]
        public void Execute_Validation_ParameterValidationIsUsed()
        {
            var mockParameter = new Mock<IParameter>();
            mockParameter.Setup(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>())).Returns(new Argument("name", new List<string>()));

            var parameters = new[]
                                 {
                                     mockParameter.Object
                                 };
            var command = new Command<ActionArgumentDictionary>(Name, Description, parameters, ActionTest<IActionArgument>.Hello);

            command.Execute(new Collection<string>());

            mockParameter.Verify(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>()), Times.Once());
        }

        [Test]
        public void Execute_AllConditionsAreMet_ActionIsExecuted()
        {
            var isActionExecuted = false;
            var command = new Command<ActionArgumentDictionary>(Name, Description, new Collection<IParameter>(), actionArgument => isActionExecuted = true);

            command.Execute(new Collection<string>());

            Assert.IsTrue(isActionExecuted, "Command should execute Action delegate");
        }

        private static IParameter CreateParameter(string name, string description)
        {
            var parameter = new Mock<IParameter>();

            parameter.Setup(x => x.Info).Returns(new ParameterInfo(name, description));

            return parameter.Object;
        }

        internal static class ActionTest<TActionArgument> where TActionArgument : IActionArgument
        {
            public static void Hello(TActionArgument argument)
            {
            }
        }
    }
}
