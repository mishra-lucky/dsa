using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePathsIII
{
    class Program
    {
        public static int path = 0;

        static void Main(string[] args)
        {
            int[][] grid = { new int[] { 1, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 2, -1 } };
            int startI = 0, startJ = 0;
            int endI = 0, endJ = 0;
            int count0 = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        startI = i; startJ = j;
                    }
                    else if (grid[i][j] == 2)
                    {
                        endI = i; endJ = j;
                    }
                    else if (grid[i][j] == 0)
                    {
                        count0++;
                    }
                }
            }
            dfs(ref grid, startI, startJ, endI, endJ, count0, 0);

            Console.WriteLine(path);
            Console.ReadLine();
        }
        public static void dfs(ref int[][] grid, int i, int j, int m, int n, int cz, int c)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == -1) return;
            if (i == m && j == n)
            {
                if (c == cz + 1)
                {
                    path++;
                }
                return;
            }
            grid[i][j] = -1;
            dfs(ref grid, i + 1, j, m, n, cz, c + 1);
            dfs(ref grid, i - 1, j, m, n, cz, c + 1);
            dfs(ref grid, i, j + 1, m, n, cz, c + 1);
            dfs(ref grid, i, j - 1, m, n, cz, c + 1);
            grid[i][j] = 0;
        }
    }
 }
