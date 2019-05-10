using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class BookHotelRoomPage: BasePage
    {
        public static readonly By CouponSection = By.CssSelector("#bookingdetails");
        public static readonly By FirstName = By.CssSelector("[name = 'firstname']");
        public static readonly By LastName = By.CssSelector("[name = 'lastname']");
        public static readonly By Email = By.CssSelector("[name = 'email']");
        public static readonly By ConfirmEmail = By.CssSelector("[name = 'confirmemail']");
        public static readonly By Phone = By.CssSelector("[name = 'phone']");
        public static readonly By Address = By.CssSelector("[name = 'address']");
        public static readonly By CountryDropDown = By.Id("s2id_autogen1");
        public static readonly By CouponField = By.CssSelector("input.RTL.form-control.coupon");
        public static readonly By ConfirmBooking = By.CssSelector("button.completebook");
        public static readonly By applyCoupon = By.CssSelector("span.applycoupon");
        private static readonly By countryDropDownList = By.CssSelector("ul.select2-results");
        private static readonly By countryDropDownOptions = By.CssSelector("ul.select2-results li");
        private string firstName = "Daniel";
        private string lastName = "Obretenov";
        private string emailAddress = "Daniel.Obretenov@abv.bg";
        private string phone = "53425235";
        private string address = "address";
        private string couponField = "12532";
        private IList<IWebElement> Countries;
        public BookHotelRoomPage(IWebDriver webDriver) : base(webDriver)
        {


        }
        public void WaitForBookHotelRoomPageToLoad()
        {
            Wait.VisibilityOfElement(webDriver, CouponSection);
        }
        public InvoicePage FillOutForm()
        {

            webDriver.FindElement(FirstName).SendKeys(firstName);
            webDriver.FindElement(LastName).SendKeys(lastName);
            webDriver.FindElement(Email).SendKeys(emailAddress);
            webDriver.FindElement(ConfirmEmail).SendKeys(emailAddress);
            webDriver.FindElement(Phone).SendKeys(phone);
            webDriver.FindElement(Address).SendKeys(address);
            webDriver.FindElement(CountryDropDown).Click();
            Wait.ClickableElement(webDriver, webDriver.FindElement(countryDropDownList));
            Countries = webDriver.FindElements(countryDropDownOptions);
            Countries[2].Click();
            webDriver.FindElement(CouponField).Clear();
            webDriver.FindElement(CouponField).SendKeys(couponField);
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", webDriver.FindElement(applyCoupon), this.webDriver);
            webDriver.FindElement(applyCoupon).Click();
            Wait.AlertIsPresent(this.webDriver);
            Alerts.HandleAlert(false, this.webDriver);
            webDriver.SwitchTo().DefaultContent();
            webDriver.FindElement(ConfirmBooking).Click();

            return new InvoicePage(webDriver);
        }

    }
}
