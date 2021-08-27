using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraSingleSourceShortestPath
{
    
    public class Heap
    {
        public class heapnode
        {
            public heapnode(int node, int dist)
            {
                this.node = node;
                this.dist = dist;
            }

            public int node { get; set; }
            public int dist { get; set; }
        }
        private List<heapnode> data;
        public Heap()
        {
            data = new List<heapnode>();
        }
        public void Add(int node, int dist)
        {
            heapnode hp = new heapnode(node, dist);
            data.Add(hp);
            propagateUp(data.Count -1);
        }
        public heapnode PopMin()
        {
            swap(0, data.Count - 1);
            heapnode max = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);
            Heapify(0, data.Count);
            return max;
        }
        public heapnode Peek()
        {
            return data[0];
        }
        private void Heapify(int i, int n)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;

            if (left < n && data[left].dist < data[smallest].dist)
                smallest = left;
            if (right < n && data[right].dist < data[smallest].dist)
                smallest = right;
            if(smallest != i)
            {
                swap(i, smallest);
                Heapify(smallest, n);
            }
        }
        public int Count()
        {
            return data.Count;
        }
        private void propagateUp(int i)
        {
            int parent = (i - 1) / 2;
            while(i > 0 && data[i].dist< data[parent].dist)
            {
                swap(i, parent);
                i = parent;
                parent = (i - 1) / 2;
            }
        }

        private void swap(int i, int j)
        {
            var temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
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
            int[] dist = Dijkstra(graph, 0);
            Console.WriteLine(string.Join(",", dist));
        }

        private static int[] Dijkstra(int[][] graph, int s)
        {
            Heap heap = new Heap();
            int[] dist = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();

            bool[] visited = new bool[graph.Length];
            dist[s] = 0;
            heap.Add(s, dist[s]);
            while(heap.Count() > 0)
            {
                Heap.heapnode h = heap.PopMin();
                int node = h.node;
                int oldDist = h.dist;
                if (dist[node] < oldDist)
                    continue;
                visited[node] = true;
                for(int i =0; i < graph[node].Length; i++)
                {
                    if (!visited[i] && graph[node][i] > 0)
                    {
                        int d = dist[node] + graph[node][i];
                        if(d < dist[i])
                        {
                            dist[i] =d;
                            heap.Add(i, dist[i]);
                        }
                    }
                }
            }
            return dist;
        }
        
    }
}
