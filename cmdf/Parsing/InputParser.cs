// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System;

namespace CommandLineInterpreterFramework.Parsing
{
    // TODO: Implement

    /// <summary>
    /// Standard mechanism to parse console input
    /// </summary>
    public class InputParser : IInputParser<IParsedCommand>
    {
        /// <summary>
        /// Parses console input
        /// </summary>
        /// <param name="input">Console input</param>
        /// <exception cref="InputParserException"/>
        /// <returns>Parsed result</returns>
        public IParsedCommand Parse(string input)
        {
            throw new NotImplementedException();
        }
    }
}
