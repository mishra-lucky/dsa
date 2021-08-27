using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestIncreasingSubsequence
{
    class Program
    {
        public static int[] lis (int[] arr)
        {
            
            int[] dp = new int[arr.Length];
            int[] pos = new int[arr.Length];

            
            for (int i = 0; i < arr.Length; i++) pos[i] = -1;
            dp[0] = 1;

            int omax = 0;
            int maxpos = 0;
            for(int i = 1; i < arr.Length; i++)
            {
                int max = 0;
                int j;
                for(j = 0; j < i; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        if(max < dp[j])
                        {
                            max = dp[j];
                            pos[i] = j;
                        }
                    }
                }
                dp[i] = 1 + max;                
                if (omax < dp[i])
                {
                    omax = dp[i];
                    maxpos = i;                    
                }
            }

            int[] res = new int[omax];
            int k = omax-1;
            while(maxpos != -1)
            {
                res[k--] = arr[maxpos];
                maxpos = pos[maxpos];
            }
            return res;
        }
        static void Main(string[] args)
        {
            int[] arr = {3, 4, 5, 7, 1, 2, 8, 9, 1, 1 };
            int[] res = lis(arr);
            Console.WriteLine("Longest Increasing Subsequence is : " + string.Join(",", res).TrimEnd(','));
            Console.ReadLine();
        }
    }
}
