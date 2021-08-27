using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid = { new int[] { 1, 3, 1 }, new int[] { 1, 5, 1 }, new int[] { 4, 2, 1 } };
          
            int minsum =  FindMinimumSum(ref grid);
            Console.WriteLine(minsum);
            Console.ReadLine();
        }

        private static int FindMinimumSum(ref int[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;
            int[,] dp = new int[grid.Length, grid[0].Length];

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                    dp[i, j] = int.MaxValue;
            return dfs(ref grid, 0, 0, ref dp);
            
        }
        public static int dfs(ref int[][] grid, int i, int j, ref int[,] dp)
        {
            if (i >= grid.Length || j >= grid[0].Length)
                return int.MaxValue;
            if (i == grid.Length - 1 && j == grid[0].Length - 1)
            {
                dp[i, j] = grid[i][j];
                return grid[i][j];
            }
            if (dp[i, j] != int.MaxValue) return dp[i, j]; 
            return dp[i,j] = grid[i][j] + Math.Min( dfs(ref grid, i + 1, j, ref dp), dfs(ref grid, i, j + 1, ref dp));
        }
    }
}
