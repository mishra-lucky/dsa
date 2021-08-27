using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestBitonicSubsequence
{
    class Program
    {
        public static int[] LBS(int[] arr)
        {
            int[] lis = new int[arr.Length];
            int[] pos = new int[arr.Length];
            int[] pos2 = new int[arr.Length];

            for(int i=0; i<arr.Length; i++)
            {
                pos[i] = -1; pos2[i] = -1;
            }

            lis[0] = 1;
            int omax = 0, maxpos = -1;

            for(int i=1; i< arr.Length; i++)
            {
                int max = 0;
                for(int j = 0; j <i; j++)
                {
                    if(arr[j] < arr[i])
                    {
                        if(max < lis[j])
                        {
                            max = lis[j];
                            pos[i] = j;
                        }
                    }
                }
                lis[i] = 1 + max;
                if (omax < lis[i])
                {
                    omax = lis[i];
                    maxpos = i;
                }
            }


            int[] lds = new int[arr.Length];
            int odmax = 0, odmaxpos = -1;

            lds[arr.Length-1] = 1;
            for(int i = arr.Length -1; i > 0; i--)
            {
                int iimax = 0;
                for (int j = arr.Length -1; j > i; j--)
                {
                    if(arr[j] < arr[i])
                    {
                        if(iimax < lds[j])
                        {
                            iimax = lds[j];
                            pos2[i] = j;
                        }
                    }
                }
                lds[i] = iimax + 1;
                if(odmax < lds[i])
                {
                    odmax = lds[i];
                    odmaxpos = i;
                }
            }


            int maxLbs = 0;
            for(int i =0; i <arr.Length; i++)
            {
                int lbsLen = lis[i] + lds[i] - 1;
                if (lbsLen > maxLbs)
                    maxLbs = lbsLen;
            }

            int[] lbs = new int[maxLbs];
            int k = maxLbs - odmax -1;
            int skip = 1;
            while(maxpos != -1)
            {
                if (skip-- > 0)
                {
                    maxpos = pos[maxpos];
                    continue;
                }
                lbs[k--] = arr[maxpos];
                maxpos = pos[maxpos];
            }
            k = maxLbs - odmax;
            while (odmaxpos != -1)
            {
                lbs[k++] = arr[odmaxpos];
                odmaxpos = pos2[odmaxpos];
            }

            return lbs;
        }
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 4, 7, 9, 10, 23, 1, 7, 2, 24, 22, 20, 11, 5, 8, 17 };
            int[] res = LBS(arr);
            Console.WriteLine(string.Join(",", res).TrimEnd(','));
            Console.ReadLine();
        }
    }
}
