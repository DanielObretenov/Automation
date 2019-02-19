using System;
using System.Collections.Generic;

namespace Program_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list1 = new List<string>() { "s", "d", "a" };
            List<string> list2 = new List<string>() { "c", "z", "a"  };
            bool contains = false;

            foreach (var symbol in list1)
            {
                if (list2.Contains(symbol))
                {
                    contains = true;
                }
            }
            Console.WriteLine(contains);
        }
    }
}
