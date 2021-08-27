using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedianOfAStream
{
    public class MaxHeap
    {
        private List<int> data;
        public int count { get; private set; }
        public MaxHeap()
        {
            data = new List<int>();
            count = 0;
        }
        public void Add(int item)
        {
            data.Add(item);
            count++;
            propagateUp(count - 1);
        }
        public int Peek()
        {
            return data[0];
        }
        public int PopMax()
        {
            if (count == 0)
                return 0;
            int ret = data[0];
            swap(0, count - 1);
            data.RemoveAt(count - 1);
            count--;
            Heapify(0);
            return ret;
        }

        private void Heapify(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            if (left < count && data[left] > data[largest])
                largest = left;
            if (right < count && data[right] > data[largest])
                largest = right;
            if(largest != i)
            {
                swap(i, largest);
                Heapify(largest);
            }
        }

        private void propagateUp(int i)
        {
            int parent = (i - 1) / 2;
            while(i > 0 && data[i] > data[parent])
            {
                swap(i, parent);
                i = parent;
                parent = (parent - 1) / 2;
            }
        }

        private void swap(int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
    public class MinHeap
    {
        private List<int> data;
        public int count { get; private set; }
        public MinHeap()
        {
            data = new List<int>();
            count = 0;
        }
        public void Add(int item)
        {
            data.Add(item);
            count++;
            propagateUp(count - 1);
        }
        public int Peek()
        {
            return data[0];
        }
        public int PopMin()
        {
            if (count == 0)
                return 0;
            int ret = data[0];
            swap(0, count - 1);
            data.RemoveAt(count - 1);
            count--;
            Heapify(0);
            return ret;
        }

        private void Heapify(int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;
            if (left < count && data[left] < data[smallest])
                smallest = left;
            if (right < count && data[right] < data[smallest])
                smallest = right;
            if (smallest != i)
            {
                swap(i, smallest);
                Heapify(smallest);
            }
        }

        private void propagateUp(int i)
        {
            int parent = (i - 1) / 2;
            while (i > 0 && data[i] < data[parent])
            {
                swap(i, parent);
                i = parent;
                parent = (parent - 1) / 2;
            }
        }

        private void swap(int i, int j)
        {
            int temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
    }
    public class MedianFinder
    {

        private MaxHeap lo_max;
        private MinHeap hi_min;
        int count;
        /** initialize your data structure here. */
        public MedianFinder()
        {
            lo_max = new MaxHeap();
            hi_min = new MinHeap();
            count = 0;
        }

        public void AddNum(int num)
        {
            if (count == 0)
            {
                hi_min.Add(num);                
            }
            else
            {
                if(hi_min.count == lo_max.count)
                {
                    if(hi_min.count == 0 || num < lo_max.Peek())
                    {
                        hi_min.Add(lo_max.PopMax());
                        lo_max.Add(num);
                    }
                    else
                    {
                        hi_min.Add(num);
                    }
                }
                else
                {
                    if(lo_max.count == 0 || num > hi_min.Peek())
                    {
                        lo_max.Add(hi_min.PopMin());
                        hi_min.Add(num);
                    }
                    else
                    {
                        lo_max.Add(num);
                    }
                }
            }
            count++;
        }

        public double FindMedian()
        {
            if ((count & 1) == 1)
                return hi_min.Peek();
            else
                return ((double)lo_max.Peek() + hi_min.Peek()) / 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = {"MedianFinder","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian","addNum","findMedian"};
            int[] parameters = { 0,6,0,10,0,2,0,6,0,5,0,0,0,6,0,3,0,1,0,0,0,0,0};
              
            MedianFinder mf = null;
            for(int i = 0; i< commands.Length; i++)
            {
                switch(commands[i])
                {
                    case "MedianFinder":
                        mf = new MedianFinder();
                        break;
                    case "addNum":
                        mf.AddNum(parameters[i]);
                        break;
                    case "findMedian":
                        double median = mf.FindMedian();
                        Console.WriteLine(median);
                        break;
                    default:
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
