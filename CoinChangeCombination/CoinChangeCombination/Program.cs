using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangeCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = { 2, 5, 3, 6 };
            int amount = 10;
            int[,] dp = new int[coins.Length + 1, amount + 1];
            for (int i = 0; i <= coins.Length; i++)
                for (int j = 0; j <= amount; j++)
                    dp[i, j] = -1;
            int c = CoinChangeCombination(coins, coins.Length -1,  amount, ref dp);
            Console.WriteLine(c);
            Console.ReadLine();
        }

        private static int CoinChangeCombination(int[] coins, int index, int amount, ref int[,] dp)
        {
            if (amount == 0)
                return 1;
            if (index < 0 || amount < 0)
                return 0;

            if (dp[index, amount] != -1)
                return dp[index, amount];
            return dp[index, amount] = CoinChangeCombination(coins, index - 1, amount, ref dp) +
                    CoinChangeCombination(coins, index, amount - coins[index], ref dp);
            
           
        }
    }
}
