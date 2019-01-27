using System;
using System.Collections.Generic;
namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //list
            Console.Write("Remove Index: ");
            int num = int.Parse(Console.ReadLine());
            int[] arrayInt = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            List<int> listInt = new List<int>(arrayInt);
            listInt.RemoveAt(num);

            for (int i = 0; i < listInt.Count; i++)
            {
                Console.WriteLine(listInt[i]);
            }

        }
    }
}
