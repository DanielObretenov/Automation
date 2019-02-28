using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LectureSeven
{
    class Student
    {
     

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
        private Regex yearOfAdmissionRegex = new Regex(@"(\d{1,2})([A-z]+)(\d{4})(\d{2})(\d{2})(\d{2})") ;
        private Match match;


        public Student(string firstname, string lastname)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Subject = "null";
            this.DateOfBirth = RandomDateOfBirth();
            this.YearAdmission = "null";
            this.Gender = "null";
            this.Hometown = "null";
            this.EducationStatus = "inactive";
            this.address = new StudendCurrentAddress("Street", 152);
        }

        public Student(string firstname, string lastname,  string gender)
        : this(firstname, lastname )
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
                if (value.ToString().ToLower() == "active")
                {

                    this.educationStatus = "active";
                }
                else
                {
                    this.educationStatus = "inactive";
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
            get { return EmailSimulator(); }
        }

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }
        public DateTime DateOfBirth
        {
            get {return dateOfBirth; }
            set
            {
                if (!value.Year.Equals(0001) && value.Year < 2000 )
                {
                    this.dateOfBirth = value;
                }
                else
                {
                    this.dateOfBirth = RandomDateOfBirth();
                }

               
            }
        }

        public string StudentNumber
        {
            get { return this.studentNumber; }
            set
            {
                match = yearOfAdmissionRegex.Match(value);
                int.TryParse(this.yearAdmission, out int result);
                if (match.Groups[1].ToString() == (result - 2000 ).ToString("d2") 
                    && match.Groups[2].ToString() == this.Subject
                    && match.Groups[3].ToString() == this.DateOfBirth.Year.ToString()
                    && match.Groups[4].ToString() == this.DateOfBirth.Month.ToString("d2")
                    && match.Groups[5].ToString() == this.DateOfBirth.Day.ToString("d2")
                    && match.Groups[6].ToString().Length == 2)
                {
                    this.studentNumber = value;
                }
                else
                {
                    this.studentNumber = StudentNumberGenerator();
                }
            
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z]+$"))
                {
                    this.lastName = value;
                }
                else
                {
                    this.lastName = "Invalid";

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
                    this.firstName = value;

                }
                else
                {
                    this.firstName = "Invalid"; 
                }
            }

        }
        //methods

        private string EmailSimulator()
        {
            if (this.firstName != "Invalid" && this.lastName != "Invalid")
            {
                this.email = $"{this.FirstName}.{this.LastName}@mentormate.com";
            }
            else
            {
                this.email = "Please Enter Valid First and Last Name";
            }
            return
            this.email ;

        }

        private DateTime RandomDateOfBirth()
        {
            DateTime startDate = new DateTime(currnetDate.Year - 49, currnetDate.Month, currnetDate.Day);
            DateTime endDate = new DateTime(currnetDate.Year - 19, currnetDate.Month, currnetDate.Day);
            int range = (endDate - startDate).Days;
            return this.dateOfBirth = startDate.AddDays(gen.Next(1, range));
        }

        private string StudentNumberGenerator()
        {
            return
            this.studentNumber = string.Format(this.gen.Next(1, 19) + this.Subject + this.dateOfBirth.Year + this.dateOfBirth.Month.ToString("d2") + this.dateOfBirth.Day.ToString("d2") + this.gen.Next(1, 10) + this.gen.Next(1, 10)) + " Randomly Generated";
            
        }

        public void ViewProfile()
        {
            Console.WriteLine("First Name: " + this.FirstName);
            Console.WriteLine("Last Name: " + this.LastName);
            Console.WriteLine("Subject: " + this.Subject);
            Console.WriteLine("email: " + this.Email);
            Console.WriteLine("DOB: " + this.DateOfBirth.ToString("yyyy/MM/dd"));
            Console.WriteLine("Admission: " + this.YearAdmission);
            Console.WriteLine("Gender: " + this.Gender);
            Console.WriteLine("Hometown: " + this.Hometown);
            Console.WriteLine("Education Status: " + this.EducationStatus);
            Console.WriteLine("Student Number: " + this.StudentNumber);
            this.address.ViewAdderss();
        }

    }
}
