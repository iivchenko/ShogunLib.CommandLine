// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>shogun@ua.fm</email>

using System.Collections.Generic;

namespace CommandLineInterpreterFramework
{
    /// <summary>
    /// Provides functionality to work with the command
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets the name of the command. Name shouldn't have white spaces.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets command description
        /// </summary>
        string Description { get; }
        
        /// <summary>
        /// Gets description of the command parameters
        /// </summary>
        ICollection<IParameter> Parameters { get; }
        
        /// <summary>
        /// Performs specific action
        /// </summary>
        /// <param name="args">Command input arguments</param> 
        void Execute(IEnumerable<string> args);
    }
}
