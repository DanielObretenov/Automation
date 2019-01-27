using System;

namespace Problem_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] newArrayStr = new string[,]
           {
                {"OneOne","OneTwo", "OneThree"},
                {"TwoOne", "TwoTwo", "TwoThree"}
           };

           for (int m = newArrayStr.GetLength(0) - 1; m >= 0; m--)
            {
                for (int z = newArrayStr.GetLength(1) - 1; z >= 0; z--)
                {
                    Console.Write(newArrayStr[m, z] + " ");
                }

                Console.WriteLine();
            }

        }
    }
}
