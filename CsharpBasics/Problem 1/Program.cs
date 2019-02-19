using System;
using System.Collections.Generic;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 2, 3, 4 };

            //first approach
            List<int> array3 = new List<int>(array1);
            foreach (var number in array3)
            {
                Console.WriteLine(number * 2);
            }

            Console.WriteLine();

            //second
            int[] array2 = new int[array1.Length];

            for (int i = 0; i < array1.Length; i++)
            {
                array2[i] = array1[i] * 2;
            }

            foreach (var number in array2)
            {
                Console.WriteLine(number);
            }



        }
    }
}
