using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordFind
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] wordDict= { "cats", "dog", "sand", "and", "cat" };
            string s = "catsandog";
            bool fi = WordBreak(s, wordDict);
            Console.WriteLine(fi);
            Console.ReadLine();
        }
        public static bool WordBreak(string s, IList<string> wordDict)
        {
            if (s == null || wordDict == null || wordDict.Count == 0 || s.Length == 0) return false;
            Dictionary<string, bool> dp = new Dictionary<string, bool>();
            return wordFind(s, ref wordDict, ref dp);

        }
        public static bool wordFind(string s, ref IList<string> wordDict, ref Dictionary<string, bool> dp)
        {
            if (s.Length == 0) return true;
            if (dp.ContainsKey(s)) return dp[s];
            for (int i = 1; i <= s.Length; i++)
            {
                Console.WriteLine(s.Substring(0, i));
                if (wordDict.Contains(s.Substring(0, i)) &&
                  wordFind(s.Substring(i, s.Length - i), ref wordDict, ref dp))
                {
                    dp.Add(s, true);
                    return true;
                }
            }
            dp.Add(s, false);
            return false;
        }
    }
}
