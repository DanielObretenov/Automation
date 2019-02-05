using System;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPrime = true;
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            for (int j = Math.Min(a, b); j <= Math.Max(a, b); j++)
            {
                isPrime = true;

                for (int i = 2; i < j/2; i++)
                {
                    if (j % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime && j>1)
                {
                    Console.WriteLine(j);
                }
            }


        }
    }
}
