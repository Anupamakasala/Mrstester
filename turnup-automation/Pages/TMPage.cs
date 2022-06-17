﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            IWebElement typeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]"));
            typeDropdown.Click();

            // Wait till the material option is clickable
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_option_selected']", 2);

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_option_selected']"));
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

            Thread.Sleep(2000);

            // Wait till the last page button is clickable
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            // Check if material record has been created
            IWebElement newCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //if (newCode.Text == "AAA111")
            //{
            //    Assert.Pass("New material record created successfully");
            //}
            //else
            //{
            //    Assert.Fail("Material record hasn't been created");
            //}

            Assert.That(newCode.Text == "AAA111", "Material record hasn't been created");

        }

        public void EditTM(IWebDriver driver)
        {

            // Wait till the last page button is clickable
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            // Wait till the edit button is visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 5);

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


            // update price per unit textbox value
            IWebElement priceInputTag2 = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceInputTag2.SendKeys("0");

            // Click on save button
            IWebElement saveButton2 = driver.FindElement(By.Id("SaveButton"));
            saveButton2.Click();

            Thread.Sleep(2000);

            // Wait till the last page button is clickable
            WaitHelpers.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 2);

            // Click on go to last page button
            IWebElement goToLastPageButton2 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton2.Click();

            // Check if material record has been updated
            IWebElement updatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            //if (updatedCode.Text == "BBB222")
            //{
            //    Assert.Pass("Existing material record updated successfully");
            //}
            //else
            //{
            //    Assert.Fail("Existing material record hasn't been updated");
            //}

            Assert.That(updatedCode.Text == "BBB222", "Existing material record hasn't been updated");

        }

        public void DeleteTM(IWebDriver driver)
        {

            // Wait till the last page button is clickable
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]", 5);

            // Click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            goToLastPageButton.Click();

            // Wait till the delete button is visible
            WaitHelpers.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 5);

            // Check if material record can be deleted
            IWebElement Delete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            Delete.Click();

            driver.SwitchTo().Alert().Accept();

            Assert.Pass("Existing material record has been deleted successfully");

        }
    }
}
