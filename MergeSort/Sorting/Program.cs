using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        public static void MergeSort(ref int[] arr, int left, int right)
        {
            if(left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSort(ref arr, left, mid);
                MergeSort(ref arr, mid + 1, right);
                Merge(ref arr, left, right, mid);
            }
        }

        private static void Merge(ref int[] arr, int left, int right, int mid)
        {
            
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];

            int i = 0, j = 0, k = 0;

            for (i = 0; i < n1; i++)
            {
                L[i] = arr[left + i];
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = arr[mid + 1 + j];
            }
            i = 0; j = 0;  k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] < R[j])
                    arr[k++] = L[i++];
                else
                    arr[k++] = R[j++];
            }

            while (i < n1)
                arr[k++] = L[i++];
            while (j < n2)
                arr[k++] = R[j++];

        }

        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 5, 4, 7, 8, 8, 9, 9, 21, 1, 15, 2, 4 };
            MergeSort(ref arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(",", arr).TrimEnd(','));
            Console.ReadLine();
        }
    }
}
