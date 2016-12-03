// <copyright company="XATA">
//      Copyright (c) 2017, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using System.Collections.Generic;
using ShogunLib.CommandLine.Commands.Parameters;

namespace OwnClassesImplementation
{
    public class OwnArgument : IArgument
    {
        public OwnArgument(IEnumerable<string> values)
        {
            Values = values;
        }

        public string Name
        {
            get { return "OwnArgument"; }
        }

        public IEnumerable<string> Values { get; private set; }
    }
}
