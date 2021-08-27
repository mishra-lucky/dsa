using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumEditDistanceRecurisve
{
    class Program
    {
        static void Main(string[] args)
        {
            String str1 = "sunday";
            String str2 = "saturdayy";

            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
                for (int j = 0; j <= str2.Length; j++)
                    dp[i, j] = -1;
            Console.Write(editDist(str1, str2, str1.Length -1, str2.Length -1, ref dp));
            Console.ReadLine();
        }

        private static int editDist(string str1, string str2, int i, int j, ref int[,] dp)
        {
            if (i == 0) return j;
            if (j == 0) return i;
            if (dp[i, j] != -1)
                return dp[i, j];
            if (str1[i] == str2[j])
                return dp[i,j] = editDist(str1, str2, i - 1, j - 1, ref dp);
            else
                return dp[i,j] = 1 + Math.Min(editDist(str1, str2, i - 1, j, ref dp), Math.Min(editDist(str1, str2, i, j - 1, ref dp), editDist(str1, str2, i - 1, j - 1, ref dp)));

        }
    }
}
