// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using ShogunLib.CommandLine.Commands.Parameters;
using ShogunLib.CommandLine.Commands.Parameters.ArgumentValidation;

namespace ShogunLib.CommandLine.Building
{
    /// <summary>
    /// Lazy parameter initialization.
    /// </summary>>
    public class ParameterBuilder : IParameterBuilder
    {
        private readonly string _name;
        private readonly CompositeArgumentValidator _validators;
        private string _description;

        /// <summary>
        /// Initializes a new instance of the ParameterBuilder class.
        /// </summary>
        /// <param name="name">Future parameter name.</param>
        public ParameterBuilder(string name)
        {
            name.ValidateStringEmpty(nameof(name));

            _name = name;
            _description = string.Empty;
            _validators = new CompositeArgumentValidator();
        }

        /// <summary>
        ///  Sets parameter description.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        public IParameterBuilder SetDescription(string description)
        {
            _description = description;

            return this;
        }

        /// <summary>
        /// Adds new validator to the end of validators list.
        /// </summary>
        /// <returns>Pointer to this.</returns>
        public IParameterBuilder AddValidator(IArgumentValidator validator)
        {
            validator.ValidateNull(nameof(validator));

            _validators.Add(validator);

            return this;
        }

        /// <summary>
        /// Create parameter with specified data.
        /// </summary>
        public IParameter Create()
        {
            return new Parameter(new ParameterInfo(_name, _description), _validators);
        }
    }
}
