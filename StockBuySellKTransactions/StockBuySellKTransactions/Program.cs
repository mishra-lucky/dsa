using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockBuySellKTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            //k = 2, prices = [3, 2, 6, 5, 0, 3]
            int k = 4;
            int[] prices = { 3, 2, 6, 5, 0, 3 };
            int profit = GetMaxProfit(prices, k);
            Console.WriteLine(profit);
            Console.ReadLine();
        }

        private static int GetMaxProfit(int[] prices, int k)
        {
            if (prices == null || prices.Length == 0 || k == 0)
                return 0;

            int[,] dp = new int[k + 1, prices.Length];
            for (int i = 0; i <= k; i++)
                for (int j = 0; j < prices.Length; j++)
                    dp[i, j] = -1;
            return getMax(prices, k, prices.Length -1, ref dp);
        }
        public static int getMax(int[] prices, int k, int i, ref int[,] dp)
        {
            if (k == 0)
                return 0;
            // We're at the start of the price list
            // so if we are in the middle of a transaction,
            // force the associated "buy"
            if (i == 0)
                return (k & 1) == 1 ? -prices[0] : 0;

            if (dp[k, i] != -1) return dp[k, i];
  // Current k is odd so we have completed a "sell" -
  // choose to record the associated "buy" or skip
            if ((k & 1) == 1)
            {
                return dp[k,i] = Math.Max(
                  -prices[i] + getMax(prices, k - 1, i - 1, ref dp), // buy
                  getMax(prices, k, i - 1, ref dp) // skip
                );
  // Current k is even so we have completed a "buy" or
  // are "at rest" - choose to record a new "sell" or skip
            }
            else
            {
                return dp[k,i] = Math.Max(
                  prices[i] + getMax(prices, k - 1, i - 1, ref dp), // sell
                  getMax(prices, k, i - 1, ref dp) // skip
                );
          }
        }
    }
}
