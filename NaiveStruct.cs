using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_safety
{
    public class NaiveStruct : IStruct
    {
        public string[] Strings;

        public NaiveStruct(string[] strings)
        {
            this.Strings = strings;
        }

        public Tuple<int, string> ReplaceFirst(string word, string replace)
        {
            for (int i = 0; i < Strings.Length; i++)
            {
                var place = Strings[i].IndexOf(word, 0, StringComparison.Ordinal);
                if (place != -1)
                {
                    Strings[i] = Strings[i].Remove(place, word.Length);
                    Strings[i] = Strings[i].Insert(place, replace);
                    return new Tuple<int, string>(i, Strings[i]);
                }
            }
            return null;
        }
    }
}
