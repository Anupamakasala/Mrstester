using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnup_automation.Utilities
{
    public class WaitHelpers
    {

        // Generic function to wait for element to be clickable
        public void WaitForWebElement(IWebDriver driver, int seconds, string locatorValue)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));

        }
    }
}
