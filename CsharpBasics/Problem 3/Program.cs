using System;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Start Number");
            int startNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Number of rows");
            int totalRows = int.Parse(Console.ReadLine());

            for (int row = 0; row <= totalRows; row++)
            {
                for (int keys = 1; keys <= row; keys++)
                {
                    Console.Write(startNum + " ");
                    startNum++;
                }
                Console.WriteLine();
            }
        }
    }
}
