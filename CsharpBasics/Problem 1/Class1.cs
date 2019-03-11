using CsharpBasics.Accounts;
using System;

namespace CsharpBasics
{
    class Program
    {
        static void Main(string[] args)
        {

            Deposit_Account user1 = new Deposit_Account("Daniel");

            user1.InterestPerc = 0.065m;
            user1.NumberOfmonths = 6;
            user1.Deposit(500);
            user1.withdraw(400);
            user1.interestPercentage();
            Console.WriteLine();

            Credit_Account user2 = new Credit_Account("Daniel");
            user2.NumberOfMonths = 6;
            user2.InterestPerc = 0.065m;
            user2.Deposit(300);
            user2.PersonalAccountOptions();
            Console.WriteLine();

            Morgage_Account user3 = new Morgage_Account("Daniel");
            user3.NumberOfMonths = 6;
            user3.InterestPerc = 0.065m;
            user3.Deposit(200);
            user3.BusinessAccountOptions();
        }
    }
}
