using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchFindInsertIndex
{
    class Program
    {
        static void Main(string[] args)
        {
            // A = [1,2,4,4,5,6,8] and T = 3
            int[] arr = { 1, 2, 4, 4, 5, 6, 8 };
            int target = 9;
            int i = FindInsertIndex(arr, target);
            Console.Write(i);
            Console.ReadLine();
        }

        private static int FindInsertIndex(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return -1;
            int begin = 0, end = arr.Length - 1;

            while(begin <= end)
            {
                int mid = begin + ((end - begin) >> 1);
                if(arr[mid] >= target)
                {
                    if (mid > 0 && arr[mid - 1] < target)
                        return mid;
                    end = mid - 1;
                }
                else
                {
                    if (mid < arr.Length -1 && arr[mid + 1] > target)
                        return mid +1;
                    begin = mid + 1;
                }
            }
            return begin;
        }
    }
}
