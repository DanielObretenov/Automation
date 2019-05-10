using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    
    class SupplierSignUpPage : BasePage
    {
        private static readonly By Carousel = By.XPath("//div[@id='Carousel']");
        private static readonly By Hotel = By.XPath("//button[@id='hotels']");
        private static readonly By StartedSection = By.XPath("//section[@class='started']");
        private static readonly By startedSectionTitleAct = By.XPath("//h2[@class='text-center']");
        private string startedSectionTitleExp = "Easy registration process";

        public SupplierSignUpPage(IWebDriver webDriver) : base(webDriver)
        {

        }


        public void OpenEasyRegistrationForm()
        {

            Wait.VisibilityOfElement(webDriver, Carousel);
            webDriver.FindElement(Hotel).Click();
            RunningJSTests run = new RunningJSTests();
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", webDriver.FindElement(StartedSection), this.webDriver);
            Wait.VisibilityOfElement(webDriver, StartedSection);
        }

        public bool ConfirmTextVisiblity()
        {
            return webDriver.FindElement(startedSectionTitleAct).Text.Equals(startedSectionTitleExp);
        }
    }
}
