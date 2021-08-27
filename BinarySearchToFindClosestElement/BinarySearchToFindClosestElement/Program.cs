using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchToFindClosestElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 4, 5, 6, 6, 8, 9 };
            int p = 7;
            int closest = FindClosest(arr, p);
            Console.WriteLine(closest);
            Console.ReadLine();
        }

        private static int FindClosest(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return -1;
            int lo = 0, hi = arr.Length - 1, mid =0;

            if (target < arr[0]) return arr[0];
            if (target > arr[arr.Length - 1]) return arr[arr.Length - 1];

            while(lo < hi)
            {
                mid = lo + (hi - lo) / 2;
                if(arr[mid] == target)
                {
                    return arr[mid];
                }
                else if(target < arr[mid])
                {
                    if (mid > 0 && target > arr[mid - 1])
                        return (target - arr[mid - 1] > arr[mid] - target) ? arr[mid] : arr[mid - 1];
                    hi = mid;
                }
                else // p > arr[mid]
                {
                    if (mid < arr.Length -1 && target < arr[mid + 1])
                        return (arr[mid + 1] - target > target - arr[mid]) ? arr[mid] : arr[mid + 1];
                    lo = mid + 1;
                }
            }

            return arr[mid];
        }
    }
}
