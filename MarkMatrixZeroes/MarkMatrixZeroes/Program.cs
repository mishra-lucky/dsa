using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMatrixZeroes
{
    class Program
    {
        public static void SetZeroes(int[][] matrix)
        {
            bool firstrow = false, firstcol = false;
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        if (i == 0 && j == 0)
                        {
                            firstrow = true;
                            firstcol = true;
                        }
                        else if (i == 0)
                        {
                            firstrow = true;
                        }
                        else if (j == 0)
                        {
                            firstcol = true;
                        }
                        else
                        {
                            matrix[i][0] = matrix[0][j] = 0;
                            matrix[i][j] = int.MaxValue;
                        }

                    }
                }
            }

            for (int j = 1; j < matrix[0].Length; j++)
            {
                if (matrix[0][j] == 0)
                    setColumnToZero(ref matrix, j);
            }
            for (int i = 1; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                    setRowToZero(ref matrix, i);
            }
            if (firstrow)
                setRowToZero(ref matrix, 0);
            if (firstcol)
                setColumnToZero(ref matrix, 0);

            printMatrix(ref matrix);
        }
        public static void printMatrix(ref int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + ",");
                }
                Console.WriteLine();
            }
        }
        public static void setColumnToZero(ref int[][] matrix, int j)
        {
            for (int i = 0; i < matrix.Length; i++)
                matrix[i][j] = 0;
        }

        public static void setRowToZero(ref int[][] matrix, int i)
        {
            for (int j = 0; j < matrix[0].Length; j++)
                matrix[i][j] = 0;
        }
        static void Main(string[] args)
        {
            int[][] matrix = { new int[] { 0, 1, 2, 0 }, new int[] { 3, 4, 5, 2 }, new int[] { 1, 3, 1, 5 } };
            SetZeroes(matrix);
        }
    }
}
