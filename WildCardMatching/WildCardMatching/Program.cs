using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildCardMatching
{
    class Program
    {        
        public static bool IsMatch(string s, string p, ref Dictionary<string, bool> dp)
        {
            if (s == null || p == null)
                return false;

            if (s == "")
                return p == "" || p == "*" || checkallchars(p ,'*'); // if string is empty, then check if pattern is empty.
            if (p == "")
                return s == ""; // blank pattern matches blank string.

            if (dp.ContainsKey(s + "|" + p))
                return dp[s + "|" + p];

            string newstring = "";
            string newpattern = "";            
            if (p[0] == '*')
            {
                newstring = s.Length > 1 ? s.Substring(1) : "";
                newpattern = p.Length > 1 ? p.Substring(1) : "";
                return dp[s + "|" + p] = IsMatch(newstring, p, ref dp) || IsMatch(s, newpattern, ref dp);
            }
            else if (p[0] == '?' || s[0] == p[0])
            {
                newstring = s.Length > 1 ? s.Substring(1) : "";
                newpattern = p.Length > 1 ? p.Substring(1) : "";
                return dp[ s + "|" + p] = IsMatch(newstring, newpattern, ref dp);

            }
            return dp[s + "|" + p] = false;
        }

        private static bool checkallchars(string p, char v)
        {
            bool ret = false;
            for(int i =1; i < p.Length; i++)
            {
                if (p[i - 1] == p[i] && p[i] == v)
                    ret = true;
                else
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }

        static void Main(string[] args)
        {
            string s = "aaaaaa";
            string p = "?*?b**";
            Dictionary<string, bool> dp = new Dictionary<string, bool>();
            bool ret = IsMatch(s, p, ref dp);
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
}
