// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation;

namespace OwnClassesImplementation
{
    public class OwnArgumentValidator : IArgumentValidator
    {
        public OwnArgumentValidator()
        {
            ErrorMessage = string.Empty;
        }

        public string ErrorMessage { get; private set; }

        public bool Validate(IEnumerable<string> args)
        {
            if (args == null || args.Count() != 1)
            {
                ErrorMessage = "args should not be a null value and should contain one value";
                return false;
            }

            if (args.First() != "own")
            {
                ErrorMessage = string.Format(CultureInfo.InvariantCulture, "args should be an 'own' value but have {0}", args.First());
                return false;
            }

            return true;
        }
    }
}
