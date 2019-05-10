using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModel.Pages
{
    class LetsTalkTeaPage : BasePage
    {
        private static readonly By Name = By.XPath("//input[@name='name']");
        private static readonly By Email = By.XPath("//input[@name='email']");
        private static readonly By Subject = By.XPath("//input[@name='subject']");
        private static readonly By Message = By.XPath("//input[@name='message']");
        private static readonly By SubmitButton = By.XPath("//input[@value='Submit']");

        public LetsTalkTeaPage(IWebDriver webDriver) : base(webDriver)
        {

        }
        public void FillinForm()
        {
            this.webDriver.FindElement(Name).SendKeys("Daniel");
            this.webDriver.FindElement(Email).SendKeys("daniel.obretenov@mentormate.com");
            this.webDriver.FindElement(Subject).SendKeys("Tea");
            this.webDriver.FindElement(Message).SendKeys("I want Some tea");
        }
        public void ClickSubmit()
        {
            this.webDriver.FindElement(SubmitButton).Click();
        }
    }
}
