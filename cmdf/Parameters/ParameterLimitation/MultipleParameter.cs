// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System.Globalization;

namespace CommandLineInterpreterFramework.Parameters.ParameterLimitation
{
    /// <summary>
    /// Parameter should be used once or more
    /// </summary>
    public class MultipleParameter : IParameterLimiter
    {
        /// <summary>
        /// Initializes a new instance of the MultipleParameter class
        /// </summary>
        public MultipleParameter()
        {
            ErrorMessage = string.Empty;
        }

        /// <summary>
        /// Gets the validation failed message
        /// </summary>
        public string ErrorMessage { get; private set; }

        /// <summary>
        /// Performs count validation of the specified parameter. Parameter should be used once or more. If not than ErrorMessage is set
        /// </summary>
        /// <param name="count">Number of times when parameter was used</param>
        /// <returns>true - validaion suceeded; false - validation filed</returns>
        public bool Validate(uint count)
        {
            if (count == 0)
            {
                ErrorMessage = string.Format(CultureInfo.InvariantCulture,
                                             "Parameter should be used once or more. But used {0} times.", 
                                             count);
                return false;
            }

            ErrorMessage = string.Empty;
            return true;
        }
    }
}
