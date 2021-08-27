using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDrop
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = 100;
            int eggs = 5;

            int[,] dp = new int[floors + 1, eggs + 1];
            for (int i = 0; i <= floors; i++)
                for (int j = 0; j <= eggs; j++)
                    dp[i, j] = int.MaxValue;
            int min = findEggDrop(floors, eggs, ref dp);
            Console.WriteLine(min);
            Console.ReadLine();
        }

        private static int findEggDrop(int floors, int eggs, ref int[,] dp)
        {
            if (floors <= 1) return floors; // 0 or 1 floor, we need 1 drop for 1 and 0 drops for 0 floors.
            if (eggs == 1) return floors; // 1 egg no room to optimize.
            if (eggs < 0) return int.MaxValue;

            if (dp[floors, eggs] != int.MaxValue) return dp[floors, eggs];

            int min = int.MaxValue;
            for(int i =1; i <= floors; i++)
            {
                int res = Math.Max(findEggDrop(floors -i , eggs, ref dp), // Did not break, come to next floor
                    findEggDrop(i -1, eggs -1, ref dp)); // Broke, so eggs = egg -1 and floor will between 1 and i, 

                if (res < min)
                    min = res;
            }
            return dp[floors, eggs] = min + 1;
        }
    }
}
