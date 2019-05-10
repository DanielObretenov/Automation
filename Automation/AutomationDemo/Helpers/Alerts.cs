using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster
{
    public class Alerts
    {
        public IAlert alert;

        public string GetAlertText(IWebDriver driver)
        {
            alert = driver.SwitchTo().Alert();

            return alert.Text;
        }

        public void HandleAlert(bool accept, IWebDriver driver)
        {
            alert = driver.SwitchTo().Alert();
            if (accept)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }
        }

        public void EnterTextToAlert(string text, IWebDriver driver)
        {
            alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
        }
    }
}
