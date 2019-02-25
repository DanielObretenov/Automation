using System;

namespace LectureSeven
{
    class Program
    {
        static void Main(string[] args)
        {
            Student firstStudent = new Student("Daniel", "Obretenov", "Yes");
            firstStudent.Subject = "Maths";
            firstStudent.YearAdmission = "2001";
            firstStudent.Gender = "Male";
            firstStudent.Hometown = "Sofia";
            firstStudent.StudentNumberGenerator();
            firstStudent.RandomDateOfBirth();
            firstStudent.EmailSimulator();
            firstStudent.ViewProfile();
            Console.WriteLine();

            Student secondtStudent = new Student("Second", "User", "text");
            secondtStudent.Subject = "Chemistry";
            secondtStudent.StudentNumberGenerator();
            secondtStudent.RandomDateOfBirth();
            secondtStudent.EmailSimulator();
            secondtStudent.ViewProfile();
            Console.WriteLine();

            Student thirdStudent = new Student("Dan", "Obretenov", "No", "Male");
            thirdStudent.Address.Building = 32;
            thirdStudent.Address.Floor = 1;
            thirdStudent.Address.Street = "Tsvetan Lazarov";
            thirdStudent.ViewProfile();





        }
    }
}
