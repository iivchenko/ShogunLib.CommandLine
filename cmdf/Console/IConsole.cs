// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

namespace CommandLineInterpreterFramework.Console
{
    /// <summary>
    /// Defines functionality to manipulate the input, output, and error streams for console applications
    /// </summary>
    public interface IConsole
    {
        /// <summary>
        /// Clears the console buffer and corresponding console window of display information
        /// </summary>
        void Clear();

        /// <summary>
        /// Reads the next character from the standard input stream
        /// </summary>
        /// <returns>The next character from the input stream, or negative one (-1) if there are currently no more characters to be read</returns>
        int Read();

        /// <summary>
        /// Reads the next line of characters from the standard input stream
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available</returns>
        string ReadLine();

        /// <summary>
        /// Writes the specified string value to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        void Write(string value);

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        void WriteLine(string value);
    }
}
