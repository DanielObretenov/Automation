using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.Helpers
{
    public static class Alerts
    {
        public static IAlert alert;

        public static string GetAlertText(IWebDriver driver)
        {
            alert = driver.SwitchTo().Alert();

            return alert.Text;
        }
        public static void HandleAlert(bool accept, IWebDriver driver)
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

        public static void EnterTextToAlert(string text, IWebDriver driver)
        {
            alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
        }
    }
}
