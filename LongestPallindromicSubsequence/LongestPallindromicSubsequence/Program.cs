using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestPallindromicSubsequence
{
    class Program
    {
        public static int findLPS(string str, int left, int right, ref int[,] dp)
        {
            if (left > right) return 0;
            if (left == right) return 1;
           

            if (dp[left, right] != -1)
                return dp[left, right];
            if (str[left] == str[right])
            {
                return dp[left,right] = 2 + findLPS(str, left + 1, right - 1, ref dp);
            }
            else
                return dp[left, right] = Math.Max(findLPS(str, left, right - 1, ref dp), findLPS(str, left +1, right, ref dp));
        }
        static void Main(string[] args)
        {
            string str = "";
            int[,] dp = new int[str.Length +1, str.Length + 1];
            for (int i = 0; i <= str.Length; i++)
                for (int j = 0; j <= str.Length; j++)
                    dp[i, j] = -1;

            int l = findLPS(str, 0, str.Length - 1, ref dp);
            Console.Write(l);
            Console.ReadLine();
        }
    }
}
