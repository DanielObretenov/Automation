using System;
using System.Collections.Generic;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<string>() { "Black", "Red", "Maroon", "Yellow" };
            var list2 = new List<string>() { "#000000", "#FF0000", "#800000", "#FFFF00" };
            var result = new Dictionary<string, string>();

            for (int i = 0; i < list1.Count; i++)
            {
                if (!result.ContainsKey(list1[i]))
                {
                    result.Add(list1[i], list2[i]);
                }
            }

            foreach (var pair in result)
            {
                Console.WriteLine($"key: {pair.Key}, value: {pair.Value}");
            }
        }
    }
}
