using System;

namespace Problem_8
{
    class Program
    {
        static void Main(string[] args)
        {

            int numStartDesc = 97;
            int numEndDesc = 54;
            int count = 1;

            while (numStartDesc >= numEndDesc)
            {
                numStartDesc -= 3;
                if (count != 4 && count != 7)
                {
                    Console.WriteLine(numStartDesc);
                }
                //else
                //{
                //    if (count == 7)
                //    {
                //        count = 0;
                //    }
                //    Console.WriteLine("Skipped number " + numStartDesc);
                //}
                count++;



            }
        }
    }
}
