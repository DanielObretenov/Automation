using System;

namespace Problem_9
{
    class Program
    {
        static void Main(string[] args)
        {


            string words = Console.ReadLine();
            words = words.Replace(" ", string.Empty);

            int countLetters = 0;
            int countDigits = 0;
            int countSpecChar = 0;
            
            for (int i = 0; i <= words.Length - 1; i++)
            {
                if (char.IsLetter(words[i]))
                {
                    countLetters++;
                }
                else if (char.IsDigit(words[i]))
                {
                    countDigits++;
                }
                else
                {
                    countSpecChar++;
                }
            }

            Console.WriteLine($"Letters:{countLetters}");
            Console.WriteLine($"Digits:{countDigits}");
            Console.WriteLine($"Special Chars:{countSpecChar}");


        }
    }
}
