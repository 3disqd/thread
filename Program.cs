using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_safety
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder ourString = new StringBuilder("anananas");
            for (int i = 0; i < 15; i++)
                ourString.Append(ourString);
            var safeStruct = new NaiveStruct(new string[] { ourString.ToString() });
            var server = new SimpleServer(safeStruct);
        }
    }
}
