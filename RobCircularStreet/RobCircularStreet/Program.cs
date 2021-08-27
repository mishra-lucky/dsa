using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobCircularStreet
{
    class Program
    {
        public static int Rob(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int[,] dp = new int[nums.Length, nums.Length];
            for (int i = 0; i < nums.Length; i++)
                for (int j = 0; j < nums.Length; j++)
                    dp[i, j] = -1;
            return maxProfit(nums, 0, nums.Length - 1, ref dp);
        }

        public static int maxProfit(int[] nums, int begin, int end, ref int[,] dp)
        {
            if (begin > end) return 0;

            if (dp[begin, end] != -1) return dp[begin, end];
            int include = 0, exclude = 0;

            if (begin == 0)
                include = nums[begin] + maxProfit(nums, begin + 2, end - 1, ref dp);
            else
                include = nums[begin] + maxProfit(nums, begin + 2, end, ref dp);

            exclude = maxProfit(nums, begin + 1, end, ref dp);

            Console.WriteLine(begin + " " + end + " " + include + " " + exclude);
            return dp[begin, end] = Math.Max(include, exclude);
        }
        static void Main(string[] args)
        {
            int p = Rob(new int[] { 1, 2, 1, 1 });
            Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
