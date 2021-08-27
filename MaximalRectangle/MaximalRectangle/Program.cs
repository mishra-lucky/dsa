using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //char[][] matrix = { new char[] { '1', '0', '1', '0', '0' }, new char[] { '1', '0', '1', '1', '1' },
            //    new char[] { '1', '0', '1', '1', '1' }, new char[]{ '1', '0', '0', '1', '0' } };

            char[][] matrix = { new char[] {'1', '0', '1', '1', '1' },
                                new char[] {'0', '1', '0', '1', '0' },
                                new char[] {'1', '1', '0', '1', '1' },
                                new char[] {'1', '1', '0', '1', '1' },
                                new char[] {'0', '1', '1', '1', '1' }
            };

            int area = findMaximal(ref matrix);
            Console.WriteLine(area);
            Console.ReadLine();
        }

        public static int findMaximal(ref char[][] matrix)
        {
            if (matrix == null || matrix.Length == 0) return 0;
            int maxArea = 0;

            for(int i =0; i < matrix.Length; i++)
            {
                int[] arr = ConvertToHistogram(ref matrix, i);
                int area = LargestRectangleArea(arr);
                if (area > maxArea)
                    maxArea = area;
            }
            return maxArea;
        }

        private static int[] ConvertToHistogram(ref char[][] matrix, int k)
        {
            if (k == 0) return matrix[0].Select(x=>x - '0').ToArray();

            int[] arr = new int[matrix[k].Length];
            int j = 0;
            
            while(j < matrix[k].Length)
            {
                if (matrix[k][j] == '0')
                {
                    arr[j] = 0;
                }
                else
                {
                    int i = k;
                    while (i >= 0 && matrix[i][j] != '0')
                    {
                        arr[j] += matrix[i][j] - '0';
                        i--;
                    }
                }
                j++;
            }
            return arr;
        }

        public static int LargestRectangleArea(int[] heights)
        {
            if (heights == null || heights.Length == 0) return 0;

            int[] rb = new int[heights.Length]; // find index of next smallest element on right
            rb[heights.Length - 1] = heights.Length; // default value of right boundary -- arr.Length
                                                     // Required because the width calculation depends on this.
            Stack<int> stack = new Stack<int>();
            stack.Push(heights.Length - 1);
            for (int i = heights.Length - 2; i >= 0; i--)
            {
                while (stack.Any() && heights[i] <= heights[stack.Peek()])
                {
                    stack.Pop(); // Pop until the stack top is > than heights[i]
                }
                if (!stack.Any())
                {
                    rb[i] = heights.Length;
                }
                else
                {
                    rb[i] = stack.Peek();
                }
                stack.Push(i);
            }


            int[] lb = new int[heights.Length]; // find index of next smallest element on left

            lb[0] = -1; // default value of left boundary -- -1
                        // Required because the width calculation depends on this.
            stack = new Stack<int>();
            stack.Push(0);
            for (int i = 1; i < heights.Length; i++)
            {
                while (stack.Any() && heights[i] <= heights[stack.Peek()])
                {
                    stack.Pop(); // Pop until the stack top is > than heights[i]
                }
                if (!stack.Any())
                {
                    lb[i] = -1;
                }
                else
                {
                    lb[i] = stack.Peek();
                }
                stack.Push(i);
            }
            int maxArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int width = rb[i] - lb[i] - 1;
                int height = heights[i];

                int area = width * height;

                if (area > maxArea)
                    maxArea = area;
            }
            return maxArea;
        }

    }
}
