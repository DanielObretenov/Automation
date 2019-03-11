using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasics.Accounts
{

        class Deposit_Account : Account
        {
            private string name;
            private decimal deposit;
            private decimal balance;
            private decimal interestPerc;
            private int numberOfmonths;

            public Deposit_Account(string name)
            {
                this.name = name;
                this.balance = Balance();
            }

            //Props
            public int NumberOfmonths
            {
                get { return numberOfmonths; }
                set { numberOfmonths = value; }
            }


            public decimal InterestPerc
            {
                get { return interestPerc; }
                set { interestPerc = value; }
            }
            //metods
            public override decimal interestPercentage()
            {
                if (this.balance > 0 && this.balance <= 1000)
                {
                    Console.WriteLine("No Interest. Your Balance is the same: " + this.balance);
                }
                else
                {
                    Console.WriteLine("Balance with Interest for {0} months with montlhy interest {1} is: {2:f2}", numberOfmonths, interestPerc, (this.balance + this.balance * numberOfmonths * interestPerc));

                }
                return this.interestPerc;
            }

            public void Deposit(decimal deposit)
            {
                if (deposit > 0)
                {
                    this.deposit = deposit;
                    this.balance += this.deposit;
                    Console.WriteLine("You Have deposited {0}. New balance is: {1}", deposit, this.balance);
                }
            }

            public override decimal Balance()
            {
                return base.Balance();
            }


            public void withdraw(decimal amount)
            {
                if (amount < this.balance)
                {
                    this.balance -= amount;
                    Console.WriteLine("You have withdrawed {0}. Remaining balance is {1}", amount, this.balance);
                }
                else
                {
                    Console.WriteLine("You do not have enough money in your card. Balance: " + this.balance);

                }
            }
        }
    
}
