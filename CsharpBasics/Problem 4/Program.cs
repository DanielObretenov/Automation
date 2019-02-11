using System;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            //Approach 1
            char[] wordInChars = word.ToCharArray();
            Array.Reverse(wordInChars);

            Console.WriteLine(new string(wordInChars));
        }
    }
}
