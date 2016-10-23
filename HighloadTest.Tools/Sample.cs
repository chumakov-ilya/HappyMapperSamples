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
    }
}
