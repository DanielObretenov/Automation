using AutomationDemo.Helpers;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
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
        //private static readonly By TourTab = By.CssSelector("[href='#tours']");
        //private static readonly By DestinationField = By.CssSelector("#s2id_autogen5 a");
        //private static readonly By ToursCitiesOptions = By.XPath("//ul[@class='select2-results']/li[2]");
        //private static readonly By AdultsField = By.CssSelector("#adults");
        //private static readonly By TourtypeField = By.CssSelector("#tourtype");
        //private static readonly By ToursButton = By.CssSelector("#tours button");
        //private static readonly By FeaturedHotelsPrices = By.XPath("//div[@class='main_slider']//span[@class='text-center']");
        //private static readonly By FeaturedHotelsImg = By.XPath("//div[@class='main_slider']//span[@class='text-center']//..//..//..//div[@class='imgLodBg']");
        //private static readonly By FeaturedHotelsImgNoPrices = By.CssSelector("div.featured-back div.imgLodBg");
        //private static readonly By FooterSection = By.CssSelector("div.footer-section");
        //private static readonly By FooterSectionSignUpButton = By.XPath("//div[@id='footer']//a[@class='btn btn-warning']");
        //private static readonly By TourPrices = By.CssSelector("div.hotel-person span");
        //private static readonly By TableFeaturedHotels = By.XPath("//div[@class='vc_row wpb_row vc_inner vc_row-fluid vc_column-gap-30 RTL']");
        //private static readonly By FeaturedHotelsSection = By.CssSelector("div.featured-back");
        //private static readonly By RightArrowForFeaturedHotels = By.CssSelector("i.icon-right-open-3");
        //private static readonly By BookButtonFeaturedHotels = By.XPath("//a[@class='thm-btn btn-block']");
        //private static readonly By CountryNameFeaturedHotels = By.CssSelector("a.loader.wow.animated");


     

        [FindsBy(How = How.CssSelector, Using = "[href='#tours']")]
        protected IWebElement TourTab;

        [FindsBy(How = How.CssSelector, Using = "#s2id_autogen5 a")]
        protected IWebElement DestinationField;

        [FindsBy(How = How.XPath, Using = "//ul[@class='select2-results']/li[2]")]
        protected IList<IWebElement> ToursCitiesOptions;

        [FindsBy(How = How.CssSelector, Using = "#adults")]
        protected IWebElement AdultsField;

        [FindsBy(How = How.CssSelector, Using = "#tourtype")]
        protected IWebElement TourtypeField;

        [FindsBy(How = How.CssSelector, Using = "#tours button")]
        protected IWebElement ToursButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='main_slider']//span[@class='text-center']")]
        protected IList<IWebElement> FeaturedHotelsPrices;

        [FindsBy(How = How.XPath, Using = "//div[@class='main_slider']//span[@class='text-center']//..//..//..//div[@class='imgLodBg']")]
        protected IList<IWebElement> FeaturedHotelsImg;

        [FindsBy(How = How.CssSelector, Using = "div.featured-back div.imgLodBg")]
        protected IList<IWebElement> FeaturedHotelsImgNoPrices;

        [FindsBy(How = How.CssSelector, Using = "div.footer-section")]
        protected IWebElement FooterSection;

        [FindsBy(How = How.XPath, Using = "//div[@id='footer']//a[@class='btn btn-warning']")]
        protected IWebElement FooterSectionSignUpButton;

        [FindsBy(How = How.CssSelector, Using = "div.hotel-person span")]
        protected IList<IWebElement> TourPrices;

        [FindsBy(How = How.XPath, Using = "//div[@class='vc_row wpb_row vc_inner vc_row-fluid vc_column-gap-30 RTL']")]
        protected IWebElement TableFeaturedHotels;

        [FindsBy(How = How.CssSelector, Using = "div.featured-back")]
        protected IWebElement FeaturedHotelsSection;

        [FindsBy(How = How.CssSelector, Using = "i.icon-right-open-3")]
        protected IWebElement RightArrowForFeaturedHotels;

        [FindsBy(How = How.XPath, Using = "//a[@class='thm-btn btn-block']")]
        protected IList<IWebElement> BookButtonFeaturedHotels;

        [FindsBy(How = How.CssSelector, Using = "a.loader.wow.animated")]
        protected IWebElement CountryNameFeaturedHotels;


        private List<string> allTabs;
        private int[] arrayToursList;
        public int minPriceRoom;
        int[] priceOptions;
        Actions action;
        bool FeaturedHotelsHavePrices;


        protected int random = 0;
        protected static Random rnd = new Random();

      


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
            webDriver.Navigate().GoToUrl("https://www.phptravels.net/hotels/detail/Islamabad/Islamabad-Marriott-Hotel");
            return new HotelPage(this.webDriver);
        }

        public void NavigateToToursTab()
        {
            TourTab.Click();
        }

        public void SelectRandomCityInToursTab()
        {
            Wait.ClickableElement(webDriver,DestinationField);
            DestinationField.Click();
            random = rnd.Next(ToursCitiesOptions.Count);
            Wait.ClickableElement(webDriver, ToursCitiesOptions[random]);
            ToursCitiesOptions.ElementAt(random).Click();
        }


        public void SelectRandomAdultsinTourTab()
        {
            SelectElement adults = new SelectElement(AdultsField);
            random = rnd.Next(adults.Options.Count);
            adults.Options.ElementAt(random).Click();

        }


        public void SelectRandomTourTypeinTourTab()
        {

            SelectElement tourType = new SelectElement(TourtypeField);
            random = rnd.Next(tourType.Options.Count);
            tourType.Options.ElementAt(random).Click();
        }


        public ToursPage ClickSearchForTourButton()
        {
            ToursButton.Click();
            return new ToursPage(webDriver);
        }


        public HotelPage FeaturedHoteWithLowestPrice()
        {

            action = new Actions(webDriver);
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", FeaturedHotelsSection, this.webDriver);
            priceOptions = new int[FeaturedHotelsPrices.Count];
            ClickOnFeaturedHotel();
            return new HotelPage(webDriver);
        }

        public void ClickOnFeaturedHotel()
        {

            if (CheckPricesAreDisplayed())
            {
                int minPriceIndex = Array.IndexOf(priceOptions, priceOptions.Min());
                action.MoveToElement(FeaturedHotelsPrices[minPriceIndex]).Perform();
                FeaturedHotelsImg[minPriceIndex].Click();

            }
            else
            {
                Wait.ClickableElement(webDriver, FeaturedHotelsImgNoPrices[0]);
                action.MoveToElement(FeaturedHotelsImgNoPrices[0]).Perform();
                FeaturedHotelsImgNoPrices[0].Click();
            }
        }

        public bool CheckPricesAreDisplayed()
        {
            FeaturedHotelsHavePrices = false;
            for (int i = 0; i < FeaturedHotelsPrices.Count; i++)
            {
                if (!FeaturedHotelsPrices[i].Displayed)
                {
                    RightArrowForFeaturedHotels.Click();
                    FeaturedHotelsHavePrices = true;
                }
                Wait.ClickableElement(webDriver, FeaturedHotelsPrices[i]);
                priceOptions[i] = int.Parse(FeaturedHotelsPrices[i].Text.Replace("USD $", ""));
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
            return TourTab.Text.Equals(expMsgChangeToEN);
        }

        public SupplierSignUpPage NavigateToSupplierSignUpPageByFooter()
        {
            Wait.ClickableElement(webDriver, FooterSection);
            cookieButtonGotIt.Click();
            webDriver.SwitchTo().DefaultContent();
            FooterSectionSignUpButton.Click();
            allTabs = webDriver.WindowHandles.ToList();
            WaitForTabsList();
            webDriver.SwitchTo().Window(allTabs[1]);
            return new SupplierSignUpPage(webDriver);
        }


        public void WaitForTabsList()
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
        public void FeaturedToursLowestPrice()
        {
        
    
            JSHelper.RunJSHelper("arguments[0].scrollIntoView(true)", TableFeaturedHotels, this.webDriver);


            arrayToursList = new int[TourPrices.Count];
            for (int i = 0; i < TourPrices.Count; i++)
            {
                string currentWord = Regex.Replace(TourPrices[i].Text, "[^0-9.]", "");
                bool newValue = int.TryParse(currentWord, out arrayToursList[i]);
            }
            int minPriceIndex = Array.IndexOf(arrayToursList, arrayToursList.Min());
            minPriceRoom = arrayToursList[minPriceIndex];
            BookButtonFeaturedHotels[minPriceIndex].Click();

        }


        public int GetLowestPriceForTour()
        {
            return minPriceRoom;
        }
        public FeaturedToursPage NavigateToFeaturedToursPageWithLowestPrice()
        {
            return new FeaturedToursPage(webDriver);
        }
    }
}
