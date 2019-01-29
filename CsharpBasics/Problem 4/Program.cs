using System;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayInt = new int[] { 1, 2, 5, 4, 4, 6, 7, 8, 2 };
            //First Approach
            for (int i = arrayInt.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(arrayInt[i]);
            }

            //Second
            Console.WriteLine();


            Array.Reverse(arrayInt);
            Array.ForEach(arrayInt, Console.WriteLine);
        }
    }
}
