using System;
using System.Linq;


namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array1 = new string[] { "1FirstArray", "2FirstArray" };
            string[] array2 = new string[] { "1SecondArray", "2SecondArray", "3SecondArray" };

            //First Approach
            string[] arr = array1.Concat(array2).ToArray();

            foreach (var arrvalue in arr)
            {
                Console.WriteLine(arrvalue);
            }

            //Second Approach
            Console.WriteLine();

            int array1Lenght = array1.Length;
            int array2Lenght = array2.Length;
            string[] arr2Approach = new string[array1Lenght + array2Lenght];
            int count = 0;

            foreach (var arr1 in array1)
            {
                arr2Approach[count] = arr1;
                count++;
            }

            foreach (var arr2 in array2)
            {
                arr2Approach[count] = arr2;
                count++;
            }
            foreach (var item in arr2Approach)
            {
                Console.WriteLine(item);
            }

        }
    }
}
