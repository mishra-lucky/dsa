using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsLadderBFS
{
    class Program
    {
        static void Main(string[] args)
        {
            string beginWord = "leet", endWord = "code";
            string[] wordList = { "lest", "leet", "lose", "code", "lode", "robe", "lost" };
            Dictionary<string, List<string>> dict = PreProcessDictionary(wordList);
            int level = DoBFS(beginWord, endWord, dict);
            Console.WriteLine(level);
            Console.ReadLine();
        }

        private static int DoBFS(string beginWord, string endWord, Dictionary<string, List<string>> dict)
        {
            Queue<string> q = new Queue<string>();
            if (!dict.Any()) return int.MaxValue;
            if (beginWord.Equals(endWord)) return 0;

            q.Enqueue(beginWord);
            int level = 0;
            HashSet<string> seen = new HashSet<string>();
            seen.Add(beginWord);

            while (q.Any())
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    string word = q.Dequeue();
                    if (word.Equals(endWord))
                        return 1+level;

                    for (int j = 0; j < word.Length; j++)
                    {
                        string newWord = word.Substring(0, j) + '*' + word.Substring(j + 1);
                        if (dict.ContainsKey(newWord))
                        {
                            foreach (string s in dict[newWord])
                                if (!seen.Contains(s))
                                {
                                    q.Enqueue(s);
                                    seen.Add(s);
                                }

                        }
                    }
                }
                level++;

           }
            return -1;
        }

        private static Dictionary<string, List<string>> PreProcessDictionary(string[] wordList)
        {
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
           foreach (string word in wordList)
           {
                for(int i =0; i < word.Length; i++)
                {
                    int len = word.Length;
                    string newWord = word.Substring(0,i) + '*' + word.Substring(i+1);
                    if (dict.ContainsKey(newWord))
                        dict[newWord].Add(word);
                    else
                        dict[newWord] = new List<string>{ word };
                }

           }
            return dict;
        }
    }
}
