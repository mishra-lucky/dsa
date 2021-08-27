using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxAreaSquare
{
    class Program
    {
        public static int MaximalSquare(char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;

            int max = 0;
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j =0; j < matrix[0].Length; j++)
                {
                    int area = maxSquare(ref matrix, i, j);
                    if (area > max)
                        max = area;
                }
            }
            return maxSquare(ref matrix, 0, 0) * 2;
        }

        public static int maxSquare(ref char[][] grid, int i, int j)
        {
            if (i >= grid.Length || j >= grid[0].Length) return 0;

            int l = maxSquare(ref grid, i, j + 1);
            int b = maxSquare(ref grid, i + 1, j);
            int d = maxSquare(ref grid, i + 1, j + 1);

            int min = Math.Min(l, Math.Min(b, d));
            if (grid[i][j] == '1')
                return 1 + min;
            else
                return 0;
        }

        static void Main(string[] args)
        {
            char[][] matrix = {new char[] {'1', '1', '1', '1', '0'},
                               new char[] {'1', '1', '1', '1', '0'},
                               new char[] {'1', '1', '1', '1', '1'},
                               new char[] {'1', '1', '1', '1', '1'},
                               new char[] {'0', '0', '1', '1', '1'}
            };
            int max = MaximalSquare(matrix);
            Console.WriteLine(max);
            Console.ReadLine();
        }
    }
}
