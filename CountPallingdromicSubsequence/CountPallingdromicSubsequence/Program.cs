using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountPallingdromicSubsequence
{
    class Program
    {
        public static long CountPalindromicSubsequences(string s)
        {

            if (s == null || s.Length == 0) return 0;
            long[,] dp = new long[s.Length, s.Length];
            for (int i = 0; i < s.Length; i++)
                for (int j = 0; j < s.Length; j++)
                    dp[i, j] = -1;
            return count(s,0, s.Length -1, ref dp);
        }       
        public static long count(string s, int start,  int end, ref long[,] dp)
        {
            if (start < 0 || start >= s.Length || end < 0 || end >= s.Length || end < start) return 0;
            if (end == start) return 1;
            if (dp[start, end] != -1) return dp[start, end];
            else if (s[start] == s[end]) return dp[start, end] = 1 + count(s, start + 1, end, ref dp) + count(s, start, end - 1, ref dp);
            else return dp[start, end] = count(s, start + 1, end, ref dp) + count(s, start, end - 1, ref dp) - count(s, start + 1, end - 1, ref dp);
        }
        static void Main(string[] args)
        {
            long i = CountPalindromicSubsequences("abcdabcdabcdabcdabcdabcdabcdabcddcbadcbadcbadcbadcbadcbadcbadcba");
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
