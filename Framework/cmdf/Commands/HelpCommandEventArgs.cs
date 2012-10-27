// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CommandLineInterpreterFramework.Commands
{
    /// <summary>
    /// Arguments of the Help Command executed.
    /// </summary>
    public class HelpCommandEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the HelpCommandEventArgs class.
        /// </summary>
        /// <param name="commands">Commands descriptions.</param>
        public HelpCommandEventArgs(IList<CommandDescriptor> commands)
        {
            Commands = new ReadOnlyCollection<CommandDescriptor>(commands);
        }

        /// <summary>
        /// Gets commands descriptions.
        /// </summary>
        public ReadOnlyCollection<CommandDescriptor> Commands { get; private set; }
    }
}
