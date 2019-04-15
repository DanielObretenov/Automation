using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace AutomationDemo
{
    [TestFixture]

    public class SeleniumTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetDriver()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Manage().Window.Maximize();

          //  driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); 
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Dispose();
        }
        [Test]
        [Category("LoginTest")]
        public void LogInTest()
        {
            // Navigate to URL
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            // Navigate to login screen
            driver.FindElement(By.CssSelector(@"#content [href=""/login""]")).Click();
            //Clear and send keys on Username field
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            //Clear and send keys on Password field
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            //Explicit Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("radius")));
            //Click Login
            driver.FindElement(By.ClassName("radius")).Click();
            // Assert Log in message
            string actMsgLogIn = driver.FindElement(By.Id("flash")).Text;
            string expMsgLogIn = "You logged into a secure area!\r\n×";
            Assert.AreEqual(actMsgLogIn, expMsgLogIn);
            //Log Out
            driver.FindElement(By.CssSelector("a.button.secondary.radius")).Click();
            Thread.Sleep(4000);
            // Assert Log out  message
            string actMsgLogOut = driver.FindElement(By.Id("flash")).Text;
            string expMsgLogOut = "You logged out of the secure area!\r\n×";
            Assert.AreEqual(actMsgLogOut, expMsgLogOut);
        }

        //Parameteralized Test
        [Test]
        [Category("Parameteralized LoginTests")]
        [TestCase( "tomsmith", "SuperSecretPassword!")]
        [TestCase( "tomsmith", "NewPassword")]
        [TestCase("NewName", "SuperSecretPassword!")]
        [TestCase( "NewName", "NewPassword!")]
        [TestCase("", "")]

        public void Login(string actUsername, string actPassword)
        {

            //Navigate to URL
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            //Initialize expl. Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //Wait for link to load
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Form Authentication")));
            driver.FindElement(By.LinkText("Form Authentication")).Click();

            //Wait Clear and Send Keys to Username field
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("username")));
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(actUsername);
            //Wait Clear and Send Keys to Password field
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("password")));
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(actPassword);
            //Click log in button
            driver.FindElement(By.ClassName("radius")).Click();


            //Assert Fields
            string actMsgLogIn = driver.FindElement(By.Id("flash")).Text;
            Assert.AreEqual(actMsgLogIn, actLogInMsg(actUsername, actPassword));
        }

        public string actLogInMsg(string actUsername, string actPassword)
        {
            string expMsgLogIn;

            if (actUsername == "tomsmith" && actPassword == "SuperSecretPassword!")
            {
                // Assert Log in message
                expMsgLogIn = "You logged into a secure area!\r\n×";

            }
            else if (actUsername == "tomsmith" && actPassword != "SuperSecretPassword!")
            {
                // Assert Log in message
                expMsgLogIn = "Your password is invalid!\r\n×";
            }
            else
            {
                // Assert Log in message
                expMsgLogIn = "Your username is invalid!\r\n×";
            }
            return expMsgLogIn;
        }

        [Test]
        [Category("Dropdowns")]

        public void MultiDropDownRandomElement()
        {
            //Navigate to URL
            driver.Navigate().GoToUrl("https://biologist-gladys-66140.netlify.com/");
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("select_one")));
            Random rnd = new Random();
            
            int randomOption1 = rnd.Next(0,dropdown.Options.Count);
            int randomOption2 = rnd.Next(0,dropdown.Options.Count);

            if (dropdown.IsMultiple)
            {
                dropdown.SelectByIndex(randomOption1);
                dropdown.SelectByIndex(randomOption2);

                Assert.IsTrue(dropdown.Options.ElementAt(randomOption1).Selected);
                Assert.IsTrue(dropdown.Options.ElementAt(randomOption2).Selected);
            }
            for (int i = 0; i < dropdown.Options.Count - 1; i++)
            {
                Console.WriteLine(dropdown.Options.ElementAt(i).Text);
            }
         

        }

        [Test]
        [Category("Dropdowns")]
        public void DropDownRandomElement()
        {
            driver.Navigate().GoToUrl("https://biologist-gladys-66140.netlify.com/");
            SelectElement dropdown = new SelectElement(driver.FindElement(By.Id("select_two")));
            Random rnd = new Random();
            int RandomIndex = rnd.Next(0, dropdown.Options.Count);
            dropdown.SelectByIndex(RandomIndex);
            Assert.IsTrue(dropdown.Options.ElementAt(RandomIndex).Selected);

            foreach (var element in dropdown.Options)
            {
                Console.WriteLine(element.Text);
            }
        }

        [Test]
        [Category("Radiobuttons")]
        public void RadioButtonList()
        {
            driver.Navigate().GoToUrl("https://biologist-gladys-66140.netlify.com/");
            Random rnd = new Random();
            IList<IWebElement> radioButtons = driver.FindElements(By.XPath("//form[@id='form_one']/input"));
            Console.WriteLine(radioButtons.Count);

            for (int i = 0; i < radioButtons.Count; i++)
            {
                int randomNum = rnd.Next(0, radioButtons.Count);
                radioButtons.ElementAt(randomNum).Click();
                Assert.IsTrue(radioButtons.ElementAt(randomNum).Selected);
            }
            foreach (var element in radioButtons)
            {
                Console.WriteLine(element.Selected);
            }
        }

        [Test]
        [Category("Checkboxes")]
        public void Checkbox()
        {
            driver.Navigate().GoToUrl("https://biologist-gladys-66140.netlify.com/");
            IList<IWebElement> checkboxes = driver.FindElements(By.XPath("//form[@id='form_two']/input"));
            Console.WriteLine(checkboxes.Count); 

            Random rnd = new Random();
            //check 3 rnd elements
            int randomSelect1 = rnd.Next(0, checkboxes.Count);
            int randomSelect2 = rnd.Next(0, checkboxes.Count);
            while (randomSelect1 == randomSelect2 &&  checkboxes.Count > 1)
            {
                randomSelect2 = rnd.Next(0, checkboxes.Count);
            }
            checkboxes.ElementAt(randomSelect1).Click();
            checkboxes.ElementAt(randomSelect2).Click();
            Assert.IsTrue(checkboxes.ElementAt(randomSelect1).Selected 
                && checkboxes.ElementAt(randomSelect2).Selected);

            for (int i = 0; i < checkboxes.Count; i++)
            {
                Console.Write(checkboxes.ElementAt(i).Selected);
            }
        
        }


        [Test]
        [Category("Forms")]
        public void PersonalInfoForm()
        {
            driver.Navigate().GoToUrl("https://www.toolsqa.com/automation-practice-form/");
            Assert.IsTrue(driver.Url.Contains("https://www.toolsqa.com/automation-practice-form/"));
            // Send Keys first name
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys("Daniel");
            // Send Keys last name
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys("Obretenov");

            //Checkbox - Gender
            Random rnd = new Random();

            IList<IWebElement> sexCheckbox = driver.FindElements(By.Name("sex"));
            int rndSex = rnd.Next(0, sexCheckbox.Count);
            sexCheckbox.ElementAt(rndSex).Click();
            Assert.IsTrue(sexCheckbox.ElementAt(rndSex).Selected);
            for (int i = 0; i < sexCheckbox.Count; i++)
            {
                if (rndSex != i)
                {
                    Assert.IsFalse(sexCheckbox.ElementAt(i).Selected);
                }
            }

           
            //Checkbox - Years of Experience 
            IList<IWebElement> experienceCheckbox = driver.FindElements(By.Name("exp"));
            int rndExperience= rnd.Next(0, experienceCheckbox.Count);
            experienceCheckbox.ElementAt(rndExperience).Click();
            Assert.IsTrue(experienceCheckbox.ElementAt(rndExperience).Selected);
            for (int i = 0; i < experienceCheckbox.Count; i++)
            {
                if (rndExperience != i )
                {
                    Assert.IsFalse(experienceCheckbox.ElementAt(i).Selected);
                }
            }
            //DatePicker
            driver.FindElement(By.Id("datepicker")).Clear();
            driver.FindElement(By.Id("datepicker")).SendKeys("23/12/2000");
            //Profession
            IList<IWebElement> professionList = driver.FindElements(By.Name("profession"));
            for (int i = 0; i < professionList.Count; i++)
            {
                professionList.ElementAt(i).Click();
                Assert.IsTrue(professionList.ElementAt(i).Selected);
            }
            //Automation Tool
            IList<IWebElement> automationToolList = driver.FindElements(By.Name("tool"));
            int rndTool1 = rnd.Next(0, automationToolList.Count);
            int rndTool2 = rnd.Next(0, automationToolList.Count);
            while (rndTool1 == rndTool2)
            {
                rndTool2 = rnd.Next(0, automationToolList.Count);
            }
            automationToolList.ElementAt(rndTool1).Click();
            automationToolList.ElementAt(rndTool2).Click();
            Assert.IsTrue(automationToolList.ElementAt(rndTool1).Selected &&
                automationToolList.ElementAt(rndTool2).Selected);

            //Continents

            SelectElement continentsDropdown =new SelectElement(driver.FindElement(By.Id("continents")));
            int rndContinent = rnd.Next(0, continentsDropdown.Options.Count);
            continentsDropdown.Options.ElementAt(rndContinent).Click();
            Assert.IsTrue(continentsDropdown.Options.ElementAt(rndContinent).Selected);

            //Selenium Commands

            SelectElement selenimCommands = new SelectElement(driver.FindElement(By.Id("selenium_commands")));
            int selectRnd1 = rnd.Next(0, selenimCommands.Options.Count);
            int selectRnd2 = rnd.Next(0, selenimCommands.Options.Count);
            while (selectRnd1 == selectRnd2 && selenimCommands.Options.Count>1)
            {
                selectRnd2 = rnd.Next(0, selenimCommands.Options.Count);
            }

           if (selenimCommands.IsMultiple)
           {
                selenimCommands.Options.ElementAt(selectRnd1).Click();
                selenimCommands.Options.ElementAt(selectRnd2).Click();
                Assert.IsTrue(selenimCommands.Options.ElementAt(selectRnd1).Selected &&
                   selenimCommands.Options.ElementAt(selectRnd2).Selected);
            }


            // Click submit
            driver.FindElement(By.Id("submit")).Click();
            Assert.IsTrue(driver.Url.Contains("submit"));

            //Chekc fields
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("firstname")));
            Assert.IsEmpty(driver.FindElement(By.Name("firstname")).Text);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Name("lastname")));
            Assert.IsEmpty(driver.FindElement(By.Name("lastname")).Text);
        }

        [Test]
        public void DownloadCsv()
        {

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/");
            Assert.IsTrue(driver.Url.Contains("https://the-internet.herokuapp.com/"));
            driver.FindElement(By.LinkText("JQuery UI Menus")).Click();

            Actions action = new Actions(driver);



            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
             driver.FindElement(By.LinkText("Enabled")).Click();
           // action.MoveToElement(driver.FindElement(By.LinkText("Enabled")));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("Downloads")));
            driver.FindElement(By.LinkText("Downloads")).Click();

            //action.MoveToElement(driver.FindElement(By.LinkText("Downloads")));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("PDF")));
            driver.FindElement(By.LinkText("PDF")).Click();

            //action.MoveToElement(driver.FindElement(By.LinkText("PDF")));

           // action.Click().Build().Perform();

          
        }


    }
}
