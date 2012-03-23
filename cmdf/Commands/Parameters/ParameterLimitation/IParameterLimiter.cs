// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

namespace CommandLineInterpreterFramework.Commands.Parameters.ParameterLimitation
{
    /// <summary>
    /// Define usage rules for specified parameter in command line
    /// </summary>
    public interface IParameterLimiter
    {
        /// <summary>
        /// Gets the validation failed message
        /// </summary>
        string ErrorMessage { get; }

        /// <summary>
        /// Performs count validation of the specified parameter. If validation failed ErrorMessage is set
        /// </summary>
        /// <param name="count">Number of times when parameter was used</param>
        /// <returns>true - validaion suceeded; false - validation filed</returns>
        bool Validate(uint count);
    }
}
