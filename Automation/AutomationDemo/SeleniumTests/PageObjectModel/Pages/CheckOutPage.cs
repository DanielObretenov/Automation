using AutomationDemo.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Pages
{
    class CheckOutPage :BasePage
    {
        private static readonly By Email = By.XPath("//*[@id='email']");
        private static readonly By Name = By.XPath("//*[@id='name']");
        private static readonly By CardType = By.XPath("//*[@id='card_type']");
        private static readonly By VerificationCode = By.XPath("//*[@id='verification_code']");
        private static readonly By PlaceOrderButton = By.XPath("//*[@class='btn btn-primary']");


        public CheckOutPage(IWebDriver webDriver) :base(webDriver)
        {

        }

        private  void ChooseCardType(string cardType)
        {
            Wait.VisibilityOfElement(webDriver, CardType);
            IWebElement cardTypeElement = webDriver.FindElement(CardType);
            SelectElement cardTypeDropDown = new SelectElement(cardTypeElement);
            cardTypeDropDown.SelectByText(cardType);
        }

        public void FillingForm()
        {
            this.webDriver.FindElement(Email).SendKeys("daniel.obretenov@mentormate.com");
            this.webDriver.FindElement(Name).SendKeys("Daniel Obretenov");
            ChooseCardType("Visa");
            this.webDriver.FindElement(VerificationCode).SendKeys("12345");
        }

        public MenuPage PlaceOrder()
        {
            webDriver.FindElement(PlaceOrderButton).Click();
            return new MenuPage(webDriver);
        }
    }
}
