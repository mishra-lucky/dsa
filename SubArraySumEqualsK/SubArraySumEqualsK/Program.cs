using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubArraySumEqualsK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 5, 2 };
            int sum = 8;
            int[] res = subArraySumK(arr, sum);
            Console.WriteLine(res[0] + " " + res[1]);
            Console.ReadLine();
        }

        private static int[] subArraySumK(int[] arr, int sum)
        {
            int[] result = new int[2];
            if (arr == null || arr.Length == 0) return result;

            int begin = 0, end = 0;
            int currSum = arr[begin];
            while(begin < arr.Length)
            {
                if(begin > end)
                {
                    end = begin;
                    sum = arr[begin];
                }
                if (currSum == sum)
                {
                    result[0] = begin;
                    result[1] = end;
                    break;
                }
                else if (currSum < sum)
                {
                    if (end >= arr.Length - 1)
                        break;

                    end++;
                    currSum += arr[end];
                }
                else
                {
                    currSum -= arr[begin];
                    begin++;                    
                }
                
            }
            return result;
        }
    }
}
