using System;

namespace Problem_7
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateA = new DateTime(1999, 10, 22, 5, 2, 3);
            //YYYYMMDDHHmm
            Console.WriteLine(
                $"your.name+" +
                $"{dateA.Year}" +
                $"{dateA.Month}" +
                $"{dateA.Day}" +
                $"{dateA.Hour}" +
                $"{dateA.Minute}" +
                $"@mentormate.com");
        }
    }
}
