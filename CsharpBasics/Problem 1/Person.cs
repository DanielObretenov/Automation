using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpBasics
{

    class Person
    {
        private string firstName;
        private string lastName;
        private string egn;


        //constructor
        public Person(string firstName, string lastName, string egn)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Egn = egn;
        }


        public string Egn
        {
            get { return egn; }
            set { egn = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.All(char.IsLetter))
                {
                    lastName = value;
                }
                else
                {
                    lastName = "Invalid";
                    Console.WriteLine("Please Enter Valid Last Name");
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.All(char.IsLetter))
                {
                    firstName = value;
                }
                else
                {
                    firstName = "Invalid";
                    Console.WriteLine("Please Enter Valid First Name");
                }

            }
        }



    }
}
