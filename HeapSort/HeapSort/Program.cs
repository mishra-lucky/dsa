using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Program
    {
        public static void HeapSort(ref int[] arr)
        {
            int n = arr.Length;
            for (int i = n/2 -1; i >= 0;  i--)
                Heapify(ref arr, i, n);

            for (int i = n-1; i > 0; i--)
            {
                Swap(ref arr, 0, i);
                Heapify(ref arr, 0, i);
            }
        }

        private static void Heapify(ref int[] arr, int i, int n)
        {
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            int smallest = i;

            if (l < n && arr[l] <= arr[smallest])
                smallest = l;
            if (r < n && arr[r] < arr[smallest])
                smallest = r;
            if (smallest != i)
            {
                Swap(ref arr, i, smallest);
                Heapify(ref arr, smallest, n);
            }
        }
        public static void Swap(ref int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 5, 10, 4, 3, 9, 11, 4, 2, 5, 9 };
            HeapSort(ref arr);
            Console.WriteLine(string.Join(",", arr).TrimEnd(','));
            Console.ReadLine();
        }
    }
}
