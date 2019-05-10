using AutomationDemo.SeleniumTests.PageObjectModelEaster.HelpersEaster;
using AutomationDemo.SeleniumTests.PageObjectModelEaster.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationDemo.SeleniumTests.PageObjectModelEaster.Tests
{
    class WordGamesEasterTests: BaseTestEaster
    {
        [Test]
        public void PlayEasterGame()
        {
            HomePageEaster homeTestEaster = new HomePageEaster(driver);
            homeTestEaster.NavigateToHomePage();
            TopicsPageEasterPage topicsPageEaster = homeTestEaster.NavigateToEasterTopicFromAZTopics();
            WordGamesEasterPage wordGamesEasterPage = topicsPageEaster.NavigateToEasterGame();
            wordGamesEasterPage.SwitchToGameiFrame();
            wordGamesEasterPage.SelectOptions2Remaining();
            wordGamesEasterPage.ClickFinishGame();
            wordGamesEasterPage.CancelFinishGame();
            wordGamesEasterPage.SelectOptions2Last();
            wordGamesEasterPage.ClickFinishGame();
            Assert.IsTrue(wordGamesEasterPage.ExpFinishMsg());
        }
    }
}
