using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighloadTest.Tools;
using NUnit.Framework;

namespace HighloadTest
{
    public class OutputWrapper
    {
        public void WriteLine()
        {
            Console.WriteLine();
        }
    }

    public class ClassPrinter_SmokeTests
    {
        [Test]
        public void PrintClasses_Test()
        {
            var namePairs = ClassPrinter.PrintClasses(new OutputWrapper(), 3);
        }
    }
}
