// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Globalization;

namespace CommandLineInterpreterFramework.Commands.Parameters.ArgumentValidation.TypeValidation
{
    /// <summary>
    /// Validate if specified arguments can be converted to the Int type.
    /// </summary>
    public class IntTypeValidator : IArgumentValidator
    {
        /// <summary>
        /// Initializes a new instance of the IntTypeValidator class.
        /// </summary>
        public IntTypeValidator()
        {
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Gets the error validation message if validation is failed.
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Validate console command arguments.
        /// </summary>
        /// <param name="args">Input arguments.</param>
        /// <returns>true - validation succeeded; false - fail.</returns>
        public bool Validate(IEnumerable<string> args)
        {
            if (args == null)
            {
                throw new ArgumentNullException("args");
            }

            var error = ErrorMessage = string.Empty;

            foreach (var arg in args)
            {
                int result;
                if (!int.TryParse(arg, out result))
                {
                    error = string.IsNullOrEmpty(error)
                                ? string.Format(CultureInfo.InvariantCulture,
                                                "Value {0} can't be converted to integer type.",
                                                arg)
                                : string.Format(CultureInfo.InvariantCulture,
                                                "{0}\nValue {1} can't be converted to integer type.",
                                                error,
                                                arg);
                }
            }

            if (!string.IsNullOrEmpty(error))
            {
                ErrorMessage = error;
                return false;
            }

            return true;
        }
    }
}