using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChangePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] coins = {1,2,3};
            int amount = 4;

            int[] dp = new int[amount + 1];
                for (int j = 0; j <= amount; j++)
                    dp[j] = -1;
            int p = permutations(coins,amount, ref dp);
            Console.WriteLine(p);
            Console.ReadLine();
        }

        private static int permutations(int[] coins, int amount, ref int[] dp)
        {
            if (amount < 0)
                return 0;
            if (amount == 0)
                return 1;
            if (dp[amount] != -1)
                return dp[amount];

            int pc = 0;
            for(int i = 0; i < coins.Length; i++)
            {
                pc += permutations(coins, amount - coins[i], ref dp);
            }
            return dp [amount] = pc;
        }
    }
}
