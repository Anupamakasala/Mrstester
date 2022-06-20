using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_automation.Pages;

namespace turnup_automation.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;


        // Page object initialization
        LoginPage loginPageObject = new LoginPage();
        HomePage homePageObject = new HomePage();


        [SetUp]
        public void LoginActions()
        {
            // open chrome browser
            driver = new ChromeDriver();

            // login page object initialization and definition

            loginPageObject.LoginSteps(driver);

            // home page object initialization and definition

            homePageObject.GoToTMPage(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();

        }
    }
}
