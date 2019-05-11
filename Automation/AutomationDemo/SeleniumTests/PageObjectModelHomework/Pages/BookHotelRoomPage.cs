using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
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
        //public static readonly By CouponSection = By.CssSelector("#bookingdetails");
        //public static readonly By FirstName = By.CssSelector("[name = 'firstname']");
        //public static readonly By LastName = By.CssSelector("[name = 'lastname']");
        //public static readonly By Email = By.CssSelector("[name = 'email']");
        //public static readonly By ConfirmEmail = By.CssSelector("[name = 'confirmemail']");
        //public static readonly By Phone = By.CssSelector("[name = 'phone']");
        //public static readonly By Address = By.CssSelector("[name = 'address']");
        //public static readonly By CountryDropDown = By.CssSelector("#s2id_autogen1");
        //public static readonly By CouponField = By.CssSelector("input.RTL.form-control.coupon");
        //public static readonly By ConfirmBooking = By.CssSelector("button.completebook");
        //public static readonly By applyCoupon = By.CssSelector("span.applycoupon");
        //private static readonly By countryDropDownList = By.CssSelector("ul.select2-results");
        //private static readonly By countryDropDownOptions = By.CssSelector("ul.select2-results li");
        [FindsBy(How = How.CssSelector, Using = "#bookingdetails")]
        protected IWebElement CouponSection;

        [FindsBy(How = How.CssSelector, Using = "[name = 'firstname']")]
        protected IWebElement FirstName;

        [FindsBy(How = How.CssSelector, Using = "[name = 'lastname']")]
        protected IWebElement LastName;

        [FindsBy(How = How.CssSelector, Using = "[name = 'email']")]
        protected IWebElement Email;

        [FindsBy(How = How.CssSelector, Using = "[name = 'confirmemail']")]
        protected IWebElement ConfirmEmail;

        [FindsBy(How = How.CssSelector, Using = "[name = 'phone']")]
        protected IWebElement Phone;

        [FindsBy(How = How.CssSelector, Using = "[name = 'address']")]
        protected IWebElement Address;

        [FindsBy(How = How.CssSelector, Using = "#s2id_autogen1")]
        protected IWebElement CountryDropDown;

        [FindsBy(How = How.CssSelector, Using = "input.RTL.form-control.coupon")]
        protected IWebElement CouponField;

        [FindsBy(How = How.CssSelector, Using = "button.completebook")]
        protected IWebElement ConfirmBooking;

        [FindsBy(How = How.CssSelector, Using = "span.applycoupon")]
        protected IWebElement applyCoupon;

        [FindsBy(How = How.CssSelector, Using = "ul.select2-results")]
        protected IWebElement countryDropDownList;

        [FindsBy(How = How.CssSelector, Using = "ul.select2-results li")]
        protected IList<IWebElement> countryDropDownOptions;


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
            Wait.ClickableElement(webDriver, CouponSection);
        }
        public InvoicePage FillOutForm()
        {

            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
            Email.SendKeys(emailAddress);
            ConfirmEmail.SendKeys(emailAddress);
            Phone.SendKeys(phone);
            Address.SendKeys(address);
            CountryDropDown.Click();
            Wait.ClickableElement(webDriver,countryDropDownList);
            countryDropDownOptions[2].Click();
            CouponField.Clear();
            CouponField.SendKeys(couponField);
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", applyCoupon, this.webDriver);
            applyCoupon.Click();
            Wait.AlertIsPresent(this.webDriver);
            Alerts.HandleAlert(false, this.webDriver);
            webDriver.SwitchTo().DefaultContent();
            ConfirmBooking.Click();

            return new InvoicePage(webDriver);
        }

    }
}
