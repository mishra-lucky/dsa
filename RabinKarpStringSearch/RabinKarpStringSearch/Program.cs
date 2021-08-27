using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarpStringSearch
{
    class Program
    {
        public static int Prime = 31;
        static void Main(string[] args)
        {
            string s1 = "Hello world, this is monday.";
            string s2 = "wor";
            int idx = FindWord(s1, s2);
            Console.WriteLine(idx);
            Console.ReadLine();
        }

        private static int FindWord(string search, string pattern)
        {
            if (search == null || search.Length == 0 || pattern == null || pattern.Length == 0 || pattern.Length > search.Length) return -1;
            int len = pattern.Length;
            int patHash = getHashCode(pattern, len);
            string lookahead = search.Substring(0, len);
            int stringHash = getHashCode(lookahead, len);

            if (stringHash == patHash && pattern.Equals(search.Substring(0, len)))
                return 0;

            int pow = findPowerOfPrime(len);
            for(int i =len; i < search.Length; i++)
            {
                stringHash = (stringHash - ((search[i - len]) * pow)) * Prime + search[i];             
                if (stringHash == patHash && pattern.Equals(search.Substring(i - len + 1, len)))
                    return i - len + 1;
            }
            return -1;
        }

        private static int getHashCode(string pattern, int len)
        {
            int hash = 0;
            for(int i =0; i < len; i++)
            {
                hash = (hash * Prime) + pattern[i];
            }
            return hash;
        }      
       
        public static int findPowerOfPrime(int len)
        {
            int pow = 1;
            for (int i = 0; i < len -1; i++)
                pow *= Prime;

            return pow;
        }
     
    }
}
