using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllPallindromicSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = findAllPallindromicSubstrings("bccb");
            Console.WriteLine(i);
            Console.ReadLine();
        }

        private static int findAllPallindromicSubstrings(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            int count = 0;
            for(int i =0; i < s.Length; i++)
            {
                for(int j =i; j <s.Length; j++)
                {
                    if (isPallindrome(s, i, j))
                        count++;
                }
            }
            return count;
        }

        private static bool isPallindrome(string s, int i, int j)
        {
            if (i > j) return true;
            return s[i] == s[j] && isPallindrome(s, i + 1, j - 1);
        }
    }
}
