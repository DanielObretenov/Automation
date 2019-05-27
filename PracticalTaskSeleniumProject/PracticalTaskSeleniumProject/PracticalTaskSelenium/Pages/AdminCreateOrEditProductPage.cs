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
    class AdminCreateOrEditProductPage:BasePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@id='chosen_select_parent_chosen']")]
        protected IWebElement parentDropDown;

        [FindsBy(How = How.XPath, Using = "//li[text()='Tablets']")]
        protected IWebElement parentTabletOption;

        [FindsBy(How = How.XPath, Using = "//input[@id='ContentDescription][1][name1']")]
        protected IWebElement titleField;

        [FindsBy(How = How.XPath, Using = "//body[@id='tinymce']")]
        protected IWebElement desctiptionBox;

        [FindsBy(How = How.XPath, Using = "//a[@href='#data']")]
        protected IWebElement dataTab;

        [FindsBy(How = How.XPath, Using = "//select[@id='ContentProductLabelId']")]
        protected IWebElement productLabelDropdown;

        [FindsBy(How = How.XPath, Using = "//button[@id='submitbutton']")]
        protected IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "//a[@href='#atributes']")]
        protected IWebElement attributesTab;


        [FindsBy(How = How.XPath, Using = "//div[@id='atributes']/a")]
        protected IWebElement clickSetAttributesValues;


        [FindsBy(How = How.XPath, Using = "//a[@href='/attributes/admin_editor_value/save/']")]
        protected IWebElement clickAApplyttribute;

        [FindsBy(How = How.XPath, Using = "//input[@id='ContentProductIsNew']")]
        protected IWebElement NewProductDataTab;


        [FindsBy(How = How.XPath, Using = "//input[@name='data[values_s][70][set]']")]
        protected IList<IWebElement> setStorage;


        [FindsBy(How = How.XPath, Using = "//div[@id='editAttrModal']")]
        protected IList<IWebElement> fadeModal;

        protected string parentOption = "Tablet";
        protected string productLabelOption = "New";
        protected string frameForDescription = "content_description_1_ifr";
        protected string frameForShortDescription = "content_short_description_1_ifr";


        public AdminCreateOrEditProductPage(IWebDriver driver) : base(driver)
        {

        }

        public void SelectOptionFromParentDropdown()
        {
            parentDropDown.Click();
            Wait.WaitUntilClickable(webDriver,parentTabletOption);
            parentTabletOption.Click();
            webDriver.SwitchTo().DefaultContent();

        }


        public void WriteDescription(string textForDescription)
        {
            webDriver.SwitchTo().Frame(frameForDescription);
            desctiptionBox.Clear();
            desctiptionBox.SendKeys(textForDescription);
            webDriver.SwitchTo().DefaultContent();

        }

        public void WriteShortDescription(string textForShortDescription)
        {
            webDriver.SwitchTo().Frame(frameForShortDescription);
            desctiptionBox.Clear();
            desctiptionBox.SendKeys(textForShortDescription);
            webDriver.SwitchTo().DefaultContent();

        }
        public void NavigateToDataTab()
        {
            dataTab.Click();
        }
        public void SelectProductLabel()
        {
            SelectElement SelectProductLabel = new SelectElement(productLabelDropdown);
            SelectProductLabel.SelectByText(productLabelOption);
        }

        public void AddTitle(string title)
        {
            titleField.Clear();
            titleField.SendKeys(title);
        }
        public AdminCategoryPage SubmitProduct()
        {
            Wait.WaitUntilClickable(webDriver, submitButton);
            submitButton.Click();
            return new AdminCategoryPage(webDriver);
        }

        public void OpenAttributesTab()
        {
            Wait.WaitUntilClickable(webDriver, attributesTab);
            attributesTab.Click();
        }

        public void SetAttributesValueToStorage16()
        {
            Wait.WaitUntilClickable(webDriver, clickSetAttributesValues);
            clickSetAttributesValues.Click();
            Wait.WaitUntilClickable(webDriver, setStorage[1]);
            setStorage[1].Click();
            Wait.WaitUntilClickable(webDriver, clickAApplyttribute);
            clickAApplyttribute.Click();
            Wait.InvisibilityOfElement(webDriver, By.XPath("//div[@id='editAttrModal']"));
            webDriver.SwitchTo().DefaultContent();
        }

        public void CheckNewProductInTheDataTab()
        {
            if (!NewProductDataTab.Selected)
            {
                NewProductDataTab.Click();
            }
        }
        public string RandomName()
        {
            Random rnd = new Random();
            int random = rnd.Next(0, 1000);
            string randomName = "Test" + random;
            return randomName;
        }
    }
}
