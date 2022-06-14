using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using turnup_automation.Pages;
using turnup_automation.Utilities;

namespace turnup_automation
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {

        [SetUp]
        public void LoginActions()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // login page object initialization and definition
            LoginPage loginPageObject = new LoginPage();

            loginPageObject.LoginSteps(driver);

            // home page object initialization and definition
            HomePage homePageObject = new HomePage();

            homePageObject.GoToTMPage(driver);
        }

        [Test]
        public void CreateTM()
        {
            // tm page object initialization and definition
            TMPage tmPageObject = new TMPage();

            // create TM
            tmPageObject.CreateTM(driver);
        }


        [Test]
        public void EditTM()
        {
            // edit TM
            TMPage tmPageObject = new TMPage();
            tmPageObject.EditTM(driver);
        }

        [Test]
        public void DeleteTM()
        {
            // delete TM
            TMPage tmPageObject = new TMPage();
            tmPageObject.DeleteTM(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();

        }

    }

}
