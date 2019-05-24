using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster
{
    public static class JSHelper 
    {
        public static void RunJSHelper(string script, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script);
        }
        public static  void RunJSHelper(string script, IWebElement el, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript(script, el);
        }
    }
}
