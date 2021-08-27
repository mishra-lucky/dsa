using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumOfSlidingWindow
{
    public class MaxQueue
    {
        private LinkedList<int> data;
        private LinkedList<int> max;
        public MaxQueue()
        {
            data = new LinkedList<int>();
            max = new LinkedList<int>();
        }
        public void Enqueue(int val)
        {
            data.AddFirst(val);
            while (max.Last != null && max.Last.Value < val)
                //max.Remove(max.Last.Value);
                max.RemoveLast();
            max.AddFirst(val);
        }
        public int Dequeue()
        {
            int val = -1;
            if(data.Any())
            {
                val = data.Last();
                data.RemoveLast();
                if (max.Last != null && max.Last.Value == val)
                    max.RemoveLast();
            }
            return val;
        }
        public int GetMax()
        {
            return max.Last.Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //A = [4,6,5,2,4,7] and K = 3,
            int[] arr = { 4, 6, 5, 2, 4, 7 };
            int k = 3;

            List<int> result = new List<int>();
            MaxQueue mq = new MaxQueue();
            for (int i = 0; i < k; i++)
                mq.Enqueue(arr[i]);
            result.Add(mq.GetMax());

            for (int i = k; i < arr.Length; i++)
            {
                mq.Dequeue();
                mq.Enqueue(arr[i]);             
                result.Add(mq.GetMax());
            }

            Console.WriteLine(string.Join(",", result));

        }
    }
}
