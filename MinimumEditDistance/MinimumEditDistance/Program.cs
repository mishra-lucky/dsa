using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistance
{
    class Program
    {
        public static int MinDistance(string word1, string word2)
        {

            int[,] dp = new int[word1.Length + 1, word2.Length + 1];
            dp[0, 0] = 0;

            for (int i = 1; i < word1.Length + 1; i++)
                dp[i, 0] = i;
            for (int j = 1; j < word2.Length + 1; j++)
                dp[0, j] = j;

            for (int i = 1; i <= word1.Length; i++)
            {
                for (int j = 1; j <= word2.Length; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                    {
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                    }
                }
            }

            return dp[word1.Length, word2.Length];
        }
        static void Main(string[] args)
        {
            int res = MinDistance("abced", "abcdk");
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
