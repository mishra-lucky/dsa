using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixChainMultiplication
{
    class Program
    {
        public static int MCM (int[] arr, int left, int right, ref int[,] memo)
        {
            if (left == right)
                return 0;
            if (memo[left, right] != -1)
                return memo[left, right];
            int mincount = int.MaxValue;
            for(int k = left; k < right; k++)
            {
                int leftP = MCM(arr, left, k,ref memo);
                int rightP = MCM(arr, k + 1, right,ref memo);
                int currentProd = arr[left-1] * arr[k] * arr[right];
                int total = leftP + rightP + currentProd;
                if (total < mincount)
                    mincount = total;               

            }
            memo[left, right] = mincount;
            return mincount;
        }
        static void Main(string[] args)
        {
            int[] matC = { 10,20,30,40, 50, 60};
            int[,] memo = new int[matC.Length, matC.Length];
            for (int i = 0; i < matC.Length; i++)
                for (int j = 0; j < matC.Length; j++)
                    memo[i, j] = -1;
            int minCount = MCM(matC, 1, matC.Length - 1, ref memo);
            Console.WriteLine(minCount);
            Console.ReadLine();

        }
    }
}
