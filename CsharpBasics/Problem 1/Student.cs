using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LectureSeven
{
    class Student
    {
        //        Име
        //   Фамилия
        //Студентски номер(Номерът има следният формат: Година на приемане + Специалност + Дата на раждане + 2 случайни (random) цифри)
        //Специалност
        //email
        //Дата на раждане
        //Година на прием
        //Пол(м/ж)
        //Роден град
        //Статус(активен/прекъснал)
        //Настоящ Адрес

        //fields
        private string firstName;
        private string lastName;
        private string subject;
        private DateTime dateOfBirth;
        private string yearAdmission;
        private string gender;
        private string hometown;
        private string educationStatus;
        private string studentNumber;
        private string email;
        private Random gen = new Random();
        private DateTime currnetDate = DateTime.Now;
        private StudendCurrentAddress address;

        public Student(string firstname, string lastname, string educationStatus)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Subject = "null";
            this.dateOfBirth = RandomDateOfBirth();
            this.YearAdmission = "null";
            this.Gender = "null";
            this.Hometown = "null";
            this.EducationStatus = educationStatus;
            this.address = new StudendCurrentAddress("Street", 152);
        }

        public Student(string firstname, string lastname, string educationStatus, string gender)
        : this(firstname, lastname, educationStatus)
        {
            this.gender = gender;
        }
        public StudendCurrentAddress Address
        {
            get { return this.address; }

        }


        //props
        public string EducationStatus
        {
            get { return educationStatus; }
            set
            {
                if (value.ToLower() == "yes")
                {
                    educationStatus = "active";
                }
                else if (value.ToLower() == "no")
                {
                    educationStatus = "inactive";
                }
                else
                {
                    educationStatus = "invalid";
                }
            }
        }


        public string Hometown
        {
            get { return hometown; }
            set { hometown = value; }
        }


        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }


        public string YearAdmission
        {
            get { return yearAdmission; }
            set
            {
                int.TryParse(value, out int result);
                if (this.currnetDate.Year - result <= 19)
                {
                    yearAdmission = value;
                }
                else
                {
                    yearAdmission = "invalid";
                }
            }
        }

        public string Email
        {
            get { return email; }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    lastName = value;
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    firstName = value;

                }
            }

        }
        //methods

        public string EmailSimulator()
        {
            return
            this.email = $"{this.FirstName}.{this.LastName}@mentormate.com";

        }
        public DateTime RandomDateOfBirth()
        {
            DateTime startDate = new DateTime(currnetDate.Year - 49, currnetDate.Month, currnetDate.Day);
            DateTime endDate = new DateTime(currnetDate.Year - 19, currnetDate.Month, currnetDate.Day);
            int range = (endDate - startDate).Days;
            return this.dateOfBirth = startDate.AddDays(gen.Next(1, range));
        }
        public void ViewProfile()
        {
            Console.WriteLine("First Name: " + this.FirstName);
            Console.WriteLine("Last Name: " + this.LastName);
            Console.WriteLine("Subject: " + this.Subject);
            Console.WriteLine("email: " + this.Email);
            Console.WriteLine("DOB: " + this.dateOfBirth.ToString("yyyy/MM/dd"));
            Console.WriteLine("Admission: " + this.YearAdmission);
            Console.WriteLine("Gender: " + this.Gender);
            Console.WriteLine("Hometown: " + this.Hometown);
            Console.WriteLine("Education Status: " + this.EducationStatus);
            Console.WriteLine("Student Number: " + this.studentNumber);

            this.address.ViewAdderss();
        }

        public string StudentNumberGenerator()
        {

            return
            this.studentNumber = string.Format(this.gen.Next(1, 19) + this.Subject + this.dateOfBirth.Year + this.dateOfBirth.Month + this.dateOfBirth.Day + this.gen.Next(1, 10) + this.gen.Next(1, 10));

        }


    }
}
