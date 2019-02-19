using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>()
            { "apple",
              "banana",
              "orange",
              "tomato",
              "carrot",
              "papaya",
              "pitanga",
              "ape"};
            var result = new Dictionary<string, int>();
            string firstAndLast ;
            foreach (var word in words.Where(x => x.Length > 2))
            {
                firstAndLast = string.Format("{0}{1}", word[0], word[word.Length - 1]);
                firstAndLast = firstAndLast.ToLower();
                if (result.ContainsKey(firstAndLast))
                {
                    result[firstAndLast]++;
                }
                else
                {
                    result.Add(firstAndLast, 1);
                }
            }
            foreach (var item in result.Where(x => x.Value == result.Values.Max()))
            {
                Console.WriteLine($"Key: {item.Key} Value: {item.Value}");
            }

        }
    }
}
