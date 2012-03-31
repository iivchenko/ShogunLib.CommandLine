// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;

namespace CommandLineInterpreterFramework.Console
{
    /// <summary>
    /// Defines lazy functionality to manipulate the input, output, and error streams for console applications. All needed actions should be defined by user
    /// </summary>
    public class LazyConsole : IConsole
    {
        /// <summary>
        /// Gets or sets action for Clear() method
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "This is a design")]
        public Action ClearAction { protected get; set; }

        /// <summary>
        /// Gets or sets action for Read() method
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "This is a design")]
        public Func<int> ReadAction { protected get; set; }

        /// <summary>
        /// Gets or sets action for ReadLine() method
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "This is a design")]
        public Func<string> ReadLineAction { protected get; set; }

        /// <summary>
        /// Gets or sets action for Write() method
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "This is a design")]
        public Action<string> WriteAction { protected get; set; }

        /// <summary>
        /// Gets or sets action for WriteLine() method
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1044:PropertiesShouldNotBeWriteOnly", Justification = "This is a design")]
        public Action<string> WriteLineAction { protected get; set; }

        /// <summary>
        /// Clears the console buffer and corresponding console window of display information
        /// </summary>
        public void Clear()
        {
            if (ClearAction != null)
            {
                ClearAction();
            }
        }

        /// <summary>
        /// Reads the next character from the standard input stream
        /// </summary>
        /// <returns>The next character from the input stream, or negative one (-1) if there are currently no more characters to be read</returns>
        public int Read()
        {
            return ReadAction != null ? ReadAction() : -1;
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream
        /// </summary>
        /// <returns>The next line of characters from the input stream, or null if no more lines are available</returns>
        public string ReadLine()
        {
            return ReadLineAction != null ? ReadLineAction() : null;
        }

        /// <summary>
        /// Writes the specified string value to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        public void Write(string value)
        {
            if (WriteAction != null)
            {
                WriteAction(value);
            }
        }

        /// <summary>
        /// Writes the specified string value, followed by the current line terminator, to the standard output stream
        /// </summary>
        /// <param name="value">The value to write</param>
        public void WriteLine(string value)
        {
            if (WriteLineAction != null)
            {
                WriteLineAction(value);
            }
        }
    }
}
