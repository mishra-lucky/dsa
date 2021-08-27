using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        public static void QuickSort(ref int[] arr, int low, int high)
        {
            if(low < high)
            {
                int p = Partition(ref arr, low, high);

                QuickSort(ref arr, low, p);
                QuickSort(ref arr, p + 1, high);
            }
        }

        private static int Partition(ref int[] arr, int low, int high)
        {
            int pivot = low;

            int i = low; int j = high;
            while(i < j)
            {
                do
                {
                    i++;
                } while (i < high && arr[i] <= arr[pivot]);
                do
                {
                    j--;
                } while (j > low && arr[j] >= arr[pivot]);

                if (i <= j)
                    Swap(ref arr, i, j);
            }
            Swap(ref arr, pivot, j);
            return j;
        }

        public static void Swap(ref int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        static void Main(string[] args)
        {
            int[] arr = { 4, 5, 3, 7, 9, 9, 6, 7, 1, 2, 3, 21, 10, 15};
            QuickSort(ref arr, 0, arr.Length);
            Console.WriteLine(string.Join(",", arr).TrimEnd(','));
            Console.ReadLine();
        }
    }
}
