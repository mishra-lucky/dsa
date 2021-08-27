using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingBuffer
{
    public class RingBuffer
    {
        private int length;
        private int size;
        private int front;
        private int back;
        private int[] data;
        public RingBuffer(int n)
        {
            size = n;
            data = new int[size];
            length = front = back = 0;

        }
        public bool enQueue(int val)
        {
            bool ret = true;
            if (length == size)
                return false;
            length++;
            data[back] = val;
            back = (back + 1) % size;
            return ret;
        }
        public bool deQueue()
        {
            bool ret = true;
            if (length == 0)
                return false;
            length--;
            int val = data[front];
            front = (front + 1) % size;
            return ret;
        }
        public int Front()
        {
            return length > 0 ? data[0]: -1;
        }
        public int Rear()
        {
            return length > 0 ? data[(front+length-1)%size] : -1;
        }
        public bool isFull()
        {
            return length == size;
        }
        public bool isEmpty()
        {
            return length == 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = { "MyCircularQueue", "enQueue", "enQueue", "enQueue", "enQueue", "Rear", "isFull", "deQueue", "enQueue", "Rear" };
            int[] parameters = { 3,1,2,3,4,0,0,0,4,0};

            RingBuffer rb = null;
            bool ret;
            for(int i =0; i < commands.Length; i++)
            {
                switch(commands[i])
                {
                    case "MyCircularQueue":
                        rb = new RingBuffer(parameters[i]);
                        break;
                    case "enQueue":
                        ret = rb.enQueue(parameters[i]);
                        Console.WriteLine(commands[i] + " " + parameters[i] + " " + ret);
                        break;
                    case "deQueue":                        
                        ret = rb.deQueue();
                        Console.WriteLine(commands[i] + " " + parameters[i] + " " + ret);
                        break;
                    case "isFull":
                        ret = rb.isFull();
                        Console.WriteLine(commands[i] + " " + parameters[i] + " " + ret);
                        break;
                    case "isEmpty":
                        ret = rb.isEmpty();
                        Console.WriteLine(commands[i] + " " + parameters[i] + " " + ret);
                        break;
                    case "Rear":
                        int val = rb.Rear();
                        Console.WriteLine(commands[i] + " " + parameters[i] + " " + val);
                        break;
                    case "Front":
                        int val2 = rb.Front();
                        Console.WriteLine(commands[i] + " " + parameters[i] + " " + val2);
                        break;
                    default:
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}
