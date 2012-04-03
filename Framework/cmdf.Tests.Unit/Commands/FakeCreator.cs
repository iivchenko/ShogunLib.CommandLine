﻿// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using CommandLineInterpreterFramework.Commands;
using CommandLineInterpreterFramework.Commands.Parameters;
using CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation;
using Moq;

namespace CommandLineInterpreterFramework.Tests.Unit.Commands
{
    /// <summary>
    /// This helper class should return MOCKed and STUBed objects
    /// </summary>
    internal static class FakeCreator
    {
        public const string CommandName = "Command";
        public const string CommandDescription = "Description";

        public const string ParameterName = "/name:";
        public const string ParameterDescription = "Description";

        #region public Command

        /// <summary>
        /// Creates fake command with one parameter and default description
        /// </summary>
        public static ICommand CreateCommand(string name)
        {
            return CreateCommandFakeInternal(name, CommandDescription, 1, ParameterName, ParameterDescription).Object;
        }

        #endregion
        #region public Parameter

        /// <summary>
        /// Creates fake parameter with succeeded validation
        /// </summary>
        public static IParameter CreateParameter(string name, string description)
        {
            return CreateParameterFakeInternal(name, description, null).Object;
        }

        /// <summary>
        /// Creates fake with succeeded validation
        /// </summary>
        public static Mock<IParameter> CreateParameterFake(string name, string description)
        {
            return CreateParameterFakeInternal(name, description, null);
        }

        #endregion
        #region public ParameterInfo

        /// <summary>
        /// Crates fake parameter information with default name and description
        /// </summary>
        public static IParameterInfo CreateParameterInfo()
        {
            return CreateParameterInfoFakeInternal(ParameterName, ParameterDescription).Object;
        }

        /// <summary>
        /// Creates fake parameter information
        /// </summary>
        public static IParameterInfo CreateParameterInfo(string name, string description)
        {
            return CreateParameterInfoFakeInternal(name, description).Object;
        }

        #endregion
        #region public ArgumentValidator

        /// <summary>
        /// Creates fake argument validator with specified validation reslult
        /// </summary>
        public static IArgumentValidator CreateArgumentValidator(bool validationResult)
        {
            return CreateArgumentValidatorFakeInternal(validationResult).Object;
        }

        #endregion

        private static Mock<ICommand> CreateCommandFakeInternal(string commandName, string commandDescription, int parametersCount, string parametersTemplateName, string parametersTemplateDescription)
        {
            var parameters = new Collection<IParameterInfo>();

            for (var i = 0; i < parametersCount; i++)
            {
                var parameterName = string.Format(CultureInfo.InvariantCulture, "{0}{1}", parametersTemplateName, i);
                var parameterDescription = string.Format(CultureInfo.InvariantCulture, "{0}{1}", parametersTemplateDescription, i);
                var parameter = CreateParameterInfoFakeInternal(parameterName, parameterDescription);

                parameters.Add(parameter.Object);
            }

            var stubCommand = new Mock<ICommand>();
            stubCommand.Setup(command => command.Name).Returns(commandName);
            stubCommand.Setup(command => command.Description).Returns(commandDescription);
            stubCommand.Setup(command => command.Parameters).Returns(parameters);

            return stubCommand;
        }

        private static Mock<IParameter> CreateParameterFakeInternal(string name, string description, IArgument validationResult)
        {
            var info = CreateParameterInfo(name, description);

            var stubParameter = new Mock<IParameter>();

            stubParameter.Setup(parameter => parameter.Info).Returns(info);
            stubParameter.Setup(parameter => parameter.Validate(It.IsAny<IEnumerable<string>>())).Returns(validationResult);

            return stubParameter;
        }

        private static Mock<IParameterInfo> CreateParameterInfoFakeInternal(string name, string description)
        {
            var stubParameterInfo = new Mock<IParameterInfo>();

            stubParameterInfo.Setup(parameterInfo => parameterInfo.Name).Returns(name);
            stubParameterInfo.Setup(parameterInfo => parameterInfo.Description).Returns(description);

            return stubParameterInfo;
        }

        private static Mock<IArgumentValidator> CreateArgumentValidatorFakeInternal(bool validationResult)
        {
            var stubArgumentValidator = new Mock<IArgumentValidator>();

            stubArgumentValidator.Setup(validator => validator.Validate(It.IsAny<IEnumerable<string>>())).Returns(validationResult);

            return stubArgumentValidator;
        }
    }
}
