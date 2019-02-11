using System;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "The quick brown fox jumps over the lazy dog.";
            string[] words = sentence.Split(' ');
            Console.WriteLine(words.Length);

        }
    }
}
