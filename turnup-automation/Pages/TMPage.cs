using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using turnup_automation.Utilities;

namespace turnup_automation.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
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
            codeTextbox.SendKeys("Keyboard");

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

        public void CreateTMAssertion(IWebDriver driver)
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

            Assert.That(newCode.Text == "Keyboard", "Material record hasn't been created");
            Assert.That(newTypeCode.Text == "M", "Material record hasn't been created");
            Assert.That(newDescription.Text == "Unknown Material", "Material record hasn't been created");
            Assert.That(newPrice.Text == "$20.00", "Material record hasn't been created");
        }

        public void EditTM(IWebDriver driver, string description, string code, string price)
        {

            // Wait till the last page button is clickable
            //WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);
            Thread.Sleep(2000);

            // Click on go to last page button
            IWebElement goToLastPageButton2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton2.Click();

            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]", 2);

            IWebElement findNewRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            Console.Write(findNewRecord.Text);

            if (findNewRecord.Text == "M")
            {
                
                // Check if material record has been updated
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();

            }
            else
            {
                Assert.Fail("Record to be edited not found.");
            }

            // update code textbox value
            IWebElement codeTextbox2 = driver.FindElement(By.Id("Code"));
            codeTextbox2.Clear();
            codeTextbox2.SendKeys(code);

            // update description textbox value
            IWebElement descriptionTextbox2 = driver.FindElement(By.Id("Description"));
            descriptionTextbox2.Clear();
            descriptionTextbox2.SendKeys(description);

            // update price per unit textbox value
            IWebElement priceInputTag2 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag2.Click();
            Thread.Sleep(1000);

            IWebElement pricePerUnit2 = driver.FindElement(By.XPath("//*[@id='Price']"));
            pricePerUnit2.Clear();
            pricePerUnit2.Click();
            pricePerUnit2.SendKeys(price);

            // Click on save button
            IWebElement saveButton2 = driver.FindElement(By.Id("SaveButton"));
            saveButton2.Click();

            Thread.Sleep(5000);


        }

        public void EditTMAssertion(IWebDriver driver, string description, string code, string price)
        {
            // Click on go to last page button
            IWebElement goToLastPageButton3 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton3.Click();

            // Check if material record has been updated
            IWebElement updatedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement updatedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement updatedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //if (updatedCode.Text == "BBB222")
            //{
            //    Assert.Pass("Existing material record updated successfully");
            //}
            //else
            //{
            //    Assert.Fail("Existing material record hasn't been updated");
            //}

            Assert.That(updatedTypeCode.Text == code, "Material record hasn't been created");
            Assert.That(updatedDescription.Text == description, "Material record hasn't been created");
            Assert.That(updatedPrice.Text == price, "Material record hasn't been created");
        }

        public void DeleteTM(IWebDriver driver)
        {

            // Wait till the last page button is clickable
            Thread.Sleep(2000);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            // Wait till the delete button is visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 5);

            // Check if material record can be deleted
            IWebElement Delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            Delete.Click();

            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(2000);


        }

        public void DeleteTMAssertion(IWebDriver driver)
        {

            driver.Navigate().Refresh();

            // Check if material record has been updated
            IWebElement updatedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement updatedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement updatedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //if (updatedCode.Text == "BBB222")
            //{
            //    Assert.Pass("Existing material record updated successfully");
            //}
            //else
            //{
            //    Assert.Fail("Existing material record hasn't been updated");
            //}

            Assert.That(updatedTypeCode.Text != "M", "Material record hasn't been deleted");
            Assert.That(updatedDescription.Text != "Known Material", "Material record hasn't been deleted");
            Assert.That(updatedPrice.Text != "$10.00", "Material record hasn't been deleted");

        }
    }
}
