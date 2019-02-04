using System;

namespace Problem_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 1;

            while (num > 0)
            {
                sum *= num;
                num--;
            }
            Console.WriteLine(sum);
        }
    }
}
