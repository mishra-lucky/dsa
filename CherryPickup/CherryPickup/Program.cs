using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CherryPickup
{
    class Program
    {
        static void Main(string[] args)
        {
            //[[0,1,-1],[1,0,-1],[1,1,1]]
            int[][] grid = { new int[] { 0, 1, -1 }, new int[] { 1, 0, -1 }, new int[] { 1, 1, 1 } };
            int count = 0, maxCount = int.MinValue;
            goForward(ref grid, 0, 0, ref count, ref maxCount);
            Console.WriteLine(maxCount);
            Console.ReadLine();
        }

        private static void goForward(ref int[][] grid, int i, int j, ref int count, ref int maxCount)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == -1)
                return;

            if(i == grid.Length -1 && j == grid[0].Length -1)
            {
                goBackWards(ref grid, i, j, ref count, ref maxCount);
                return;
            }

            if(grid[i][j] == 1)
            {
                grid[i][j] = 0;
                count++;
                goForward(ref grid, i + 1, j, ref count, ref maxCount);
                goForward(ref grid, i, j+1  , ref count, ref maxCount);
                count--;
                grid[i][j] = 1;
            }
            else
            {
                goForward(ref grid, i + 1, j, ref count, ref maxCount);
                goForward(ref grid, i, j + 1, ref count, ref maxCount);
            }
        }

        private static void goBackWards(ref int[][] grid, int i, int j, ref int count, ref int maxCount)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length || grid[i][j] == -1)
                return;

            if (i == 0 && j == 0)
            {
                count = grid[i][j] == 1 ? count + 1 : count;
                maxCount = Math.Max(count, maxCount);
                return;
            }


            if (grid[i][j] == 1)
            {
                grid[i][j] = 0;
                count++;
                goBackWards(ref grid, i - 1, j, ref count, ref maxCount);
                goBackWards(ref grid, i, j - 1, ref count, ref maxCount);
                count--;
                grid[i][j] = 1;
            }
            else
            {
                goBackWards(ref grid, i - 1, j, ref count, ref maxCount);
                goBackWards(ref grid, i, j -1, ref count, ref maxCount);
            }
        }
    }
}
