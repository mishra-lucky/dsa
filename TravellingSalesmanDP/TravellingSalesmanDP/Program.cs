using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellingSalesmanDP
{
    class Program
    {
        public static int VISTIED_ALL =0;
        static void Main(string[] args)
        {
            int[][] graph = { new int[] { 0, 10, 15, 20 },
                       new int[] { 10, 0, 35, 25 },
                       new int[] { 15, 35, 0, 30 },
                       new int[] { 20, 25, 30, 0 } };
            VISTIED_ALL = (1 << graph.Length) - 1; // 2^n -1;
            int[,] dp = new int[VISTIED_ALL + 1,graph.Length];
            for (int i = 0; i < VISTIED_ALL+1; i++)
                for (int j = 0; j < graph.Length; j++)
                    dp[i,j] = -1; 
            int minDist = tsp(1, 0, ref graph, ref dp);
            Console.WriteLine(minDist);
            Console.ReadLine();
            
        }

        private static int tsp(int mask, int city, ref int[][] graph, ref int[,] dp)
        {
            if (mask == VISTIED_ALL)
                return graph[city][0];

            int minDist = int.MaxValue;
            if (dp[mask, city] != -1)
                return dp[mask, city];
            for(int i =0; i < graph.Length; i++)
            {
                if((mask & (1<<i)) == 0)
                {
                    int dist = graph[city][i] + tsp((mask | (1 << i)), i, ref graph, ref dp);
                    minDist = Math.Min(minDist, dist);
                }
            }
            return dp[mask,city] = minDist;
        }
    }
}
