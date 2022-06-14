using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using turnup_automation.Pages;
using turnup_automation.Utilities;

namespace turnup_automation
{
    public class TM_Tests
    {
        static void Main(string[] args)
        {
            // open chrome browser
            IWebDriver driver = new ChromeDriver();

            // login page object initialization and definition
            LoginPage loginPageObject = new LoginPage();

            loginPageObject.LoginSteps(driver);

            // home page object initialization and definition
            HomePage homePageObject = new HomePage();

            homePageObject.GoToTMPage(driver);

            // tm page object initialization and definition
            TMPage tmPageObject= new TMPage();

            // create TM
            tmPageObject.CreateTM(driver);
            
            // edit TM
            tmPageObject.EditTM(driver);
            
            // delete TM
            tmPageObject.DeleteTM(driver);


        }
    }
}
