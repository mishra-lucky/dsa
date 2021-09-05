using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISRecursive
{
    class Pair
    {
        public Pair(int index, int prev)
        {
            this.index = index;
            this.prev = prev;
        }

        public int index { get; set; }
        public int prev { get; set; }
    }
    class Program
    {
        public static Dictionary<Pair, int> dp = new Dictionary<Pair, int>();

        static void Main(string[] args)
        {
            int[] arr = { 11, 6, 8, 3, 2, 1, 6, 9, 12, 14, 15, 18 };
            int n = Lis(arr, 0, int.MinValue);

            var k = dp.First(x => x.Value == n).Key;
            int[] actLis = getSubarr(arr, k.index, n);
            Console.WriteLine(n);
            Console.ReadLine();
        }

        private static int[] getSubarr(int[] arr, int index, int n)
        {
            int[] res = new int[n];
            for(int i=0; i < n; i++)
            {
                res[i] = arr[index + i];
            }
            return res;
        }

        private static int Lis(int[] arr, int i, int prev)
        {
            if (i == arr.Length)
                return 0;
            Pair key = new Pair(i, prev);
            if (dp.ContainsKey(key)) return dp[key];

            int exclude = Lis(arr, i + 1, prev);
            int include = 0;
            if (arr[i] > prev)
            {
                include = 1 + Lis(arr, i + 1, arr[i]);
            }

            int val = Math.Max(include, exclude);
            dp.Add(key, val);
            return val;
        }
	}
}
