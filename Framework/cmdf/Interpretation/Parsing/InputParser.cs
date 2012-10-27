// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandLineInterpreterFramework.Interpretation.Parsing
{
    /// <summary>
    /// Standard mechanism to parse console input.
    /// </summary>
    public class InputParser : IInputParser
    {
        /// <summary>
        /// Parses console input. If input is null, empty string or whitespaces function will return null.
        /// </summary>
        /// <param name="input">Console input.</param>
        /// <exception cref="InputParserException"/>
        /// <returns>Parsed result.</returns>
        public IParsedCommand Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (!IsCorrectNumberOfDubleQuotes(input))
            {
                throw new InputParserException("Error number of double quotes are used. There are must be even number of double quotes.");
            }

            var parameters = CreateParameters(input);
            var name = parameters[0];
            var args = parameters.GetRange(1, parameters.Count - 1); // Exclude name from parameters list

            return new ParsedCommand(name, args);
        }

        private static bool IsCorrectNumberOfDubleQuotes(string input)
        {
            // We should to delete all \" strings from input string to perform validation for "
            var temp = input.Replace("\\\"", string.Empty);
            var template = new Regex("\"");

            // If there is even number of double quotes returns true else false
            return template.Matches(temp).Count % 2 == 0 ? true : false;
        }
        
        private static List<string> CreateParameters(string input)
        {
            var args = new List<string>();
            var arg = new StringBuilder();
            var doubleQuotesAreOpened = false;

            for (var i = 0; i < input.Length; i++)
            {
                // it is possible to create new argument if there is no open double quote
                if (!doubleQuotesAreOpened)
                {
                    // next argument check
                    if (input[i] == ' ')
                    {
                        // current argument is ready and creation of the new argument will be started
                        if (arg.Length > 0)
                        {
                            args.Add(arg.ToString());
                            arg.Clear();
                        }

                        continue;
                    }
                }

                // " check
                if (input[i] == '\"')
                {
                    // There is could be opened or closed double quote
                    doubleQuotesAreOpened = !doubleQuotesAreOpened;
                    continue;
                }

                // \" check
                // This double quote should be a part of argument without slash
                if (input[i] == '\\')
                {
                    if (i + 1 <= input.Length - 1 && input[i + 1] == '\"')
                    {
                        i++;
                    }
                }

                arg.Append(input[i]);
            }

            // Last parameter should be added separatly
            if (arg.Length > 0)
            {
                args.Add(arg.ToString());
            }
            
            return args;
        }
    }
}
