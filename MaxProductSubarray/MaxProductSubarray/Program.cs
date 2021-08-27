using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProductSubarray
{
    class Program
    {
        public static int MaxProduct(int[] nums)
        {
            int maxprod = nums[0];
            int currprod = nums[0];

            int[] maxdp = Enumerable.Repeat(int.MinValue, nums.Length).ToArray();
            int[] mindp = Enumerable.Repeat(int.MaxValue, nums.Length).ToArray();

            for (int i=1; i < nums.Length; i++)
            {
                int max = getmax(nums, i - 1, ref maxdp, ref mindp);
                int min = getmin(nums, i - 1, ref maxdp, ref mindp);

                currprod = Math.Max(nums[i], Math.Max(nums[i] * max, nums[i] * min));

                maxprod = Math.Max(currprod, maxprod);
            }
            return maxprod;
        }
        public static int getmax(int[]nums, int index, ref int[] maxdp, ref int[] mindp)
        {
            if (index < 0) return 1;
            if (maxdp[index] != int.MinValue) return maxdp[index];
            return maxdp[index] = Math.Max(nums[index], Math.Max(nums[index] * getmax(nums, index - 1, ref maxdp, ref mindp), 
                nums[index] * getmin(nums, index -1, ref maxdp, ref mindp)));
        }
        public static int getmin(int[] nums, int index, ref int[] maxdp, ref int[] mindp)
        {
            if (index < 0) return 1;
            if (mindp[index] != int.MaxValue) return mindp[index];
            return mindp[index] = Math.Min(nums[index], Math.Min(nums[index] * getmin(nums, index - 1, ref maxdp, ref mindp), 
                nums[index] * getmax(nums, index - 1, ref maxdp, ref mindp)));
        }
        static void Main(string[] args)
        {
            int p = MaxProduct(new int[] {0, -1, 4, -4, 5, -2, -1, -1, -2, -3, 0, -3, 0, 1, -1, -4, 4, 6, 2, 3, 0, -5, 2, 1, -4, -2, -1, 3, -4, -6, 0, 2, 2, -1, -5, 1, 1, 5, -6, 2, 1, -3, -6, -6, -3, 4, 0, -2, 0, 2});
            Console.WriteLine(p);
            Console.ReadLine();
        }
    }
}
