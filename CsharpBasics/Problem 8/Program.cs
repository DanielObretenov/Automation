using System;
using System.Collections.Generic;

namespace Problem_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            var pairs = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!pairs.ContainsKey(word[i]))
                {
                    pairs.Add(word[i], 1);
                }
                else
                {
                    pairs[word[i]]++;
                }
            }

            Console.WriteLine(string.Join(",", pairs));
        }
    }
}
