using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01KnapSack
{
    class Program
    {
        public static int Kanpsack(int[] wt, int[] val, int cap, int n, ref int[,]dp)
        {
            if (n == 0)
                return 0;
            if (dp[n, cap] != -1)
                return dp[n, cap];
            if(cap >= wt[n])
            {
                return dp[n,cap] = Math.Max(val[n] + Kanpsack(wt, val, cap - wt[n], n - 1, ref dp),
                     Kanpsack(wt, val, cap, n - 1, ref dp)
                    );
            }
            else
            {
                return dp[n, cap] = Kanpsack(wt, val, cap, n - 1, ref dp);
            }
        }
        static void Main(string[] args)
        {
            int[] val = { 60, 100, 120 };
            int[] wt = { 10, 20, 30 };
            int W = 50;

            int[,] dp = new int[wt.Length + 1, W + 1];
            for (int i = 0; i <= wt.Length; i++)
                for (int j = 0; j <= W; j++)
                    dp[i, j] = -1;

            int maxProfit = Kanpsack(wt, val, W, wt.Length -1, ref dp);

            Console.WriteLine(maxProfit);
            Console.ReadLine();
        }
    }
}
