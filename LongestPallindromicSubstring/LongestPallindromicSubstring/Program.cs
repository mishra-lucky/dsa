using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPallindromicSubstring
{
    class Program
    {
        public static string Manachers(string str)
        {
            string s1 = getModifiedString(str);
            int[] lps = new int[s1.Length];
            int c = 0, r = 0;

            for(int i =1; i<s1.Length -1; i++)
            {
                int mirror = c - (c - i);

                if(i < r)
                {
                    lps[i] = Math.Min(r-i, lps[mirror]);
                }

                while (s1[i + lps[i] + 1] == s1[i - lps[i] - 1])
                    lps[i]++;

                if(i > c)
                {
                    c = i;
                    r = i + lps[i];
                }
            }
            int maxlen = 0, maxpos = -1;
            for(int i=0; i<lps.Length;i++)
            {
                if(lps[i] >maxlen)
                {
                    maxlen = lps[i];
                    maxpos = i;
                }
            }

            if (maxpos != -1)
            {
                return str.Substring((maxpos - maxlen - 1) / 2, maxlen);
            }
            
            return string.Empty;
        }

        private static string getModifiedString(string str)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("@");
            foreach(char c in str)
            {
                sb.Append(c);
                sb.Append("#");
            }
            sb.Append("&");
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Dictionary<int, int> dct = new Dictionary<int, int>();
            string res = Manachers("abbabba");
            Console.WriteLine(res);
            Console.ReadLine();

        }
    }
}
