using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxStockPriceInLastKDays
{
    public class StockPrice
    {
        public int day { get; set; }
        public int price { get; set; }
        public StockPrice(int price, int day)
        {
            this.day = day;
            this.price = price;
        }
        public override bool Equals(object obj)
        {
            StockPrice sp = obj as StockPrice;
            return this.day == sp.day && this.price == sp.price;
        }
    }
    public class MaxStockPriceWithKDays
    {
        int windowLength;
        LinkedList<StockPrice> data;
        public MaxStockPriceWithKDays(int win)
        {
            windowLength = win;
            data = new LinkedList<StockPrice>();
        }
        public void Enqueue(StockPrice sp)
        {
            while(data.Last != null && (sp.day - data.Last.Value.day) >= windowLength)
                    data.RemoveLast();
            data.AddFirst(sp);
        }
        public void Dequeue()
        {
            data.RemoveLast();
        }
        public int getMax()
        {
            int max = int.MinValue;
            foreach (var node in data)
                max = Math.Max(max, node.price);
            return max;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MaxStockPriceWithKDays msp = new MaxStockPriceWithKDays(3);
            StockPrice[] sps = {new StockPrice(32, 1), new StockPrice(33, 1), new StockPrice(30, 2), new StockPrice(31, 3)
            , new StockPrice(30, 4), new StockPrice(50, 5),new StockPrice(51, 6)};

            List<int> result = new List<int>();
            
           for(int i= 0; i < sps.Length; i++)
            {
                msp.Enqueue(sps[i]);
                result.Add(msp.getMax());
            }
            Console.WriteLine(string.Join(",", result));
            Console.ReadLine();
        }
    }
}
