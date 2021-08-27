using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubStringWithUniqueChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "whatwhywhere";
            string s1 = maxSubstringWithUniqueChar(s);
            Console.WriteLine(s1);
            Console.ReadLine();
        }

        private static string maxSubstringWithUniqueChar(string s)
        {
            if (string.IsNullOrEmpty(s)) return string.Empty;
            Dictionary<char, int> charAndPos = new Dictionary<char, int>();
            int[] res = new int[2];
            int begin = 0, end = 0;

            while(end < s.Length)
            {
                if(charAndPos.ContainsKey(s[end]) && charAndPos[s[end]] >= begin)
                {                   
                    begin = charAndPos[s[end]] + 1;
                }
                charAndPos[s[end]] =  end;
                end++;
                if ((res[1] - res[0]) < end - begin)
                {
                    res[0] = begin;
                    res[1] = end;
                }
            }

            return s.Substring(res[0], res[1] - res[0]);
        }
    }
}
