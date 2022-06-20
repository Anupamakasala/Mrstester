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
using turnup_automation.Utilities;

namespace turnup_automation.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinition
    {
        // open chrome browser
        ChromeDriver driver = new ChromeDriver();

        [Given(@"I logged into turnup portal succesfully")]
        public void ILoggedIntournupPortalSuccesfully()
        {

            // maximise window
            driver.Manage().Window.Maximize();

            // launch turn up portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            try
            {
                // identify username textbox and enter valid username
                IWebElement userName = driver.FindElement(By.Id("UserName"));
                userName.SendKeys("hari");

                // identify password textbox and enter valid password
                IWebElement password = driver.FindElement(By.Id("Password"));
                password.SendKeys("123123");

                // identify login button and click
                IWebElement login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
                login.Click();

            }
            catch (Exception ex)
            {
                Assert.Fail("TurnUp portal page did not launch");
            }

        }

        [When(@"I navigate to time and material page")]
        public void INavigateToTimeAndMaterialPage()
        {
            // navigate to home page and check if user has logged in Successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            //if (helloHari.Text == "Hello hari!")
            //{
            //    Assert.Pass("login successful, Test passed");
            //}
            //else
            //{
            //    Assert.Fail("login failed, Test failed");
            //}

            Assert.That(helloHari.Text == "Hello hari!", "login failed, Test failed");

            // Click on Administration tab
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            // Select Time and Material from the dropdown list
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();

        }

        [When(@"I create a new time and material record")]
        public void ICreateANewTimeAndMaterialRecord()
        {

            // Click on create new button
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]", 2);

            // Select Material from typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeCodeDropdown.Click();

            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 2);

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();

            // Identify code textbox and enter a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("AAA111");

            // Identify description textbox and enter a description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Unknown Material");

            // Identify price per unit textbox and enter a code
            IWebElement priceInputTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag.Click();
            Thread.Sleep(1000);

            IWebElement pricePerUnit = driver.FindElement(By.XPath("//*[@id='Price']"));
            pricePerUnit.Clear();
            pricePerUnit.SendKeys("20");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(2000);


        }

        [Then(@"The record should be created succesfully")]
        public void TheRecordShouldBeCreateSuccesfully()
        {
            // Wait till the last page button is clickable
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            // Check if material record has been created
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            //if (newCode.Text == "AAA111")
            //{
            //    Assert.Pass("New material record created successfully");
            //}
            //else
            //{
            //    Assert.Fail("Material record hasn't been created");
            //}
            Assert.That(newCode.Text == "AAA111", "Material record hasn't been created");
            Assert.That(newTypeCode.Text == "M", "Material record hasn't been created");
            Assert.That(newDescription.Text == "Unknown Material", "Material record hasn't been created");
            Assert.That(newPrice.Text == "$20.00", "Material record hasn't been created");

        }
    }
}
