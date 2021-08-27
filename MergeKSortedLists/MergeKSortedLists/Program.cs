using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeKSortedLists
{
    class Program
    {
        public class HeapNode
        {
            public int value { get; set; }
            public int listnumber { get; set; }
            public int indexInList { get; set; }
        }
        public class Heap
        {
            public List<HeapNode> storage = new List<HeapNode>();
            public void Heapify()
            {
                int n = storage.Count;
                for(int i = storage.Count /2 -1; i >= 0; i--)
                {
                    Min_Heapify(i, n);
                }
            }

            private void Min_Heapify(int i, int n)
            {
                int l = 2 * i + 1;
                int r = 2 * i + 2;
                int smallest = i;

                if (l < n && storage[l].value <= storage[smallest].value)
                    smallest = l;
                if (r < n && storage[r].value <= storage[smallest].value)
                    smallest = r;

                if(smallest != i)
                {
                    Swap(i, smallest);
                    Min_Heapify(smallest, n);
                }
            }

            private void Swap(int i, int j)
            {
                HeapNode temp = storage[i];
                storage[i] = storage[j];
                storage[j] = temp;
            }

            public HeapNode Pop()
            {
                Swap(0, storage.Count - 1);
                HeapNode temp = storage[storage.Count - 1];
                storage.RemoveAt(storage.Count - 1);
                Min_Heapify(0, storage.Count);
                return temp;
            }
        }
        static void Main(string[] args)
        {
            List<List<int>> lists = new List<List<int>>();
            List<int> temp =new List<int> { 1, 2, 3, 4, 5, 6};
            List<int> temp2 = new List<int> {2, 4, 6, 8};
            List<int> temp3 = new List<int> { 3, 6, 9, 12};
            List<int> temp4 = new List<int> { 4, 8, 12, 16, 20 };
            lists.Add(temp);
            lists.Add(temp2);
            lists.Add(temp3);
            lists.Add(temp4);

            List<int> results = MergeLists(lists);
            Console.WriteLine(string.Join(",", results).TrimEnd(','));
            Console.ReadLine();
        }

        public static List<int> MergeLists(List<List<int>> lists)
        {
            List<int> results = new List<int>();
            Heap hp = new Heap();
            for(int i=0; i<lists.Count; i++)
            {
                HeapNode h = new HeapNode();
                h.value = lists[i][0];
                h.listnumber = i;
                h.indexInList = 0;
                hp.storage.Add(h);
            }
            hp.Heapify();

            while(hp.storage.Any())
            {
                HeapNode temp = hp.Pop();
                results.Add(temp.value);

                HeapNode newnode = new HeapNode();
                newnode.listnumber = temp.listnumber;
                newnode.indexInList = temp.indexInList + 1;
                if (lists[newnode.listnumber].Count > newnode.indexInList)
                {
                    newnode.value = lists[newnode.listnumber][newnode.indexInList];
                    hp.storage.Add(newnode);
                    hp.Heapify();
                }
            }
            return results;
        }
    }
}
