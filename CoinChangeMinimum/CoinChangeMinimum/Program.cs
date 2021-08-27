using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangeMinimum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 1, 2, 5 };
            int amount = 11;

            int[] dp = Enumerable.Repeat(-1, amount + 1).ToArray();

            int c=  getMinimumCoins(coins, amount, ref dp);
            Console.Write(c);
            Console.ReadLine();
        }

        private static int getMinimumCoins(int[] coins, int amount, ref int[] dp)
        {
            if (amount <= 0) return 0;
            if (dp[amount] != -1) return dp[amount];
            int min = int.MaxValue;

            for(int i=0; i< coins.Length; i++)
            {
                if(coins[i] <= amount)
                {
                    int m = getMinimumCoins(coins, amount - coins[i], ref dp);
                    if(m  != int.MaxValue && m + 1 < min)
                    {
                        min = m + 1;
                    }
                }
            }
            return dp[amount] = min;
        }
    }
}
