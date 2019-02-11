using System;
using System.Text;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            //Approach 1
            char[] wordInChars = word.ToCharArray();
            Array.Reverse(wordInChars);
            string reversedWord = new string(wordInChars);

            Console.WriteLine(word.Equals(reversedWord)
            ? $"{word} = {reversedWord}"
            : "Nope");

            // Aproach 2

        }
    }
}
