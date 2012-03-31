// <copyright company="XATA">
//      Copyright (c) 2012, All Right Reserved
// </copyright>
// <author>Ivan Ivchenko</author>
// <email>iivchenko@live.com</email>

using CommandLineInterpreterFramework.Console;
using NUnit.Framework;

namespace CommandLineInterpreterFramework.Tests.Unit.Console
{
    [TestFixture]
    public class LazyConsoleTests
    {
        [Test]
        public void Clear_NullClearAction_DoNothing()
        {
            var console = new LazyConsole();

            console.Clear();
        }

        [Test]
        public void Clear_ClearActionIsSet_ClearActionExecuted()
        {
            var executed = false;
            var console = new LazyConsole
                              {
                                  ClearAction = () => executed = true
                              };

            console.Clear();

            Assert.IsTrue(executed);
        }

        [Test]
        public void Read_NullReadAction_DoNothing()
        {
            const int DefaultValue = -1;

            var console = new LazyConsole();

            Assert.AreEqual(DefaultValue, console.Read());
        }

        [Test]
        public void Read_ReadActionIsSet_ReadActionExecuted()
        {
            var executed = false;
            var console = new LazyConsole
            {
                ReadAction = () => { executed = true; return 0;}
            };

            console.Read();

            Assert.IsTrue(executed);
        }

        [Test]
        public void ReadLiner_NullReadLineAction_DoNothing()
        {
            var console = new LazyConsole();

            Assert.IsNull(console.ReadLine());
        }

        [Test]
        public void ReadLine_ReadLineActionIsSet_ReadLineActionExecuted()
        {
            var executed = false;
            var console = new LazyConsole
            {
                ReadLineAction = () => { executed = true; return string.Empty; }
            };

            console.ReadLine();

            Assert.IsTrue(executed);
        }

        [Test]
        public void Write_NullWriteAction_DoNothing()
        {
            var console = new LazyConsole();

            console.Write(string.Empty);
        }

        [Test]
        public void Write_WriteActionIsSet_WriteActionExecuted()
        {
            var executed = false;
            var console = new LazyConsole
            {
                WriteAction = (s) => { executed = true; }
            };

            console.Write(string.Empty);

            Assert.IsTrue(executed);
        }

        [Test]
        public void WriteLine_NullWriteLineAction_DoNothing()
        {
            var console = new LazyConsole();

            console.WriteLine(string.Empty);
        }

        [Test]
        public void WriteLine_WriteLineActionIsSet_WriteLineActionExecuted()
        {
            var executed = false;
            var console = new LazyConsole
            {
                WriteLineAction = (s) => { executed = true; }
            };

            console.WriteLine(string.Empty);

            Assert.IsTrue(executed);
        }
    }
}
