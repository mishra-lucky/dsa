using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStackRecursive
{
    class Program
    {
        public static void ReverseStack(ref Stack<int> s)
        {
            int top;
            if (s.Any())
            {
                top = s.Pop();
                ReverseStack(ref s);
                pushElementReverse(ref s, top);
            }
        }

        private static void pushElementReverse(ref Stack<int> s, int top)
        {
            if(!s.Any())
            {
                s.Push(top);
            }
            else
            {
                int oldTop = s.Pop();
                pushElementReverse(ref s, top);
                s.Push(oldTop);
            }
        }

        static void Main(string[] args)
        {
            Stack<int> s = new Stack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            s.Push(4);
            s.Push(5);

            ReverseStack(ref s);
            Console.WriteLine(s);
            Console.ReadKey();
        }
    }
}
