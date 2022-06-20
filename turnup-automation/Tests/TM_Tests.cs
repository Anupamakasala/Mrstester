using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using turnup_automation.Pages;
using turnup_automation.Utilities;

namespace turnup_automation.Tests
{
    [TestFixture]
    public class TM_Tests : CommonDriver
    {
        // Page object initialization
        HomePage homePageObj = new HomePage();
        TMPage tmPageObject = new TMPage();
        private string description;

        [Test, Order(1), Description("Create time and material record with valid data")]
        public void CreateTM()
        {

            // create TM
            homePageObj.GoToTMPage(driver);
            tmPageObject.CreateTM(driver);
        }


        [Test, Order(2), Description("Edit existing time and material record with valid data")]
        public void EditTM()
        {
            // edit TM
            homePageObj.GoToTMPage(driver);
            tmPageObject.EditTM(driver, description);
        }

        [Test, Order(3), Description("Delete existing time and material record")]
        public void DeleteTM()
        {
            // delete TM
            homePageObj.GoToTMPage(driver);
            tmPageObject.DeleteTM(driver);
        }

    }

}
