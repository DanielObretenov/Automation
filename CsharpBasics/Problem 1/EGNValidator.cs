using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CsharpBasics
{
    class EgnValidator
    {
        private string egn;
        private string firstName;
        private string lastName;
        private Regex regex;
        Match egnGroupMatches;
        int year;
        int month;
        int day;
        int last4digits;
        bool egnWithoutString;
        bool after2000;
        


        public EgnValidator(Person currentUser)
        {
            this.EGN = currentUser.Egn  ;
            regex = new Regex(@"^(\d{2})(\d{2})(\d{2})(\d{4})");
            this.egnGroupMatches = regex.Match(this.egn);
            this.firstName = currentUser.FirstName;
            this.lastName = currentUser.LastName;
            SetVariablesFromRegex();
            BeforeOrAfter2000();
            DateCheck();
        }

        public string EGN
        {
            get { return egn; }
            set{
                bool positive = long.TryParse(value.ToString(), out long result);

                if (value.Length == 10 && value.All(char.IsDigit) && result > 0)
                {
                    this.egn = value;
                    this.egnWithoutString = true;
                }
                else
                {
                    this.egn = "invalid";

                }
            }
        }
        public void SetVariablesFromRegex()
        {
            bool GroupParseYear = int.TryParse(this.egnGroupMatches.Groups[1].ToString(), out this.year);
            bool GroupParseMonth = int.TryParse(this.egnGroupMatches.Groups[2].ToString(), out this.month);
            bool GroupParseDay = int.TryParse(this.egnGroupMatches.Groups[3].ToString(), out this.day);
            bool GroupParse = int.TryParse(this.egnGroupMatches.Groups[4].ToString(), out this.last4digits);

        }

        public void BeforeOrAfter2000()
        {
            if (egnWithoutString)
            {
                if (this.month >=  40 && this.month<= 52 )
                {
                    this.after2000 = true;
                }
                
            }
        }

        public void DateCheck()
        {
            int yearOfBirth;
            int monthOfBirth;
            string date ;
            DateTime validDate;
            if (after2000)
            {
                yearOfBirth = 2000 + year;
                monthOfBirth = this.month - 40;

            }
            else
            {
                
                yearOfBirth = 1900 + year;
                monthOfBirth = this.month ;
            }
            date = string.Format("{0:d2}{1:d2}{2:d2}", yearOfBirth, monthOfBirth, day);

            if (!DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out validDate))
                {
                Console.WriteLine("Not a valid egn");
            }
            else if (validDate > DateTime.Now)
            {
                Console.WriteLine("Baby's coming soon... I am so exited" );
            }
            else
            {
                Console.Write($"First Name: {this.firstName} , Last Name: {this.lastName}, ");
                boyOrAGirl();
                Console.WriteLine($"Your egn is {this.egn}. Your Date Of Birth is {validDate.ToShortDateString()}");
              
            }
        }

        public void boyOrAGirl()
        {
            int lastDigits  ;
            char boyOrGirl = last4digits.ToString()[2];
            bool GroupParseDay = int.TryParse(boyOrGirl.ToString(), out lastDigits);
            if (lastDigits%2==0)
            {
                Console.WriteLine("Gender: M");
            }
            else
            {
                Console.WriteLine("Gender: F");
            }

        }
    }

}
