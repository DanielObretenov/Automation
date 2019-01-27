using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] intArray = new int[2, 2]{
              { 2, 3 },
              { 2, 3 } };

            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    Console.WriteLine($"Row {i} Column {j}");
                }
            }
        }
    }
}
