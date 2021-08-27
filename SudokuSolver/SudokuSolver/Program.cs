using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static char[,] solved = new char[9, 9];

        public static void solve(char[][] board, int row, int col, int lastrow, int lastcol)
        {
            if (row == lastrow)
            {
                for (int i = 0; i < lastrow; i++)
                    for (int j = 0; j < lastcol; j++)
                        solved[i, j] = board[i][j];

                return;
            }
            int nextrow = row; int nextcol = col;
            if (col == lastcol - 1)
            {
                nextrow = row + 1;
                nextcol = 0;
            }
            else
                nextcol = col + 1;

            if (board[row][col] == '.')
            {
                for (char i = '1'; i <= '9'; i++)
                {
                    if (canPlaceDigit(board, row, col, i))
                    {
                        board[row][col] = i;
                        solve(board, nextrow, nextcol, lastrow, lastcol);
                        board[row][col] = '.';
                    }                    
                }
            }
            else
                solve(board, nextrow, nextcol, lastrow, lastcol);
        }

        public static bool canPlaceDigit(char[][] grid, int row, int col, char opt)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                if (grid[i][col] == opt)
                    return false;
            }

            for (int j = 0; j < grid.Length; j++)
            {
                if (grid[row][j] == opt)
                    return false;
            }

            int sr = 3 * (row / 3);
            int sc = 3 * (col / 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[sr + i][sc + j] == opt)
                        return false;
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            char[][] board = {
            new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'},
            new char[]{'6', '.', '.', '1', '9', '5', '.', '.', '.'},
            new char[]{'.', '9', '8', '.', '.', '.', '.', '6', '.'},
            new char[]{'8', '.', '.', '.', '6', '.', '.', '.', '3'},
            new char[]{'4', '.', '.', '8', '.', '3', '.', '.', '1'},
            new char[]{'7', '.', '.', '.', '2', '.', '.', '.', '6'},
            new char[]{'.', '6', '.', '.', '.', '.', '2', '8', '.'},
            new char[]{'.', '.', '.', '4', '1', '9', '.', '.', '5'},
            new char[]{'.', '.', '.', '.', '8', '.', '.', '7', '9'}};
            solve(board, 0, 0, 9, 9);
            printSudoku(solved);

            Console.ReadLine();
        }

        private static void printSudoku(char[,] board)
        {
            for(int i =0; i <9; i++)
            {
                for(int j =0; j< 9; j++)
                {
                    Console.Write(board[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
