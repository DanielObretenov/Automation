using System;

namespace Problem_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array1 = new int[,] { { 1, 2, 3 }, { 1, 2, 3 } };
            int[,] array2 = new int[,] { { 4, 5, 6 }, { 4, 5, 6 } };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array1[i, j] + array2[i, j] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}
