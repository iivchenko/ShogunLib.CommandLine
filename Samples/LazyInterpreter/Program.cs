// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

namespace LazyInterpreter
{
    /// <summary>
    /// Entry point
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        public static void Main()
        {
            var interpreter = Interpreter.Create();

            interpreter.Run();
        }
    }
}
