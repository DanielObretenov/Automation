using System;
using System.Collections.Generic;

namespace Problem_7
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Dictionary<int, int>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                result.Add(i, i * i);
            }
            foreach (var pair in result)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }



        }
    }
}
