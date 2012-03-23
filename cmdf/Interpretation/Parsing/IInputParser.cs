// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

namespace CommandLineInterpreterFramework.Interpretation.Parsing
{
    /// <summary>
    /// Represents a mechanism to parse console input
    /// </summary>
    public interface IInputParser
    {
        /// <summary>
        /// Parses console input. If input is null, empty string or whitespacese function should return null
        /// </summary>
        /// <param name="input">Console input</param>
        /// <returns>Parsed result</returns>
        /// <exception cref="InputParserException"/>
        IParsedCommand Parse(string input);
    }
}
