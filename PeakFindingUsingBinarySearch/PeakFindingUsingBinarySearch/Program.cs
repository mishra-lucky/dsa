using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeakFindingUsingBinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //A = [1,3,4,5,2] => Peak = 5
            int[] nums = { 1, 3, 4, 5, 2};
            Console.WriteLine(string.Join(",", nums));

            int peak = findPeak(nums);
            Console.WriteLine(peak);
            Console.ReadLine();
        }
        private static int findPeak(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            if (arr.Length == 1) return arr[0];
            if (arr.Length == 2) return arr[0] > arr[1] ? arr[0] : arr[1];

            int begin = 0, end = arr.Length - 1;
            while(begin <= end)
            {
                int mid = begin + ((end - begin) >> 1);
                int left = mid > 0 ? arr[mid - 1] : int.MinValue;
                int right = mid < arr.Length - 1 ? arr[mid + 1] : int.MinValue;

                if (left < arr[mid] && arr[mid] < right) // increasing slope
                    begin = mid + 1;
                else if (left > arr[mid] && right < arr[mid]) // decreasing slope
                    end = mid - 1;
                else if (left > arr[mid] && right > arr[mid])
                    end = mid - 1;
                else
                    return arr[mid];
            }
            return -1;
        }
    }
}
