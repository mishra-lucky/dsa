using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PallindromePermutationsII
{
    class Program
    {
        HashSet<string> results = new HashSet<string>();
        int strlen = 0;
        static void Main(string[] args)
        {
            string s1 = "aaa";
            Program p1 = new Program();
            List<string> l = p1.generateAllPallindromicPermutations(s1);
            Console.WriteLine(string.Join(",", l));
            Console.ReadLine();
        }

        private List<string> generateAllPallindromicPermutations(string s)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();
            foreach (char c in s)
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq.Add(c, 1);

            int distinctchars = freq.Keys.Count;
            char[] chars = new char[distinctchars];
            int[] charcount = new int[distinctchars];
            int idx = 0;
            foreach (var kvp in freq)
            {
                chars[idx] = kvp.Key;
                charcount[idx++] = kvp.Value;
                strlen += kvp.Value;
            }
            char[] buffer = Enumerable.Repeat('-', strlen).ToArray();
            Permutate(buffer, chars, charcount, 0, 0);
            return results.ToList();
        }

        public void Permutate(char[] buffer, char[] chars, int[] charcount, int bufferLength, int buffindex)
        {
            if (bufferLength == strlen)
            {
                string added = new string(buffer);
                if (!results.Contains(added))
                    results.Add(added);
                Console.WriteLine(bufferLength);
                return;
            }

            for (int i = 0; i < chars.Length; i++)
            {
                if (charcount[i] == 0)
                    continue;
                if (charcount[i] >= 2 && buffer[buffindex] == '-')
                {
                    buffer[buffindex] = chars[i];
                    buffer[buffer.Length - 1 - buffindex] = chars[i];
                    charcount[i] -= 2;
                    Permutate(buffer, chars, charcount, bufferLength + 2, buffindex + 1);
                    charcount[i] += 2;
                    buffer[buffer.Length - 1 - buffindex] = '-';
                    buffer[buffindex] = '-';
                }
                else if (buffer[buffindex] == '-' && buffindex == Math.Floor((decimal)strlen / 2))
                {
                    buffer[buffindex] = chars[i];
                    charcount[i] -= 1;
                    Permutate(buffer, chars, charcount, bufferLength + 1, buffindex + 1);
                    charcount[i] += 1;
                    buffer[buffindex] = '-';
                }

            }
        }
    }
}
