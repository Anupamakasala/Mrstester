using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnup_automation.Pages
{
    public class HomePage
    {

        public void GoToTMPage(IWebDriver driver)
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

        public void GoToEmployeePage(IWebDriver driver)
        {

        }
    }
}
