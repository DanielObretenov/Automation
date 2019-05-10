using AutomationDemo.SeleniumTests;
using AutomationDemo.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Text.RegularExpressions;


namespace AutomationDemo.SeleniumTests
{
    [TestFixture]
    public class AdvancedSeleniumHomework : BaseTest
    {

        [Test]
        public void CorrectDestinationTest()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/");

            Actions action = new Actions(driver);
            Random rnd = new Random();
            int random;
            IWebElement tourTab = driver.FindElement(By.XPath("//div[@class='col-md-12']//a[@href='#tours']"));
            Wait.ClickableElement(driver, tourTab);
            tourTab.Click();

            //Clear and add text tot destination field
            IWebElement destinationField = driver.FindElement(By.CssSelector("#s2id_autogen5 a"));
            Wait.ClickableElement(driver, destinationField);
            destinationField.Click();

            Wait.ClickableElement(driver, driver.FindElement(By.CssSelector("ul.select2-result-sub")));
            IList<IWebElement> destinationFieldOptions = driver.FindElements(By.CssSelector("ul.select2-result-sub li"));
            random = rnd.Next(destinationFieldOptions.Count);
            string randomDestincation = destinationFieldOptions[random].Text;
            destinationFieldOptions[random].Click();

            SelectElement adults = new SelectElement(driver.FindElement(By.Id("adults")));
            random = rnd.Next(adults.Options.Count);
            adults.Options[random].Click();
            SelectElement tourType = new SelectElement(driver.FindElement(By.Id("tourtype")));
            random = rnd.Next(tourType.Options.Count);
            tourType.Options[random].Click();
            driver.FindElement(By.CssSelector("#tours button")).Click();

            string ActDestination = driver.FindElement(By.XPath("//span[@class='select2-chosen']")).Text;
            bool filterIsDisplayed = driver.FindElement(By.CssSelector("div.filter")).Displayed;
            Assert.True(randomDestincation == ActDestination && filterIsDisplayed);
            Thread.Sleep(5000);
        }

        [Test]
        public void BookARoom()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
            //IWebElement homePagebutton = driver.FindElement(By.CssSelector("img[src='https://www.phptravels.net/uploads/global/logo.png']"));
            //homePagebutton.Click();

            Wait.VisibilityOfElement(driver, By.CssSelector("div.main_slider"));

            IWebElement slider = driver.FindElement(By.CssSelector("div.hotels"));
            Actions action = new Actions(driver);
            action.ClickAndHold(slider).Perform();
            action.MoveByOffset(-1000, 0).Perform();
            action.Release().Build().Perform();
            Thread.Sleep(3000);

            IList<IWebElement> hotels = driver.FindElements(By.CssSelector("div.hotels >div>div>div"));
            hotels[7].Click();

            IWebElement table = driver.FindElement(By.CssSelector("#ROOMS table"));
            RunJS("arguments[0].scrollIntoView(true)", table);
            Wait.VisibilityOfElement(driver, By.CssSelector("#ROOMS table "));
            IList<IWebElement> roomPrices = driver.FindElements(By.CssSelector("h2.book_price>strong"));
            foreach (var item in roomPrices)
            {
                Console.WriteLine(item.Text);
            }


        }



        [Test]
        public void ChangeLanguage()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
            driver.FindElement
                (By.XPath("//ul[@class='nav navbar-nav navbar-right hidden-sm go-left']//ul[@class='nav navbar-nav']//li[@class='dropdown']")).Click();
            driver.FindElement(By.XPath("//li[@class='dropdown open']//ul[@class='dropdown-menu wow fadeIn animated']//li//a[@id='ar']")).Click();
            driver.FindElement
                (By.XPath("//ul[@class='nav navbar-nav navbar-right hidden-sm go-left']//ul[@class='nav navbar-nav']//li[@class='dropdown']")).Click();
            driver.FindElement(By.XPath("//li[@class='dropdown open']//ul[@class='dropdown-menu wow fadeIn animated']//li//a[@id='en']")).Click();

            string expMst = "TOURS";
            string actMsg = driver.FindElement(By.XPath("//span[contains(text(),'Tours')]")).Text;
            Assert.AreEqual(expMst, actMsg);
        }
        [Test]
        public void FeaturedTours()
        {
            Random rnd = new Random();
            int random;

            driver.Navigate().GoToUrl("https://www.phptravels.net/");
            IList<IWebElement> tourPrices = driver.FindElements(By.CssSelector("div.hotel-person span"));
            IWebElement table = driver.FindElement(By.XPath("//div[@class='vc_row wpb_row vc_inner vc_row-fluid vc_column-gap-30 RTL']"));
            RunJS("arguments[0].scrollIntoView(true)", table);

            int[] array = new int[tourPrices.Count];
            for (int i = 0; i < tourPrices.Count; i++)
            {
                string currentWord = Regex.Replace(tourPrices[i].Text, "[^0-9.]", "");
                bool newValue = int.TryParse(currentWord, out array[i]);
            }
            int minPriceIndex = Array.IndexOf(array, array.Min());
            IList<IWebElement> bookButtons = driver.FindElements(By.XPath("//a[@class='thm-btn btn-block']"));
            int minPriceRoom = array[minPriceIndex];
            bookButtons[minPriceIndex].Click();



            Wait.VisibilityOfElement(driver, By.CssSelector("div.fotorama__stage"));
            driver.SwitchTo().Frame("mapframe");
            IWebElement mapError = driver.FindElement(By.XPath("//div[@class='gm-err-title']"));
            Console.WriteLine(mapError.Text);
            driver.SwitchTo().DefaultContent();

            Wait.InvisibilityOfElement(driver, By.CssSelector("div.fotorama__nav.fotorama__nav--thumbs"));
            IList<IWebElement> shareButtons = driver.FindElements(By.CssSelector("[class^='st-label']"));
            random = rnd.Next(shareButtons.Count);
            shareButtons[random].Click();
            //driver.FindElement(By.XPath("//div[@data-network='linkedin']"));
            List<string> allWindows = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(allWindows[1]);
            driver.Close();
            driver.SwitchTo().Window(allWindows[0]);
            IWebElement priceBox = driver.FindElement(By.XPath("//h4[@class='well well-sm text-center strong']"));
            RunJS("arguments[0].scrollIntoView(true)", priceBox);
            IWebElement price = driver.FindElement(By.CssSelector("h4.well-sm.text-center strong"));
            

            bool convertPriece = int.TryParse(price.Text, out int actPrice);

            Assert.AreEqual(minPriceRoom, actPrice);

        }

        [Test]
        public void SupplierSignUp()
        {
            driver.Navigate().GoToUrl("https://www.phptravels.net/");
            Wait.VisibilityOfElement(driver, By.CssSelector("div.footer-section"));
            driver.FindElement(By.CssSelector("#cookyGotItBtnBox button")).Click();
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("//div[@id='footer']//a[@class='btn btn-warning']")).Click();
            List<string> allTabs = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(allTabs[1]);
            Wait.VisibilityOfElement(driver, By.XPath("//div[@id='Carousel']"));
            driver.FindElement(By.XPath("//button[@id='hotels']")).Click();

            IWebElement startedSection = driver.FindElement(By.XPath("//section[@class='started']"));
            RunJS("arguments[0].scrollIntoView(true)", startedSection);
            Wait.VisibilityOfElement(driver, By.XPath("//section[@class='started']"));
            string startedSectionTitleAct = driver.FindElement(By.XPath("//h2[@class='text-center']")).Text;
            string startedSectionTitleExp = "Easy registration process";
            Assert.AreEqual(startedSectionTitleExp, startedSectionTitleAct);
        }




























        //[Test]
        //public void AddProduct()
        //{
        //    Actions action = new Actions(driver);
        //    Random rnd = new Random();
        //    driver.Navigate().GoToUrl("https://demo.cs-cart.com/");
        //    //Hover Apparel
        //    action.MoveToElement(driver.FindElement
        //        (By.XPath("//a[@class='ty-menu__item-link'][contains(text(),'Apparel')]"))).Perform();
        //    //Add Apparel Options to a list
        //    IList<IWebElement> apparelOptions =
        //        driver.FindElements(By.XPath("//a[@class='ty-menu__item-link'][contains(text(),'Apparel')]/..//ul/li/a"));
        //    int random = rnd.Next(apparelOptions.Count);

        //    //Click Random Option
        //    Wait.ClickableElement(driver, apparelOptions[random]);
        //    apparelOptions[random].Click();
        //    Thread.Sleep(3000);
        //    //Click on a brand
        //    Wait.VisibilityOfElement(driver, By.CssSelector("[id^='ranges'] label"));
        //    IList<IWebElement> brandOptions = driver.FindElements(By.CssSelector("[id^='ranges'] label"));
        //    random = rnd.Next(brandOptions.Count);
        //    Wait.ClickableElement(driver, brandOptions[random]);
        //    brandOptions[random].Click();
        //    Thread.Sleep(4000);
        //    IList<IWebElement> productsDisplayed = driver.FindElements(By.CssSelector("form[name^='product_form']"));

        //    //if (productsDisplayed.Count < 2)
        //    //{
        //        driver.FindElement(By.XPath("//div[@class='ty-product-filters__tools clearfix']/a")).Click();
        //    //}
        //    Wait.VisibilityOfElement(driver, By.CssSelector("#sw_elm_sort_fields"));
        //    action.MoveToElement(driver.FindElement(By.CssSelector("#sw_elm_sort_fields"))).Perform();
        //    driver.FindElement(By.CssSelector("#sw_elm_sort_fields")).Click();

        //    Wait.ClickableElement(driver, driver.FindElement(By.LinkText("Sort by Popularity")));
        //    driver.FindElement(By.LinkText("Sort by Popularity")).Click();
        //    IList<IWebElement> productsPrices = driver.FindElements(By.CssSelector("form[name^='product_form']"));

        //    Thread.Sleep(4000);
    }

}
