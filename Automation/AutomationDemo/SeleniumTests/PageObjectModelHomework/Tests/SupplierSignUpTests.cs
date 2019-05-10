using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Tests
{
    class SupplierSignUpTests : BaseTestHomework
    {
        [Test]
        public void OpenEasyRegistratiopn()
        {

            HomePage homePage = new HomePage(driver);
            homePage.NavigateToHomePage();
            SupplierSignUpPage supplierSignUpPage = homePage.NavigateToSupplierSignUpPageByFooter();
            supplierSignUpPage.OpenEasyRegistrationForm();
            Assert.IsTrue(supplierSignUpPage.ConfirmTextVisiblity());
        }
    }
}
