using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighloadTest.Tools
{
    public class Sample
    {
        public string MyProperty { get; set; }

        public static dynamic Init(dynamic replica)
        {
            replica.MyProperty = DateTime.Now.ToLongDateString();
            return replica;
        }

        public static void Compare(dynamic src, dynamic dest)
        {
            bool areEqual = true;

            areEqual = areEqual && src.MyProperty == dest.MyProperty;
            
            if (!areEqual) throw new Exception("Inequality!");
        }
    }
}
