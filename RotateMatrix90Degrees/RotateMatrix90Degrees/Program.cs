using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrix90Degrees
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix =
          {
                new int[] {1, 2,  3,  4,  5},
                new int[] {6, 7,  8,  9,  10},
                new int[] {11,12, 13, 14, 15},
                new int[] {16,17, 18, 19, 20},
                new int[] {21,22, 23, 24, 25}
            };
            printMatrix(ref matrix);
            RotateBy90Degrees(ref matrix);
            printMatrix(ref matrix);
            Console.ReadLine();
        }

        private static void printMatrix(ref int[][] matrix)
        {
            for(int i=0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void RotateBy90Degrees(ref int[][] matrix)
        {            
            
            for(int layer = 0; layer < matrix.Length/2; layer++)
            {
                int firstrow = layer, firstcol = layer;
                int lastrow = matrix.Length - 1 - layer, lastcol = matrix[0].Length - 1 - layer;
                for (int offset =0; offset < (lastrow-firstrow) ; offset++)
                {
                    int temp = matrix[firstrow][firstcol + offset];
                    matrix[firstrow][firstcol + offset] = matrix[lastrow - offset][firstcol];
                    matrix[lastrow - offset][firstcol] = matrix[lastrow][lastcol - offset];
                    matrix[lastrow][lastcol - offset] = matrix[firstrow + offset][lastcol];
                    matrix[firstrow + offset][lastcol] = temp;
                   

                }
                printMatrix(ref matrix);
            }
        }
    }
}
