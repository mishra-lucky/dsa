using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestWayToFormWord
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = "abc";
            string target = "abcbc";
            int i = ShortestWay(source, target);
            Console.WriteLine(i);
            Console.ReadLine();
        }

        private static int ShortestWay(string source, string target)
        {
            int numSubstring = 0;
            string remainder = target;

            while(remainder.Length > 0)
            {
                StringBuilder subSeq = new StringBuilder();
                int i = 0, j = 0;
                while(i < source.Length && j < remainder.Length)
                {
                    if(source[i++] == remainder[j])
                    {
                        subSeq.Append(remainder[j++]);
                    }
                }
                if (subSeq.Length == 0)
                    return -1;
                numSubstring++;
                remainder = remainder.Remove(0, subSeq.Length);           
                
            }
            return numSubstring;
        }
    }
}
