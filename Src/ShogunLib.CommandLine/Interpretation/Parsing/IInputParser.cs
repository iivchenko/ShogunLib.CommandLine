// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace ShogunLib.CommandLine.Interpretation.Parsing
{
    /// <summary>
    /// Represents a mechanism to parse console input.
    /// </summary>
    public interface IInputParser
    {
        /// <summary>
        /// Parses console input. If input is null, empty string or whitespaces function should return null.
        /// </summary>
        /// <param name="input">Console input.</param>
        /// <returns>Parsed result.</returns>
        /// <exception cref="InputParserException">Input string contains incorrect format.</exception>
        IParsedCommand Parse(string input);
    }
}
