using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.Pages
{
    class BasePageEaster : BaseTestEaster
    {
        protected  IWebDriver webDriver { get; }
        protected int random { get; set; }
        protected static Random rnd = new Random();

        public BasePageEaster(IWebDriver webDriver )
        {
            this.webDriver = webDriver;
        }
        protected static readonly By cookieBanner = By.XPath("//*[@id='cookie-banner']//button");
        protected static readonly By cookieBannerBox = By.XPath("//*[@id='cookie-banner']");

   
        

    }
}
