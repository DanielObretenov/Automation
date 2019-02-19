using System;
using System.Collections.Generic;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = Console.ReadLine();
            List<string> list1 = new List<string>(letters.Split(' '));
            string resultString = Console.ReadLine();
            List<string> ResultList = new List<string>(resultString.Split(' '));
            int count = 0;
            foreach (var letter in list1)
            {
                if (ResultList.Contains(letter))
                {
                    count++;
                }
            }
            bool countMatches = count == ResultList.Count;
            Console.WriteLine(countMatches ? true :false);
        }
    }
}
