using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
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
        //private static readonly By Carousel = By.XPath("//div[@id='Carousel']");
        //private static readonly By Hotel = By.XPath("//button[@id='hotels']");
        //private static readonly By StartedSection = By.XPath("//section[@class='started']");
        //private static readonly By startedSectionTitleAct = By.XPath("//h2[@class='text-center']");

        [FindsBy(How = How.XPath, Using = "//div[@id='Carousel']")]
        protected IWebElement Carousel;

        [FindsBy(How = How.XPath, Using = "//button[@id='hotels']")]
        protected IWebElement Hotel;

        [FindsBy(How = How.XPath, Using = "//section[@class='started']")]
        protected IWebElement StartedSection;

        [FindsBy(How = How.XPath, Using = "//h2[@class='text-center']")]
        protected IWebElement startedSectionTitleAct;

     

        private string startedSectionTitleExp = "Easy registration process";

        public SupplierSignUpPage(IWebDriver webDriver) : base(webDriver)
        {

        }


        public void OpenEasyRegistrationForm()
        {

            Wait.ClickableElement(webDriver, Carousel);
            Hotel.Click();
            RunningJSTests run = new RunningJSTests();
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", StartedSection, this.webDriver);
            Wait.ClickableElement(webDriver, StartedSection);
        }

        public bool ConfirmTextVisiblity()
        {
            return startedSectionTitleAct.Text.Equals(startedSectionTitleExp);
        }
    }
}
