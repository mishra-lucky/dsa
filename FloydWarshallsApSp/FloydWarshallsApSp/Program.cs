using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydWarshallsApSp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] graph = { new int[]{ 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                                     new int[] { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                                      new int[]{ 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                                      new int[]{ 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                                     new int[] { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                                     new int[] { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                                      new int[]{ 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                                     new int[] { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                                      new int[]{ 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            };
            int[,] dist = GetAllPairShortestPath(graph);
            for (int i = 0; i < graph.Length; i++)
                for (int j = 0; j < graph[0].Length; j++)
                    Console.WriteLine(string.Format("Distance between {0} and {1}  is {2}.", i, j, dist[i, j]));
                             
            Console.ReadLine();
        }

        private static int[,] GetAllPairShortestPath(int[][] graph)
        {
            int[,] dp = new int[graph.Length, graph[0].Length];
            int[,] next = new int[graph.Length, graph[0].Length];

            for(int i=0; i<graph.Length;i++)
            {
                for(int j=0; j< graph[0].Length; j++)
                {
                    dp[i, j] = graph[i][j];
                    next[i, j] = j;
                    if (graph[i][j] == 0)
                        dp[i, j] = int.MaxValue;
                    if (i == j)
                        dp[i, j] = 0;
                }
            }

            // fill dp
            for(int k=0; k < graph.Length; k++)
            {
                for(int i=0; i<graph.Length; i++)
                {
                    for(int j =0; j < graph[0].Length; j++)
                    {
                        if(dp[i,k] != int.MaxValue && dp[k,j] != int.MaxValue && dp[i,k] + dp[k,j] < dp[i,j])
                        {
                            dp[i, j] = dp[i, k] + dp[k, j];
                            next[i, j] = next[i,k];
                        }
                    }
                }
            }

            // negetive cycles
            for (int k = 0; k < graph.Length; k++)
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    for (int j = 0; j < graph[0].Length; j++)
                    {
                        if (dp[i, k] != int.MaxValue && dp[k, j] != int.MaxValue  && dp[i, k] + dp[k, j] < dp[i, j])
                        {
                            dp[i, j] = int.MinValue;
                            next[i, j] = -1;
                        }
                    }
                }
            }
            return dp;
            
        }
    }
}
