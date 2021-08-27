using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFordSSP
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
            int[] dist = BellmanFord(graph, 0);
            Console.WriteLine(string.Join(",", dist));
            Console.ReadLine();
        }

        private static int[] BellmanFord(int[][] graph, int s)
        {
            int[] dist = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            dist[s] = 0;


            for (int k = 0; k < graph.Length - 1; k++)
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    for (int j = 0; j < graph[i].Length; j++)
                    {
                        if (graph[i][j] != 0 && dist[i] + graph[i][j] < dist[j])
                            dist[j] = dist[i] + graph[i][j];
                    }
                }
            }

            for (int k = 0; k < graph.Length - 1; k++)
            {
                for (int i = 0; i < graph.Length; i++)
                {
                    for (int j = 0; j < graph[i].Length; j++)
                    {
                        if (graph[i][j] != 0 && dist[i] + graph[i][j] < dist[j])
                            dist[j] =int.MinValue;
                    }
                }
            }
            return dist;
        }
    }
}
