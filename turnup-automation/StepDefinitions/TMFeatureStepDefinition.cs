using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using turnup_automation.Pages;
using turnup_automation.Utilities;

namespace turnup_automation.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinition : CommonDriver
    {
        // open chrome browser
        ChromeDriver driver = new ChromeDriver();

        LoginPage loginPageObject = new LoginPage();
        HomePage homePageObject = new HomePage();
        TMPage tmPageObject = new TMPage();

        [Given(@"I logged into turnup portal succesfully")]
        public void ILoggedIntournupPortalSuccesfully()
        {

            // login page object initialization and definition
            loginPageObject.LoginSteps(driver);

        }

        [When(@"I navigate to time and material page")]
        public void INavigateToTimeAndMaterialPage()
        {
            homePageObject.GoToTMPage(driver);

        }

        [When(@"I create a new time and material record")]
        public void ICreateANewTimeAndMaterialRecord()
        {

            tmPageObject.CreateTM(driver);


        }

        [Then(@"The record should be created succesfully")]
        public void TheRecordShouldBeCreateSuccesfully()
        {
            tmPageObject.CreateTMAssertion(driver);
            driver.Quit();

        }

        [When(@"I edit an existing time and material record '([^']*)' '([^']*)' '([^']*)'")]
        public void IEditAnExistingTimeAndMaterialRecord(string p0, string p1, string p2)
        {
            tmPageObject.EditTM(driver, p0, p1, p2);
        }

        [Then(@"The record should be updated succesfully '([^']*)' '([^']*)' '([^']*)'")]
        public void TheRecordShouldBeUpdatedSuccesfully(string p0, string p1, string p2)
        {
            tmPageObject.EditTMAssertion(driver, p0, p1, p2);
            driver.Quit();
        }

        [When(@"I delete an existing time and material record")]
        public void IDeleteAnExistingTimeAndMaterialRecord()
        {
            tmPageObject.DeleteTM(driver);
            driver.Quit();
        }

        [Then(@"The record should be deleted succesfully")]
        public void TheRecordShouldBeDeletedSuccesfully()
        {
            tmPageObject.DeleteTMAssertion(driver);
        }
    }

}
