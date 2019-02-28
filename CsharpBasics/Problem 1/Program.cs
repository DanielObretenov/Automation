using System;

namespace LectureSeven
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            Student firstStudent = new Student("gds", "Obrete2141nov");
            firstStudent.Subject = "Maths";
            firstStudent.YearAdmission = "2011";
            firstStudent.Gender = "Male";
            firstStudent.Hometown = "Sofia";
            firstStudent.DateOfBirth = new DateTime(2011, 11, 01);
            firstStudent.StudentNumber = "11Maths1999110142";
            firstStudent.ViewProfile();
            Console.WriteLine();

            Student secondtStudent = new Student("Second", "User", "text");
            secondtStudent.Subject = "Chemistry";
            secondtStudent.ViewProfile();
            Console.WriteLine();

            Student thirdStudent = new Student("Da231n", "Obretenov",  "Male");
            thirdStudent.Address.Building = 32;
            thirdStudent.Address.Floor = 1;
            thirdStudent.Address.Street = "Tsvetan Lazarov";
            thirdStudent.ViewProfile();





        }
    }
}
