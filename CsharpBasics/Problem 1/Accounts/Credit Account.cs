using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpBasics.Accounts
{
    class Credit_Account : Account , IBusinessAccount , IPersonalAccount
    {
        private string name;
        private decimal balance;
        private decimal deposit;
        private decimal interestPerc;
        private int numberOfMonts;
        private int discountInterest;





        public Credit_Account(string name)
        {
            this.name = name;
            this.balance = Balance();
        }

        //props
        public decimal InterestPerc
        {
            get { return interestPerc; }
            set
            {
                if (value>0)
                {
                    interestPerc = value;
                }
                else
                {
                    Console.WriteLine("Please enter valid percentage");
                }
            }
        }

        public int NumberOfMonths
        {
            get { return numberOfMonts; }
            set
            {

                if (value > 0)
                {
                    numberOfMonts = value;
                }
                else
                {
                    Console.WriteLine("Please enter valid number of months");
                }
              
            }
        }

        //methods
        public override decimal Balance()
        {
            return base.Balance();
        }
      


        public override decimal interestPercentage()
        {
          return  this.numberOfMonts*this.interestPerc;
        }
        public void Deposit(decimal deposit)
        {
            if (deposit > 0 && this.balance > 0 && deposit< this.balance)
            {
                this.deposit = deposit;
                this.balance -= this.deposit;
                Console.WriteLine("You Have deposited {0:f2}. New balance is {1:f2}", deposit, this.balance);
            }
            else if (deposit > this.balance && this.balance!=0)
            {
                Console.WriteLine("You have deposited more than enough.You have paid your dept. {0:f2} to spare", deposit - this.balance);
                this.balance = 0; 
               
            }
            else if (this.balance == 0 )
            {
                Console.WriteLine("No need to deposit. You have paid your dept");
            }
            else
            {
                Console.WriteLine("Please enter valid amount");
            }
        }

        public void PersonalAccountOptions()
        {
            this.discountInterest = this.numberOfMonts - 3;
            BusinessAndAccountOptions();

        }
        public void BusinessAccountOptions()
        {
            this.discountInterest = this.numberOfMonts - 2;
            BusinessAndAccountOptions();
        }

        public void BusinessAndAccountOptions()
        {
            decimal newbalance = this.balance + this.balance * (discountInterest * interestPerc);
            if (balance > 0 && newbalance > 0)
            {


                Console.WriteLine
                    ("Balance with interest for {0} months with {1} percentage is {2:f2}"
                    , this.numberOfMonts, this.interestPerc, this.balance + this.balance * (discountInterest * interestPerc));
            }

            else if (newbalance < 0)
            {
                Console.WriteLine("Too many months. You need to it sooner");
            }
        }
    }
}
