using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_6
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] intNum = new int[] { 2, 3, 1, 4, 8, 5, 7, 6 };

            //First Approach

            Array.Sort(intNum);
            Console.WriteLine(intNum[intNum.Length - 2]);

            //Second Approach
            int maxNumber2 = intNum[intNum.Length - 1];

            for (int i = intNum.Length - 1; i >= 0; i--)
            {
                if (intNum[i] != maxNumber2)
                {
                    Console.WriteLine(intNum[i]);
                    break;
                }
            }

            //Third Approach
            List<int> listNums = new List<int>(intNum);
            int maxNumber3 = listNums.Max();
            listNums.RemoveAll(number => number == maxNumber3);
            Console.WriteLine(listNums.Max());
        }
    }
}
