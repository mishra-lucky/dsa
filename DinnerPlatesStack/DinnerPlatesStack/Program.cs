using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerPlatesStack
{
    public class DinnerPlates
    {
        List<Stack<int>> allStacks;
        List<int> stacksinuse;
        private int capacity;
        HashSet<int> usedStackIndex;
        public DinnerPlates(int capacity)
        {
            if (capacity == 0)
                throw new Exception("Stack Size 0");
            this.capacity = capacity;
            allStacks = new List<Stack<int>>();
            stacksinuse = new List<int>();
            usedStackIndex = new HashSet<int>();
        }
        private void swap(int i, int j)
        {
            int temp = stacksinuse[i];
            stacksinuse[i] = stacksinuse[j];
            stacksinuse[j] = temp;
        }
        public void Min_Heapify(int i, int n)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int smallest = i;
            if (left < n && stacksinuse[left] < stacksinuse[smallest])
                smallest = left;
            if (right < n && stacksinuse[right] <= stacksinuse[smallest])
                smallest = right;
            if (smallest != i)
            {
                swap(smallest, i);
                Min_Heapify(smallest, n);
            }
        }     
        private void Heapify(bool max)
        {
            int n = stacksinuse.Count;
            for (int i = n / 2 - 1; i >= 0; i--)
                if (max) Max_Heapify(i, n);
                else Min_Heapify(i, n);
        }
        private int _getLeft()
        {
            int n = stacksinuse.Count - 1;
            Heapify(false);
            for (int i =0; i <= n; i++)
            {
                if (allStacks[stacksinuse[0]].Count < capacity)
                    return stacksinuse[0];
                else
                {
                    swap(0, n - i);
                    Min_Heapify(0, n - i);
                }                
            }
            return -1;

        }
        private int _getRight()
        {
            int n = stacksinuse.Count - 1;
            Heapify(true);
            for (int i = 0; i <= n; i++)
            {
                if (allStacks[stacksinuse[0]].Count > 0)
                    return stacksinuse[0];
                else
                {
                    swap(0, n - i);
                    Max_Heapify(0, n - i);
                }
            }
            return -1;

        }

        private void Max_Heapify(int i, int n)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            if (left < n && stacksinuse[left] > stacksinuse[largest])
                largest = left;
            if (right < n && stacksinuse[right] >= stacksinuse[largest])
                largest = right;
            if(largest != i)
            {
                swap(largest, i);
                Max_Heapify(largest, n);
            }
        }

        public void Push(int val)
        {
            int idx = _getLeft();
            if(idx != -1)
            {
                allStacks[idx].Push(val);
            }
            else
            {
                Stack<int> ns = new Stack<int>(capacity);
                ns.Push(val);
                allStacks.Add(ns);
                stacksinuse.Add(allStacks.Count - 1);
            }
        }

        public int Pop()
        {
            int idx = _getRight();
            if (idx != -1)
            {
                return allStacks[idx].Pop();
            }
            return -1;
        }

        public int PopAtStack(int index)
        {
            if (allStacks.Count > index && allStacks[index].Count > 0)
                return allStacks[index].Pop();
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = { "DinnerPlates", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "popAtStack", "popAtStack", "popAtStack", "popAtStack", "popAtStack", "popAtStack", "popAtStack", "popAtStack", "popAtStack", "popAtStack", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "push", "pop", "pop", "pop", "pop", "pop", "pop", "pop", "pop", "pop", "pop" };
            int[] param = { 2,373,86,395,306,370,94,41,17,387,403,66,82,27,335,252,6,269,231,35,346,4,6,2,5,2,2,7,9,8,1,474,216,256,196,332,43,75,22,273,101,11,403,33,365,338,331,134,1,250,19,0,0,0,0,0,0,0,0,0,0};
            DinnerPlates dp = null;
            for (int i = 0; i < command.Length; i++)
            {
                if (i == 50)
                    ;
                switch (command[i])
                {
                    case "DinnerPlates":
                        dp = new DinnerPlates(Convert.ToInt32(param[i]));
                        break;
                    case "push":
                        dp.Push(Convert.ToInt32(param[i]));
                        break;
                    case "pop":
                        int x = dp.Pop();
                        Console.WriteLine(i + " " + x);
                        break;
                    case "popAtStack":
                        int y = dp.PopAtStack(Convert.ToInt32(param[i]));
                        Console.WriteLine(i + " " + y);
                        break;
                }

            }
            Console.ReadLine();

        }
    }
}
