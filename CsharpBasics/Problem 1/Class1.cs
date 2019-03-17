using System;

namespace CsharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            Person User = new Person("Dani", "Obretenov", "9308077120");
            EgnValidator Validator = new EgnValidator(User);

            Console.WriteLine();

            Person User2 = new Person("Zlatka", "Zlateva", "0151097110");
            Validator = new EgnValidator(User2);

        }
    }
}
