using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentTree
{
    class Program
    {
        public static int CreateSegmentTree(int[] st, int si, int[] arr, int l, int r)
        {
            if (l == r)
            {
                st[si] = arr[l];
                return arr[l];
            }
            int mid = (l + r) / 2;
            st[si] = CreateSegmentTree(st, 2 * si + 1, arr, l, mid) 
                    + CreateSegmentTree(st, 2 * si + 2, arr, mid + 1, r);
            return st[si];
        }    
        public static int getSum(int[]st, int si, int sl, int sr, int l, int r)
        {
            if (l <= sl && r >= sr)
                return st[sl];
            if (l > sr || r < sl)
                return 0;
            int mid = (sl + sr) / 2;
            return getSum(st, 2 * si + 1, sl, mid, l, r) + getSum(st, 2 * si + 2, mid + 1, sr, l, r);
        }
        public static int findLengthOfST(int arrLen)
        {
            int h = (int)Math.Ceiling(Math.Log(arrLen + 1, 2));
            return (int)Math.Pow(2, h) - 1;
        } 
        public static void updateST(int[]st, int si,  int sl, int sr, int pos, int diff)
        {
            if (sl > pos || sr < pos)
                return;
            st[si] += diff;

            if(sl != sr)
            {
                int mid = (sl + sr) / 2;
                updateST(st, 2 * si + 1, sl, mid, pos, diff);
                updateST(st, 2 * si + 2, mid + 1, sr, pos, diff);
            }
        }   
        static void Main(string[] args)
        {
            int[] arr = {3, 4, 5, 7, 8, 9, 11, 14 };
            int[] st = new int[findLengthOfST(arr.Length)];
            CreateSegmentTree(st, 0, arr, 0, arr.Length - 1);
            int sum = getSum(st, 0, 0, arr.Length - 1, 3, 7);

            int diff = arr[3];
            arr[3] = 25;
            diff -= arr[3];

            updateST(st, 0, 0, arr.Length - 1, 3, diff);

            Console.ReadLine();
        }
    }
}
