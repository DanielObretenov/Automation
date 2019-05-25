using OpenQA.Selenium;
using PracticalTaskSeleniumProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTaskSeleniumProject.PracticalTaskSelenium.Pages
{
    class ProductTable:BasePage
    {
        private List<ProductRows> tableRows = new List<ProductRows>();
        private static readonly By TableRoot = By.XPath("//table[@class='contentTable']");

        public ProductTable(IWebDriver webDriver):base(webDriver)
        {
            Wait.VisibilityOfElement(webDriver, TableRoot);
            tableRows = LoadAllRows();
        }

        public List<ProductRows> LoadAllRows()
        {
            IWebElement table = webDriver.FindElement(By.XPath("//table[@class='contentTable']"));
            IList<IWebElement> allLines = webDriver.FindElement(TableRoot).FindElements(By.TagName("tr"));
            List<ProductRows> allRows = new List<ProductRows>();

            foreach (IWebElement row in allLines)
            {
                allRows.Add(new ProductRows(webDriver, row));
            }
            return allRows;
        }

        public ProductRows GetRowByTitle(string Title)
        {
            foreach (ProductRows row in tableRows.Skip(2))
            {
                if (row.GetTitle().Equals(Title))
                {
                    return row;
                }
            }

            throw new Exception("Row not found");
        }

        public ProductRows GetRowByIndex(int index)
        {
            return tableRows.ElementAt(index);
        }


    }
}
