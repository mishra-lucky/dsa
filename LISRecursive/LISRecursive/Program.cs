using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISRecursive
{
    class Program
    {
        public static int LIS(int[]arr)
        {
            int last = int.MinValue;
            int[] dp = Enumerable.Repeat(-1, arr.Length).ToArray();
            arr[0] = 1;
            int l = _lis(arr,0, arr.Length -1, ref last, ref dp);
            return l;
        }
        public static int _lis(int[] arr, int i, int n, ref int last , ref int[] dp)
        {
            if (i == n)
            {
                return 0;
            }

            if (dp[i] != -1)
                return dp[i];
            int include=0, exulde = 0;
            if (arr[i] > last)
            {
                last = arr[i];
                include =  1 + _lis(arr, i +1, n, ref last, ref dp);

            }
            exulde =  _lis(arr, i+1, n, ref last, ref dp);

            return dp[i] = Math.Max(include, exulde);

        }
        static void Main(string[] args)
        {
            int l = LIS(new int[] {4, 6, 8, 10, 3, 2, 11, 15, 13, 12 });
            Console.WriteLine(l);
            Console.ReadLine();
        }
    }
}
