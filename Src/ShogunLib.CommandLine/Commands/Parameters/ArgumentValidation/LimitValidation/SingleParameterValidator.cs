// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation.LimitValidation
{
    /// <summary>
    /// Parameter should be used once.
    /// </summary>
    public sealed class SingleParameterValidator : IArgumentValidator
    {
        /// <summary>
        /// Initializes a new instance of the SingleParameterValidator class.
        /// </summary>
        public SingleParameterValidator()
        {
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Gets the validation failed message.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Performs count validation of the specified parameter. Parameter should be used once. If not than ErrorMessage is set.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>true - validation succeeded; false - validation filed.</returns>
        public bool Validate(IEnumerable<string> args)
        {
            args.ValidateNull(nameof(args));

            var argsCount = args.Count();

            if (argsCount != 1)
            {
                ErrorMessage = string.Format(CultureInfo.InvariantCulture,
                                             "Parameter should be used once. But used {0} times.",
                                             argsCount);
                return false;
            }

            ErrorMessage = string.Empty;
            return true;
        }
    }
}
