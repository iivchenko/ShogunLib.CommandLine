// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using ShogunLib.CommandLine.Commands.Parameters;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation;

namespace OwnClassesImplementation
{
    public class OwnParameter : IParameter
    {
        private readonly IArgumentValidator _validator;

        public OwnParameter(IArgumentValidator validator)
        {
            _validator = validator;
        }

        public IParameterInfo Info
        {
            get { return new ParameterInfo("OwnParameter", "Hm... this parameter needs for something..."); }
        }

        public IArgument Validate(IEnumerable<string> args)
        {
            if (!_validator.Validate(args))
            {
                throw new ArgumentValidationException(_validator.ErrorMessage);
            }

            return new OwnArgument(args);
        }
    }
}
