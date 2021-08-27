using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnBoundedKnapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] wt = { 1, 3, 4, 5 };
            int[] val = { 10, 40, 50, 70 };
            int capacity = 8;

            int c = maxProfit(wt, val, capacity, wt.Length - 1);
            Console.WriteLine(c);
            Console.ReadLine();
        }

        private static int maxProfit(int[] wt, int[] val, int capacity, int index)
        {
            if (capacity <= 0) return 0;
            if (index < 0) return 0;

            int include = 0, exclude = 0;
            if (wt[index] <= capacity)
            {
                include = val[index] + maxProfit(wt, val, capacity - wt[index], index);
            }
            exclude = maxProfit(wt, val, capacity, index - 1);

            return Math.Max(include, exclude);
           
        }
    }
}
