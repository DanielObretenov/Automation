﻿using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelHomework.Pages
{
    class HomePage : BasePage
    {
        private static string HomePageUrl = "https://www.phptravels.net/";
        private static readonly By TourTab = By.CssSelector("[href='#tours']");
        private static readonly By DestinationField = By.CssSelector("#s2id_autogen5 a");
        private static readonly By ToursCitiesOptions = By.XPath("//ul[@class='select2-results']/li[2]");
        private static readonly By AdultsField = By.CssSelector("#adults");
        private static readonly By TourtypeField = By.CssSelector("#tourtype");
        private static readonly By ToursButton = By.CssSelector("#tours button");
        private static readonly By FeaturedHotelsPrices = By.XPath("//div[@class='main_slider']//span[@class='text-center']");
        private static readonly By FeaturedHotelsImg = By.XPath("//div[@class='main_slider']//span[@class='text-center']//..//..//..//div[@class='imgLodBg']");
        private static readonly By FeaturedHotelsImgNoPrices = By.CssSelector("div.featured-back div.imgLodBg");
        private static readonly By FooterSection = By.CssSelector("div.footer-section");
        private static readonly By FooterSectionSignUpButton = By.XPath("//div[@id='footer']//a[@class='btn btn-warning']");
        private static readonly By TourPrices = By.CssSelector("div.hotel-person span");
        private static readonly By TableFeaturedHotels = By.XPath("//div[@class='vc_row wpb_row vc_inner vc_row-fluid vc_column-gap-30 RTL']");
        private static readonly By FeaturedHotelsSection = By.CssSelector("div.featured-back");
        private static readonly By RightArrowForFeaturedHotels = By.CssSelector("i.icon-right-open-3");
        private static readonly By BookButtonFeaturedHotels = By.XPath("//a[@class='thm-btn btn-block']");
        private static readonly By CountryNameFeaturedHotels = By.CssSelector("a.loader.wow.animated");
        private List<string> allTabs;
        private double minPriceRoom;
        IList<IWebElement> featuredHotelsPricesList;
        IList<IWebElement> featuredHotelsImages;
        int[] priceOptions;
        Actions action;
        bool FeaturedHotelsHavePrices;

        public double MinPriceRoom
        {
            get { return minPriceRoom; }
            set { minPriceRoom = value; }
        }


        private static readonly By OpenLanguageDropdown =
            By.XPath("//ul[@class='nav navbar-nav navbar-right hidden-sm go-left']//ul[@class='nav navbar-nav']//li[@class='dropdown']");
        private static readonly By ChooseLanguageArabian =
            By.XPath("//li[@class='dropdown open']//ul[@class='dropdown-menu wow fadeIn animated']//li//a[@id='ar']");
        private static readonly By ChooseLanguageEnglish =
          By.XPath("//li[@class='dropdown open']//ul[@class='dropdown-menu wow fadeIn animated']//li//a[@id='en']");
        private string expMsgChangeToEN = "TOURS";




        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void NavigateToHomePage()
        {
            webDriver.Navigate().GoToUrl(HomePageUrl);
        }
        public HotelPage NavigateToHotelPage()
        {
            webDriver.Navigate().GoToUrl("https://www.phptravels.net/hotels/detail/Dubai/Hyatt-Regency-Perth");
            return new HotelPage(this.webDriver);
        }

        public void NavigateToToursTab()
        {
            webDriver.FindElement(TourTab).Click();
        }

        public void SelectRandomCityInToursTab()
        {
            Wait.ClickableElement(webDriver, webDriver.FindElement(DestinationField));
            webDriver.FindElement(DestinationField).Click();
            Wait.ClickableElement(webDriver, webDriver.FindElement(ToursCitiesOptions));
            IList<IWebElement> ToursCitiesOptionsList = webDriver.FindElements(ToursCitiesOptions);
            random = rnd.Next(ToursCitiesOptionsList.Count);
            ToursCitiesOptionsList.ElementAt(random).Click();
        }


        public void SelectRandomAdultsinTourTab()
        {
            SelectElement adults = new SelectElement(webDriver.FindElement(AdultsField));
            random = rnd.Next(adults.Options.Count);
            adults.Options.ElementAt(random).Click();

        }


        public void SelectRandomTourTypeinTourTab()
        {

            SelectElement tourType = new SelectElement(webDriver.FindElement(TourtypeField));
            random = rnd.Next(tourType.Options.Count);
            tourType.Options.ElementAt(random).Click();
        }


        public ToursPage ClickSearchForTourButton()
        {
            webDriver.FindElement(ToursButton).Click();
            return new ToursPage(webDriver);
        }


        public HotelPage FeaturedHoteWithLowestPrice()
        {

            action = new Actions(webDriver);
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", webDriver.FindElement(FeaturedHotelsSection), this.webDriver);
            featuredHotelsPricesList = webDriver.FindElements(FeaturedHotelsPrices);
            featuredHotelsImages = webDriver.FindElements(FeaturedHotelsImg);
            priceOptions = new int[featuredHotelsPricesList.Count];
            ClickOnFeaturedHotel();
            return new HotelPage(webDriver);
        }

        public void ClickOnFeaturedHotel()
        {

            if (HasPrices())
            {
                int minPriceIndex = Array.IndexOf(priceOptions, priceOptions.Min());
                action.MoveToElement(featuredHotelsPricesList[minPriceIndex]).Perform();
                featuredHotelsImages[minPriceIndex].Click();

            }
            else
            {
                featuredHotelsImages = webDriver.FindElements(FeaturedHotelsImgNoPrices);
                Wait.ClickableElement(webDriver, featuredHotelsImages[0]);
                action.MoveToElement(featuredHotelsImages[0]).Perform();
                featuredHotelsImages[0].Click();
            }
        }

        public bool HasPrices()
        {
            FeaturedHotelsHavePrices = false;
            for (int i = 0; i < featuredHotelsPricesList.Count; i++)
            {
                if (!featuredHotelsPricesList[i].Displayed)
                {
                    webDriver.FindElement(RightArrowForFeaturedHotels).Click();
                    FeaturedHotelsHavePrices = true;
                }
                Wait.ClickableElement(webDriver, featuredHotelsPricesList[i]);
                priceOptions[i] = int.Parse(featuredHotelsPricesList[i].Text.Replace("USD $", ""));
            }


            return FeaturedHotelsHavePrices;
        }



        public void ChangeLanguage()
        {
            webDriver.FindElement(OpenLanguageDropdown).Click();
            Wait.VisibilityOfElement(webDriver, ChooseLanguageArabian);
            webDriver.FindElement(ChooseLanguageArabian).Click();
            Wait.VisibilityOfElement(webDriver, OpenLanguageDropdown);
            webDriver.FindElement(OpenLanguageDropdown).Click();
            Wait.VisibilityOfElement(webDriver, ChooseLanguageEnglish);
            webDriver.FindElement(ChooseLanguageEnglish).Click();
        }

        public bool expMsgChangeLanguageToEN()
        {
            return webDriver.FindElement(TourTab).Text.Equals(expMsgChangeToEN);
        }

        public SupplierSignUpPage NavigateToSupplierSignUpPageByFooter()
        {
            Wait.VisibilityOfElement(webDriver, FooterSection);
            webDriver.FindElement(cookieButtonGotIt).Click();
            webDriver.SwitchTo().DefaultContent();
            webDriver.FindElement(FooterSectionSignUpButton).Click();
            allTabs = webDriver.WindowHandles.ToList();
            waitForTabsList();
            webDriver.SwitchTo().Window(allTabs[1]);
            return new SupplierSignUpPage(webDriver);
        }


        public void waitForTabsList()
        {
            int counter = 0;
            while (allTabs.Count < 2)
            {
                allTabs = webDriver.WindowHandles.ToList();
                if (counter > 200)
                {
                    break;
                }
                counter++;
            }
        }
        public void featuredToursLowestPrice()
        {
        
            IList<IWebElement> tourPricesList = webDriver.FindElements(TourPrices);
            IWebElement tableFeaturedHotels = webDriver.FindElement(TableFeaturedHotels);
    
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", tableFeaturedHotels, this.webDriver);


            int[] array = new int[tourPricesList.Count];
            for (int i = 0; i < tourPricesList.Count; i++)
            {
                string currentWord = Regex.Replace(tourPricesList[i].Text, "[^0-9.]", "");
                bool newValue = int.TryParse(currentWord, out array[i]);
            }
            int minPriceIndex = Array.IndexOf(array, array.Min());
            IList<IWebElement> bookButtons = webDriver.FindElements(BookButtonFeaturedHotels);
            minPriceRoom = array[minPriceIndex];
            bookButtons[minPriceIndex].Click();

        }
        public FeaturedToursPage NavigateToFeaturedToursPageWithLowestPrice()
        {
            featuredToursLowestPrice();
            return new FeaturedToursPage(webDriver);
        }
    }
}
