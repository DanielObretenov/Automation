using System;

namespace Problem_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int numStartDesc = 66;
            int numEndDesc = 21;
            int numStartAsc = 77;
            int numEndAsc = 99;

            do
            {
                numStartDesc -= 4;
                numStartAsc += 2;
                if (numStartDesc >= numEndDesc && numStartAsc <= numEndAsc)
                {
                    Console.WriteLine(numStartDesc);
                    Console.WriteLine(numStartAsc);
                }
                else if (numStartDesc <= numEndDesc && numStartAsc >= numEndAsc)
                {
                    break;
                }
                else if (numStartDesc <= numEndDesc)
                {
                    Console.WriteLine("XX");
                    Console.WriteLine(numStartAsc);
                }
                else if (numStartAsc >= numEndAsc)
                {
                    Console.WriteLine(numStartDesc);
                    Console.WriteLine("XX");
                }

                Console.WriteLine();

            }
            while (numStartDesc >= numEndDesc || numStartAsc <= numEndAsc);
        }
    }
}
