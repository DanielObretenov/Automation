using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
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
        public static readonly By FirstName = By.ClassName("firstname");
        public static readonly By LastName = By.ClassName("lastname");
        public static readonly By Email = By.ClassName("email");
        public static readonly By ConfirmEmail = By.ClassName("confirmemail");
        public static readonly By Phone = By.ClassName("phone");
        public static readonly By Address = By.ClassName("address");
        public static readonly By CountryDropDown = By.CssSelector("#s2id_autogen1");
        public static readonly By CouponField = By.CssSelector("input.RTL.form-control.coupon");
        public static readonly By ConfirmBooking = By.CssSelector("button.completebook");
        public static readonly By applyCoupon = By.CssSelector("span.applycoupon");
        private SelectElement countryDropDown;
        private string firstName = "Daniel";
        private string lastName = "Obretenov";
        private string emailAddress = "Daniel.Obretenov@abv.bg";
        private string phone = "53425235";
        private string address = "address";
        private string couponField = "12532";
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
            countryDropDown = new SelectElement(webDriver.FindElement(CountryDropDown));
            countryDropDown.Options[0].Click();
            webDriver.FindElement(CouponField).Clear();
            webDriver.FindElement(CouponField).SendKeys(couponField);
            webDriver.FindElement(applyCoupon).Click();
            Alerts.HandleAlert(false, this.webDriver);
            webDriver.SwitchTo().DefaultContent();
            webDriver.FindElement(ConfirmBooking).Click();

            return new InvoicePage(webDriver);
        }

    }
}
