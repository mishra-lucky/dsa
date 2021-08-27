using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    class Program
    {
        public static string LCS (string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];
            
            for(int r=1; r<=s1.Length; r++)
            {
                for(int c=1; c <=s2.Length; c++)
                {
                    if(s1[r-1] == s2[c-1])
                    {
                        dp[r, c] = 1 + dp[r - 1, c - 1];
                    }
                    else
                    {
                        dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]);
                    }
                }
            }

            int maxLen = dp[s1.Length, s2.Length];
            char[] ret = new char[maxLen];
            int i = s1.Length, j = s2.Length, k = maxLen -1;
            while(i > 0 || j > 0)
            {
                if(s1[i-1] == s2[j-1]) // dp[i,j] = 1 + dp[i-1, j-1]
                {
                    ret[k] = s1[i-1];
                    i--; j--; k--;
                }
                else
                {
                    if (dp[i - 1, j] > dp[i, j - 1])
                    {
                        i--;

                    }
                    else
                    {
                        j--;
                    }
                }
            }

            return new string(ret);
        }
        static void Main(string[] args)
        {
            string s1 = "abbce";
            string s2 = "ace";
            string lcs = LCS(s1, s2);
            Console.WriteLine("Longest common subsequence is " + lcs);
            Console.ReadLine();
        }
    }
}
