using System;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            //first - multiplication table num by num
            for (int row = 1; row <= num; row++)
            {
                for (int column = 1; column <= num; column++)
                {
                    Console.Write($"{row * column} ");
                }
                Console.WriteLine();
            }

            //second
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine($"{num}X{i} = {num * i}");
            }
        }
    }
}
