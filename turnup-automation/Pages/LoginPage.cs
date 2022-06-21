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
    public class LoginPage
    {

        public void LoginSteps(IWebDriver driver)
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
            catch(Exception ex)
            {
                Assert.Fail("TurnUp portal page did not launch");
            }

        }
    }
}
