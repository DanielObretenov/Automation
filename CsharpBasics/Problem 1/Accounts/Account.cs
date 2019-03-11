using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpBasics
{
    public abstract class Account
    {

        public virtual decimal Balance()
        {
            Console.WriteLine("Initial balance = {0}", 1000);
            return 1000;
        }

        public abstract decimal interestPercentage();

    }
}
