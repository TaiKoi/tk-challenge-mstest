using TK_Challenge.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using TK_Challenge;

namespace TKTest
{
    [TestClass]
    public class TKTests
    {
        public static IWebDriver driver;

        [ClassInitialize]
        public static void ClassInitialize(TestContext test)
        {
            driver = new ChromeDriver();
        }

        /*[ClassCleanup]
        public static void ClassCleanup()
        {
            driver.Close();
        }*/

        [TestMethod]
        public void AddEmployee()
        {
            driver.Url = "file:///C:/Users/smadd/OneDrive/Desktop/Paylocity%20QA%20Interview%20Challenge/login.html";
            driver.Manage().Window.Maximize();
            driver.Login();
            driver.GetElement(BenefitsDashboardPage.AddEmployeeButton).Click();
            //Assert.IsTrue(driver.FindElement(BenefitsDashboardPage.AddEmployeeModal).Displayed);
            driver.GetElement(BenefitsDashboardPage.AddEmployeeModal).WaitForDisplayed();
            Assert.IsTrue(driver.FindElement(By.Id("addEmployeeModal")).Displayed);
        }

        [TestMethod]
        public void Login()
        {
            // TODO: Put all elements into an array and assert that the array contains 7 elements

            driver.Url = "file:///C:/Users/smadd/OneDrive/Desktop/Paylocity%20QA%20Interview%20Challenge/login.html";
            driver.Manage().Window.Maximize();
            driver.Login();
            Assert.AreEqual("file:///C:/Users/smadd/OneDrive/Desktop/Paylocity%20QA%20Interview%20Challenge/home.html?username=testUser", driver.Url);
        }

        /*[TestMethod]
        public void ConnectEmptyForm()
        {
            driver.Url = "file:///C:/Users/smadd/OneDrive/Desktop/Paylocity%20QA%20Interview%20Challenge/login.html";
            driver.Manage().Window.Maximize();
            driver.GetElement(LocityHomePage.RequestADemoButton).Click();
            driver.GetElement(ConnectPage.FirstNameField).WaitForDisplayed();
            driver.GetElement(ConnectPage.ContactMeButton).Click();
            driver.GetElement(ConnectPage.FirstNameField).WaitForDisplayed();
            Assert.IsTrue(driver.GetElement(ConnectPage.ValidMessageFirstName).Displayed);
        }*/
    }
}