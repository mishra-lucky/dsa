using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProfit2Trades
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = {9,3,2,1,5,7,2,8,3,4};
            int maxProfit = GetMaxProfit(ref prices);
            Console.WriteLine(maxProfit);
            Console.ReadLine();
        }

        private static int GetMaxProfit(ref int[] prices)
        {
            int[] max_till_i = new int[prices.Length];
            int[] max_from_i = new int[prices.Length];

            int minprice = int.MaxValue;
            for(int i=0; i < prices.Length; i++)
            {
                minprice = Math.Min(minprice, prices[i]);
                max_till_i[i] = prices[i] - minprice;
            }

            int maxPrice = int.MinValue;
            for(int i = prices.Length -1; i >= 0; i--)
            {
                maxPrice = Math.Max(maxPrice, prices[i]);
                max_from_i[i] = maxPrice - prices[i];
            }

            int omax = int.MinValue;
            for(int i=0; i<prices.Length; i++)
            {
                int maxsecondTrade = i < prices.Length - 1 ? max_from_i[i + 1] : 0;
                omax = Math.Max(omax, max_till_i[i] + maxsecondTrade);
            }
            return omax;
        }
    }
}
