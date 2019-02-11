using System;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //No Caps
            string sentence = Console.ReadLine();

            // With Caps 
            //string sentence2 = Console.ReadLine().ToLower();

            int countA = 0;
            int countS = 0;
            int countE = 0;


            for (int i = 0; i <= sentence.Length - 1; i++)
            {

                if (sentence[i].Equals('a'))
                {
                    countA++;
                }
                else if (sentence[i].Equals('s'))
                {
                    countS++;
                }
                else if (sentence[i].Equals('e'))
                {
                    countE++;
                }
            }
            Console.WriteLine($"Count 'a' = {countA}");
            Console.WriteLine($"Count 's' = {countS}");
            Console.WriteLine($"Count 'e' = {countE}");

        }
    }
}
