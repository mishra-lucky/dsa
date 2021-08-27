using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrambleString
{
    class Program
    {
        public static bool IsScramble(string s1, string s2, ref Dictionary<string, bool> dp)
        {
            if (s1 == null || s2 == null || s1.Length != s2.Length) return false;
            if (s1 == s2) return true;
            if (s1.Length == 1) return s1 == s2;
            if (s1.Length == 0) return true;

            if (dp.ContainsKey(s1 + "|" + s2)) return dp[s1 + "|" + s2];
            bool res = false;
            int n = s1.Length;
            for (int i = 1; i < n; i++)
            {

                res |= (IsScramble(s1.Substring(0,i), s2.Substring(n-i), ref dp) && IsScramble(s1.Substring(i), s2.Substring(0, n-i), ref dp));
                res |= (IsScramble(s1.Substring(0,i), s2.Substring(0,i), ref dp) && IsScramble(s1.Substring(i), s2.Substring(i), ref dp));

            }
            dp.Add(s1 + "|" + s2, res);
            return res;

        }
        static void Main(string[] args)
        {
            string s1 = "great";
            string s2 = "rgeat";

            Dictionary<string, bool> dp = new Dictionary<string, bool>();
            bool ret = IsScramble(s1, s2, ref dp);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
}
