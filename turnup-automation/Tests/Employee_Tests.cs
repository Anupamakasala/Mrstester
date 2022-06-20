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
    [Parallelizable]
    public class Employee_Tests : CommonDriver
    {

        // Page object initialization
        EmployeePage employeePageObj = new EmployeePage();

        [Test, Order(1), Description("Create employee record with valid data")]
        public void CreateEmployee()
        {
            employeePageObj.CreateEmployee(driver);
        }

        [Test, Order(2), Description("Edit existing employee record with valid data")]
        public void EditEmployye()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.EditEmployee(driver);
        }

        [Test, Order(1), Description("Delete existing employee record")]
        public void DeleteEmployye()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.DeleteEmployee(driver);
        }

    }
}
