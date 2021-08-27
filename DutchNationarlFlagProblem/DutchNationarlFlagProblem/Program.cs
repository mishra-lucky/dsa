using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchNationarlFlagProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 5, 2, 4, 4, 6, 4, 4, 3 };
            int pivot = 4;

            PartitionTo3(ref a, pivot);
            Console.WriteLine(string.Join(",", a));
            Console.ReadLine();
        }

        private static void PartitionTo3(ref int[] a, int pivot)
        {
            if (a == null || a.Length == 0) return;
            int lb = 0, hb = a.Length - 1;
            int i = 0;
            while(i < hb)
            {
                if (a[i] < pivot)
                {
                    swap(ref a, i, lb);
                    lb++;
                    i++;
                }
                else if (a[i] > pivot)
                {
                    swap(ref a, i, hb);
                    hb--;
                }
                else
                    i++;
            }

        }

        private static void swap(ref int[] a, int i, int hb)
        {
            int temp = a[i];
            a[i] = a[hb];
            a[hb] = temp;
        }
    }
}
