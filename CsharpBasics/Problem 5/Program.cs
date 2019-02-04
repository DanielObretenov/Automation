using System;

namespace Problem_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int newNum = num;
            for (int row = 1; row <= num; row++)
            {
                for (int column = 0; column < num; column++)
                {
                    Console.Write(row + column + " ");
                }
                Console.WriteLine();
            }



        }
    }
}
