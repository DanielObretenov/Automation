using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest
{
    [TestFixture]

    class Interest
    {
        //testBorders
        [Test]
        [Category("IsPercentageCorrect")]
        [TestCase(-1, 0)]
        [TestCase(0.3, 3)]
        [TestCase(100, 3)]
        [TestCase(100.1, 5)]
        [TestCase(999.99, 5)]
        public void IsPercentageCorect(decimal accoountBalance, decimal expectedInterest)
        {
            decimal actualInterest = CalcInterest(accoountBalance);
            Assert.IsTrue(actualInterest == expectedInterest);
        }



        //testValuesFrom100to1000
        [Test]
        [Category("IsPercentageCorrect")]

        [TestCaseSource("GetValuesFrom100to1000")]
        public void PercentagesFrom100to1000(decimal accountBalance)
        {
            decimal actualInterest = CalcInterest(accountBalance);
        }
        public static IEnumerable GetValuesFrom100to1000
        {
            get
            {
                for (decimal i = 101; i < 1000; i++)
                {
                    yield return new TestCaseData(i);
                }
            }
        }

        //Calculation for interest
        public decimal CalcInterest(decimal accountBalance)
        {
            if (accountBalance >= 1000)
            {
                return 7;
            }
            else if (accountBalance > 100)
            {
                return 5;
            }
            else if (accountBalance > 0)
            {
                return 3;
            }
            return 0;
        }
    }
}
