using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintMatrixDiagonally
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
            PrintMatrixDiagonal(ref matrix);
            Console.ReadLine();
        }

       

        private static void PrintMatrixDiagonal(ref int[][] matrix)
        {
            bool up = true;
            int row =0, col = 0;
            while (true)
            {
                Console.WriteLine(matrix[row][col] + ", ");
               
                if((row ==0 || row == matrix.Length -1) && col != matrix[0].Length -1)
                {
                    col++;
                    Console.WriteLine(matrix[row][col] + ", ");
                    up = !up;
                }
                else if(col == 0 || col == matrix[0].Length - 1)
                {
                    row++;
                    Console.WriteLine(matrix[row][col] + ", ");
                    up = !up;
                }
                if (row == matrix.Length - 1 && col == matrix[0].Length - 1)
                    break;
                row = up ? row - 1 : row + 1;
                col = up ? col + 1 : col - 1;
            }
        }
    
    }
}
