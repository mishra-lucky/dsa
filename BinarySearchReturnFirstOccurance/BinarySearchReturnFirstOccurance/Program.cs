using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchReturnFirstOccurance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 3, 4, 6, 6, 6};
            int target = 6;
            int i = getFirstOccurance(arr, target);
            Console.WriteLine(i);
            Console.ReadLine();
        }

        private static int getFirstOccurance(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return -1;
            if (arr.Length == 1) return arr[0] == target ? 0 : -1;
            int begin = 0, end = arr.Length - 1;

            while(begin <= end)
            {
                int mid = begin + ((end - begin) >> 1);

                if (arr[mid] >= target)
                {
                    if (arr[mid] == target && mid != 0 && arr[mid - 1] < target)
                        return mid;
                    end = mid - 1;
                }
                else
                {
                    begin = mid + 1;
                }
            }
            return -1;
        }
    }
}
