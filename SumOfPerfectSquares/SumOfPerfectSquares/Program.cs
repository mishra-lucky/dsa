using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfPerfectSquares
{
    class Program
    {
        public static int sqrtSum(int n)
        {
            if (n <= 3) return n;
            int result = n;       
            for(int i=2; i * i <= n; i++ )
            {
                result = Math.Min(result, 1 + sqrtSum(n - (i * i)));
            }
            return result;
        }
        static void Main(string[] args)
        {
            int i =  sqrtSum(127);
            Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
