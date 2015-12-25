using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_safety
{
    public interface IStruct
    {
        Tuple<int, string> ReplaceFirst(string word, string replace);
    }
}
