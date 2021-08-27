using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSubstringWithAllChars
{
    class Program
    {
        public static string MinWindow(string s, string t)
        {

            if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return null;
            if (s.Length < t.Length) return null;

            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach (char c in t)
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;

           
            int begin = 0, end = 0;
            int minLen = int.MaxValue;
            int lbegin = 0;

            while(begin < s.Length)
            {
                Dictionary<char, int> sCounts = new Dictionary<char, int>();
                if (begin > end)
                    end = begin;

                bool expanded = false;            
                while(!keysEqual(sCounts, counts))
                {
                    if (end >= s.Length)
                        break;
                    char c = s[end];
                    if(counts.ContainsKey(c))
                    {
                        if (sCounts.ContainsKey(c))
                            sCounts[c]++;
                        else 
                            sCounts[c] = 1; 
                    }
                    end++;
                    expanded = true;
                }
                if (expanded) end--;

                bool contracted = false;
                while(keysEqual(sCounts, counts))
                {
                    if (begin > s.Length)
                        break;
                    char c = s[begin];
                    if (sCounts.ContainsKey(c))
                    {
                        sCounts[c]--;
                    }
                    begin++;
                    contracted = true;
                }

                if (contracted)
                {
                    begin--;
                    int len = end - begin + 1;
                    if (len < minLen)
                    {
                        lbegin = begin;
                        minLen = len;
                    }
                }
                begin++;
                end = begin;

            }
            return minLen == int.MaxValue ? "" : s.Substring(lbegin, minLen);

        }

        private static bool keysEqual(Dictionary<char, int> sCounts, Dictionary<char, int> counts)
        {
            if (sCounts.Keys.Count != counts.Keys.Count)
                return false;
          
            foreach(var kvp in sCounts)
            {
               if (!counts.ContainsKey(kvp.Key) || kvp.Value < counts[kvp.Key])
                    return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            //string res = MinWindow("ADOBECODEBANC","ABC");
            string res = MinWindow("aaaaaaaaaaaabbbbbcdd", "abcdd");

            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
