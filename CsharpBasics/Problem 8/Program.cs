using System;
using System.Collections.Generic;

namespace Problem_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = Console.ReadLine().ToLower();
            List<char> letters = new List<char>();
            bool moteThanOne = false;

            for (int letter = 0; letter < sentence.Length - 1; letter++)
            {
                for (int wordCheck = letter + 1; wordCheck <= sentence.Length - 1; wordCheck++)
                {
                    if (sentence[letter] == sentence[wordCheck])
                    {
                        moteThanOne = true;
                        break;
                    }
                }

                if (!letters.Contains(sentence[letter]) && moteThanOne && sentence[letter] != ' ')
                {
                    letters.Add(sentence[letter]);
                }
                moteThanOne = false;
            }
            Console.WriteLine(string.Join(',', letters));







        }
    }
}
