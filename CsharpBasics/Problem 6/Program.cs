using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<int>() { 1, 2, 3 };
            var list2 = new List<int>() { 5, 7 };

            list1.RemoveAt(list1.Count - 1);
            list1.AddRange(list2);
            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
