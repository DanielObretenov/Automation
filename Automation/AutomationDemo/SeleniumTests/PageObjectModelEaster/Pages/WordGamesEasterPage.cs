using AutomationDemo.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using AutomationDemo;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.Pages
{
    class WordGamesEasterPage : BasePageEaster
    {
        private static readonly By OptionsList = By.CssSelector("#main_list li");
        private static readonly By QuestionsList = By.CssSelector("#questions div.question");
        private static readonly By BodyiFrame = By.CssSelector("body.skin-kids");
        private static readonly By FinshButton = By.CssSelector("#finishButton");
        private static readonly By FinshCancelButton = By.XPath("//button[text()='Cancel']");
        private static readonly By FinishScore = By.CssSelector("div.bootstrap-dialog-message");
        private string expFinishMsg = "Total score";
        private IList<IWebElement> optionsList;
        private IList<IWebElement> questionsList;
        private Actions action;
        public WordGamesEasterPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void SwitchToGameiFrame()
        {
            webDriver.SwitchTo().Frame(0);
            webDriver.SwitchTo().Frame(0);

        }
        //Select First Options - 2 remaining
        public void SelectOptions2Remaining()
        {
        
            action = new Actions(this.webDriver);
            action.MoveToElement(webDriver.FindElement(BodyiFrame)).Perform();
            optionsList = webDriver.FindElements(OptionsList);
            questionsList = webDriver.FindElements(QuestionsList);
            IEnumerable<IWebElement> optionsSortedEnum = optionsList.OrderBy(f => int.Parse(f.GetAttribute("data-question-index")));
            IList<IWebElement> optionsSortedList = optionsSortedEnum.ToList();

            for (int i = 0; i < optionsList.Count - 2; i++)
            {
                optionsList[i].Click();
                JSHelper.RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(BodyiFrame), this.webDriver);
                questionsList[i].Click();

            }
        }
        //Select First Options - 2 last
        public void SelectOptions2Last()
        {
            for (int i = optionsList.Count-2; i < optionsList.Count; i++)
            {
                optionsList[i].Click();
                JSHelper.RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(BodyiFrame), this.webDriver);
                questionsList[i].Click();
            }
        }
            //FinshGame

            public void ClickFinishGame()
        {
            webDriver.FindElement(FinshButton).Click();

        }
        //CancelFinshGame
        public void CancelFinishGame()
        {
            Wait.VisibilityOfElement(webDriver, FinshCancelButton);
            webDriver.FindElement(FinshCancelButton).Click();
            action.MoveToElement(webDriver.FindElement(BodyiFrame)).Perform();

        }

        //Select All Options
        public void SelectOptionsAll()
        {

            for (int i = 0; i < optionsList.Count; i++)
            {
                optionsList[i].Click();
               // RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(BodyiFrame));
                JSHelper.RunJSEaster("arguments[0].scrollIntoView(true)", webDriver.FindElement(BodyiFrame), this.webDriver);
                questionsList[i].Click();

            }
        }

        //Assert
        public bool ExpFinishMsg()
        {
            return webDriver.FindElement(FinishScore).Text.Contains(expFinishMsg);
        }




        //public void AssosiateOptionsToAnswers()
        //{
        //    while (optionsList.Count - 2 > 0)
        //    {
        //        optionsList[random].Click();
        //        RunJS("arguments[0].scrollIntoView(true)", webDriver.FindElement(BodyiFrame));
        //        questionsList[random].Click();

        //        optionsList.RemoveAt(random);
        //        questionsList.RemoveAt(random);
        //    }
        //    webDriver.FindElement(FinshButton).Click();
        //    Wait.VisibilityOfElement(webDriver, FinshCancelButton);
        //    webDriver.FindElement(FinshCancelButton).Click();


        //    Wait.InvisibilityOfElement(webDriver, FinshCancelButton);

        //    while (optionsList.Count > 0)
        //    {
        //        random = rnd.Next(optionsList.Count);
        //        optionsList[random].Click();
        //        RunJS("arguments[0].scrollIntoView(true)", webDriver.FindElement(BodyiFrame));
        //        questionsList[random].Click();

        //        optionsList.RemoveAt(random);
        //        questionsList.RemoveAt(random);
        //    }
        //    webDriver.FindElement(FinshButton).Click();
            
         

        //}


        public void SortOptionsByAttribute()
        {

            IEnumerable<IWebElement> optionsSortedEnum = optionsList.OrderBy(f => int.Parse(f.GetAttribute("data-question-index")));
            IList<IWebElement> optionsSortedList = optionsSortedEnum.ToList();
        }




    }
}
