using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace turnup_automation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Open chrome browser
            IWebDriver driver = new ChromeDriver();

            // launch turn up portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();

            // identify username textbox and enter valid username
            IWebElement userName = driver.FindElement(By.Id("UserName"));
            userName.SendKeys("hari");

            // identify password textbox and enter valid password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            // identify login button and click
            IWebElement login = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            login.Click();

            // navigate to home page and check if user has logged in Successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("login successful, Test passed");
            }
            else
            {
                Console.WriteLine("login failed, Test failed");
            }

            // Click on Administration tab
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationTab.Click();

            // Select Time and Material from the dropdown list
            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();

            // Click on create new button
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createButton.Click();

            // Select Material from typecode dropdown
            IWebElement typeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeDropdown.Click();

            Thread.Sleep(2000);

            //SelectElement materialOption = new SelectElement(driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span")));
            //materialOption.SelectByText("Material");

            IWebElement materialOption = driver.FindElement(By.XPath(  "//*[@id='TypeCode_option_selected']"));
            materialOption.Click();

            // Identify code textbox and enter a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("AAA111");

            // Identify description textbox and enter a description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Unknown Material");

            // Identify price per unit textbox and enter a code
            IWebElement priceInputTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag.SendKeys("50");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            // Pause the automation script for 2 seconds
            Thread.Sleep(2000);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            // Check if material record has been created
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (newCode.Text == "AAA111")
            {
                Console.WriteLine("New material record created successfully");
            }
            else
            {
                Console.WriteLine("Material record hasn't been created");
            }

            Thread.Sleep(2000);

            // Check if material record has been updated
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            // update code textbox value
            IWebElement codeTextbox2 = driver.FindElement(By.Id("Code"));
            codeTextbox2.Clear();
            codeTextbox2.SendKeys("BBB222");

            // update description textbox value
            IWebElement descriptionTextbox2 = driver.FindElement(By.Id("Description"));
            descriptionTextbox2.Clear();
            descriptionTextbox2.SendKeys("Known Material");

            Thread.Sleep(2000);
            // update price per unit textbox value
            IWebElement priceInputTag2 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag2.SendKeys("0");

            // Click on save button
            IWebElement saveButton2 = driver.FindElement(By.Id("SaveButton"));
            saveButton2.Click();

            // Pause the automation script for 2 seconds
            Thread.Sleep(2000);

            // Click on go to last page button
            IWebElement goToLastPageButton2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton2.Click();

            // Check if material record has been updated
            IWebElement updatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (updatedCode.Text == "BBB222")
            {
                Console.WriteLine("Existing material record updated successfully");
            }
            else
            {
                Console.WriteLine("Existing material record hasn't been updated");
            }

            Thread.Sleep(2000);

            // Check if material record can be deleted
            IWebElement Delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            Delete.Click();

            Thread.Sleep(1000);

            driver.SwitchTo().Alert().Accept();

        }
    }
}
