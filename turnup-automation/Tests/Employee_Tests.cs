using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using turnup_automation.Pages;
using turnup_automation.Utilities;

namespace turnup_automation.Tests
{
    [TestFixture]
    public class Employee_Tests : CommonDriver
    {

        // Page object initialization
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();

        [Test, Order(1), Description("Create employee record with valid data")]
        public void CreateEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.CreateEmployee(driver);
        }

        [Test, Order(2), Description("Edit existing employee record with valid data")]
        public void EditEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.EditEmployee(driver);
        }

        [Test, Order(1), Description("Delete existing employee record")]
        public void DeleteEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.DeleteEmployee(driver);
        }

    }
}
