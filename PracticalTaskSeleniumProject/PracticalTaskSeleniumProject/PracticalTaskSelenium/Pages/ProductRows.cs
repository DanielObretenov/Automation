using OpenQA.Selenium;
using PracticalTaskSeleniumProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages
{
    class ProductRows:BasePage
    {
        protected IWebElement GivenRow;

        /// <summary>
        /// Colunm Names
        /// </summary>
        protected static readonly By TitleColumn = By.XPath(".//td[1]");
        protected static readonly By TypeColumn = By.XPath(".//td[2]");
        protected static readonly By ActiveColumn = By.XPath(".//td[3]");
        protected static readonly By ShowInMenuColumn = By.XPath(".//td[4]");
        protected static readonly By ExportColumn = By.XPath(".//td[5]");
        protected static readonly By DefaultColumn = By.XPath(".//td[6]");
        protected static readonly By NewColumn = By.XPath(".//td[7]");
        protected static readonly By FeaturedColumn = By.XPath(".//td[8]");
        protected static readonly By PriceColumn = By.XPath(".//td[9]");
        protected static readonly By StockColumn = By.XPath(".//td[10]");
        protected static readonly By SortOrderColumn = By.XPath(".//td[11]");
        protected static readonly By ActionColumn = By.XPath(".//td[12]");
        protected static readonly By CheckMarkForAllColumns = By.XPath(".//td[13]");

        protected static readonly By OnlyTitle = By.XPath(".//td[1]/a");
        protected static readonly By OnlyCheckMark = By.XPath(".//td[13]//input[@id='ContentModify][']");
        protected static readonly By StatusCheckbox = By.XPath(".//td[3]/a/img");


        /// <summary>
        /// Initialize new country row
        /// </summary>
        /// <param name="webdriver"></param>
        /// <param name="givenRow"></param>
        public ProductRows(IWebDriver webdriver, IWebElement givenRow):base(webdriver)
        {
            this.GivenRow = givenRow;
        }

        public string GetTitle()
        {
            By OnlyTitle = By.XPath(".//td[1]/a");
            return GivenRow.FindElement(OnlyTitle).Text;
        }
        public AdminCreateOrEditProductPage ClickOnTitle()
        {
            GivenRow.FindElement(By.XPath(".//td[1]/a")).Click();
            return new AdminCreateOrEditProductPage(webDriver);
        }

        public void ClickOnCheckbox()
        {
            By OnlyCheckMark = By.XPath(".//td[13]//input[@id='ContentModify][']");
            GivenRow.FindElement(OnlyCheckMark).Click();
        }

        public bool IsProductInactive()
        {
            Wait.WaitUntilClickable(webDriver,webDriver.FindElement(StatusCheckbox));
            bool status = false;
            bool.TryParse(GivenRow.FindElement(StatusCheckbox).GetAttribute("title").ToLower(), out status);
            Console.WriteLine(GivenRow.FindElement(StatusCheckbox).GetAttribute("title"));

            return status;
        }
    }
}
