using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxStack
{
    public class MaxStack
    {

        Stack<int> stack;
        Stack<int> maxStack;
        /** initialize your data structure here. */
        public MaxStack()
        {

            stack = new Stack<int>();
            maxStack = new Stack<int>();
        }

        public void Push(int x)
        {
            stack.Push(x);
            if (!maxStack.Any() || x >= maxStack.Peek())
                maxStack.Push(x);

        }

        public int Pop()
        {
            if (stack.Any())
            {
                int x = stack.Pop();
                if (x == maxStack.Peek())
                    maxStack.Pop();
                return x;
            }
            return -1;
        }

        public int Top()
        {
            return stack.Any() ? stack.Peek() : -1;
        }

        public int PeekMax()
        {
            return maxStack.Any() ? maxStack.Peek() : -1;
        }

        public int PopMax()
        {

            if (maxStack.Any())
            {
                int x = maxStack.Pop();
                Stack<int> buffer = new Stack<int>();

                while (stack.Any() && stack.Peek() < x)
                {
                    buffer.Push(stack.Pop());
                }
                stack.Pop();               
                
                while (buffer.Any())
                    Push(buffer.Pop());

                return x;
            }
            return -1;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MaxStack ms = new MaxStack();
            //["MaxStack","push","pop","push","push","push","push","popMax","push","pop","pop","top","push"]
            //[[],          [15],  [],  [1],    [-52],  [80],[-39], [],        [91],  [],[],[],         [36]]
            ms.Push(15);
            int x = ms.Pop();
            Console.WriteLine(x);
            ms.Push(1);
            ms.Push(-52);
            ms.Push(80);
            ms.Push(-39);
            x = ms.PopMax();
            Console.WriteLine(x);
            ms.Push(91);
            x = ms.Pop();
            Console.WriteLine(x);
            x = ms.Pop();
            Console.WriteLine(x);
            x = ms.Top();
            Console.WriteLine(x);
            ms.Push(36);
        }
    }
}
