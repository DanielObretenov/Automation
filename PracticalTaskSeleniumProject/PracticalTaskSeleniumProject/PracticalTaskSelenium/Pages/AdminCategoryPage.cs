using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PracticalTaskSeleniumProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages
{
    class AdminCategoryPage:BasePage
    {
        Actions actions; 
        [FindsBy(How = How.XPath, Using = "//div[@id='flashMessage']")]
        protected IWebElement successMessage ;

        [FindsBy(How = How.XPath, Using = "//tbody//td[1]/a")]
        protected IList<IWebElement> titles;

        [FindsBy(How = How.XPath, Using = "//div[@id='flashMessage'][text()='Attributes Value Saved.']")]
        protected IWebElement alertMessageAttributes;


        [FindsBy(How = How.XPath, Using = "//div[@id='flashMessage'][text()='Inactivated content item.']")]
        protected IWebElement alertMessageDeactivate;

        [FindsBy(How = How.XPath, Using = "//tr")]
        protected IList<IWebElement> tableRows;

        [FindsBy(How = How.XPath, Using = "//select[@id='multiaction']")]
        protected IWebElement multiActionDropDown;

        public AdminCategoryPage(IWebDriver driver) : base(driver)
        {

        }

        public bool IsNewProductCreated()
        {
           return successMessage.Text.Equals("Record saved.");
        }
        public bool IsProductDeactivated()
        {
            Wait.WaitUntilClickable(webDriver, alertMessageDeactivate);
            return alertMessageDeactivate.Text.Equals("Inactivated content item.");
        }

        public AdminCreateOrEditProductPage ClickOnProduct(string title)
        {
            foreach (IWebElement item in titles)
            {
                if (item.Text.Contains(title))
                {
                    item.Click();
                    return new AdminCreateOrEditProductPage(webDriver);
                }
                
            }
            throw new Exception("No such title");
        }

        public bool IsAlertForAttributesDisplayed()
        {
            return alertMessageAttributes.Displayed;
        }

        public int GetIndexOfRow(string Title)
        {
            foreach (IWebElement row in tableRows)
            {
                if (row.Text.Contains(Title))
                {
                    Console.WriteLine(tableRows.IndexOf(row));
                    return tableRows.IndexOf(row);
                }
            }
            throw new Exception("No such element");
        }

        public void DeactivateFromMultiActionDropDown(string Action)
        {
            Wait.WaitUntilClickable(webDriver, multiActionDropDown);
            SelectElement multiDropdow = new SelectElement(multiActionDropDown);
            multiDropdow.SelectByText(Action);
            
        }
        public ProductTable AgreeToDisableProductAlert()
        {
            Alerts.HandleAlert(true, webDriver);
            webDriver.SwitchTo().DefaultContent();
            return new ProductTable(webDriver);
        }
    }
}
