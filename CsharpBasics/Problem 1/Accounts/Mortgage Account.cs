using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpBasics.Accounts
{
    class Morgage_Account : Account, IPersonalAccount, IBusinessAccount
    {
        private string name;
        private decimal balance;
        private decimal deposit;
        private decimal interestPerc;
        private decimal numberOfMonths;




        public Morgage_Account(string name)
        {
            this.name = name;
            this.balance = Balance();
        }


        //props 
        public decimal InterestPerc
        {
            get { return interestPerc; }
            set { interestPerc = value; }
        }

        public decimal NumberOfMonths
        {
            get { return numberOfMonths; }
            set { numberOfMonths = value; }
        }


        //methods
        public override decimal Balance()
        {
            return base.Balance();
        }
        public override decimal interestPercentage()
        {
            return this.numberOfMonths * this.interestPerc;
        }


        public void BusinessAccountOptions()
        {

            if (numberOfMonths > 12)
            {
                decimal balanceForFirst12Months = this.balance + this.balance * 12 * this.InterestPerc / 2;
                decimal balanceAfter12Months = this.balance + this.balance * ((this.NumberOfMonths - 12) * this.InterestPerc);
                this.balance = balanceForFirst12Months + balanceAfter12Months;

            }
            else
            {

                decimal balanceForFirst12Months = this.balance + this.balance * NumberOfMonths * this.InterestPerc / 2;
                this.balance = balanceForFirst12Months;
            }
            Console.WriteLine("Balance in {0} months will be: {1:f2}", numberOfMonths, this.balance);

        }
        public void PersonalAccountOptions()
        {
            if (numberOfMonths > 6)
            {
                this.balance = this.balance + this.balance * (NumberOfMonths - 6) * this.InterestPerc;
            }
            Console.WriteLine("Balance in {0} months will be: {1:f2}", numberOfMonths, this.balance);

        }

        public void Deposit(decimal deposit)
        {
            if (deposit > 0 && this.balance > 0 && deposit < this.balance)
            {
                this.deposit = deposit;
                this.balance -= this.deposit;
                Console.WriteLine("You Have deposited {0:f2}. New balance is: {1:f2}", deposit, this.balance);
            }
            else if (deposit > this.balance && this.balance != 0)
            {
                Console.WriteLine("You have deposited more than enough.You have paid your dept. {0:f2} to spare", deposit - this.balance);
                this.balance = 0;

            }
            else if (this.balance == 0)
            {
                Console.WriteLine("No need to deposit. You have paid your dept");
            }
            else
            {
                Console.WriteLine("Please enter valid amount");
            }
        }

    }
}
