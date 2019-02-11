using System;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {

            string word = Console.ReadLine();
            string newWord = "";

            for (int i = 0; i <= word.Length - 1; i++)
            {
                if (char.IsUpper(word[i]))
                {
                    newWord += char.ToLower(word[i]);
                }
                else
                {
                    newWord += char.ToUpper(word[i]);
                }

            }
            Console.WriteLine(newWord);
        }
    }
}
